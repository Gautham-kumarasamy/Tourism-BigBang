using MakeYourTrip.Models;
using MakeYourTrip.Services;

namespace MakeYourTrip.Interfaces
{
    public interface IRoomBookingsService
    {


        Task<RoomBooking> Add_RoomBookingsService(RoomBooking roomBookingsService);
        Task<List<RoomBooking>?> View_All_RoomBookingsService();
    }
}
