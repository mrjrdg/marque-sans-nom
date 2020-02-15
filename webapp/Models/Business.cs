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
        [Required]
        public string Name { get; set; }
        public Address Address { get; set; }
        [Required]
        public string Phone { get; set; }

        // foreign key //

        public ICollection<Event> Events { get; set; }
    }
}