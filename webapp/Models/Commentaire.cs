using System.ComponentModel.DataAnnotations.Schema;
using System;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using Models;
using System.Collections.Generic;

namespace Models
{
    public class Commentaire
    {
        [Required]
        public int Id { get; set; }
        [Required]
        public string Content {get;set;}
        [Required]
        public ApplicationUser User { get; set; }
        
        public int EventId { get; set; }
        [ForeignKey("EventId")]
        public Event Event { get; set; }


       
    }
}