using System;
using System.Collections.Generic;
using System.Text;
using Modules.Coaches.Domain;
namespace Modules.Coaches.Application.Commands.CreateCoaches
{
    public class CreateCoachesCommandHandler
    {
        private readonly ICoachesRepository _coachesRepository;

        public CreateCoachesCommandHandler(ICoachesRepository coachesRepository)
        {
            _coachesRepository = coachesRepository;
        }

        public async Task HandleAsync(CreateCoachesCommand command)
        {
            var coaches = new CoachesItem(Guid.NewGuid(), command.Ime, command.Prezime, command.Licenca, command.OpisLicence, command.Ekipa);

            await _coachesRepository.AddAsync(coaches);
        }
    }
}
