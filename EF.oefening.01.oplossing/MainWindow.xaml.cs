using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace EF.oefening._01.oplossing
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

        private void BtnNieuw_Click(object sender, RoutedEventArgs e)
        {
            LstPersonen.SelectedIndex = -1;

            ToggleVelden(true);

            ToggleKnoppen(false, false, true);

            TxtNaam.Focus();
        }

        private void BtnVerwijder_Click(object sender, RoutedEventArgs e)
        {
            ToggleVelden(false);

            ToggleKnoppen(true, false, false);

            LstPersonen.Items.Remove(LstPersonen.SelectedItem);
            LstPersonen.SelectedIndex = -1;
        }

        private void BtnBewaar_Click(object sender, RoutedEventArgs e)
        {
            if (LstPersonen.SelectedIndex == -1)
            {
                Persoon persoon = new Persoon(TxtNaam.Text, TxtVoornaam.Text, DateTime.Parse(TxtGeboortedatum.Text), CbHeeftRijbewijs.IsChecked.Value);
                LstPersonen.Items.Add(persoon);
            }
            else
            {
                Persoon persoon = (Persoon)LstPersonen.SelectedItem;
                persoon.Naam = TxtNaam.Text;
                persoon.Voornaam = TxtVoornaam.Text;
                persoon.Geboortedatum = DateTime.Parse(TxtGeboortedatum.Text);
                persoon.HeeftRijbewijs = CbHeeftRijbewijs.IsChecked.Value;
                LstPersonen.Items.Refresh();
            }

            ToggleVelden(false);

            ToggleKnoppen(true, false, false);

            LstPersonen.SelectedIndex = -1;
        }

        private void BtnAnnuleer_Click(object sender, RoutedEventArgs e)
        {
            ToggleVelden(false);

            ToggleKnoppen(true, false, false);

            LstPersonen.SelectedIndex = -1;
        }

        private void BtnAfsluiten_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void ToggleVelden(bool status)
        {
            TxtNaam.Text = "";
            TxtNaam.IsEnabled = status;

            TxtVoornaam.Text = "";
            TxtVoornaam.IsEnabled = status;

            TxtGeboortedatum.Text = "";
            TxtGeboortedatum.IsEnabled = status;

            CbHeeftRijbewijs.IsChecked = false;
            CbHeeftRijbewijs.IsEnabled = status;
        }

        private void ToggleKnoppen(bool nieuw, bool verwijder, bool bewaarannuleer)
        {
            BtnNieuw.IsEnabled = nieuw;
            BtnVerwijder.IsEnabled = verwijder;
            BtnAnnuleer.IsEnabled = bewaarannuleer;
            BtnBewaar.IsEnabled = bewaarannuleer;
        }

        private void LstPersonen_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ToggleVelden(true);
            Persoon persoon = (Persoon)LstPersonen.SelectedItem;
            if (persoon != null)
            {
                TxtNaam.Text = persoon.Naam;
                TxtVoornaam.Text = persoon.Voornaam;
                TxtGeboortedatum.Text = persoon.Geboortedatum.ToString("dd/MM/yyyy");
                CbHeeftRijbewijs.IsChecked = persoon.HeeftRijbewijs;

                ToggleKnoppen(false, true, true);

                TxtNaam.Focus();
            }
            else
            {
                ToggleKnoppen(true, false, false);
            }
        }
    }
}