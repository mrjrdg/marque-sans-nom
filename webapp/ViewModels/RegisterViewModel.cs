using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;


namespace ViewModels
{
    public class RegisterViewModel
    {
        [Required(ErrorMessage = "Le prénom est requis.")]
        [RegularExpression("^[A-Za-z]{1,32}$", ErrorMessage = "Veuillez saisir un maximum de 32 lettres dans le prénom.")]
        [Display(Name = "Prénom")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Le nom de famille est requis.")]
        [RegularExpression("^[A-Za-z]{1,32}$", ErrorMessage = "Veuillez saisir un maximum de 32 lettres dans le nom.")]
        [Display(Name = "Nom de famille")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Le courriel est requis.")]
        [Display(Name = "Courriel")]
        [EmailAddress(ErrorMessage = "Veuillez saisir une adresse courriel valide.")]
        [Remote(action: "IsEmailInUse", controller: "Account")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Le mot de passe requis.")]
        [RegularExpression("^.{1,32}$", ErrorMessage = "Veuillez saisir un maximum de 32 caractères dans le mot de passe.")]
        [Display(Name = "Mot de passe")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirmer le mot de passe")]
        [Compare("Password", ErrorMessage = "Les deux mots de passe ne correspondent pas.")]
        public string ConfirmPassword { get; set; }

        [RegularExpression("^[A-Za-z]{1,32}$", ErrorMessage = "Veuillez saisir un maximum de 32 lettres dans la ville.")]
        [Display(Name = "Ville")]
        public string ville { get; set; }

        [RegularExpression("^.{1,1024}$", ErrorMessage = "Veuillez saisir un maximum de 1024 caractères.")]
        [Display(Name = "À propos de moi")]
        public string Descrption { get; set; }
    }
}