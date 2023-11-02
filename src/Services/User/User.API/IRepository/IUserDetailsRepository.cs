using User.API.Models;

namespace User.API.Repository
{
    public interface IUserDetailsRepository
    {
        Task<List<UserDetails>> GetAllUser();
        Task<int> AddUserDetails(UserDetails userDetails);
        Task<UserDetails> GetUserByEmail(string emailId);
        Task<int> UpdateUserDetails(UserDetails userDetails);
    }
}
