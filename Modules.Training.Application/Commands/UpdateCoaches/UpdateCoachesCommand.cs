using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;

namespace Modules.Coaches.Application.Commands.UpdateCoaches
{
    
    public record UpdateCoachesCommand(Guid Id,string Ime, string Prezime, string Licenca, string OpisLicence, string Ekipa);
}


