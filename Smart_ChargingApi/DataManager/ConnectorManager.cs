using Microsoft.EntityFrameworkCore;
using Smart_ChargingApi.Data;
using Smart_ChargingApi.Interfaces;
using Smart_ChargingApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Smart_ChargingApi.DataManager
{
    public class ConnectorManager : IConnector
    {
        readonly Smart_Charging_Context _context;
        public ConnectorManager(Smart_Charging_Context context)
        {
            _context = context;
        }

        public async Task<List<Connector>> GetAsync()
        {
            return await _context.Connectors.Include(s => s.ChargeStations).ThenInclude(s => s.Group).ToListAsync();
        }

        async Task<Connector> IBase<Connector>.GetByIdAsync(int id)
        {
            return await _context.Connectors.Include(s => s.ChargeStations).ThenInclude(s => s.Group)
                .FirstOrDefaultAsync(e => e.Id == id);
        }
        public async Task<List<ChargeStation>> GetChargeStationByConnectionIdAsync(int id)
        {
           return await _context.ChargeStations.Include(s => s.Group).Where(s => s.ConnectorId == 1).ToListAsync();
        }

        public async Task<int> PostAsync(Connector model)
        {
            Connector connector = model;
            await _context.Connectors.AddAsync(connector);
            await _context.SaveChangesAsync();
            int id = connector.Id;
            return id;
        }

        public async Task UpdateAsync(Connector updatedModel)
        {
            _context.Entry(updatedModel).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (Exception)
            {
                throw;
            }
        }


        public async Task DeleteAsync(Connector model)
        {
            try
            {
                _context.Connectors.Remove(model);
                await _context.SaveChangesAsync();
            }
            catch (Exception)
            {
                throw;
            }


        }

        public bool Exists(int id)
        {
            return _context.Groups.Any(e => e.Id == id);
        }


    }
}
