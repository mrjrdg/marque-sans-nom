using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

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
        /// The Street
        /// </summary>
        /// <value></value>
        [Display(Name = "Rue")]
        [Required(ErrorMessage ="Le nom de la rue est requis.")]
        [RegularExpression("^[A-Za-z0-9_ ]+", ErrorMessage = "Veuillez saisir seulement des chiffres et des lettres dans le nom de la rue.")]
        public string Street { get; set; }

        /// <summary>
        /// The civic number of the address
        /// </summary>
        [Display(Name = "Numéro civique")]
        [Required(ErrorMessage = "Le numéro civique est requis.")]
        [RegularExpression("^[0-9]+$", ErrorMessage = "Veuillez saisir seulement des chiffres dans le numéro civique.")]
        public int CivicNumber { get; set; }

        /// <summary>
        /// The city of the address
        /// </summary>
        [Display(Name = "Ville")]
        [Required(ErrorMessage = "La ville est requise.")]
        [RegularExpression("^[A-Za-z]+$", ErrorMessage = "Veuillez saisir seulement des lettres dans le nom de la ville.")]
        public string City { get; set; }

        /// <summary>
        /// The state of the address
        /// </summary>
        [Display(Name = "Province")]
        [Required(ErrorMessage = "La province est requise.")]
        [RegularExpression("^[A-Za-z]+$", ErrorMessage = "Veuillez saisir seulement des lettres dans le nom de la province.")]
        public string State { get; set; }

        /// <summary>
        /// The postalcode of the address
        /// </summary>
        [Display(Name = "Code postal")]
        [Required(ErrorMessage = "Le code postal est requis.")]
        [RegularExpression("^[A-Za-z][0-9][A-Za-z]\\s*[0-9][A-Za-z][0-9]$", ErrorMessage = "Veuillez saisir un code postal valide.")]
        [DisplayFormat()]
        public string PostalCode { get; set; }

        /// <summary>
        /// The country of the address
        /// </summary>
        [Display(Name = "Pays")]
        [Required(ErrorMessage = "Le pays est requis.")]
        [RegularExpression("^[A-Za-z]+$", ErrorMessage = "Veuillez saisir seulement des lettres dans le nom du pays.")]
        public string Country { get; set; }

        /// <summary>
        ///     The appartment number
        /// </summary>
        [Display(Name = "Appartement")]
        [RegularExpression("^[0-9]*$", ErrorMessage = "Veuillez saisir seulement des chiffres dans le num�ro de l'appartement.")]
        public int? AppartmentNumber { get; set; }

        // FOREIGN KEY //

        /// <summary>
        /// will contain all the reference to the associated business
        /// </summary>
        public List<Business> Businesses { get; set; }


        /// <summary>
        /// will contain all the reference to the associated Events
        /// </summary>
        public List<Event> Events { get; set; }


        /// <summary>
        ///     Return the value of the Name property that is the address as a string.
        /// </summary>
        /// <returns>The address as a string</returns>
        public override string ToString()
        {
            return $"{CivicNumber}, {Street} - {City} {State}  {PostalCode} - {Country}";
        }

        [NotMapped]
        public string fullAddress
        {
            get { return $"{CivicNumber}, {Street} - {City} {State}  {PostalCode} - {Country}"; }

        }

    }
}