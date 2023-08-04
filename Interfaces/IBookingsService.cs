using MakeYourTrip.Models;

namespace MakeYourTrip.Interfaces
{
    public interface IBookingsService
    {

        Task<Booking> Add_Bookings(Booking booking);
        Task<List<Booking>?> View_All_bookings();

    }
}
