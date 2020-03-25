using System.Threading.Tasks;

namespace TravelHelper.Infrastructure.Commands
{
    public interface ICommandHandler<T> where T : ICommand
    {
         Task HandleAsync(T command);
    }
}