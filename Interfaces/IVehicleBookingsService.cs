using MakeYourTrip.Models;
using MakeYourTrip.Models.DTO;

namespace MakeYourTrip.Interfaces
{
    public interface IVehicleBookingsService
    {
        Task<VehicleBooking> Add_VehicleBooking(VehicleBooking vehicleBooking);
        Task<List<VehicleBooking>?> View_All_VehicleBooking();

    }
}