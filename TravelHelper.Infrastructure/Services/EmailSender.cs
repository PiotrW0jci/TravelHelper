using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;

namespace TravelHelper.Infrastructure.Services
{
    public class EmailSender :IEmailSender
    {
        
    public async Task <string> SendActivateEmail(string email, string value)
        {
            SmtpClient client = new SmtpClient("smtp.poczta.onet.pl",587);
            client.UseDefaultCredentials = false;
            client.Credentials = new NetworkCredential("travelhelper@adres.pl", "zaq1@WSX");
            var message = new MailMessage();
            message.To.Add(new MailAddress(email));
            message.From = new MailAddress("Travel Helper <travelhelper@adres.pl>");
            var link = "https://localhost:5001/users/activate/"+ value ;
             message.Body = "Click on the link to activate account "+link;
            message.Subject = "Travel Helper activate account" ;
            client.Send(message);
            return("true");
        }
    }
}