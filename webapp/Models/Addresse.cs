using System.ComponentModel.DataAnnotations;

namespace Models
{
    public class Addresse
    {
        /// <summary>
        /// The id of the Addresse
        /// </summary>
        /// <value></value>
        [Required]
        public int Id { get; set; }

        /// <summary>
        /// The Addresse
        /// </summary>
        /// <value></value>
        [Required]
        public string AddresseName { get; set; }
    }
}