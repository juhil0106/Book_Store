using Microsoft.EntityFrameworkCore;
using User.API.Context;
using User.API.Models;

namespace User.API.Repository
{
    public class UserDetailsRepository : IUserDetailsRepository
    {
        private readonly UserdbContext _context;

        public UserDetailsRepository(UserdbContext context)
        {
            _context = context;
        }

        public async Task<List<UserDetails>> GetAllUser()
        {
            return await _context.UserDetails.ToListAsync();
        }

        public async Task<UserDetails> GetUserByEmail(string emailId)
        {
            var user = await _context.UserDetails.Where(x => x.Email == emailId).Include(x => x.UserChoices).FirstOrDefaultAsync();
            return user;
        }

        public async Task<int> AddUserDetails(UserDetails userDetails)
        {
            if (_context.UserDetails.Any(x => x.Email == userDetails.Email && x.MobileNo == userDetails.MobileNo)) 
                return 0;

            await _context.UserDetails.AddAsync(userDetails);
            return await _context.SaveChangesAsync();
        }

        public async Task<int> UpdateUserDetails(UserDetails userDetails)
        {
            if (_context.UserDetails.Any(x => x.Email == userDetails.Email && x.MobileNo == userDetails.MobileNo && x.Id != userDetails.Id))
                return 0;

            _context.UserDetails.Update(userDetails);
            return await _context.SaveChangesAsync();
        }
    }
}
