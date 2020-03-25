using System.Threading.Tasks;
using TravelHelper.Infrastructure.Commands;
using TravelHelper.Infrastructure.Commands.Users;

namespace TravelHelper.Infrastructure.Handlers.Users
{
    public class ChangeUserPasswordHandler : ICommandHandler <ChangeUserPassword>
    {
        public async Task HandleAsync(ChangeUserPassword command)
        {
            await Task.CompletedTask;
        }
    }
}