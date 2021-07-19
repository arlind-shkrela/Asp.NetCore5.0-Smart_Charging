using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Smart_ChargingApi.Interfaces
{
    public interface IBase<T>
    {
        Task<List<T>> GetAsync();

        Task<T> GetByIdAsync(int id);

        Task<int> PostAsync(T model);
         
        Task UpdateAsync(T updatedModel);

        Task DeleteAsync(T entity);

        bool Exists(int Id);
    }
}
