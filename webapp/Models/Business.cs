using System;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using Models;
using System.Collections.Generic;

namespace Models
{
    public class Business
    {
        [Required]
        public int Id { get; set; }


        [Required(ErrorMessage = "Le nom de l'entreprise est requis.")]
        public string Name { get; set; }


        public Address Address { get; set; }


        [Required(ErrorMessage = "Le numéro de téléphone de l'entreprise est requis.")]
        [RegularExpression("^\\([0-9]{3}\\)\\s[0-9]{3}[-]{1}[0-9]{4}$", ErrorMessage = "Veuillez saisir le num�ro de t�l�phone dans le format suivant : (111) 222-3333")]
        public string Phone { get; set; }

        // foreign key //

        public ICollection<Event> Events { get; set; }
    }
}