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

namespace MakeYourTrip.Controllers
{
    [Route("api/[controller]")]
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
                return BadRequest(new Error(10, "No hotels are Existing"));
            }
            catch (InvalidSqlException ise)
            {
                return BadRequest(new Error(25, ise.Message));
            }
        }

        // GET: api/RoomBookings/5
        /*    [HttpGet("{id}")]
            public async Task<ActionResult<RoomBooking>> GetRoomBooking(int id)
            {
              if (_context.RoomBookings == null)
              {
                  return NotFound();
              }
                var roomBooking = await _context.RoomBookings.FindAsync(id);

                if (roomBooking == null)
                {
                    return NotFound();
                }

                return roomBooking;
            }*/

        // PUT: api/RoomBookings/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        /* [HttpPut("{id}")]
         public async Task<IActionResult> PutRoomBooking(int id, RoomBooking roomBooking)
         {
             if (id != roomBooking.Id)
             {
                 return BadRequest();
             }

             _context.Entry(roomBooking).State = EntityState.Modified;

             try
             {
                 await _context.SaveChangesAsync();
             }
             catch (DbUpdateConcurrencyException)
             {
                 if (!RoomBookingExists(id))
                 {
                     return NotFound();
                 }
                 else
                 {
                     throw;
                 }
             }

             return NoContent();
         }*/

        // POST: api/RoomBookings
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<RoomBooking>> PostRoomBooking(RoomBooking roomBooking)
        {

            try
            {
                var myhotel = await _roomBooking.Add_RoomBookingsService(roomBooking);
                if (myhotel.Id != null)
                    return Created("Hotel Added Successfully", myhotel);
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

            // DELETE: api/RoomBookings/5
            /*     [HttpDelete("{id}")]
                 public async Task<IActionResult> DeleteRoomBooking(int id)
                 {
                     if (_context.RoomBookings == null)
                     {
                         return NotFound();
                     }
                     var roomBooking = await _context.RoomBookings.FindAsync(id);
                     if (roomBooking == null)
                     {
                         return NotFound();
                     }

                     _context.RoomBookings.Remove(roomBooking);
                     await _context.SaveChangesAsync();

                     return NoContent();
                 }*/

            /*    private bool RoomBookingExists(int id)
            {
                return (_context.RoomBookings?.Any(e => e.Id == id)).GetValueOrDefault();
            }*/
        }
    }
}
