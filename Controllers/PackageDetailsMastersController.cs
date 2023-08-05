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
using MakeYourTrip.Services;
using MakeYourTrip.Models.DTO;

namespace MakeYourTrip.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class PackageDetailsMastersMastersController : ControllerBase
    {
        private readonly IPackageDetailsMasterService _PackageDetailsMasterService;

        public PackageDetailsMastersMastersController(IPackageDetailsMasterService PackageDetailsMasterService)
        {
            _PackageDetailsMasterService = PackageDetailsMasterService;
        }

        [ProducesResponseType(typeof(PackageDetailsMaster), StatusCodes.Status200OK)]//Success Response
        [ProducesResponseType(StatusCodes.Status404NotFound)]//Failure Response
        [HttpPost]
        public async Task<ActionResult<List<PackageDetailsMaster>>> Add_PackageDetailsMaster(List<PackageDetailsMaster> PackageDetailsMaster)
        {

            try
            {
                var myPackageDetailsMaster = await _PackageDetailsMasterService.Add_PackageDetailsMaster(PackageDetailsMaster);

                if (myPackageDetailsMaster!= null)
                {
                    return Created("PackageDetailsMaster created Successfully", myPackageDetailsMaster);
                }

                return BadRequest(new Error(1, "No PackageDetailsMaster were added."));
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

        [ProducesResponseType(typeof(PackageDetailsMaster), StatusCodes.Status200OK)]//Success Response
        [ProducesResponseType(StatusCodes.Status404NotFound)]//Failure Response
        [HttpGet]

        public async Task<ActionResult<List<PackageDetailsMaster>>> Get_all_PackageDetailsMaster()
        {
            var myPackageDetailsMasters = await _PackageDetailsMasterService.Get_all_PackageDetailsMaster();
            if (myPackageDetailsMasters?.Count > 0)
                return Ok(myPackageDetailsMasters);
            return BadRequest(new Error(10, "No PackageDetailsMaster are Existing"));
        }


        [ProducesResponseType(typeof(PackageDetailsMaster), StatusCodes.Status200OK)]//Success Response
        [ProducesResponseType(StatusCodes.Status404NotFound)]//Failure Response
        [HttpPost]

        public async Task<ActionResult<PackageDetailsMaster>> PostPlaceMaster([FromForm] PlaceFormModel placeFormModel)
        {
            try
            {
                var createdHotel = await _PackageDetailsMasterService.PostImage(placeFormModel);
                return Ok(createdHotel);

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }
    }
}
