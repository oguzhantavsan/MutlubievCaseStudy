using System.Collections.Generic;
using System.Threading.Tasks;
using MutlubievAPI.Models;

namespace MutlubievAPI.Data
{
    public interface IServiceRepository
    {
        //to get all services
         Task<List<Service>> GetAllServices();
        //To save all services and its' descriptions at the beginning of the program.
         Task<bool> SaveAllServices();         
    }
}