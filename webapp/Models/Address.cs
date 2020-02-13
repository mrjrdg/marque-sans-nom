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
        [RegularExpression("^[A-Za-z]*$", ErrorMessage = "")]
        public string Street { get; set; }

        /// <summary>
        /// The civic number of the address
        /// </summary>
        [Required]
        [RegularExpression("^[0-9]*$", ErrorMessage = "")]
        public int CivicNumber { get; set; }

        /// <summary>
        /// The city of the address
        /// </summary>
        [Required]
        [RegularExpression("^[A-Za-z]*$", ErrorMessage = "")]
        public string City { get; set; }

        /// <summary>
        /// The state of the address
        /// </summary>
        [Required]
        [RegularExpression("^[A-Za-z][A-Za-z]$", ErrorMessage = "")]
        public string State { get; set; }

        /// <summary>
        /// The postalcode of the address
        /// </summary>
        [Required]
        [RegularExpression("^[A-Za-z][0-9][A-Za-z]\\s*[0-9][A-Za-z][0-9]$", ErrorMessage = "")]
        [DisplayFormat()]
        public string PostalCode { get; set; }

        /// <summary>
        /// The country of the address
        /// </summary>
        [Required]
        [RegularExpression("^[A-Za-z]*$", ErrorMessage = "")]
        public string Country { get; set; }

        /// <summary>
        ///     The appartment number
        /// </summary>
        [RegularExpression("^[0-9]*$", ErrorMessage = "")]
        public int? AppartmentNumber { get; set; }


        /// <summary>
        ///     Return the value of the Name property that is the address as a string.
        /// </summary>
        /// <returns>The address as a string</returns>
        public override string ToString()
        {
            return $"{CivicNumber} {Street} {City}, {State} {Country}";
        }
    }
}