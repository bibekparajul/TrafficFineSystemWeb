using TrafficFineSystemWeb.Models;

namespace TrafficFineSystemWeb.Repository.IRepository
{
    public interface IFineRepository : IRepository<FineModel>
    {
        void Update(FineModel obj);

        //save must be done in Repository ma but this is not the good practice 
    }
}
