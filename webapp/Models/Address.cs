using System.ComponentModel.DataAnnotations;

namespace Models
{
    public class Address
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
        public string Name { get; set; }


        /// <summary>
        ///     Return the value of the Name property that is the address as a string.
        /// </summary>
        /// <returns>The address as a string</returns>
        public override string ToString()
        {
            return Name;
        }
    }
}