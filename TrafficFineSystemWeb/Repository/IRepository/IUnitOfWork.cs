namespace TrafficFineSystemWeb.Repository.IRepository
{
    public interface IUnitOfWork
    {
        ITrafficAddRepository TrafficAdd { get; }
        IDriversAddRepository DriversAdd { get; }
        IFineRepository FineAdd { get; }



        void Save();
    }
}
