using System;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using Models;
using System.Collections.Generic;

namespace Models
{
    public class Entreprise
    {
        [Required]
        public int Id { get; set; }
        [Required]
        public string EntrepriseName { get; set; }
        [Required]
        public Address Address { get; set; }
        [Required]
        public string EntreprisePhone { get; set; }

        // foreign key //

        public ICollection<Event> Events { get; set; }
    }
}