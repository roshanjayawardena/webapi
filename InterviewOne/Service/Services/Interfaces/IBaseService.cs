using Common.HelperMethods;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Service.Services.Interfaces
{
    public interface IBaseService<T>
    {

        #region read
        Task<PageList<T>> Read(int skip, int take, string searchTerm);
        Task<T> Read(int request);
        Task<List<KeyValuePair<int, string>>> ReadKeyValue(Search request);
        #endregion
        Task Delete(int request);
        Task Create(T request);
        Task Update(T request);



    }
}
