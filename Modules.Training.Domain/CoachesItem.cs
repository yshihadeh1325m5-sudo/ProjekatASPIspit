using System;
using System.Collections.Generic;
using System.Text;

namespace Modules.Coaches.Domain
{
    public class CoachesItem
    {
        public Guid Id { get; private set; }
        public string Ime { get; private set; }
        public string Prezime { get; private set; }
        public string Licenca { get; private set; }
        public string OpisLicence { get; private set; }
        public string Ekipa { get; private set; }

        
        protected CoachesItem() { }

        public CoachesItem(Guid id, string ime, string prezime, string licenca, string opisLicence, string ekipa)
        {
            Id = id;
            Ime = ime;
            Prezime = prezime;
            Licenca = licenca;
            OpisLicence = opisLicence;
            Ekipa = ekipa;
        }

        public void UpdateDetails(string ime, string prezime, string licenca, string opisLicence, string ekipa)
        {
            if (string.IsNullOrWhiteSpace(ime))
                throw new ArgumentException("Ime ne može biti prazno.");

            if (string.IsNullOrWhiteSpace(prezime))
                throw new ArgumentException("Prezime ne može biti prazno.");

            if (string.IsNullOrWhiteSpace(licenca))
                throw new ArgumentException("Licenca ne može biti prazna.");

            Ime = ime;
            Prezime = prezime;
            Licenca = licenca;
            OpisLicence = opisLicence;
            Ekipa = ekipa;
        }
    }
}