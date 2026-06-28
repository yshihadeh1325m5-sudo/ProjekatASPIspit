using System;
using System.Collections.Generic;
using System.Text;

using Modules.Teams.Domain;

namespace Modules.Teams.Application.Teams.Commands.CreateTeam;

public class CreateTeamCommandHandler
{
    private readonly ITeamRepository _teamRepository;

    // Kroz konstruktor ubrizgavamo (DI) interfejs iz Domena
    public CreateTeamCommandHandler(ITeamRepository teamRepository)
    {
        _teamRepository = teamRepository;
    }

    public async Task HandleAsync(CreateTeamCommand command)
    {
        // 1. Mapiramo podatke iz komande u pravi domenski objekat
        var team = new Team(Guid.NewGuid(), command.Name, command.Stadium);

        // 2. Prosledimo ga repozitorijumu da se upiše u bazu
        await _teamRepository.AddAsync(team);
    }
}