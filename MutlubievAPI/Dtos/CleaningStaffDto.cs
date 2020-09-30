namespace MutlubievAPI.Dtos
{
    //I created dto for Cleaning Staff Registration
    public class CleaningStaffDto
    {
        public string StaffName { get; set; }
        public string PhoneNumber { get; set; }
        public string Province { get; set; }
        public string District { get; set; }
        public string Gender { get; set; }
        public bool PersonalDPTApproval { get; set; }//Protection of Personal Data 
    }
}