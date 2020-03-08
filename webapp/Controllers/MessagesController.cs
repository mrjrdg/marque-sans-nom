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


namespace Controllers
{
    public class MessagesController : Controller
    {
        private readonly ILogger<MessagesController> _logger;
        private readonly IMessageConversationServices _messageConversationsServices;
        private readonly IMessageServices _messagesServices;
        private readonly UserManager<ApplicationUser> _userManager;

        public MessagesController(ILogger<MessagesController> logger, IMessageServices messageServices, IMessageConversationServices messageConversationServices, UserManager<ApplicationUser> userManager)
        {
            _logger = logger;
            _messagesServices = messageServices;
            _messageConversationsServices = messageConversationServices;
            _userManager = userManager;
        }

        public async Task<IActionResult> Index()
        {
            var user = await _userManager.GetUserAsync(User);
            int count = 0;

            var conversations = await _messageConversationsServices
                .GetFromPredicate(x => x.SenderId == user.Id || x.ReceiverId == user.Id, x => x.Messages);

            foreach (var conversation in conversations)
            {
                test(conversation, ref count);
            }

            return View(conversations);
        }

        private void test(MessageConversation conversation , ref int count)
        {
            if (conversation != null)
            {
                foreach (var message in conversation.Messages)
                {
                    count++;
                    test(message.MessageConversation, ref count);
                }
            }

        }
    }
}