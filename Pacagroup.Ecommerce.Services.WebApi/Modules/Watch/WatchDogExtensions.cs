using WatchDog;

namespace Pacagroup.Ecommerce.Services.WebApi.Modules.Watch
{
    public static class WatchDogExtensions
    {
        public static IServiceCollection AddWatchDog(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddWatchDogServices(opt => {
                opt.SetExternalDbConnString = configuration.GetConnectionString("NorthwindConnection");
                opt.SqlDriverOption = WatchDog.src.Enums.WatchDogSqlDriverEnum.MSSQL;
                opt.IsAutoClear = true;
                opt.ClearTimeSchedule = WatchDog.src.Enums.WatchDogAutoClearScheduleEnum.Monthly;
            });

            return services;
        }
    }
}
