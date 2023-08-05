using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MakeYourTrip.Models;
using MakeYourTrip.Interfaces;

namespace MakeYourTrip.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class RoomTypeMastersController : ControllerBase
    {
        private readonly IRoomTypeMasterService _RoomTypeMasterService;


        public RoomTypeMastersController(IRoomTypeMasterService RoomTypeMasterService)
        {
            _RoomTypeMasterService = RoomTypeMasterService;
        }

        [ProducesResponseType(typeof(RoomTypeMaster), StatusCodes.Status200OK)]//Success Response
        [ProducesResponseType(StatusCodes.Status404NotFound)]//Failure Response
        [HttpPost]
        public async Task<ActionResult<RoomTypeMaster>> Add_RoomTypeMaster(RoomTypeMaster newplace)
        {
            /* try
             {*/
            /* if (additionalCategoryMaster.Id <=0)
                 throw new InvalidPrimaryID();*/
            var myRoomTypeMaster = await _RoomTypeMasterService.Add_RoomTypeMaster(newplace);
            if (myRoomTypeMaster != null)
                return Created("RoomTypeMaster created Successfully", myRoomTypeMaster);
            return BadRequest(new Error(1, $"RoomTypeMaster {newplace.Id} is Present already"));
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

        [ProducesResponseType(typeof(RoomTypeMaster), StatusCodes.Status200OK)]//Success Response
        [ProducesResponseType(StatusCodes.Status404NotFound)]//Failure Response
        [HttpGet]

        public async Task<ActionResult<List<RoomTypeMaster>>> Get_all_RoomTypeMaster()
        {
            var myRoomTypeMasters = await _RoomTypeMasterService.Get_all_RoomTypeMaster();
            if (myRoomTypeMasters?.Count > 0)
                return Ok(myRoomTypeMasters);
            return BadRequest(new Error(10, "No RoomTypeMaster are Existing"));
        }
    }
}
