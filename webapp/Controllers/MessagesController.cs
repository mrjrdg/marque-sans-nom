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

        private readonly AppDbContext _context;

        public MessagesController(ILogger<MessagesController> logger, IMessageServices messageServices, 
        IMessageConversationServices messageConversationServices, UserManagerSQL userManager, AppDbContext context)
        {
            _logger = logger;
            _messagesServices = messageServices;
            _messageConversationsServices = messageConversationServices;
            _userManager = userManager;
            _context = context;
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

         public async Task<IActionResult> Create()
        {
            var user = await _userManager
                .GetUserAsync(User);

               

            var conversations = await _messageConversationsServices
                .GetAllMessageConversationsOfUser(user);

            var model = new CreateMessageView();
            model.listUser =  await _context.Users.ToListAsync();

            return View(model);
        }

         [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CreateMessageView newConversation)
        {
               var sender = await _userManager
                .GetUserAsync(User);

            var receiver = await _context.Users.FindAsync(newConversation.UserId);
            newConversation.messageConversation.Receiver = receiver;
            newConversation.messageConversation.ReceiverId = receiver.Id;
            newConversation.messageConversation.Sender = sender;
            newConversation.messageConversation.SenderId = sender.Id;

            var message = new Message();
            message.MessageConversationId = newConversation.messageConversation.Id;
            message.Content = newConversation.Message.Content;
            message.User= sender;

            



            return RedirectToAction(nameof(Index));
        }


    }
}