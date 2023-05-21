using TrafficFineSystemWeb.Models;

namespace TrafficFineSystemWeb.Repository.IRepository
{
    public interface ITrafficAddRepository : IRepository<TrafficModel>
    {
        void Update(TrafficModel obj);

        //save must be done in Repository ma but this is not the good practice 
    }
}
