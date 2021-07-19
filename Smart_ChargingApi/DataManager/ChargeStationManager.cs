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
    public class ChargeStationManager : IChargeStation
    {
        readonly Smart_Charging_Context _context;
        public ChargeStationManager(Smart_Charging_Context context)
        {
            _context = context;
        }

        public async Task<List<ChargeStation>> GetAsync()
        {
            return await _context.ChargeStations.Include(s=>s.Connector).Include(s=>s.Group).ToListAsync();
        }

        public async Task<ChargeStation> GetByIdAsync(int id)
        {
            return await _context.ChargeStations.Include(s => s.Connector).Include(s => s.Group)
                .FirstOrDefaultAsync(e => e.Id == id);
        }
        public async Task<List<ChargeStation>> GetChargeStationByGroupIdAsync(int id)
        {
            return await _context.ChargeStations.Include(s => s.Connector).Include(s => s.Group).Where(s=>s.GroupId == id)
                .ToListAsync();
        }
        public async Task<int> PostAsync(ChargeStation model)
        {
            ChargeStation chargeStation = model;
            await _context.ChargeStations.AddAsync(chargeStation);
            await _context.SaveChangesAsync();
            return chargeStation.Id;
        }


        public async Task UpdateAsync(ChargeStation updatedModel)
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

        public async Task DeleteAsync(ChargeStation model)
        {
            try
            {
                _context.ChargeStations.Remove(model);
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
