using System.Threading.Tasks;
using Models;
using Services;

namespace Services
{
    public interface IAvatarServices : IDatabaseServices<Avatar>
    {
        Task<Avatar> Get(string id);
    }
}