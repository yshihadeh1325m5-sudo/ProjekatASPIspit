using System;
using System.Collections.Generic;
using System.Text;
using Modules.Coaches.Domain;

namespace Modules.Coaches.Application.Commands.UpdateCoaches
{
   
    public class UpdateCoachesCommandHandler
    {
        private readonly ICoachesRepository _repository;

        public UpdateCoachesCommandHandler(ICoachesRepository repository)
        {
            _repository = repository;
        }

        public async Task HandleAsync(UpdateCoachesCommand command)
        {
            var coach = await _repository.GetByIdAsync(command.Id);

            if (coach != null)
            {
                coach.UpdateDetails(command.Ime, command.Prezime, command.Licenca, command.OpisLicence, command.Ekipa);

                await _repository.UpdateAsync(coach);
            }
        }
    }
}
