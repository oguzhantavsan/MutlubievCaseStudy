using System;

namespace MutlubievAPI.Models
{
    public class District
    {
        public District(Guid provinceId, string districtName, DateTime creationTime, DateTime modificationTime)
        {
            this.ProvinceId = provinceId;
            this.DistrictName = districtName;
            this.CreationTime = creationTime;
            this.ModificationTime = modificationTime;
        }
        public Guid Id { get; set; }
        public Guid ProvinceId { get; set; }
        public virtual Province Province { get; set; }
        public string DistrictName { get; set; }
        public DateTime CreationTime { get; set; }
        public DateTime ModificationTime { get; set; }
    }
}