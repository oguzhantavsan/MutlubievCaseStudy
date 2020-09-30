using System;
using System.Threading.Tasks;
using MutlubievAPI.Dtos;
using MutlubievAPI.Models;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using System.IO;
using System.Collections.Generic;

namespace MutlubievAPI.Data
{
    public class StaffRepository : IStaffRepository
    {
        private readonly DataContext _context;

        public StaffRepository(DataContext context)
        {
            _context = context;
        }

        public async Task<List<CleaningStaff>> GetAllCleaningStaff()
        {
            //to get all staffs
            var staffs = from s in _context.CleaningStaffs select s;
            //if there is not any staff
            if(staffs.Count() == 0)
            {
                return null;
            }

            return staffs.ToList();
        }
        // TODO (Oğuzhan) : I couldn't check if there is a same cleaning staff registration in the database because there is not any unique information
        public async Task<bool> RegisterCleaningStaff(CleaningStaffDto cleaningStaffDto)
        {
            bool isExistProvinceAndDistrict = false;
            //to save provinces and districts at the beginning of the program
            if (await SaveProvinceAndDistrict())
            {
                //is there any province with given province name in the database
                var province = await _context.Provinces.FirstOrDefaultAsync(x => x.ProvinceName == cleaningStaffDto.Province);
                if (province != null)
                {
                    // is there any district with related provinceId and given district name
                    var district = from n in _context.Districts where n.ProvinceId == province.Id && n.DistrictName == cleaningStaffDto.District select n;
                    if (district.Count() != 0)
                    {
                        isExistProvinceAndDistrict = true;
                    }
                    else
                    {
                        return false;
                    }
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
            //if there are a province and district with given names
            if (isExistProvinceAndDistrict == true)
            {
                //creating cleaning staff with given informations for the database
                var Staff = new CleaningStaff(cleaningStaffDto.StaffName, cleaningStaffDto.PhoneNumber, cleaningStaffDto.Province, cleaningStaffDto.District, cleaningStaffDto.Gender,
                cleaningStaffDto.PersonalDPTApproval, false, DateTime.UtcNow, DateTime.UtcNow);
                await _context.CleaningStaffs.AddAsync(Staff);
            }

            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> SaveProvinceAndDistrict()
        {
            var isAlreadySaved = from x in _context.Provinces select x;
            //if Saving Provinces and District is not done
            if (isAlreadySaved.Count() == 0)
            {
                string province = "", district = "";
                string checkForProvince = "";
                Guid g = Guid.NewGuid();
                string[] lines = File.ReadAllLines(@"Data\Provinces.txt");
                //reading txt is not successful
                if (lines == null)
                {
                    return false;
                }
                //the character * determines that after this line province comes
                foreach (string line in lines)
                {
                    //if line is *, I saves this line for the next line to check previous line is *
                    if (line == "*")
                    {
                        checkForProvince = line;
                    }
                    else if (checkForProvince == "*")//if previous line is *, then this line is province
                    {
                        //I assign guid Id manually to use for districts as a foreign key
                        //after saving province, I reset checkforprovince as "" to prevent any confusion
                        g = Guid.NewGuid();
                        province = line;
                        var dbProvince = new Province(g, province, DateTime.UtcNow, DateTime.UtcNow);
                        await _context.Provinces.AddAsync(dbProvince);
                        checkForProvince = "";
                    }
                    else // if this line is not "*" and previous line is not "*", this line have to be district
                    {
                        district = line;
                        var dbDistrict = new District(g, district, DateTime.UtcNow, DateTime.UtcNow);
                        await _context.Districts.AddAsync(dbDistrict);
                    }
                }

                await _context.SaveChangesAsync();
            }

            return true;
        }
    }
}