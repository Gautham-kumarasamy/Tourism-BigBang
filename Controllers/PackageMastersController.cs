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
using MakeYourTrip.Models.DTO;
using MakeYourTrip.Services;

namespace MakeYourTrip.Controllers
{

    [Route("api/[controller]/[action]")]
    [ApiController]
    public class PackageMastersController : ControllerBase
    {
        private readonly IPackageMasterService _PackageMasterService;


        public PackageMastersController(IPackageMasterService PackageMasterService)
        {
            _PackageMasterService = PackageMasterService;
        }

        [ProducesResponseType(typeof(PackageMaster), StatusCodes.Status200OK)]//Success Response
        [ProducesResponseType(StatusCodes.Status404NotFound)]//Failure Response
        [HttpPost]
        public async Task<ActionResult<PackageMaster>> Add_PackageMaster(PackageMaster newplace)
        {
            /* try
             {*/
            /* if (additionalCategoryMaster.Id <=0)
                 throw new InvalidPrimaryID();*/
            var myPackageMaster = await _PackageMasterService.Add_PackageMaster(newplace);
            if (myPackageMaster != null)
                return Created("PackageMaster created Successfully", myPackageMaster);
            return BadRequest(new Error(1, $"PackageMaster {newplace.Id} is Present already"));
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

        [ProducesResponseType(typeof(PackageMaster), StatusCodes.Status200OK)]//Success Response
        [ProducesResponseType(StatusCodes.Status404NotFound)]//Failure Response
        [HttpGet]

        public async Task<ActionResult<List<PackageMaster>>> Get_all_PackageMaster()
        {
            var myPackageMasters = await _PackageMasterService.Get_all_PackageMaster();
            if (myPackageMasters?.Count > 0)
                return Ok(myPackageMasters);
            return BadRequest(new Error(10, "No PackageMaster are Existing"));
        }

        [ProducesResponseType(typeof(PackageMaster), StatusCodes.Status200OK)]//Success Response
        [ProducesResponseType(StatusCodes.Status404NotFound)]//Failure Response
        [HttpPost]

        public async Task<ActionResult<PackageMaster>> View_PackageMaster(IdDTO idDTO)
        {
            try
            {
                if (idDTO.IdInt <= 0)
                    return BadRequest(new Error(4, "Enter Valid PackageMaster ID"));
                var myPackageMaster = await _PackageMasterService.View_PackageMaster(idDTO);
                if (myPackageMaster != null)
                    return Created("PackageMaster", myPackageMaster);
                return BadRequest(new Error(9, $"There is no PackageMaster present for the id {idDTO.IdInt}"));
            }
            catch (InvalidSqlException ise)
            {
                return BadRequest(new Error(25, ise.Message));
            }
        }

        [ProducesResponseType(typeof(PackageDTO), StatusCodes.Status200OK)]//Success Response
        [ProducesResponseType(StatusCodes.Status404NotFound)]//Failure Response
        [HttpPost]

        public async Task<ActionResult<PackageDTO>> Get_package_details(IdDTO id)
        {
            var result = await _PackageMasterService.Get_package_details(id);
            if(result!= null)
            {
                return Ok(result);
            }
            return BadRequest(new Error(9, $"There is no PackageMaster present for the id {id.IdInt}"));

        }

        [ProducesResponseType(typeof(PackageMaster), StatusCodes.Status200OK)]//Success Response
        [ProducesResponseType(StatusCodes.Status404NotFound)]//Failure Response
        [HttpPost]

        public async Task<ActionResult<PackageMaster>> PostPackageMasterImage([FromForm] PackageFormModel packageFormModel)
        {
            try
            {
                var createdHotel = await _PackageMasterService.PostDashboardImage(packageFormModel);
                return Ok(createdHotel);

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

    }
}
