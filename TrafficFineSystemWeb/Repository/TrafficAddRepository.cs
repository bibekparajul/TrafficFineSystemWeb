using TrafficFineSystemWeb.Data;
using TrafficFineSystemWeb.Models;
using TrafficFineSystemWeb.Repository.IRepository;

namespace TrafficFineSystemWeb.Repository
{
    public class TrafficAddRepository : Repository<TrafficModel>, ITrafficAddRepository
    {

        private ApplicationDbContext _db;

        public TrafficAddRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }


        public void Update(TrafficModel obj)
        {
            _db.TrafficAds.Update(obj);
        }
    }
}
