using System;
using System.Collections.Generic;
using System.Text;

namespace Modules.Teams.Application.Teams.Queries.GetTeams;

public class TeamDto
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string Stadium { get; set; }

    // Dodaj konstruktor ako ti treba, ali get;set; je ključan
    public TeamDto(Guid id, string name, string stadium)
    {
        Id = id;
        Name = name;
        Stadium = stadium;
    }
}