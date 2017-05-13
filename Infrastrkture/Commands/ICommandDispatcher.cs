using System.Threading.Tasks;

namespace Infrastrkture.Commands
{
    public interface ICommandDispatcher
    {
        Task Dispatch<T>(T command) where T : ICommand;
    }
}
