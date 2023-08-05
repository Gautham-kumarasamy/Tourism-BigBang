using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MakeYourTrip.Models;
using MakeYourTrip.Exceptions;
using MakeYourTrip.Interfaces;
using MakeYourTrip.Models.DTO;
using MakeYourTrip.Services;

namespace MakeYourTrip.Controllers
{

    [Route("api/[controller]/[action]")]
    [ApiController]
    public class VehicleDetailsMastersController : ControllerBase
    {
        private readonly IVehicleDetailsMasterService _VehicleDetailsMasterService;

        public VehicleDetailsMastersController(IVehicleDetailsMasterService VehicleDetailsMasterService)
        {
            _VehicleDetailsMasterService = VehicleDetailsMasterService;
        }

        [ProducesResponseType(typeof(VehicleDetailsMaster), StatusCodes.Status200OK)]//Success Response
        [ProducesResponseType(StatusCodes.Status404NotFound)]//Failure Response
        [HttpPost]
        public async Task<ActionResult<List<VehicleDetailsMaster>>> Add_VehicleDetailsMaster(List<VehicleDetailsMaster> VehicleDetailsMaster)
        {

            try
            {
                var myVehicleDetailsMaster = await _VehicleDetailsMasterService.Add_VehicleDetailsMaster(VehicleDetailsMaster);

                if (myVehicleDetailsMaster != null)
                {
                    return Created("VehicleDetailsMaster created Successfully", myVehicleDetailsMaster);
                }

                return BadRequest(new Error(1, "No VehicleDetailsMaster were added."));
            }
            catch (InvalidPrimaryID ip)
            {
                return BadRequest(new Error(2, ip.Message));
            }
            catch (InvalidSqlException ise)
            {
                return BadRequest(new Error(25, ise.Message));
            }

        }

        [ProducesResponseType(typeof(VehicleDetailsMaster), StatusCodes.Status200OK)]//Success Response
        [ProducesResponseType(StatusCodes.Status404NotFound)]//Failure Response
        [HttpGet]

        public async Task<ActionResult<List<VehicleDetailsMaster>>> Get_all_VehicleDetailsMaster()
        {
            var myVehicleDetailsMasters = await _VehicleDetailsMasterService.Get_all_VehicleDetailsMaster();
            if (myVehicleDetailsMasters?.Count > 0)
                return Ok(myVehicleDetailsMasters);
            return BadRequest(new Error(10, "No VehicleDetailsMaster are Existing"));
        }

        [ProducesResponseType(typeof(PackageDetailsMaster), StatusCodes.Status200OK)]//Success Response
        [ProducesResponseType(StatusCodes.Status404NotFound)]//Failure Response
        [HttpPost]

        public async Task<ActionResult<PackageDetailsMaster>> PostPlaceMaster([FromForm] VehicleFormModel vehicleFormModel)
        {
            try
            {
                var createdHotel = await _VehicleDetailsMasterService.PostImage(vehicleFormModel);
                return Ok(createdHotel);

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }
    }
}
