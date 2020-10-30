using System;
using System.Collections.Generic;
using System.Text;

namespace Prb.Boekenkast.Core
{
    public class Boek
    {
        public string Titel { get; set; }
        public int Jaar { get; set; }
        public string Auteur_ID { get; set; }

        public Boek(string titel, int jaar, string auteur_id)
        {
            Titel = titel;
            Jaar = jaar;
            Auteur_ID = auteur_id;
        }
        public override string ToString()
        {
            return Titel;
        }
    }



}
