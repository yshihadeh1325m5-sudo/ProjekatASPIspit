using System;
using System.Collections.Generic;
using System.Text;

namespace Modules.Teams.Domain;

public class Team
{
    public Guid Id { get; private set; }
    public string Name { get; private set; }
    public string Stadium { get; private set; }

    public Team(Guid id, string name, string stadium)
    {
      
        Id = id;
        Name = name;
        Stadium = stadium;
    }

    // Dodaj ovu metodu za promenu podataka
    public void UpdateDetails(string name, string stadium)
    {
        if (string.IsNullOrWhiteSpace(name))
            throw new ArgumentException("Ime tima ne može biti prazno.");

        if (string.IsNullOrWhiteSpace(stadium))
            throw new ArgumentException("Naziv stadiona ne može biti prazan.");

        Name = name;
        Stadium = stadium;
    }
 
}
