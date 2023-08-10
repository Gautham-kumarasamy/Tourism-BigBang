using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MakeYourTrip.Models;
using MakeYourTrip.Interfaces;
using MakeYourTrip.Exceptions;
using MakeYourTrip.Services;
using MakeYourTrip.Models.DTO;

namespace MakeYourTrip.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class RoomBookingsController : ControllerBase
    {
        private readonly IRoomBookingsService _roomBooking;

        public RoomBookingsController(IRoomBookingsService roomBooking)
        {
            _roomBooking = roomBooking;
        }

        // GET: api/RoomBookings
        [HttpGet]
        public async Task<ActionResult<IEnumerable<RoomBooking>>> GetRoomBookings()
        {

            try
            {
                var myhotel = await _roomBooking.View_All_RoomBookingsService();
                if (myhotel.Count > 0)
                    return Ok(myhotel);
                return BadRequest(new Error(10, "No room are Existing"));
            }
            catch (InvalidSqlException ise)
            {
                return BadRequest(new Error(25, ise.Message));
            }
        }


        // POST: api/RoomBookings
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<RoomBooking>> PostRoomBooking(RoomBooking roomBooking)
        {

            try
            {
                var myhotel = await _roomBooking.Add_RoomBookingsService(roomBooking);
                if (myhotel.Id != null)
                    return Created("room Added Successfully", myhotel);
                return BadRequest(new Error(1, $"hotel {myhotel.Id} is Present already"));
            }
            catch (InvalidPrimaryKeyId ip)
            {
                return BadRequest(new Error(2, ip.Message));
            }
            catch (InvalidSqlException ise)
            {
                return BadRequest(new Error(25, ise.Message));
            }


        }


        [ProducesResponseType(typeof(RoomBooking), StatusCodes.Status200OK)]//Success Response
        [ProducesResponseType(StatusCodes.Status404NotFound)]//Failure Response
        [HttpGet]

        public async Task<ActionResult<List<RoomBooking>>> Get_all_RoomBooking()
        {
            var myRoomBookings = await _roomBooking.View_All_RoomBookingsService();
            if (myRoomBookings?.Count > 0)
                return Ok(myRoomBookings);
            return BadRequest(new Error(10, "No RoomBookings are Existing"));
        }

    }
}

