using Book.API.Context;
using Book.API.Model;
using Book.API.Repositories.IRepositories;
using MongoDB.Driver;

namespace Book.API.Repositories
{
    public class GenreRepository : IGenreRepository
    {
        private readonly IBookContext _context;

        public GenreRepository(IBookContext context)
        {
            _context = context;
        }

        public async Task<List<Genre>> GetGenreList()
        {
            var genereList = await _context.Genres.Aggregate().ToListAsync();
            return genereList;
        }

        public async Task<bool> AddGenre(Genre genre)
        {
            try
            {
                await _context.Genres.InsertOneAsync(genre);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public async Task<bool> UpdateGenre(Genre genre)
        {
            var updatedGenre = await _context.Genres.FindOneAndReplaceAsync(x => x.Id == genre.Id, replacement: genre);
            if (updatedGenre == null) return false;
            return true;
        }

        public async Task<bool> DeleteGenre(string id)
        {
            var deletedGenre = await _context.Genres.FindOneAndDeleteAsync(x => x.Id == id);
            if (deletedGenre == null) return false;
            return true;
        }
    }
}
