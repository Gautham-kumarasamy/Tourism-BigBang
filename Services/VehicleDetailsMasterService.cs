using MakeYourTrip.Interfaces;
using MakeYourTrip.Models.DTO;
using MakeYourTrip.Models;

namespace MakeYourTrip.Services
{
    public class VehicleDetailsMasterService : IVehicleDetailsMasterService
    {
        private ICrud<VehicleDetailsMaster, IdDTO> _vechivledetailmasterrepo;

        public VehicleDetailsMasterService(ICrud<VehicleDetailsMaster, IdDTO> vechivledetailmasterrepo)
        {
            _vechivledetailmasterrepo = vechivledetailmasterrepo;
        }

        public async Task<VehicleDetailsMaster> Add_VehicleDetailsMaster(VehicleDetailsMaster vehicleDetailsMaster)
        {
            var VehicleDetailsMasters = await _vechivledetailmasterrepo.GetAll();
            var newVehicleDetailsMaster = VehicleDetailsMasters.SingleOrDefault(h => h.Id == vehicleDetailsMaster.Id);
            if (newVehicleDetailsMaster == null)
            {
                var myVehicleDetailsMaster = await _vechivledetailmasterrepo.Add(vehicleDetailsMaster);
                if (myVehicleDetailsMaster != null)
                    return myVehicleDetailsMaster;
            }
            return null;
        }

        public async Task<List<VehicleDetailsMaster>?> View_All_VehicleDetailsMaster()
        {
            var myVehicleDetailsMaster = await _vechivledetailmasterrepo.GetAll();
            return myVehicleDetailsMaster;
        }
    }
}
