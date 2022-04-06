using FootballManager.ViewModels;

namespace FootballManager.Contracts
{
    public interface IPlayerService
    {
        IEnumerable<AllPlayersViewModel> GetAllPlayers();

        bool AddPlayer(AddPlayerViewModel model);
        void AddPlayerToCollection(int playerId, string userId);
        IEnumerable<AllPlayersViewModel> GetCollectionOfPlayers(string userId);
        void RemoveFromCollection(int playerId, string userId);
    }
}
