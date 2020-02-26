using System.ComponentModel.DataAnnotations;

namespace ViewModels {
	public class LoginViewModel {
			[Display(Name = "Courriel")]
        	[Required]
        	[EmailAddress]
        	public string Email {get; set;}

			[Display(Name = "Mot de passe")]
        	[Required]
        	[DataType(DataType.Password)]
        	public string Password {get; set;}

        	[Display(Name = "Rester connecté")]
        	public bool RememberMe {get; set;}
	}

}
