using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MCNAPI.Models
{
    public class VehicleContext: DbContext
    {
        
        public VehicleContext()
        {           
        }
        public VehicleContext(DbContextOptions<VehicleContext> options) : base(options) { }
        public virtual DbSet<Vehicle> Vehicles { get; set; }      
    }
}
