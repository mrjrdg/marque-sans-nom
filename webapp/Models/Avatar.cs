using System.ComponentModel.DataAnnotations;
using Models;

namespace Models
{
    public class Avatar
    {
        public ApplicationUser ApplicationUser { get; set; }
        [Key]
        public string ApplicationUserId { get; set; }
        [Required]
        public string Name { get; set; }
    }
}