using System;
using System.Collections.Generic;
using System.Text;

namespace Modules.Coaches.Application.Queries.GetCoaches
{
    public class CoachesDto
    {
        public Guid Id { get; set; }
        public string Ime { get; set; }
        public string Prezime { get; set; }
        public string Licenca { get; set; }
        public string OpisLicence { get; set; }

        public string Ekipa { get; set; }

        public CoachesDto(Guid id, string ime, string prezime, string licenca, string Opis_Licence, string ekipa)
        {
            Id = id;
            Ime = ime;
            Prezime = prezime;
            Licenca = licenca;
            OpisLicence = Opis_Licence;
            Ekipa = ekipa;

        }
    }
}
