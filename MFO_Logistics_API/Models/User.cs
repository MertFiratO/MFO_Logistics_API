namespace MFO_Logistics_API.Models
{
    public class User
    {
        public int UserID { get; set; }

        public string UserName { get; set; }
        public string UserSurname { get; set; }
        public string UserLogin { get; set; }
        public string UserPassword { get; set; }
        public bool IsAdmin { get; set; }
        public int IsActive { get; set; }

    }
}
