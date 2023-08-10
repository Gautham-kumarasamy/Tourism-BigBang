using MakeYourTrip.Interfaces;
using MakeYourTrip.Models.DTO;
using MakeYourTrip.Models;
using MakeYourTrip.Repos;

namespace MakeYourTrip.Services
{
    public class RoomBookingsService : IRoomBookingsService
    {

        private readonly ICrud<RoomBooking, IdDTO> _roomBooking;

        public RoomBookingsService(ICrud<RoomBooking, IdDTO> roomBooking)
        {
            _roomBooking = roomBooking;
        }

        public async Task<RoomBooking> Add_RoomBookingsService(RoomBooking roomBookingsService)
        {

            var roombookings = await _roomBooking.GetAll();
            var roombooking = roombookings.SingleOrDefault(h => h.Id == roomBookingsService.Id);
            if (roombooking == null)
            {
                var myroombooking = await _roomBooking.Add(roomBookingsService);
                if (myroombooking != null)
                    return myroombooking;
            }
            return null;
        }

        public async Task<List<RoomBooking>?> View_All_RoomBookingsService()
        {
            var packages = await _roomBooking.GetAll();
            return packages;
        }
    }
}
