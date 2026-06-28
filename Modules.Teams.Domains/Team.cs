using System;
using System.Collections.Generic;
using System.Text;

namespace Modules.Teams.Domain;

public class Team
{
    public Guid Id { get; private set; }
    public string Name { get; private set; }
    public string Stadium { get; private set; }

    // Konstruktor preko kojeg garantujemo da tim ne može da se napravi bez imena i stadiona
    public Team(Guid id, string name, string stadium)
    {
        if (string.IsNullOrWhiteSpace(name))
            throw new ArgumentException("Ime tima ne može biti prazno.");

        if (string.IsNullOrWhiteSpace(stadium))
            throw new ArgumentException("Naziv stadiona ne može biti prazan.");

        Id = id;
        Name = name;
        Stadium = stadium;
    }
}
