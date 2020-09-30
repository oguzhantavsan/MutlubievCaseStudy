using System;

namespace MutlubievAPI.Models
{
    public class Province
    {
        public Province(Guid id, string provinceName, DateTime creationTime, DateTime modificationTime)
        {
            this.Id = id;
            this.ProvinceName = provinceName;
            this.CreationTime = creationTime;
            this.ModificationTime = modificationTime;
        }
        public Guid Id { get; set; }
        public string ProvinceName { get; set; }
        public DateTime CreationTime { get; set; }
        public DateTime ModificationTime { get; set; }
    }
}