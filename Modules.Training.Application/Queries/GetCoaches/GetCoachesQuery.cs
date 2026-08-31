using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Modules.Coaches.Domain;

namespace Modules.Coaches.Application.Queries.GetCoaches
{
    public class GetCoachesQuery();

    public class GetCoachesQueryHandler
    {
        private readonly ICoachesRepository _coachesRepository;

        public GetCoachesQueryHandler(ICoachesRepository coachesRepository)
        {
            _coachesRepository = coachesRepository;
        }

        public async Task<IEnumerable<CoachesDto>> HandleAsync(GetCoachesQuery query)
        {
            var coachesItems = await _coachesRepository.GetAllAsync();
            return coachesItems.Select(s => new CoachesDto(s.Id, s.Ime, s.Prezime, s.Licenca, s.OpisLicence, s.Ekipa));
        }
    }
}