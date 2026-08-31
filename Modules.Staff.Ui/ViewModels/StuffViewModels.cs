using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Modules.Stuff.Application.Commands.CreateStuff;

using Modules.Stuff.Application.Commands.UpdateStuff;
using Modules.Stuff.Application.Queries.GetStuff;
using System;
using System.Collections.ObjectModel;
using System.Threading.Tasks;

namespace Modules.Stuff.Ui.Viewmodels
{
    public partial class StuffViewModel : ObservableObject
    {
        private readonly GetStuffQueryHandler _getStuffHandler;
        private readonly CreateStuffCommandHandler _createStuffHandler;
        private readonly DeleteStuffCommandHandler _deleteStuffHandler;
        private readonly UpdateStuffCommandHandler _updateStuffHandler;

        public ObservableCollection<StuffDto> StuffItems { get; set; } = new();

        [ObservableProperty]
        private string _name = string.Empty;

        [ObservableProperty]
        private string _code = string.Empty;

        [ObservableProperty]
        private string _description = string.Empty;

        [ObservableProperty]
        private decimal _price; // ili količina/cena zavisno od tvoje baze

        public StuffViewModel(
            GetStuffQueryHandler getStuffHandler,
            CreateStuffCommandHandler createStuffHandler,
            DeleteStuffCommandHandler deleteStuffHandler,
            UpdateStuffCommandHandler updateStuffHandler)
        {
            _getStuffHandler = getStuffHandler;
            _createStuffHandler = createStuffHandler;
            _deleteStuffHandler = deleteStuffHandler;
            _updateStuffHandler = updateStuffHandler;

            _ = UcitajStvariAsync();
        }

        public async Task UcitajStvariAsync()
        {
            var listaIzBaze = await _getStuffHandler.HandleAsync(new GetPStuffQuery());

            StuffItems.Clear();
            foreach (var item in listaIzBaze)
            {
                StuffItems.Add(item);
            }
        }

        [RelayCommand]
        public async Task Dodaj()
        {
            // Tačan redosled prema tvom CreateStuffCommand(string Name, string Code, decimal Price, string Description)
            var command = new CreateStuffCommand(Name, Code, Price, Description);

            await _createStuffHandler.HandleAsync(command);
            await UcitajStvariAsync();

            // Resetovanje polja forme nakon uspešnog unosa
            Name = string.Empty;
            Code = string.Empty;
            Price = 0;
            Description = string.Empty;
        }

        [RelayCommand]
        public async Task Delete(Guid id)
        {
            await _deleteStuffHandler.HandleAsync(new DeleteStuffCommandcs(id));
            await UcitajStvariAsync();
        }

        [RelayCommand]
        public async Task Update(StuffDto stuff)
        {
            System.Diagnostics.Debug.WriteLine($"Pozvan Update za artikal: {stuff.Name}");
            try
            {
                await _updateStuffHandler.HandleAsync(new UpdateStuffCommand(stuff.Id, stuff.Name, stuff.Code, stuff.Price, stuff.Description));
                await UcitajStvariAsync();
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("GREŠKA: " + ex.Message);
            }
        }
    }
}