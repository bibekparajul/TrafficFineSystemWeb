using TrafficFineSystemWeb.Models;

namespace TrafficFineSystemWeb.Repository.IRepository
{
    public interface IDriversAddRepository : IRepository<DriversModel>
    {
        void Update(DriversModel obj);

        //save must be done in Repository ma but this is not the good practice 
    }
}
