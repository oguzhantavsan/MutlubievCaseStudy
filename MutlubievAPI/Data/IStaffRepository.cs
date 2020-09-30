using System.Collections.Generic;
using System.Threading.Tasks;
using MutlubievAPI.Dtos;
using MutlubievAPI.Models;

namespace MutlubievAPI.Data
{
    public interface IStaffRepository
    {
        //to save staff information in the database
         Task<bool> RegisterCleaningStaff(CleaningStaffDto cleaningStaffDto);
         //Saving provinces and their districts with their provinceId to check whether districts is at related province.
         Task<bool> SaveProvinceAndDistrict();
         //To show all saved staff to you.
         Task<List<CleaningStaff>> GetAllCleaningStaff();
    }
}