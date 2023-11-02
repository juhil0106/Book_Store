using User.API.Models;

namespace User.API.IRepository
{
    public interface IUserChoiceRepository
    {
        Task<List<UserChoice>> GetUserChoiceByUserId(int userId);
        Task<int> AddUserChoice(List<UserChoice> userChoice);
        Task<int> UpdateUserChoice(List<UserChoice> userChoice);
        Task<int> DeleteUserChoice(int id);
    }
}
