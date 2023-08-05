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

namespace MakeYourTrip.Controllers
{

    [Route("api/[controller]/[action]")]
    [ApiController]
    public class VehicleMastersController : ControllerBase
    {
        private readonly IVehicleMasterService _VehicleMasterService;


        public VehicleMastersController(IVehicleMasterService VehicleMasterService)
        {
            _VehicleMasterService = VehicleMasterService;
        }

        [ProducesResponseType(typeof(VehicleMaster), StatusCodes.Status200OK)]//Success Response
        [ProducesResponseType(StatusCodes.Status404NotFound)]//Failure Response
        [HttpPost]
        public async Task<ActionResult<VehicleMaster>> Add_VehicleMaster(VehicleMaster newplace)
        {
            /* try
             {*/
            /* if (additionalCategoryMaster.Id <=0)
                 throw new InvalidPrimaryID();*/
            var myVehicleMaster = await _VehicleMasterService.Add_VehicleMaster(newplace);
            if (myVehicleMaster != null)
                return Created("VehicleMaster created Successfully", myVehicleMaster);
            return BadRequest(new Error(1, $"VehicleMaster {newplace.Id} is Present already"));
            /*}
            catch (InvalidPrimaryID ip)
            {
                return BadRequest(new Error(2, ip.Message));
            }
            catch (InvalidSqlException ise)
            {
                return BadRequest(new Error(25, ise.Message));
            }*/
        }

        [ProducesResponseType(typeof(VehicleMaster), StatusCodes.Status200OK)]//Success Response
        [ProducesResponseType(StatusCodes.Status404NotFound)]//Failure Response
        [HttpGet]

        public async Task<ActionResult<List<VehicleMaster>>> Get_all_VehicleMaster()
        {
            var myVehicleMasters = await _VehicleMasterService.Get_all_VehicleMaster();
            if (myVehicleMasters?.Count > 0)
                return Ok(myVehicleMasters);
            return BadRequest(new Error(10, "No VehicleMaster are Existing"));
        }

        [ProducesResponseType(typeof(VehicleMaster), StatusCodes.Status200OK)]//Success Response
        [ProducesResponseType(StatusCodes.Status404NotFound)]//Failure Response
        [HttpPost]

        public async Task<ActionResult<VehicleMaster>> View_VehicleMaster(IdDTO idDTO)
        {
            try
            {
                if (idDTO.IdInt <= 0)
                    return BadRequest(new Error(4, "Enter Valid VehicleMaster ID"));
                var myVehicleMaster = await _VehicleMasterService.View_VehicleMaster(idDTO);
                if (myVehicleMaster != null)
                    return Created("VehicleMaster", myVehicleMaster);
                return BadRequest(new Error(9, $"There is no VehicleMaster present for the id {idDTO.IdInt}"));
            }
            catch (InvalidSqlException ise)
            {
                return BadRequest(new Error(25, ise.Message));
            }
        }

    }
}
