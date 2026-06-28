using System;
using System.Collections.Generic;
using System.Text;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Windows.Input;
using Modules.Teams.Application.Teams.Queries.GetTeams;
using Modules.Teams.Application.Teams.Commands.CreateTeam;

namespace Modules.Teams.UI.Viewmodels;

public class TeamsViewModel
{
    private readonly GetTeamsQueryHandler _getTeamsHandler;
    private readonly CreateTeamCommandHandler _createTeamHandler;

    public ObservableCollection<TeamDto> Teams { get; set; } = new();

    public TeamsViewModel(GetTeamsQueryHandler getTeamsHandler, CreateTeamCommandHandler createTeamHandler)
    {
        _getTeamsHandler = getTeamsHandler;
        _createTeamHandler = createTeamHandler;

        // Iskoristili smo discard (_) da utišamo CS4014 warning i eksplicitno stavimo do znanja 
        // kompajleru da namerno puštamo asinhronu operaciju "u pozadini" tokom inicijalizacije.
        _ = UcitajTimoveAsync();
    }

    public async Task UcitajTimoveAsync()
    {
        var timoviIzBaze = await _getTeamsHandler.HandleAsync(new GetTeamsQuery());

        Teams.Clear();
        foreach (var tim in timoviIzBaze)
        {
            Teams.Add(tim);
        }
    }

    public async Task DodajTimAsync(string name, string stadium)
    {
        // Pozivamo komandu za kreiranje novog tima u bazi
        await _createTeamHandler.HandleAsync(new CreateTeamCommand(name, stadium));

        // Odmah osvežavamo kolekciju kako bi tabela automatski prikazala novi tim
        await UcitajTimoveAsync();
    }
}