using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MCNAPI.Models
{
    public interface IVehicleRepository
    {
        Task<List<Vehicle>> GetVehicles();
        Vehicle GetVehicle(int? id);
        int PutVehicle(int id, Vehicle vehicle);
        Vehicle PostVehicle(Vehicle vehicle);        
        int DeleteVehicle(int? id);
    }
}
