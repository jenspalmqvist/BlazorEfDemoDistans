using BlazorEfDemo.Models;
using Microsoft.EntityFrameworkCore;

namespace BlazorEfDemo.Data
{
	public class DataAccess
	{
		private readonly MovieContext _movieContext;

		public DataAccess(MovieContext movieContext)
		{
			_movieContext = movieContext;
		}

		public async Task<List<Movie>> GetAllMovies()
		{
			await Task.Delay(1000);
			var movies = await _movieContext.Movies.ToListAsync();
			return movies;
		}

		public async Task AddMovie(Movie movie)
		{
			await _movieContext.AddAsync(movie);
			await _movieContext.SaveChangesAsync();
		}

		public async Task UpdateMovie(Movie movie)
		{
			_movieContext.Movies.Update(movie);
			await _movieContext.SaveChangesAsync();

		}
		public async Task<Movie> GetMovieById(int id)
		{
			return await _movieContext.Movies.FindAsync(id);
		}
	}
}
