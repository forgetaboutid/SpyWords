using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using SpyWord.Data;

namespace SpyWord
{
    public class Configuration
    {
        public static void ConfigureServices(IServiceCollection services)
        {
            //services.AddDbContext<GameDbContext>(options => {
            //    options.UseSqlServer("Server=tcp:spy-words.database.windows.net,1433;Initial Catalog=SpyWords;Persist Security Info=False;User ID=forgetaboutid;Password={SuperSecretPassword};MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");
            //});

            services.AddScoped<IGameService, GameService>();
            services.AddScoped<IGameRepository, GameRepository>();

        }
    }
}
