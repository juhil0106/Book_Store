using Book.API.Model;

namespace Book.API.Repositories.IRepositories
{
    public interface IGenreRepository
    {
        Task<List<Genre>> GetGenreList();
        Task<bool> AddGenre(Genre genre);
        Task<bool> UpdateGenre(Genre genre);
        Task<bool> DeleteGenre(string id);
    }
}
