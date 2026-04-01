using WebApplication7.Models;
using WebApplication7.Repositories;

namespace WebApplication7.Services
{
    public class MovieService : IMovieService
    {
        private readonly IMovieRepository _movieRepository;

        public MovieService(IMovieRepository movieRepository)
        {
            _movieRepository = movieRepository;
        }

        public List<Movie> GetAllMovies()
        {
            return _movieRepository.GetAllMovies();
        }

        public Movie GetMovieById(int id)
        {
            return _movieRepository.GetMovieById(id);
        }

        public void AddMovie(Movie movie)
        {
            _movieRepository.AddMovie(movie);
        }

        public void UpdateMovie(Movie movie)
        {
            _movieRepository.UpdateMovie(movie);
        }

        public void DeleteMovie(int id)
        {
            _movieRepository.DeleteMovie(id);
        }
    }
}
