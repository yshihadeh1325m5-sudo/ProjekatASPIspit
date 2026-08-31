using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Modules.Teams.Application.Commands.CreateTeam;
using Modules.Teams.Application.Commands.UpdateTeam;
using Modules.Teams.Application.Teams.Commands.CreateTeam;
using Modules.Teams.Application.Teams.Queries.GetTeams;
using System.Collections.ObjectModel;
using System.Threading.Tasks;

namespace Modules.Teams.UI.Viewmodels;

public partial class TeamsViewModel : ObservableObject 
{
    private readonly GetTeamsQueryHandler _getTeamsHandler;
    private readonly CreateTeamCommandHandler _createTeamHandler;
    private readonly DeleteTeamCommandHandler _deleteTeamHandler;
    private readonly UpdateTeamCommandHandler _updateTeamHandler;

    public ObservableCollection<TeamDto> Teams { get; set; } = new();


    public TeamsViewModel(
        GetTeamsQueryHandler getTeamsHandler,
        CreateTeamCommandHandler createTeamHandler,
        DeleteTeamCommandHandler deleteTeamHandler,
        UpdateTeamCommandHandler updateTeamHandler)
        
        
    {
        _getTeamsHandler = getTeamsHandler;
        _createTeamHandler = createTeamHandler;
        _deleteTeamHandler = deleteTeamHandler;
        _updateTeamHandler = updateTeamHandler;

        _ = UcitajTimoveAsync();
    }

    public async Task UcitajTimoveAsync()
    {

        var listaIzBaze = await _getTeamsHandler.HandleAsync(new GetTeamsQuery());

        Teams.Clear();
        foreach (var tim in listaIzBaze)
        {
            Teams.Add(tim);
        }
    }
   

    [RelayCommand] 
    public async Task Delete(Guid id)
    {
        await _deleteTeamHandler.HandleAsync(new DeleteTeamCommand(id));
        await UcitajTimoveAsync(); 
    }

    public async Task DodajTimAsync(string name, string stadium)
    {
        await _createTeamHandler.HandleAsync(new CreateTeamCommand(name, stadium));
        await UcitajTimoveAsync();
    }



    [RelayCommand]
    public async Task Update(TeamDto team)
    {
        System.Diagnostics.Debug.WriteLine($"Pozvan Update za tim: {team.Name}");
        try
        {
            await _updateTeamHandler.HandleAsync(new UpdateTeamCommand(team.Id, team.Name, team.Stadium));

            // POSLE ovoga, stavi breakpoint ovde
            await UcitajTimoveAsync();
        }
        catch (Exception ex)
        {
            // Ako ovde upadne, izbaciće ti poruku u Output prozor
            System.Diagnostics.Debug.WriteLine("GREŠKA: " + ex.Message);
        }
    }
}