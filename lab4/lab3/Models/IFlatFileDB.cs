using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.NetworkInformation;
using System.Threading.Tasks;
using System.Web;
using System.Web.Helpers;
using Newtonsoft.Json;


namespace lab3.Models
{
    public interface IFlatFileDB <T> where T : class
    {
        Task Save();
        Task<T> Add(T entry);
        Task<T> Get(int id);
        Task<IEnumerable<T>> GetAll();
        Task<T> Delete(int id);
        Task<T> Update(T entry);

        

    }
}