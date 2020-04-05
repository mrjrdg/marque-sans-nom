using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Models
{
    public class Event
    {
        /// <summary>
        ///     The event Id
        /// </summary>
        /// <value></value>
        [Required]
        public int Id { get; set; }

        /// <summary>
        /// The title of the event
        /// </summary>
        /// <value></value>
        [Display(Name ="Titre")]
        [Required(ErrorMessage = "Le titre de l'�v�nement est requis.")]
        [RegularExpression("^.{1,64}$", ErrorMessage = "Veuillez saisir un maximum de 64 caract�res dans le titre de l'�v�nement.")]
        public string Title { get; set; }

        /// <summary>
        /// The start date of the event
        /// </summary>
        /// <value></value>
        [Display(Name = "Date et heure de d�but")]
        [Required(ErrorMessage = "La date et l'heure de d�but sont requis.")]
        public DateTime StartDate { get; set; }


        /// <summary>
        /// The end date of the event
        /// </summary>
        /// <value></value>
        [Display(Name = "Date et heure de fin")]
        /// [Required(ErrorMessage = "La date et l'heure de fin sont requis.")]
        public DateTime EndDate { get; set; }

        /// <summary>
        ///     The enterprise hosting the event
        /// </summary>
        /// <value></value>
        [Display(Name = "Entreprise")]
        public Business Business { get; set; }


        /// <summary>
        ///     The address of the event
        /// </summary>
        /// <value></value>
        [Display(Name = "Adresse")]
        public Address Address { get; set; }

        /// <summary>
        ///     The price per participation
        /// </summary>
        /// <value></value>
        [Display(Name = "Co�t")]
        [Required(ErrorMessage = "Le prix de participation est requis. Veuillez saisir 0.00 si l'�v�nement est gratuit.")]
        [RegularExpression("^[0-9]{1,4}[.][0-9]{2}$", ErrorMessage = "Veuillez saisir le prix � payer dans ce format : 12.34. SVP saisir 0.00 si l'�v�nement est gratuit.")]
        public double PriceToPayToParticipate { get; set; }

        // FOREIGN KEY ONE TO MANY //

        /// <summary>
        ///     The type of the event
        /// </summary>
        /// <value></value>
        [Display(Name = "Cat�gorie")]
        public EventType EventType { get; set; }
        
        /// <summary>
        ///     The owner ApplicationUser of this event
        /// </summary>
        /// <value></value>
        public ApplicationUser ApplicationUser { get; set; }

        // FOREIGN KEY MANY TO MANY //

        /// <summary>
        ///     List all the ApplicationUsers participating at this event
        /// </summary>
        /// <value></value>
        public List<EventApplicationUser> Members { get; set; }
    }
}