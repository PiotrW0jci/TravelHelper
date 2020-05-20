using System.Threading.Tasks;
using TravelHelper.Infrastructure.Commands;
using TravelHelper.Infrastructure.Commands.Users;
using TravelHelper.Infrastructure.Services;

using Microsoft.Extensions.Caching.Memory;

using TravelHelper.Infrastructure.Extensions;


namespace TravelHelper.Infrastructure.Handlers.Users
{
    public class SendEmailHandler :ICommandHandler<SendEmail>
    {
    
        private readonly IEmailSender _emailService;
       
        public SendEmailHandler(IEmailSender emailService)
        {
        _emailService = emailService;   
        }
        public async Task HandleAsync(SendEmail command)
        {
            await _emailService.SendActivateEmail(command.Email,command.value);
        }

    }
}