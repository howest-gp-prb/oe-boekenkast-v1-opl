using System;
using System.Collections.Generic;
using System.Text;

namespace Prb.Boekenkast.Core
{
    public class Auteur
    {
        public string Auteur_ID { get; set; }
        public string Naam { get; set; }
        public string Land { get; set; }

        public Auteur(string naam, string land)
        {
            Auteur_ID = Guid.NewGuid().ToString();
            Naam = naam;
            Land = land;
        }

        public override string ToString()
        {
            return Naam;
        }
    }
}
