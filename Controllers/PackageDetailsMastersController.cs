/*using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MakeYourTrip.Models;
using MakeYourTrip.Exceptions;

namespace MakeYourTrip.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PackageDetailsMastersController : ControllerBase
    {
        private readonly TourPackagesContext _context;

        public PackageDetailsMastersController(TourPackagesContext context)
        {
            _context = context;
        }

        // GET: api/PackageDetailsMasters
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PackageDetailsMaster>>> GetPackageDetailsMasters()
        {
            try
            {
                var mypackages = await _packageMastersService.View_All_PackageMaster();
                if (mypackages.Count > 0)
                    return Ok(mypackages);
                return BadRequest(new Error(10, "No packages are Existing"));
            }
            catch (InvalidSqlException ise)
            {
                return BadRequest(new Error(25, ise.Message));
            }
        }

        [HttpPost]
        public async Task<ActionResult<PackageDetailsMaster>> PostPackageDetailsMaster(PackageDetailsMaster packageDetailsMaster)
        {
            try
            {
                var mypackage = await _packageMastersService.Add_PackageMaster(packageMaster);
                if (mypackage.Id != null)
                    return Created("Added created Successfully", mypackage);
                return BadRequest(new Error(1, $"Package {packageMaster.Id} is Present already"));
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

    }
}
*/