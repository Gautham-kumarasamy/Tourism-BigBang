using MakeYourTrip.Interfaces;
using MakeYourTrip.Models.DTO;
using MakeYourTrip.Models;
using MakeYourTrip.Repos;

namespace MakeYourTrip.Services
{
    public class BookingsService : IBookingsService
    {

        private ICrud<Booking, IdDTO> _Bookingrepo;


        public BookingsService(ICrud<Booking, IdDTO> Bookingrepo)
        {
            _Bookingrepo = Bookingrepo;
        }

        public async Task<Booking> Add_Bookings(Booking booking)
        {

            var Bookings = await _Bookingrepo.GetAll();
            var newBooking = Bookings.SingleOrDefault(h => h.Id == booking.Id);
            if (newBooking == null)
            {
                var myhotel = await _Bookingrepo.Add(booking);
                if (myhotel != null)
                    return myhotel;
            }
            return null;
        }

        public async Task<List<Booking>?> View_All_bookings()
        {
            var myhotel = await _Bookingrepo.GetAll();
            return myhotel;
        }
    }
}
