using NordicBio.dal.Interfaces;
using System.Transactions;

namespace NordicBio.dal.Service
{
    class UnitOfWork : IUnitOfWork
    {
        public IMovieRepository Movies { get; }

        public IOrderRepository Orders { get; }

        public ISeatRepository Seats { get; }

        public IShowingRepository Showings { get; }

        public ITicketRepository Tickets { get; }

        public IUserRepository Users { get; }

        public UnitOfWork
            (
                IMovieRepository movieRepository,
                ISeatRepository seatRepository,
                IShowingRepository showingRepository,
                IUserRepository userRepository
            )
        {
            Movies = movieRepository;
            Seats = seatRepository;
            Showings = showingRepository;
            Users = userRepository;
        }

        private TransactionScope _scope;

        public void BeginTransaction()
        {
            _scope = new TransactionScope();
        }

        public void CommitTransaction()
        {
            _scope.Complete();
        }

        public void RollBackTransaction()
        {
            if (_scope != null)
            {
                _scope.Dispose();
            }

        }
    }
}
