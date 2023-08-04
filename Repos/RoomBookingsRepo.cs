using MakeYourTrip.Exceptions;
using MakeYourTrip.Interfaces;
using MakeYourTrip.Models;
using MakeYourTrip.Models.DTO;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace MakeYourTrip.Repos
{
    public class RoomBookingsRepo : ICrud<RoomBooking, IdDTO>


    {

        private readonly TourPackagesContext _context;


        public RoomBookingsRepo(TourPackagesContext context)
        {
            _context = context;
        }



        public async Task<RoomBooking?> Add(RoomBooking item)
        {

            try
            {
                var newroomBooking = _context.RoomBookings.SingleOrDefault(f => f.Id == item.Id);
                if (newroomBooking == null)
                {
                    await _context.RoomBookings.AddAsync(item);
                    await _context.SaveChangesAsync();
                    return item;
                }
                return null;
            }
            catch (SqlException ex)
            {
                throw new InvalidSqlException(ex.Message);
            }
        }

        public async Task<RoomBooking?> Delete(IdDTO item)
        {

            try
            {
                var roomBookings = await _context.RoomBookings.ToListAsync();
                var roomBooking = roomBookings.FirstOrDefault(h => h.Id == item.Idint);
                if (roomBooking != null)
                {
                    _context.RoomBookings.Remove(roomBooking);
                    await _context.SaveChangesAsync();
                    return roomBooking;
                }
                else
                    return null;
            }
            catch (SqlException ex)
            {
                throw new InvalidSqlException(ex.Message);
            }
        }

        public async Task<List<RoomBooking>?> GetAll()
        {

            try
            {
                var roomBookings = await _context.RoomBookings.ToListAsync();
                if (roomBookings != null)
                    return roomBookings;
            }
            catch (SqlException ex)
            {
                throw new InvalidSqlException(ex.Message);
            }
            return null;
        }

        public async Task<RoomBooking?> GetValue(IdDTO item)
        {

            try
            {
                var roomBookings = await _context.RoomBookings.ToListAsync();
                var roomBooking = roomBookings.SingleOrDefault(h => h.Id == item.Idint);
                if (roomBooking != null)
                    return roomBooking;
            }
            catch (SqlException ex)
            {
                throw new InvalidSqlException(ex.Message);
            }
            return null;
        }

        public async Task<RoomBooking?> Update(RoomBooking item)
        {
            try
            {
                var roomBookings = await _context.RoomBookings.ToListAsync();
                var roomBooking = roomBookings.SingleOrDefault(h => h.Id == item.Id);
                if (roomBooking != null)
                {
                   /* roomBooking.PlaceId = roomBooking.PlaceId != null ? roomBooking.PlaceId : roomBooking.PlaceId;
                    roomBooking.PackageId = roomBooking.PackageId != null ? roomBooking.PackageId : roomBooking.PackageId;
                    roomBooking.DayNumber = roomBooking.DayNumber != null ? roomBooking.DayNumber : roomBooking.DayNumber;
*/
                    _context.RoomBookings.Update(roomBooking);
                    await _context.SaveChangesAsync();
                    return roomBooking;
                }
            }
            catch (SqlException ex)
            {
                throw new InvalidSqlException(ex.Message);
            }
            return null;
        }

    }
}
