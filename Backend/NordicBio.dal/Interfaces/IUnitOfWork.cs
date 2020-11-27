namespace NordicBio.dal.Interfaces
{
    public interface IUnitOfWork
    {
        public IMovieRepository Movies { get; }
        public IOrderRepository Orders { get; }
        public ISeatRepository Seats { get; }
        public IShowingRepository Showings { get; }
        public ITicketRepository Tickets { get; }
        public IUserRepository Users { get; }

    }
}
