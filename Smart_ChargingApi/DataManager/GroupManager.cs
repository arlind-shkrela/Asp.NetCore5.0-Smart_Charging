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
    public class GroupManager : IGroup
    {
        readonly Smart_Charging_Context _context;
        public GroupManager(Smart_Charging_Context context)
        {
            _context = context;
        }

        public async Task<List<Group>> GetAsync()
        {
            return await _context.Groups.Include(s=>s.ChargeStations).ToListAsync();
        }

        public async Task<Group> GetByIdAsync(int id)
        {
            return await _context.Groups.Include(s=>s.ChargeStations)
                .FirstOrDefaultAsync(e => e.Id == id);
        }

        public async Task<int> PostAsync(Group model)
        {
            Group group = model;
            await _context.Groups.AddAsync(group);
            await _context.SaveChangesAsync();
            return group.Id;
        }

        public async Task UpdateAsync(Group group)
        {
            _context.Entry(group).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (Exception)
            {
                throw;
            }
        }


        public async Task DeleteAsync(Group group)
        {
            try
            {
                _context.Groups.Remove(group);
                await _context.SaveChangesAsync();
            }
            catch (Exception)
            {

                throw;
            }
         
        }

        public bool Exists(int id)
        {
            return  _context.Groups.Any(e => e.Id == id);
        }
    }
}
