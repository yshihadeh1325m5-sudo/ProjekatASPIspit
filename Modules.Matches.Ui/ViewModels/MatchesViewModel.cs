using System;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Modules.Matches.Application.Commands.CreateMatch;
using Modules.Matches.Domain;

namespace Modules.Matches.Ui.ViewModels;

public partial class MatchesViewModel : ObservableObject
{
    private readonly CreateMatchCommandHandler _createMatchHandler;
    private readonly IMatchRepository _matchRepository;

    public ObservableCollection<Match> Matches { get; } = new();

    [ObservableProperty] private Guid _homeTeamId;
    [ObservableProperty] private Guid _awayTeamId;
    [ObservableProperty] private int _homeScore;
    [ObservableProperty] private int _awayScore;
    [ObservableProperty] private DateTime _matchDate = DateTime.Now;

    [ObservableProperty]
    private Match? _selectedMatch;

    public MatchesViewModel(CreateMatchCommandHandler createMatchHandler, IMatchRepository matchRepository)
    {
        _createMatchHandler = createMatchHandler;
        _matchRepository = matchRepository;

        // Automatsko učitavanje mečeva pri pokretanju
        _ = LoadMatchesAsync();
    }

    partial void OnSelectedMatchChanged(Match? value)
    {
        if (value != null)
        {
            HomeTeamId = value.HomeTeamId;
            AwayTeamId = value.AwayTeamId;
            HomeScore = value.HomeScore;
            AwayScore = value.AwayScore;
            MatchDate = value.MatchDate;
        }
    }

    [RelayCommand]
    public async Task AddMatchAsync()
    {
        var command = new CreateMatchCommand(HomeTeamId, AwayTeamId, HomeScore, AwayScore, MatchDate);
        await _createMatchHandler.HandleAsync(command);

        await LoadMatchesAsync();
    }

    [RelayCommand]
    public async Task UpdateMatchAsync()
    {
        if (SelectedMatch == null) return;

        SelectedMatch.UpdateScore(HomeScore, AwayScore);

        await _matchRepository.UpdateAsync(SelectedMatch);
        await LoadMatchesAsync();
    }

    [RelayCommand]
    public async Task DeleteMatchAsync()
    {
        if (SelectedMatch == null) return;

        await _matchRepository.DeleteAsync(SelectedMatch.Id);
        await LoadMatchesAsync();
    }

    [RelayCommand]
    public async Task LoadMatchesAsync()
    {
        var matches = await _matchRepository.GetAllAsync();

        Matches.Clear();
        foreach (var match in matches)
        {
            Matches.Add(match);
        }
    }
}