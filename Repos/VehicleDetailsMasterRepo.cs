﻿using MakeYourTrip.Exceptions;
using MakeYourTrip.Interfaces;
using MakeYourTrip.Models;
using MakeYourTrip.Models.DTO;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace MakeYourTrip.Repos
{
    public class VehicleDetailsMasterRepo : ICrud<VehicleDetailsMaster, IdDTO>

    {

        private readonly TourPackagesContext _context;

        public VehicleDetailsMasterRepo(TourPackagesContext context)
        {
            _context = context;
        }

        public async Task<VehicleDetailsMaster?> Add(VehicleDetailsMaster item)
        {
            try
            {
                var vehicleDetailsMaster = _context.VehicleDetailsMasters.SingleOrDefault(f => f.Id == item.Id);
                if (vehicleDetailsMaster == null)
                {
                    await _context.VehicleDetailsMasters.AddAsync(item);
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
    

        public async Task<VehicleDetailsMaster?> Delete(IdDTO item)
    {

        try
        {
            var VehicleDetailsMasters = await _context.VehicleDetailsMasters.ToListAsync();
            var vehicleDetailsMaster = VehicleDetailsMasters.FirstOrDefault(h => h.Id == item.Idint);
            if (vehicleDetailsMaster != null)
            {
                _context.VehicleDetailsMasters.Remove(vehicleDetailsMaster);
                await _context.SaveChangesAsync();
                return vehicleDetailsMaster;
            }
            else
                return null;
        }
        catch (SqlException ex)
        {
            throw new InvalidSqlException(ex.Message);
        }
    }

        public async Task<List<VehicleDetailsMaster>?> GetAll()
        {

            try
            {
                var vehicleDetailsMaster = await _context.VehicleDetailsMasters.ToListAsync();
                if (vehicleDetailsMaster != null)
                    return vehicleDetailsMaster;
            }
            catch (SqlException ex)
            {
                throw new InvalidSqlException(ex.Message);
            }
            return null;
        }

        public async Task<VehicleDetailsMaster?> GetValue(IdDTO item)
        {
            try
            {
                var VehicleDetailsMasters = await _context.VehicleDetailsMasters.ToListAsync();
                var VehicleDetailsMaster = VehicleDetailsMasters.SingleOrDefault(h => h.Id == item.Idint);
                if (VehicleDetailsMaster != null)
                    return VehicleDetailsMaster;
            }
            catch (SqlException ex)
            {
                throw new InvalidSqlException(ex.Message);
            }
            return null;
        }

        public async Task<VehicleDetailsMaster?> Update(VehicleDetailsMaster item)
        {
            try
            {
                var VehicleDetailsMasters = await _context.VehicleDetailsMasters.ToListAsync();
                var VehicleDetailsMaster = VehicleDetailsMasters.SingleOrDefault(h => h.Id == item.Id);
                if (VehicleDetailsMaster != null)
                {
                    VehicleDetailsMaster.PlaceId = VehicleDetailsMaster.PlaceId != null ? VehicleDetailsMaster.PlaceId : VehicleDetailsMaster.PlaceId;
                   /* VehicleDetailsMaster.PackageId = VehicleDetailsMaster.PackageId != null ? VehicleDetailsMaster.PackageId : VehicleDetailsMaster.PackageId;
                    VehicleDetailsMaster.DayNumber = VehicleDetailsMaster.DayNumber != null ? VehicleDetailsMaster.DayNumber : VehicleDetailsMaster.DayNumber;
*/
                    _context.VehicleDetailsMasters.Update(VehicleDetailsMaster);
                    await _context.SaveChangesAsync();
                    return VehicleDetailsMaster;
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
