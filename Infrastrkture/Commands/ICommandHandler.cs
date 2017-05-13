using System.Threading.Tasks;

namespace Infrastrkture.Commands
{
    interface ICommandHandler<T> where T : ICommand
    {
        Task Handle(T command);
    }
}
