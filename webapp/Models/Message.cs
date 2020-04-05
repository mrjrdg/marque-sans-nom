using System.ComponentModel.DataAnnotations.Schema;
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
        [Required]
        public int MessageConversationId { get; set; }
        [ForeignKey("MessageConversationId")]
        public MessageConversation MessageConversation { get; set; }


        [NotMapped]
        public string ReceiverName
        { 
            get 
            {
                return MessageConversation.Sender.Id == User.Id ? 
                    MessageConversation.Receiver.FullName : 
                    MessageConversation.Sender.FullName; 
            }
        }
    }
}