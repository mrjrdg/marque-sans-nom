using System;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using Models;
using System.Collections.Generic;

namespace Models
{
    public class Message
    {
        [Required]
        public int Id { get; set; }
        [Required]
        public string Content {get; set;}
        [Required]
        public ApplicationUser User { get; set; }
        public MessageConversation MessageConversation { get; set; }
    }
}