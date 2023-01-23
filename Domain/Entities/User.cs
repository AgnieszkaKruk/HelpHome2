using HH2.Utils;

namespace HH2.Entities
{
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string PasswordHash { get; set; }

       

        public virtual List<Offer> Offers { get; set; }
        

        public int RoleId { get; set; }
        public virtual Role Role { get; set; }
    }
}
