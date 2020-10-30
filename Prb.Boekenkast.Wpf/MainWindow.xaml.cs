using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Prb.Boekenkast.Core;

namespace Prb.Boekenkast.Wpf
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        bool isNieuw;
        Bibliotheek bibliotheek;
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            bibliotheek = new Bibliotheek();
            SituatieStandaard();
            ControlsLeegmaken();
            VulListbox();
            VulCombobox();
        }

        private void SituatieStandaard()
        {
            grpBoekenkast.IsEnabled = true;
            grpDetails.IsEnabled = false;
        }
        private void SituatieBewerk()
        {
            grpBoekenkast.IsEnabled = false;
            grpDetails.IsEnabled = true;
        }
        private void ControlsLeegmaken()
        {
            txtTitel.Text = "";
            txtJaar.Text = "";
            cmbAuteur.SelectedIndex = -1;
            lblNationaliteit.Content = "";
        }
        private void VulListbox()
        {
            lstBoeken.ItemsSource = null;
            lstBoeken.ItemsSource = bibliotheek.Boeken;
        }
        private void VulCombobox()
        {
            cmbAuteur.ItemsSource = null;
            cmbAuteur.ItemsSource = bibliotheek.Auteurs;
        }
        private void lstBoeken_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ControlsLeegmaken();
            if (lstBoeken.SelectedItem == null)
                return;
            Boek boek =(Boek)lstBoeken.SelectedItem;
            txtTitel.Text = boek.Titel;
            txtJaar.Text = boek.Jaar.ToString();
            string auteur_id = boek.Auteur_ID;
            foreach(Auteur auteur in bibliotheek.Auteurs)
            {
                if(auteur.Auteur_ID == auteur_id)
                {
                    cmbAuteur.SelectedItem = auteur;
                    lblNationaliteit.Content = auteur.Land;
                    break;
                }
            }

        }

        private void btnNieuw_Click(object sender, RoutedEventArgs e)
        {
            isNieuw = true;
            SituatieBewerk();
            ControlsLeegmaken();
            txtTitel.Focus();
        }

        private void btnWijzig_Click(object sender, RoutedEventArgs e)
        {
            if (lstBoeken.SelectedItem == null)
                return;
            isNieuw = false;
            SituatieBewerk();
            txtTitel.Focus();
        }

        private void btnVerwijder_Click(object sender, RoutedEventArgs e)
        {
            if (lstBoeken.SelectedItem == null)
                return;
            Boek boek = (Boek)lstBoeken.SelectedItem;
            bibliotheek.Boeken.Remove(boek);
            VulListbox();
            ControlsLeegmaken();

        }



        private void btnBewaren_Click(object sender, RoutedEventArgs e)
        {
            if (cmbAuteur.SelectedItem == null)
                return;

            string titel = txtTitel.Text.Trim();
            int jaar = 0;
            int.TryParse(txtJaar.Text, out jaar);
            Auteur auteur = (Auteur)cmbAuteur.SelectedItem;
            string auteur_id = auteur.Auteur_ID;

            Boek boek;
            if (isNieuw)
            {
                // wat te doen bij een nieuw boek ?
                boek = new Boek(titel, jaar, auteur_id);
                bibliotheek.Boeken.Add(boek);
            }
            else
            {
                // wat te doen bij wijziging bestaand boek ?
                boek = (Boek)lstBoeken.SelectedItem;
                boek.Titel = titel;
                boek.Jaar = jaar;
                boek.Auteur_ID = auteur_id;
            }
            VulListbox();
            SituatieStandaard();
            lstBoeken.SelectedItem = boek;
            lstBoeken_SelectionChanged(null, null);
        }

        private void btnAnnuleren_Click(object sender, RoutedEventArgs e)
        {
            ControlsLeegmaken();
            SituatieStandaard();
            if(lstBoeken.SelectedIndex >= 0)
            {
                lstBoeken_SelectionChanged(null, null);
            }
        }

        private void cmbAuteur_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            lblNationaliteit.Content = "";
            if (cmbAuteur.SelectedItem == null)
                return;
            Auteur auteur = (Auteur)cmbAuteur.SelectedItem;
            lblNationaliteit.Content = auteur.Land;


        }
    }
}
