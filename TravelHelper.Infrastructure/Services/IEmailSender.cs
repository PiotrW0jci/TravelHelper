using System.Threading.Tasks;

namespace TravelHelper.Infrastructure.Services
{
    public interface IEmailSender
    {

         Task<string> SendActivateEmail(string email,string value);
    }
}