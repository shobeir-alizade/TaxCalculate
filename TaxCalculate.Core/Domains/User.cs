using TaxCalculate.Core.BaseClass;
using System;
using System.ComponentModel.DataAnnotations;

namespace TaxCalculate.Core.Domains
{
    public class User : BaseEntity
    {
        [Required, MaxLength(32)]
        public string UserName { get; set; }
        public string FullName
        {
            get => FirstName + " " + LastName;
        }
        [Required, MaxLength(128)]
        public string Password { get; set; }
        [Required, MaxLength(64)]
        public string PasswordSalt { get; set; }
        [Required, MaxLength(64)]
        public string FirstName { get; set; }
        [Required, MaxLength(64)]
        public string LastName { get; set; }
        public bool IsActive { get; set; }
    }
}