   namespace FragranceHub.Web.ViewModels.User
{
    using static FragranceHub.Common.EntityValidationConstants.User;

    using System.ComponentModel.DataAnnotations;
    public class RegisterFormModel
    {
        [Required]
        [EmailAddress]

        public string Email { get; set; } = null!;

        [Required]
        [StringLength(PasswordMaxLength, MinimumLength = PasswordMinLength, 
            ErrorMessage = "The {0} must be at least {2} characters long.")]
        [DataType(DataType.Password)]
        public string Password { get; set; } = null!;

        [DataType(DataType.Password)]
        [Display(Name = "Confirm password")]
        [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
        public string ConfirmPassword { get; set; } = null!;

        [Required]
        [StringLength(FirstNameMaxLength, MinimumLength = FirstNameMinLength)]
        public string FirstName { get; set; } = null!;

        [Required]
        [StringLength(LastNameMaxLength, MinimumLength = LastNameMinLength)]
        public string LastName { get; set; } = null!;

    }
}
