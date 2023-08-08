using MakeYourTrip.Models;
using Microsoft.AspNetCore.Mvc;

namespace MakeYourTrip.Interfaces
{
    public interface IImageListRepo
    {
        Task<List<PackageMaster>> PostPackageMasterImages([FromForm] List<PackageMaster> packageMasters);

    }
}
