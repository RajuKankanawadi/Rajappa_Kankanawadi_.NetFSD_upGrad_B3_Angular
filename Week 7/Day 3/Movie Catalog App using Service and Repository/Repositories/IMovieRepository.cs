using WebApplication7.Models;

namespace WebApplication7.Repositories
{
    public interface IMovieRepository
        {
            List<Movie> GetAllMovies();
            Movie GetMovieById(int id);
            void AddMovie(Movie movie);
            void UpdateMovie(Movie movie);
            void DeleteMovie(int id);
        }
    }

