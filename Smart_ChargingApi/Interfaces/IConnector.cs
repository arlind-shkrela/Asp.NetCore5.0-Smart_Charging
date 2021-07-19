using Smart_ChargingApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Smart_ChargingApi.Interfaces
{
    public interface IConnector: IBase<Connector>
    {
        Task<List<ChargeStation>> GetChargeStationByConnectionIdAsync(int id);
    }
}
