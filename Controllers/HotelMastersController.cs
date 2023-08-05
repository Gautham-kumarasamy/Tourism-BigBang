using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MakeYourTrip.Models;
using MakeYourTrip.Interfaces;
using MakeYourTrip.Services;
using MakeYourTrip.Exceptions;
using MakeYourTrip.Models.DTO;

namespace MakeYourTrip.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class HotelMastersController : ControllerBase
    {
        private readonly IHotelMasterService _hotelMasterService;


        public HotelMastersController(IHotelMasterService hotelMasterService)
        {
            _hotelMasterService = hotelMasterService;
        }

        [ProducesResponseType(typeof(HotelMaster), StatusCodes.Status200OK)]//Success Response
        [ProducesResponseType(StatusCodes.Status404NotFound)]//Failure Response
        [HttpPost]
        public async Task<ActionResult<HotelMaster>> Add_HotelMaster(HotelMaster newHotel)
        {
            /* try
             {*/
            /* if (HotelMaster.Id <=0)
                 throw new InvalidPrimaryID();*/
            var myHotelMaster = await _hotelMasterService.Add_HotelMaster(newHotel);
            if (myHotelMaster != null)
                return Created("HotelMaster created Successfully", myHotelMaster);
            return BadRequest(new Error(1, $"HotelMaster {newHotel.Id} is Present already"));
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


        [ProducesResponseType(typeof(HotelMaster), StatusCodes.Status200OK)]//Success Response
        [ProducesResponseType(StatusCodes.Status404NotFound)]//Failure Response
        [HttpGet]

        public async Task<ActionResult<List<HotelMaster>>> Get_all_HotelMaster()
        {
            var myHotelMasters = await _hotelMasterService.Get_all_HotelMaster();
            if (myHotelMasters?.Count > 0)
                return Ok(myHotelMasters);
            return BadRequest(new Error(10, "No HotelMasters are Existing"));
        }

        [ProducesResponseType(typeof(HotelMaster), StatusCodes.Status200OK)]//Success Response
        [ProducesResponseType(StatusCodes.Status404NotFound)]//Failure Response
        [HttpPost]

        public async Task<ActionResult<HotelMaster>> View_HotelMaster(IdDTO idDTO)
        {
            try
            {
                if (idDTO.IdInt <= 0)
                    return BadRequest(new Error(4, "Enter Valid HotelMaster ID"));
                var myHotelMaster = await _hotelMasterService.View_HotelMaster(idDTO);
                if (myHotelMaster != null)
                    return Created("HotelMaster", myHotelMaster);
                return BadRequest(new Error(9, $"There is no HotelMaster present for the id {idDTO.IdInt}"));
            }
            catch (InvalidSqlException ise)
            {
                return BadRequest(new Error(25, ise.Message));
            }
        }

        [ProducesResponseType(typeof(HotelMaster), StatusCodes.Status200OK)]//Success Response
        [ProducesResponseType(StatusCodes.Status404NotFound)]//Failure Response
        [HttpPost]

        public async Task<ActionResult<HotelMaster>> PostHotelMaster([FromForm] HotelFormModule hotelFormModule)
        {
            try
            {
                var createdHotel = await _hotelMasterService.PostImage(hotelFormModule);
                return Ok(createdHotel);

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

    }
}
