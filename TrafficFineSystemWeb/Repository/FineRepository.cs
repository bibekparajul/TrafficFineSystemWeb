using TrafficFineSystemWeb.Data;
using TrafficFineSystemWeb.Models;
using TrafficFineSystemWeb.Repository.IRepository;

namespace TrafficFineSystemWeb.Repository
{
    public class FineRepository : Repository<FineModel>, IFineRepository
    {

        private ApplicationDbContext _db;

        public FineRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }


        public void Update(FineModel obj)
        {

            _db.FineModels.Update(obj);
        }
    }
}
