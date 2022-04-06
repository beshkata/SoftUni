using FootballManager.Contracts;
using FootballManager.Data.Common;
using FootballManager.Data.Models;
using FootballManager.ViewModels;

namespace FootballManager.Services
{
    public class PlayerService : IPlayerService
    {
        private readonly IRepository repo;
        private readonly IValidationService validationService;

        public PlayerService(
            IRepository _repo,
            IValidationService _validationService)
        {
            repo = _repo;
            validationService = _validationService;
        }

        public bool AddPlayer(AddPlayerViewModel model)
        {
            bool playerAdded = false;

            bool isValid = validationService.ValidateModel(model);

            if (!isValid)
            {
                return isValid;
            }

            Player player = new Player()
            {
                FullName = model.FullName,
                ImageUrl = model.ImageUrl,
                Position = model.Position,
                Speed = model.Speed,
                Endurance = model.Endurance,
                Description = model.Description
            };
            try
            {
                repo.Add(player);
                repo.SaveChanges();
                playerAdded = true;
            }
            catch (Exception)
            {
               
            }

            return playerAdded;
        }

        public void AddPlayerToCollection(int playerId, string userId)
        {
            if (repo.All<UserPlayer>()
                    .Any(up => up.UserId == userId && up.PlayerId == playerId))
            {
                return;
            }

            Player player = repo.All<Player>()
                .SingleOrDefault(p => p.Id == playerId);
            User user = repo.All<User>()
                .SingleOrDefault(u => u.Id == userId);

            if (player == null || user == null)
            {
                return;
            }

            UserPlayer userPlayer = new UserPlayer
            {
                Player = player,
                PlayerId = playerId,
                User = user,
                UserId = userId
            };
            try
            {
                repo.Add(userPlayer);
                repo.SaveChanges();
            }
            catch (Exception)
            {
            }
        }

        public IEnumerable<AllPlayersViewModel> GetAllPlayers()
        {
            return repo.All<Player>()
                .Select(p => new AllPlayersViewModel
                {
                    PlayerId = p.Id,
                    Description = p.Description,
                    ImageUrl = p.ImageUrl,
                    FullName = p.FullName,
                    Position = p.Position,
                    Speed = p.Speed,
                    Endurance = p.Endurance,
                })
                .ToList();
        }

        public IEnumerable<AllPlayersViewModel> GetCollectionOfPlayers(string userId)
        {
            return repo.All<UserPlayer>()
                .Where(up => up.UserId == userId)
                .Select(up => up.Player)
                .Select(p => new AllPlayersViewModel
                {
                    PlayerId = p.Id,
                    Description = p.Description,
                    ImageUrl = p.ImageUrl,
                    FullName = p.FullName,
                    Position = p.Position,
                    Speed = p.Speed,
                    Endurance = p.Endurance,
                })
                .ToList();

        }

        public void RemoveFromCollection(int playerId, string userId)
        {
            UserPlayer userPlayer = repo.All<UserPlayer>()
                .Where(up => up.PlayerId == playerId && up.UserId == userId)
                .FirstOrDefault();

            if (userPlayer == null)
            {
                return;
            }

            repo.Delete(userPlayer);
            repo.SaveChanges();
        }
    }
}
