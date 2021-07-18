using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Smart_ChargingApi.Interfaces
{
    public interface IBase<T>
    {
        Task<List<T>> Get();

        Task<T> GetById(int id);

        Task Post(T model);
         
        Task Update(T updatedModel);

        Task Delete(T entity);

        bool Exists(int Id);
    }
}
