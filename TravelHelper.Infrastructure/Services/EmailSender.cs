using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;

namespace TravelHelper.Infrastructure.Services
{
    public class EmailSender :IEmailSender
    {
        
    public async Task <string> SendActivateEmail(string email, string value)
        {
            SmtpClient client = new SmtpClient("poczta.int.pl",587);
            client.UseDefaultCredentials = false;
            client.Credentials = new NetworkCredential("noreplay@travelhelper.int.pl", "");
            var message = new MailMessage();
            message.From = new MailAddress("Travel Helper <noreplay@travelhelper.int.pl>");
            message.To.Add(new MailAddress(email));
            var link = "https://localhost:5001/users/activate/"+ value ;
            message.Body = "Click on the link to activate account "+link;
            message.Subject = "Travel Helper activate account" ;
            client.Send(message);
            return("true");
        }
    }
}