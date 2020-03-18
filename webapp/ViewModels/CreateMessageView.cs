using System.ComponentModel.DataAnnotations;
using Models;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc.Rendering;





namespace ViewModels
{

    public class CreateMessageView{
        public MessageConversation messageConversation {get;set;}

    public int UserId {get;set;}
        public Message Message {get;set;}

         public ApplicationUser oneUser { get; set; }

        public List<ApplicationUser> listUser;

          public IEnumerable<SelectListItem> allUsers
    {
        get { return new SelectList(listUser, "Id", "FirstName");}
    }
        

           public CreateMessageView()
   {
       messageConversation = new MessageConversation();
   }
    }
}