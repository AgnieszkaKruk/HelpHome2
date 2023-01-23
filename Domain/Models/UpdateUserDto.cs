using System.ComponentModel.DataAnnotations;

namespace Domain.Models
{
    public class UpdateUserDto
    {
      
        [Required]
        [MaxLength(25)]
        public string Name { get; set; }
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        [Phone]
        public string PhoneNumber { get; set; }

      //  public string City { get; set; }
      //  public string Street { get; set; }
      //  public string PostalCode { get; set; }
    }
}
