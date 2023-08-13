using System.ComponentModel.DataAnnotations;

namespace TaxCalculate.Model
{
    public class User
    {
        public int Id { get; set; }
        [Required, MaxLength(32)]
        public string UserName { get; set; }
        [Required, MaxLength(128)]
        public string Password { get; set; }
        [Required, MaxLength(64)]
        public string PasswordSalt { get; set; }
        [Required, MaxLength(64)]
        public string FirstName { get; set; }
        [Required, MaxLength(11)]
        public string PhoneNumber { get; set; }
        [Required, MaxLength(64)]
        public string LastName { get; set; }
        [Required, MaxLength(64)]
        public string Email { get; set; }
        public bool IsActive { get; set; }
    }
}
