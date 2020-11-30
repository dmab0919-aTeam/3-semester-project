namespace NordicBio.dal.Interfaces
{
    interface IRepository
    {
        // For use in Unit of work
        string FetchConnection();
    }
}
