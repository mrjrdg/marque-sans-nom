using System.ComponentModel.DataAnnotations;

namespace ViewModels
{
    public class CreateRoleViewModel
    {
        [Display(Name = "Nom du rôle")]
        [Required(ErrorMessage = "Le nom du rôle est requis.")]
        [RegularExpression("^.{1,16}$", ErrorMessage = "Veuillez saisir un maximum de 16 caractères dans le nom du rôle.")]
        public string RoleName { get; set; }
    }
}
