using System;
using System.Collections.Generic;
using System.Text;


namespace Prb.Boekenkast.Core
{
    public class Bibliotheek
    {
        public List<Boek> Boeken { get; set; }
        public List<Auteur> Auteurs { get; set; }

        public Bibliotheek()
        {
            Boeken = new List<Boek>();
            Auteurs = new List<Auteur>();
            DoSeeding();
        }

        private void DoSeeding()
        {
            Auteur auteur1 = new Auteur("Boon","België");
            Auteur auteur2 = new Auteur("Tuchman", "USA");
            Auteur auteur3 = new Auteur("Cronwell", "UK");

            Auteurs.Add(auteur1);
            Auteurs.Add(auteur2);
            Auteurs.Add(auteur3);

            Boek boek1 = new Boek("De bende van jan de lichte", 1995, auteur1.Auteur_ID);
            Boek boek2 = new Boek("Kapellekesweg", 1997, auteur1.Auteur_ID);
            Boek boek3 = new Boek("De trotse toren", 2001, auteur2.Auteur_ID);
            Boek boek4 = new Boek("Azincourt", 2020, auteur3.Auteur_ID);

            Boeken.Add(boek1);
            Boeken.Add(boek2);
            Boeken.Add(boek3);
            Boeken.Add(boek4);
        }
    }
}
