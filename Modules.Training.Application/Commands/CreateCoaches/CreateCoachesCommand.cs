using System;
using System.Collections.Generic;
using System.Text;

namespace Modules.Coaches.Application.Commands.CreateCoaches
{
    public record CreateCoachesCommand(string Ime, string Prezime, string Licenca, string OpisLicence, string Ekipa);
}
