using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ViewModels
{
    public class EditRoleViewModel
    {
        public string Id { get; set; }

        [Display(Name = "Nom du rôle")]
        [Required(ErrorMessage = "Le nom du rôle est requis.")]
        [RegularExpression("^.{1,16}$", ErrorMessage = "Veuillez saisir un maximum de 16 caractères dans le nom du rôle.")]
        public string RoleName { get; set; }

        [Display(Name = "Utilisateurs associés au rôle")]
        public List<string> Users { get; set; }


        public EditRoleViewModel()
        {
            Users = new List<string>();
        }
    }
}
