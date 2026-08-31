using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Modules.Coaches.Application.Commands.CreateCoaches;
using Modules.Coaches.Application.Commands.UpdateCoaches;
using Modules.Coaches.Application.Queries.GetCoaches;
using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Threading.Tasks;

namespace Modules.Coaches.Ui.Viewmodels
{
    public partial class CoachesViewModel : ObservableObject
    {
        private readonly GetCoachesQueryHandler _getCoachesHandler;
        private readonly CreateCoachesCommandHandler _createCoachesHandler;
        private readonly DeleteCoachesCommandHandler _deleteCoachesHandler;
        private readonly UpdateCoachesCommandHandler _updateCoachesHandler;

        public ObservableCollection<CoachesDto> CoachesItems { get; set; } = new();

        [ObservableProperty]
        private string _ime = string.Empty;

        [ObservableProperty]
        private string _prezime = string.Empty;

        [ObservableProperty]
        private string _licenca = string.Empty;

        [ObservableProperty]
        private string _opisLicence = string.Empty;

        [ObservableProperty]
        private string _ekipa = string.Empty;

        [ObservableProperty]
        private CoachesDto? _selectedItem;

        partial void OnSelectedItemChanged(CoachesDto? value)
        {
            if (value != null)
            {
                Ime = value.Ime;
                Prezime = value.Prezime;
                Licenca = value.Licenca;
                OpisLicence = value.OpisLicence;
                Ekipa = value.Ekipa;
            }
        }

        public CoachesViewModel(
            GetCoachesQueryHandler getCoachesHandler,
            CreateCoachesCommandHandler createCoachesHandler,
            DeleteCoachesCommandHandler deleteCoachesHandler,
            UpdateCoachesCommandHandler updateCoachesHandler)
        {
            _getCoachesHandler = getCoachesHandler;
            _createCoachesHandler = createCoachesHandler;
            _deleteCoachesHandler = deleteCoachesHandler;
            _updateCoachesHandler = updateCoachesHandler;

            _ = UcitajTrenereAsync();
        }

        public async Task UcitajTrenereAsync()
        {
            var listaIzBaze = await _getCoachesHandler.HandleAsync(new GetCoachesQuery());

            CoachesItems.Clear();
            foreach (var item in listaIzBaze)
            {
                CoachesItems.Add(item);
            }
        }

        [RelayCommand]
        public async Task Dodaj()
        {
            var command = new CreateCoachesCommand(Ime, Prezime, Licenca, OpisLicence, Ekipa);

            await _createCoachesHandler.HandleAsync(command);
            await UcitajTrenereAsync();

            Ime = string.Empty;
            Prezime = string.Empty;
            Licenca = string.Empty;
            OpisLicence = string.Empty;
            Ekipa = string.Empty;
        }

        [RelayCommand]
        public async Task Delete(Guid id)
        {
            await _deleteCoachesHandler.HandleAsync(new DeleteCoachesCommand(id));
            await UcitajTrenereAsync();
        }

        [RelayCommand]
        public async Task Update()
        {
            if (SelectedItem == null) return;

            try
            {
                var command = new UpdateCoachesCommand(SelectedItem.Id, Ime, Prezime, Licenca, OpisLicence, Ekipa);
                await _updateCoachesHandler.HandleAsync(command);
                await UcitajTrenereAsync();
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("GREŠKA: " + ex.Message);
            }
        }
    }
}