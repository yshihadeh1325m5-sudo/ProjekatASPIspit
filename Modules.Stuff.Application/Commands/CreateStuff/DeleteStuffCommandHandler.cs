using System;
using System.Collections.Generic;
using System;
using System.Threading.Tasks;
using Modules.Stuff.Domain;

namespace Modules.Stuff.Application.Commands.CreateStuff
{
    public class DeleteStuffCommandHandler
    {
        private readonly IStuffRepository _repository;

        public DeleteStuffCommandHandler(IStuffRepository repository)
        {
            _repository = repository;
        }

        public async Task HandleAsync(DeleteStuffCommandcs command)
        {
            await _repository.DeleteAsync(command.Id);
        }
    }
}