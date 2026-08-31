using Modules.Stuff.Application.Commands.CreateStuff;
using Modules.Stuff.Domain;
using System;
using System.Threading.Tasks;

namespace Modules.Stuff.Application.Commands.UpdateStuff
{
    public class UpdateStuffCommandHandler
    {
        private readonly IStuffRepository _repository;

        public UpdateStuffCommandHandler(IStuffRepository repository)
        {
            _repository = repository;
        }

        public async Task HandleAsync(UpdateStuffCommand command)
        {
            var stuff = await _repository.GetByIdAsync(command.Id);

            if (stuff != null)
            {
                stuff.UpdateDetails(command.Name, command.Code, command.Price, command.Description);

                await _repository.UpdateAsync(stuff);
            }
        }
    }
}