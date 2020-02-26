using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;


namespace ViewModels
{
    public class RegisterViewModel
    {
        [Required]
        [Display(Name = "Prénom")]
        public string FirstName { get; set; }

        [Required]
        [Display(Name = "Nom de famille")]
        public string LastName { get; set; }

        [Required]
        [Display(Name = "Courriel")]
        [EmailAddress]
        [Remote(action: "IsEmailInUse", controller: "Account")]
        public string Email { get; set; }

        [Required]
        [Display(Name = "Mot de passe")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirmer son mot de passe")]
        [Compare("Password",
            ErrorMessage = "Les deux mots de passe ne correspondent pas")]
        public string ConfirmPassword { get; set; }
    }
}
