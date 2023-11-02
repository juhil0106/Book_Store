using Microsoft.EntityFrameworkCore;
using User.API.Context;
using User.API.IRepository;
using User.API.Models;

namespace User.API.Repository
{
    public class UserChoiceRepository : IUserChoiceRepository
    {
        private readonly UserdbContext _context;

        public UserChoiceRepository(UserdbContext context)
        {
            _context = context;
        }

        public async Task<List<UserChoice>> GetUserChoiceByUserId(int userId)
        {
            var userChoices = await _context.UserChoices.Where(x => x.UserId == userId).Include(x => x.User).ToListAsync();  
            return userChoices;
        }

        public async Task<int> AddUserChoice(List<UserChoice> userChoice)
        {
            if (_context.UserChoices.Any(x => x.UserId == userChoice.FirstOrDefault().UserId))
                return 0;

            await _context.UserChoices.AddRangeAsync(userChoice);
            return await _context.SaveChangesAsync();
        }

        public async Task<int> UpdateUserChoice(List<UserChoice> userChoice)
        {
            _context.UserChoices.UpdateRange(userChoice);
            return await _context.SaveChangesAsync();
        }

        public async Task<int> DeleteUserChoice(int id)
        {
            var userChoice = await _context.UserChoices.FindAsync(id);

            if (userChoice is null)
                return 0;

            _context.UserChoices.RemoveRange(userChoice);
            return await _context.SaveChangesAsync();
        }
    }
}
