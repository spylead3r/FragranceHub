using Microsoft.AspNetCore.Identity;
using PetPals.Common;


using System.ComponentModel.DataAnnotations;

namespace PetPals.Data.Models
{
    using static EntityValidationConstants.ApplicationUser;
    public class ApplicationUser : IdentityUser<Guid> 
    {

        public ApplicationUser() 
        {
            this.Id = Guid.NewGuid();
        }

        [Required]
        [StringLength(FirstNameMaxLength)] 
        public string FirstName { get; set; }

        [Required]
        [StringLength(LastNameMaxLength)]
        public string LastName { get; set; }

        [StringLength(AddressMaxLength)] 
        public string Address { get; set; } 

        [StringLength(PhoneNumberMaxLength)] 
        public override string PhoneNumber { get; set; } 

     
    }
}
