using System.Runtime.CompilerServices;
using System.Xml.Linq;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Models;
using Microsoft.EntityFrameworkCore;
using System.Web;
using Microsoft.AspNetCore.Mvc.Rendering;
using ViewModels;
using Services;
using Microsoft.AspNetCore.Identity;
using Managers;

namespace Controllers
{
    public class MessagesController : Controller
    {
        private readonly ILogger<MessagesController> _logger;
        private readonly IMessageConversationServices _messageConversationsServices;
        private readonly IMessageServices _messagesServices;
        private readonly UserManagerSQL _userManager;

        public MessagesController(ILogger<MessagesController> logger, IMessageServices messageServices, IMessageConversationServices messageConversationServices, UserManagerSQL userManager)
        {
            _logger = logger;
            _messagesServices = messageServices;
            _messageConversationsServices = messageConversationServices;
            _userManager = userManager;
        }

        public async Task<IActionResult> Index()
        {
            var user = await _userManager
                .GetUserAsync(User);

            var conversations = await _messageConversationsServices
                .GetAllMessageConversationsOfUser(user);

            var model = 
                new MessagesConversationsIndex(conversations, user.Id);

            return View(model);
        }
    }
}