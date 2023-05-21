using Microsoft.EntityFrameworkCore;
using TrafficFineSystemWeb.Models;

namespace TrafficFineSystemWeb.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }

        public DbSet<TrafficModel> TrafficAds { get; set; }

        public DbSet<DriversModel> DriversAds { get; set; }
        public DbSet<FineModel> FineModels { get; set; }



    }
}
