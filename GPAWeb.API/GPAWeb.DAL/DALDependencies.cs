using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace GPAWeb.DAL
{
    public static class DALDependencies
    {
        public static void RegisterDALDependencies(this IServiceCollection services, IConfiguration configuration)
        {
            //services.AddDbContext<GPADbContext>(options => options.UseSqlServer(configuration.GetConnectionString("GPADbConnection")));
            //services.AddTransient(typeof(IUnitOfWork<GPADbContext>), typeof(UnitOfWork<GPADbContext>));
        }
    }
}
