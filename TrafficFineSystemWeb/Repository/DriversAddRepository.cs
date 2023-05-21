using TrafficFineSystemWeb.Data;
using TrafficFineSystemWeb.Models;
using TrafficFineSystemWeb.Repository.IRepository;

namespace TrafficFineSystemWeb.Repository
{
    public class DriversAddRepository : Repository<DriversModel>, IDriversAddRepository
    {

        private ApplicationDbContext _db;

        public DriversAddRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }


        public void Update(DriversModel obj)
        {
            _db.DriversAds.Update(obj);
        }
    }
}
