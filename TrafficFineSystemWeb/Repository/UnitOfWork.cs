using TrafficFineSystemWeb.Data;
using TrafficFineSystemWeb.Repository.IRepository;

namespace TrafficFineSystemWeb.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private ApplicationDbContext _db;

        public UnitOfWork(ApplicationDbContext db)
        {
            _db = db;
            DriversAdd = new DriversAddRepository(_db);
            TrafficAdd = new TrafficAddRepository(_db);
            FineAdd = new FineRepository(_db);



        }
        public IDriversAddRepository DriversAdd { get; private set; }
        public IFineRepository FineAdd { get; private set; }
        public ITrafficAddRepository TrafficAdd { get; private set; }



        public void Save()
        {
            _db.SaveChanges();
        }
    }
}
