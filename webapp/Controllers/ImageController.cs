using System.Reflection.Emit;
using System.Net;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Threading.Tasks;
using Managers;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Models;
using Services;
using ViewModels;
using Microsoft.AspNetCore.Hosting;
using System.IO;

namespace webapp.Controllers
{
    public class ImageController : Controller
    {
        private readonly IAvatarServices _avatarServices;
        private readonly UserManagerSQL _userManager;
         private readonly IWebHostEnvironment _env;

        public ImageController(IAvatarServices avatarServices, UserManagerSQL userManagerSQL, IWebHostEnvironment env)
        {
            _avatarServices = avatarServices;
            _userManager = userManagerSQL;
            _env = env;
        }

        [HttpGet]
        public async Task<ViewResult> TestImagePage()
        {
            var currentUser = await _userManager
                    .GetUserAsync(User);

            var avatar = await _avatarServices
                .Get(currentUser.Id);

            ViewBag.Avatar = avatar;

            return View("TestImages");
        }

        [HttpPost]
        public async Task<IActionResult> UploadAvatar(ImageViewModel model)
        {

            if (model.File.Length > 0)
            {
                // Generate a random file name
                var randomName = Path
                    .GetRandomFileName();

                if(!Directory.Exists($@"{_env.WebRootPath}\AvatarsImages"))
                {
                    Directory.CreateDirectory($@"{_env.WebRootPath}\AvatarsImages");
                }

                var startIndex = model.File.ContentType
                    .IndexOf("/");

                var extension = model.File.ContentType
                    .Substring(startIndex + 1);

                randomName += $".{extension}";

                // Combine the name of the folder (the folder in which the file are stored) with the filename
                var filePath = Path
                    .Combine(_env.WebRootPath, $@"AvatarsImages\{randomName}");

                // Get the current user
                var currentUser = await _userManager
                    .GetUserAsync(User);

                // Instanciate an avatar with the current user id and the filename
                var avatar =  new Avatar 
                { 
                    ApplicationUserId = currentUser.Id, 
                    Name = randomName
                };

                using (var stream = System.IO.File.Create(filePath))
                {
                    // Get the current avatar of the current user (To know if we create a new avatar or update the avatar of the current user)
                    var currentAvatar = await _avatarServices
                        .Get(currentUser.Id);

                    // If the user hasn't already an avatar -> Create(avatar) otherwise -> Edit(avatar)
                    Task createOrUpdateTask = currentAvatar == null ? 
                        _avatarServices.Create(avatar) : 
                        _avatarServices.Edit(avatar);

                    // Create a list of tasks for asynchronously store the file in the files structure and also inserting the filename into the database
                    var insertingTasks = new List<Task>
                    {
                        model.File.CopyToAsync(stream), // The task that will be copy the file into the application file structure
                        createOrUpdateTask              // The task that insert the filename into the Avatars table
                    };

                    // wait for all the task to finish
                    await Task.WhenAll(insertingTasks);
                }
            }

            return View("TestImagePage", new { Result = HttpStatusCode.OK });
        }
    }
}