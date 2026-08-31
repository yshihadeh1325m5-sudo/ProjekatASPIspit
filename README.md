Opis sistema 

Sistem predstavlja modularnu monolitnu desktop aplikaciju razvijenu u WPF (Windows Presentation Foundation) okruženju sa primenom MVVM (Model-View-ViewModel) arhitektonskog obrasca i .NET tehnologija. Namenjen je efikasnom upravljanju sportskim klubovima, pratećim resursima i osobljem kroz strogo izolovane poslovne domene. 

Modularna Struktura: Arhitektura je podeljena na nezavisne module (Coaches, Teams, Matches, Stuff, Users i Notification) unutar kojih je svaki domen organizovan kroz višeslojne komponente (Domain, Application, Infrastructure i UI) radi niske spregnutosti. 

CQRS i Perzistentnost: Korišćenjem CQRS obrasca razdvojene su operacije čitanja i upisa podataka, dok Entity Framework Core obezbeđuje pouzdanu bazu podataka, automatske migracije i mapiranje entiteta poput trenera, timova i opreme. 

Korisnički Interfejs: Izgrađen je korišćenjem prilagođenih DataGrid tabela i CommunityToolkit.Mvvm paketa sa [ObservableProperty] i [RelayCommand] atributima, omogućavajući dvosmerno vezivanje podataka, automatsko osvežavanje pogleda i efikasne CRUD operacije. 
