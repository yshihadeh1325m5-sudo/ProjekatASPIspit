using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Modules.Stuff.Domain;

namespace Modules.Stuff.Application.Queries.GetStuff
{
    public record GetPStuffQuery();

    public class GetStuffQueryHandler
    {
        private readonly IStuffRepository _stuffRepository;

        public GetStuffQueryHandler(IStuffRepository stuffRepository)
        {
            _stuffRepository = stuffRepository;
        }

        public async Task<IEnumerable<StuffDto>> HandleAsync(GetPStuffQuery query)
        {
            var stuffItems = await _stuffRepository.GetAllAsync();
            return stuffItems.Select(s => new StuffDto(s.Id, s.Name, s.Code, s.Price, s.Description));
        }
    }
}