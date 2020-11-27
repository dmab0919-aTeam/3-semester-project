using Microsoft.Extensions.DependencyInjection;
using NordicBio.dal.Interfaces;
using NordicBio.dal.Service;

namespace NordicBio.dal
{
    public static class ServiceRegistration
    {
        public static void AddInfrastructure(this IServiceCollection services)
        {
            services.AddTransient<IMovieRepository, MovieRepository>();
            //services.AddTransient<IOrderRepository, OrderRepository>();
            services.AddTransient<ISeatRepository, SeatRepository>();
            services.AddTransient<IShowingRepository, ShowingRepository>();
            //services.AddTransient<ITicketRepository, TicketRepository>();
            services.AddTransient<IUserRepository, UserRepository>();
            services.AddTransient<IUnitOfWork, UnitOfWork>();
        }
    }
}
