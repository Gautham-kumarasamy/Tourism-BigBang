using MakeYourTrip.Models;
using MakeYourTrip.Models.DTO;
using Microsoft.AspNetCore.Mvc;

namespace MakeYourTrip.Interfaces
{
    public interface IPackageDetailsMastersService
    {
        Task<PackageDetailsMaster> Add_PackageDetailsMaster(PackageDetailsMaster packageDetailsMaster);
        Task<List<PackageDetailsMaster>?> View_All_PackageDetailsMaster();

        Task<PackageDetailsMaster> PostImage([FromForm] PlaceFormModel placeFormModel);
    }
}
