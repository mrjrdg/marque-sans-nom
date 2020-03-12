using System.ComponentModel.DataAnnotations;
using Models;
using System.Collections.Generic;



namespace ViewModels
{

    public class CreateBusinessView{
        public Business business { get; set; }

      public Address address {get ; set;}

           public CreateBusinessView()
   {
       business = new Business();
   }
    }
}