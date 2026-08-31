using System;
using System.Threading;
using System.Threading.Tasks;
using Modules.Stuff.Domain;

namespace Modules.Stuff.Application.Commands.CreateStuff
{
    public class CreateStuffCommandHandler
    {
        private readonly IStuffRepository _stuffRepository;

        public CreateStuffCommandHandler(IStuffRepository stuffRepository)
        {
            _stuffRepository = stuffRepository;
        }

        public async Task HandleAsync(CreateStuffCommand command)
        {
            var stuff = new StuffItem(Guid.NewGuid(), command.Name, command.Code, command.Price, command.Description);

            await _stuffRepository.AddAsync(stuff);
        }
    }
}