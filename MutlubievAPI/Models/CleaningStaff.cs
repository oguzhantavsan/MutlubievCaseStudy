using System;

namespace MutlubievAPI.Models
{
    public class CleaningStaff
    {
        public CleaningStaff(string staffName, string phoneNumber, string province, string district, string gender, bool personalDPTApproval, bool isActiveStaff, DateTime creationTime, DateTime modificationTime)
        {
            this.StaffName = staffName;
            this.PhoneNumber = phoneNumber;
            this.Province = province;
            this.District = district;
            this.Gender = gender;
            this.PersonalDPTApproval = personalDPTApproval;
            this.IsActiveStaff = isActiveStaff;
            this.CreationTime = creationTime;
            this.ModificationTime = modificationTime;
        }
        public Guid Id { get; set; }
        public string StaffName { get; set; }
        public string PhoneNumber { get; set; }
        public string Province { get; set; }
        public string District { get; set; }
        public string Gender { get; set; }
        public bool PersonalDPTApproval { get; set; }
        public bool IsActiveStaff { get; set; }
        public DateTime CreationTime { get; set; }
        public DateTime ModificationTime { get; set; }
    }
}