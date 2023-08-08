/*using MakeYourTrip.Interfaces;
using MakeYourTrip.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace MakeYourTrip.Repos
{
    public class ImageRepo: IImageRepo
    {
        private readonly MakeYourTripContext _context;
        private readonly IWebHostEnvironment _hostEnvironment;


        public ImageRepo(MakeYourTripContext context, IWebHostEnvironment hostEnvironment)
        {
            _context = context;
            _hostEnvironment = hostEnvironment;
        }

        public async Task<PackageMaster> PostPackageMasterImage([FromForm] PackageMaster packageMaster)
        {
            if (packageMaster == null)
            {
                throw new ArgumentException("Invalid file");
            }

            packageMaster.Imagepath = await SaveImage(packageMaster.HotelImage);
            _context.PackageMasters.Add(packageMaster);
            await _context.SaveChangesAsync();
            return packageMaster;
        }


        [NonAction]
        public async Task<string> SaveImage(IFormFile imageFile)
        {
            string imageName = new String(Path.GetFileNameWithoutExtension(imageFile.FileName).Take(10).ToArray()).Replace(' ', '-');
            imageName = imageName + DateTime.Now.ToString("yymmssfff") + Path.GetExtension(imageFile.FileName);
            var imagePath = Path.Combine(_hostEnvironment.ContentRootPath, "wwwroot/Images", imageName);
            using (var fileStream = new FileStream(imagePath, FileMode.Create))
            {
                await imageFile.CopyToAsync(fileStream);
            }
            return imageName;
        }
    }
}
*/