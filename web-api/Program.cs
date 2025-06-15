using WebAPI.Models;
using WebAPI.Services;

namespace WebAPI
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddControllers().AddJsonOptions(options => options.JsonSerializerOptions.PropertyNamingPolicy = null);
            var section = builder.Configuration.GetSection("MovieDB");
            builder.Services.Configure<MovieDatabaseSettings>(section);
            builder.Services.AddSingleton<MoviesService>();

            var app = builder.Build();
            app.UseAuthorization();
            app.MapControllers();
            app.Run();
        }
    }
}