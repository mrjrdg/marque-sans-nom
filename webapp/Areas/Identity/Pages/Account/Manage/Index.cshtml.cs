using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Models;

namespace webapp.Areas.Identity.Pages.Account.Manage
{
    public partial class IndexModel : PageModel
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        public AppDbContext _context;

        public IndexModel(
            UserManager<ApplicationUser> userManager,
            SignInManager<ApplicationUser> signInManager, AppDbContext context)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _context = context;
        }

        public string Username { get; set; }

        [TempData]
        public string StatusMessage { get; set; }

        [BindProperty]
        public InputModel Input { get; set; }

        public class InputModel
        {
            [Phone]
            [Display(Name = "Numéro de téléphone")]
            public string PhoneNumber { get; set; }

            [Display(Name = "Prénom")]
            public string userFname { get; set; }

            [Display(Name = "Nom de famille")]
            public string userLname { get; set; }

            public string Descrption {get;set;}

            public string Ville {get;set;}


        }

        private async Task LoadAsync(ApplicationUser user)
        {
            var userName = await _userManager.GetEmailAsync(user);
            var phoneNumber = await _userManager.GetPhoneNumberAsync(user);
            var firstName = user.FirstName;
            var lastName = user.LastName;
            var description = user.Descrption;
            var ville = user.ville;

            Username = userName;

            Input = new InputModel
            {
                PhoneNumber = phoneNumber,
                userFname = firstName,
                userLname = lastName,
                Descrption = description,
                Ville = ville,


            };
        }

        public async Task<IActionResult> OnGetAsync()
        {
            var user = await _userManager.GetUserAsync(User);
            if (user == null)
            {
                return NotFound($"Unable to load user with ID '{_userManager.GetUserId(User)}'.");
            }

            await LoadAsync(user);
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            var user = await _userManager.GetUserAsync(User);
            if (user == null)
            {
                return NotFound($"Unable to load user with ID '{_userManager.GetUserId(User)}'.");
            }

            if (!ModelState.IsValid)
            {
                await LoadAsync(user);
                return Page();
            }

            var phoneNumber = await _userManager.GetPhoneNumberAsync(user);
            user.LastName = Input.userLname;
            user.FirstName = Input.userFname;
            user.Descrption = Input.Descrption;
            user.ville = Input.Ville;

            _context.Users.Update(user);

            await _userManager.UpdateAsync(user);
            await _context.SaveChangesAsync();
            if (Input.PhoneNumber != phoneNumber)
            {
                var setPhoneResult = await _userManager.SetPhoneNumberAsync(user, Input.PhoneNumber);



                if (!setPhoneResult.Succeeded)
                {
                    var userId = await _userManager.GetUserIdAsync(user);
                    throw new InvalidOperationException($"Erreur lors de l'enregistrement du téléphone de l'utilisateur '{userId}'.");
                }
            }

            await _signInManager.RefreshSignInAsync(user);
            StatusMessage = "Votre profil a été mis à jour";
            return RedirectToPage();
        }
    }
}
