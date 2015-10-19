using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ITechSite.Models.Repository.ItechUsersImport
{
    public class SitechUser
    {
        public string Nazwisko { get; set; }
        public string Imię { get; set; }
        public string Nr_identyfikacyjny { get; set; }
        public string Nr_karty { get; set; }
        public string Profil_dostepu { get; set; }
        public string Opis { get; set; }
    }
}