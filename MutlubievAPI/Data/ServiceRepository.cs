using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using MutlubievAPI.Models;
using System.Linq;

namespace MutlubievAPI.Data
{
    public class ServiceRepository : IServiceRepository
    {
        private readonly DataContext _context;

        public ServiceRepository(DataContext context)
        {
            _context = context;
        }

        public async Task<List<Service>> GetAllServices()
        {
            bool checkSave = true;
            var services = from m in _context.Services select m.ServiceName;
            //if database is empty
            if(services.Count() == 0)
            {
                if(!await SaveAllServices())
                {
                    checkSave = false;
                }
            }
            //if saving services in database not completed
            if(checkSave == false)
            {
                return null;
            }
            //update services if there is a change
            var lastServices = from m in _context.Services select m;
            // add all services to list
            return lastServices.ToList();           
        }

        public async Task<bool> SaveAllServices()
        {
            int count = 0;
            string service = "", description = "";
            string[] services = File.ReadAllLines(@"Data\Services.txt");
            //if reading not successful
            if(services == null)
            {
                return false;
            }

            foreach(string line in services)
            {
                count++;
                //to understand service name and its' description because in txt file, I put services at odd lines, their descriptions at even lines
                if(count % 2 != 0)//odd
                {
                    service = line;
                }
                else if(count % 2 == 0)//even
                {
                    description = line;
                    Service serviceProp = new Service(service, description, DateTime.UtcNow, DateTime.UtcNow);
                    await _context.Services.AddAsync(serviceProp);
                }
            }
            
            await _context.SaveChangesAsync();
            return true;
        }
    }
}