using System;

namespace MutlubievAPI.Models
{
    public class Service
    {
        public Service(string serviceName, string serviceDescription, DateTime creationTime, DateTime modificationTime)
        {
            this.ServiceName = serviceName;
            this.ServiceDescription = serviceDescription;
            this.CreationTime = creationTime;
            this.ModificationTime = modificationTime;
        }
        public Guid Id { get; set; }
        public string ServiceName { get; set; }
        public string ServiceDescription { get; set; }
        public DateTime CreationTime { get; set; }
        public DateTime ModificationTime { get; set; }
    }
}