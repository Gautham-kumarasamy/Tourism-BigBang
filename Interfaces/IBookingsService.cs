using MakeYourTrip.Models;
using MakeYourTrip.Models.DTO;

namespace MakeYourTrip.Interfaces
{
    public interface IBookingsService
    {

        Task<Booking> Add_Bookings(Booking booking);
        Task<List<Booking>?> View_All_bookings();

        Task<Booking?> View_Booking(IdDTO idDTO);

    }
}
