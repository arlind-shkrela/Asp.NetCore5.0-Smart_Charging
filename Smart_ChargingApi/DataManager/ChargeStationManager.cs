﻿using Microsoft.EntityFrameworkCore;
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
            return await _context.ChargeStations.ToListAsync();
        }

        public async Task<ChargeStation> GetByIdAsync(int id)
        {
            return await _context.ChargeStations
                .FirstOrDefaultAsync(e => e.Id == id);
        }
        public async Task PostAsync(ChargeStation model)
        {
            await _context.ChargeStations.AddAsync(model);
            await _context.SaveChangesAsync();
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
