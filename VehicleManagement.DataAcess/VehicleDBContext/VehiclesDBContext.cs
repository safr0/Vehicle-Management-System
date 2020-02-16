using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using VehicleManagement.DataAcess.Entities;

namespace VehicleManagement.DataAcess.VehicleDBContext
{
    public class VehiclesDBContext : DbContext
    {
        public VehiclesDBContext(DbContextOptions<VehiclesDBContext> options)
            : base(options)
        {
        }

        public DbSet<Car> Cars { get; set; }
        //todo boats
    }
}
