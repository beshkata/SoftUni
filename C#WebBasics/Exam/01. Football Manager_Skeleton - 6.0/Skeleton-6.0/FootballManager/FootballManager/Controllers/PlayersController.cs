using BasicWebServer.Server.Attributes;
using BasicWebServer.Server.Controllers;
using BasicWebServer.Server.HTTP;
using FootballManager.Contracts;
using FootballManager.ViewModels;

namespace FootballManager.Controllers
{
    public class PlayersController : Controller
    {
        private readonly IPlayerService playerService;
        public PlayersController(
            Request request,
            IPlayerService _playerService)
            : base(request)
        {
            playerService = _playerService;
        }

        [Authorize]
        public Response All()
        {
            IEnumerable<AllPlayersViewModel> players = playerService.GetAllPlayers();

            return this.View(new
            {
                players = players,
                IsAuthenticated = true
            });
        }

        [Authorize]
        public Response Add()
        {
            return View(new { IsAuthenticated = true });
        }

        [HttpPost]
        [Authorize]
        public Response Add(AddPlayerViewModel model)
        {
            
            bool isAdded = playerService.AddPlayer(model);

            if (isAdded)
            {
                return Redirect("/Players/All");
            }

            return View();
        }

        [Authorize]
        public Response Collection()
        {
            IEnumerable<AllPlayersViewModel> players = playerService.GetCollectionOfPlayers(User.Id);

            return View(new
            {
                players = players,
                IsAuthenticated = true
            });
        }

        [Authorize]
        public Response AddToCollection(int playerId)
        {
            playerService.AddPlayerToCollection(playerId, User.Id);

            return Redirect("/Players/All");
        }

        [Authorize]
        public Response RemoveFromCollection(int playerId)
        {
            playerService.RemoveFromCollection(playerId, User.Id);

            return Redirect("/Players/Collection");
        }
    }
}
