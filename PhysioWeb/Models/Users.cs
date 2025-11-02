namespace PhysioWeb.Models
{
    public class Users:CommanProp
    {
        public int UserId { get; set; }
        public string UserSerialNo { get; set; } = null;
        public string UserName { get; set; }

        public string EmailId { get; set; }
        public string Password { get; set; }
        public string UserRole { get; set; }
        public bool IsActive { get; set; }

    }
}
