using System;
using System.Collections.Generic;
using System.Text;
using Modules.Coaches.Domain;
namespace Modules.Coaches.Application.Commands.CreateCoaches
{
    public class DeleteCoachesCommandHandler
    {
        private readonly ICoachesRepository _repository;

        public DeleteCoachesCommandHandler(ICoachesRepository repository)
        {
            _repository = repository;
        }

        public async Task HandleAsync(DeleteCoachesCommand command)
        {
            await _repository.DeleteAsync(command.Id);
        }
    }
}
