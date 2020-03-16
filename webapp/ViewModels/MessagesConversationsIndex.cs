using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Identity;
using Models;

namespace ViewModels
{
    public class MessagesConversationsIndex
    {
        public MessageConversation[] ConversationsSent { get; private set; }
        public MessageConversation[] ConversationsReceived { get; private set; }
        public Message[] MessagesSent 
        { 
            get
            {
                return _messagesSent.ToArray();
            } 
        }
        public Message[] MessagesReceived
        { 
            get
            {
                return _messagesReceived.ToArray();
            } 
        }

        private List<Message> _messagesSent;
        private List<Message> _messagesReceived;

        public MessagesConversationsIndex(List<MessageConversation> conversations, string userId)
        {

            ConversationsSent = conversations
                .Where(x => x.SenderId == userId)
                .ToArray();

            ConversationsReceived = conversations
                .Where(x => x.SenderId != userId)
                .ToArray();

            _messagesSent =
                new List<Message>();

            _messagesReceived =
                new List<Message>();
                
            FetchAllMessages(userId, ConversationsSent);
            FetchAllMessages(userId, ConversationsReceived);

        }

        private void FetchAllMessages(string userId, MessageConversation[] conversations)
        {
            foreach (var conversation in conversations)
            {
                foreach (var message in conversation.Messages)
                {
                    if (message.User.Id == userId)
                    {
                        _messagesSent.Add(message);
                    }
                    else
                    {
                        _messagesReceived.Add(message);
                    }
                }
            }
        }
    }
}