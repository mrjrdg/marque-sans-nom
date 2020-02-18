using System.ComponentModel.DataAnnotations;

namespace ViewModels
{
    public class CreateRoleViewModel
    {
        [Required]
        public string RoleName { get; set; }
    }
}
