using Microsoft.Extensions.Options;
using MongoDB.Driver;
using WebAPI.Models;

namespace WebAPI.Services
{
    public class MoviesService
    {
        private readonly IMongoCollection<Movie> moviesCollection;

        public MoviesService(IOptions<MovieDatabaseSettings> movieDatabaseSettings)
        {
            var mongoClient = new MongoClient(movieDatabaseSettings.Value.ConnectionString);
            var mongoDatabase = mongoClient.GetDatabase(movieDatabaseSettings.Value.DatabaseName);

            moviesCollection = mongoDatabase.GetCollection<Movie>(movieDatabaseSettings.Value.MovieCollectionName);
        }

        public async Task<List<Movie>> GetAllMoviesAsync()
        {
            return await moviesCollection.Find(_ => true).ToListAsync();
        }

        public async Task<Movie> GetMovieByIdAsync(string id)
        {
            return await moviesCollection.Find(movie => movie.Id == id).FirstOrDefaultAsync();
        }

        public async Task CreateMovieAsync(Movie movie)
        {
            await moviesCollection.InsertOneAsync(movie);
        }

        public async Task UpdateMovieAsync(string id, Movie movie)
        {
            await moviesCollection.ReplaceOneAsync(m => m.Id == id, movie);
        }

        public async Task DeleteMovieAsync(string id)
        {
            await moviesCollection.DeleteOneAsync(m => m.Id == id);
        }
    }
}
