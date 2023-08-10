using MakeYourTrip.Interfaces;
using MakeYourTrip.Models;
using MakeYourTrip.Models.DTO;
using MakeYourTrip.Repos;
using Microsoft.AspNetCore.Mvc;

namespace MakeYourTrip.Services
{
    public class PackageDetailsMastersService : IPackageDetailsMastersService
    {
        private ICrud<PackageDetailsMaster, IdDTO> _packagedetailsrepo;
        private readonly IImageRepo<PackageDetailsMaster, PlaceFormModel> _imageRepo;


        public PackageDetailsMastersService(ICrud<PackageDetailsMaster, IdDTO> packagedetailsrepo, IImageRepo<PackageDetailsMaster, PlaceFormModel> imageRepo)
        {
            _packagedetailsrepo = packagedetailsrepo;
            _imageRepo = imageRepo;
        }

        public async Task<PackageDetailsMaster> Add_PackageDetailsMaster(PackageDetailsMaster packageDetailsMaster)
        {
            var packages = await _packagedetailsrepo.GetAll();
            var newpackage = packages.SingleOrDefault(h => h.Id == packageDetailsMaster.Id);
            if (newpackage == null)
            {
                var myhotel = await _packagedetailsrepo.Add(packageDetailsMaster);
                if (myhotel != null)
                    return myhotel;
            }
            return null;
        }

        public async Task<List<PackageDetailsMaster>?> View_All_PackageDetailsMaster()
        {
            var myhotel = await _packagedetailsrepo.GetAll();
            return myhotel;
        }


        public async Task<PackageDetailsMaster> PostImage([FromForm] PlaceFormModel placeFormModel)
        {
            if (placeFormModel == null)
            {
                throw new Exception("Invalid file");
            }
            var item = await _imageRepo.PostImage(placeFormModel);
            if (item == null)
            {
                return null;
            }
            return item;
        }
    }

}
