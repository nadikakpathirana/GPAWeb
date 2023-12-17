using GPAWeb.BLL.Services.IServices;
using GPAWeb.BLL.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using GPAWeb.BLL.Utilities.AutoMapperProfiles;

namespace GPAWeb.BLL
{
    public static class BLLDependencies
    {
        public static void RegisterBLLDependencies(this IServiceCollection services, IConfiguration Configuration)
        {
            services.AddAutoMapper(typeof(AutoMapperProfiles));
            services.AddScoped<IUserService, UserService>();
        }
    }
}
