using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MCNAPI.Models;

namespace MCNAPI.Controllers
{
    //VehiclesController
    [Route("api/[controller]")]
    [ApiController]
    public class VehiclesController : ControllerBase
    {
        IVehicleRepository vehicleRepository;


        public VehiclesController(IVehicleRepository _vehicleRepository)
        {
            vehicleRepository = _vehicleRepository;

        }

        // GET: api/Vehicles
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Vehicle>>> GetVehicles()
        {
            try
            {
                var Vehicles = await vehicleRepository.GetVehicles();
                if (Vehicles == null)
                {
                    return NotFound("Vehicle Not Found!");
                }

                return Ok(Vehicles);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        // GET: api/Vehicles/5
        [HttpGet("{id}")]
        public ActionResult<Vehicle> GetVehicle(int? id)
        {
            if (id == null)
            {
                return BadRequest();
            }

            try
            {
                var val = vehicleRepository.GetVehicle(id);

                if (val == null)
                {
                    return NotFound();
                }

                return Ok(val);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        // PUT: api/Vehicles/5
        [HttpPut("{id}")]
        public IActionResult PutVehicle(int id, Vehicle vehicle)
        {           
            if (ModelState.IsValid)
            {
                try
                {
                    vehicleRepository.PutVehicle(id, vehicle);
                    return Ok();
                }
                catch (Exception ex)
                {
                    if (ex.GetType().FullName == "Microsoft.EntityFrameworkCore.DbUpdateConcurrencyException")
                    {
                        return NotFound();
                    }

                    return BadRequest();
                }
            }           
            return NoContent();
        }

        // POST: api/Vehicles              
        [HttpPost]
        public ActionResult<Vehicle> PostVehicle(Vehicle vehicle)
        {
            if (vehicle == null)
            {
                return BadRequest();
            }
            if (ModelState.IsValid)
            {
                try
                {
                    var ValId = vehicleRepository.PostVehicle(vehicle);
                    if (ValId != null)
                    {
                        return Ok(ValId);
                    }
                    else
                    {
                        return NotFound();
                    }
                }
                catch (Exception e)
                {
                    throw e;
                    //return BadRequest();
                }
            }
            return NoContent();
        }

        // DELETE: api/Vehicles/1
        [HttpDelete("{id}")]
        public ActionResult<Vehicle> DeleteVehicle(int? id)
        {
            int result = 0;

            if (id == null)
            {
                return BadRequest();
            }

            try
            {
                result =  vehicleRepository.DeleteVehicle(id);
                if (result == 0)
                {
                    return NotFound();
                }
                return Ok();
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }      
    }
}
