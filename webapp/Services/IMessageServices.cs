
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Models;

namespace Services
{
    public interface IMessageServices :  IDatabaseServices<Message>
    {
        
    }
}