using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhoneDictionaryLib
{
    public interface IPhoneDictionary
    {
        Task Save();
        Task<PhoneEntry> Add(PhoneEntry entry);
        Task<PhoneEntry> Get(int id);
        Task<IEnumerable<PhoneEntry>> GetAll();
        Task<PhoneEntry> Delete(int id);
        Task<PhoneEntry> Update(PhoneEntry entry);
    }
}
