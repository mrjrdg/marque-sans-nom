using System.ComponentModel.DataAnnotations;

namespace ViewModels {
    public class LoginViewModel {

        [Display(Name = "Courriel")]
        [Required(ErrorMessage = "Le courriel est requis.")]
        [EmailAddress(ErrorMessage = "Veuillez saisir une adresse courriel valide.")]
        public string Email {get; set;}


		[Display(Name = "Mot de passe")]
        [Required(ErrorMessage = "Le mot de passe est requis.")]
        [DataType(DataType.Password)]
        public string Password {get; set;}


        [Display(Name = "Rester connecté")]
        public bool RememberMe {get; set;}
	}

}
