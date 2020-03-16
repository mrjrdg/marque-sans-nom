
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Models;

namespace Services
{
    public interface IMessageConversationServices :  IDatabaseServices<MessageConversation>
    {
        Task<List<MessageConversation>> GetAllMessageConversationsOfUser(IdentityUser user);
    }
}