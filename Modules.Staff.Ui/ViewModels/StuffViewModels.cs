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
        private decimal _price;

        [ObservableProperty]
        private StuffDto? _selectedItem;

        // Automatski se poziva kada korisnik klikne na red u DataGrid-u
        partial void OnSelectedItemChanged(StuffDto? value)
        {
            if (value != null)
            {
                Name = value.Name;
                Code = value.Code;
                Price = value.Price;
                Description = value.Description;
            }
        }

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
            var command = new CreateStuffCommand(Name, Code, Price, Description);

            await _createStuffHandler.HandleAsync(command);
            await UcitajStvariAsync();

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
        public async Task Update()
        {
            if (SelectedItem == null) return;

            try
            {
                // Uzima ID selektovanog elementa, a nove vrednosti iz Textbox polja
                var command = new UpdateStuffCommand(SelectedItem.Id, Name, Code, Price, Description);
                await _updateStuffHandler.HandleAsync(command);
                await UcitajStvariAsync();
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("GREŠKA: " + ex.Message);
            }
        }
    }
}