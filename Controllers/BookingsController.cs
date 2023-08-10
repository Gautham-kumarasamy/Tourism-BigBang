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
    public class BookingsController : ControllerBase
    {
        private readonly IBookingsService _bookingsService;

        public BookingsController(IBookingsService bookingService)
        {
            _bookingsService = bookingService;
        }

        [ProducesResponseType(typeof(Booking), StatusCodes.Status200OK)]//Success Response
        [ProducesResponseType(StatusCodes.Status404NotFound)]//Failure Response
        [HttpGet]

        public async Task<ActionResult<IEnumerable<Booking>>> GetBookings()
        {
            try
            {
                var myhotel = await _bookingsService.View_All_bookings();
                if (myhotel?.Count > 0)
                    return Ok(myhotel);
                return BadRequest(new Error(10, "No bookings are Existing"));
            }
            catch (InvalidSqlException ise)
            {
                return BadRequest(new Error(25, ise.Message));
            }
        }


        [ProducesResponseType(typeof(Booking), StatusCodes.Status200OK)]//Success Response
        [ProducesResponseType(StatusCodes.Status404NotFound)]//Failure Response
        [HttpPost]
        public async Task<ActionResult<Booking>> PostBooking(Booking booking)
        {
            try
            {
                var myhotel = await _bookingsService.Add_Bookings(booking);
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
        }

        [ProducesResponseType(typeof(Booking), StatusCodes.Status200OK)]//Success Response
        [ProducesResponseType(StatusCodes.Status404NotFound)]//Failure Response
        [HttpPost]

        public async Task<ActionResult<Booking>> View_Booking(IdDTO idDTO)
        {
            try
            {
                if (idDTO.Idint <= 0)
                    return BadRequest(new Error(4, "Enter Valid Booking ID"));
                var myBooking = await _bookingsService.View_Booking(idDTO);
                if (myBooking != null)
                    return Created("Booking", myBooking);
                return BadRequest(new Error(9, $"There is no Booking present for the id {idDTO.Idint}"));
            }
            catch (InvalidSqlException ise)
            {
                return BadRequest(new Error(25, ise.Message));
            }
        }


    }
}
