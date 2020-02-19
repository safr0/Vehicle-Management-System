using Microsoft.EntityFrameworkCore;
using VehicleManagement.DataAcess.Entities;

namespace VehicleManagement.DataAcess.VehicleDBContext
{
    /// <summary>
    /// Vehicle DBContext
    /// </summary>
    public class VehiclesDBContext : DbContext
    {
        public VehiclesDBContext(DbContextOptions<VehiclesDBContext> options)
            : base(options)
        {
        }

        public DbSet<Car> Cars { get; set; }
        
        public DbSet<VehicleSpecification> Specs { get; set; }

    }
}
