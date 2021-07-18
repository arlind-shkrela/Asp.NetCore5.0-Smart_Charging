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

        public async Task<List<Group>> Get()
        {
            return await _context.Groups.ToListAsync();
        }

        public async Task<Group> GetById(int id)
        {
            return await _context.Groups
                .FirstOrDefaultAsync(e => e.Id == id);
        }
        public async Task Add(Group entity)
        {
            await _context.Groups.AddAsync(entity);
            await _context.SaveChangesAsync();
        }
        public async Task Post(Group model)
        {
            await _context.Groups.AddAsync(model);
            await _context.SaveChangesAsync();
        }

        public async Task Update(Group group)
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


        public async Task Delete(Group group)
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
