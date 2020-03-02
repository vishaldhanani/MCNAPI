using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MCNAPI.Models;

namespace MCNAPI.Models
{
    public class VehicleRepository : IVehicleRepository
    {
       public readonly VehicleContext Db;

        public VehicleRepository(VehicleContext _Db)
        {
            Db = _Db;
        }
        public Task<List<Vehicle>> GetVehicles()
        {
            if (Db != null)
            {
                return Db.Vehicles.ToListAsync();
            }
            return null;
        }

        public Vehicle GetVehicle(int? id)
        {
            if (Db != null && id !=null)
            {
                return  Db.Vehicles.FirstOrDefault(v => v.Id == id);
            }
            return null;
        }
        
        public int DeleteVehicle(int? id)
        {
            int result = 0;
            if (Db != null)
            {
                //Find the post for specific post id
                var val =  Db.Vehicles.FirstOrDefault(v => v.Id == id);
                if (val != null)
                {         
                    //Remove Vehicle
                    Db.Vehicles.Remove(val);

                    //Commit the transaction
                    result =  Db.SaveChanges();
                }
                return result;
            }
            return result;
        }

        public Vehicle PostVehicle(Vehicle vehicle)
        {
            if (Db != null)
            {
                //Add Vehicle
                Db.Vehicles.Add(vehicle);
                Db.SaveChanges();
                return vehicle;
            }
            return null;
        }

        public int PutVehicle(int id, Vehicle vehicle)
        {
            int result = 0;
            var Val = Db.Vehicles.Find(id);
            if (Val != null)
            {
                //updates Vehicle
                Val.Make = vehicle.Make;
                Val.Year = vehicle.Year;
                Val.Model = vehicle.Model;
                result = Db.SaveChanges();
            }
            return result;
        }
    }
}
