using MakeYourTrip.Models;
using MakeYourTrip.Models.DTO;
using MakeYourTrip.Services;

namespace MakeYourTrip.Interfaces
{
    public interface IRoomBookingsService
    {


        Task<RoomBooking> Add_RoomBookingsService(RoomBooking roomBookingsService);
        Task<List<RoomBooking>?> View_All_RoomBookingsService();

/*        Task<RoomBooking?> View_RoomBooking(IdDTO idDTO);
*/
    }
}
