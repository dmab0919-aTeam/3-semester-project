using NordicBio.dal.Interfaces;

namespace NordicBio.dal.Service
{
    class UnitOfWork : IUnitOfWork
    {
        public IMovieRepository Movies { get; }
        public IOrderRepository Orders { get; }
        public ISeatRepository Seats { get; }
        public IShowingRepository Showings { get; }
        public IUserRepository Users { get; }

        public UnitOfWork
            (
                IMovieRepository movieRepository,
                ISeatRepository seatRepository,
                IShowingRepository showingRepository,
                IUserRepository userRepository,
                IOrderRepository orderRepository
            )
        {
            Movies = movieRepository;
            Seats = seatRepository;
            Showings = showingRepository;
            Users = userRepository;
            Orders = orderRepository;
        }
    }
}
