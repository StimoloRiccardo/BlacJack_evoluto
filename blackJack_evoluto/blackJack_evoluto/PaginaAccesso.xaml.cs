using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.IO;

namespace blackJack_evoluto
{
    /// <summary>
    /// Logica di interazione per PaginaAccesso.xaml
    /// </summary>
    public partial class PaginaAccesso : Window
    {
        Giocatore player;
        bool passwordVisibile = false;
        public PaginaAccesso()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            String riga = txtBox_nomeUtente.Text + ";" + txtBox_Password.Text;
            String[] campi = riga.Split(';');
            String path = "Utenti.csv";
            String nomeUtenteDaCercare = txtBox_nomeUtente.Text;

            if (campi.Length==2 && File.Exists(path))
            {
                foreach (var rigaCaricata in File.ReadLines(path))
                {
                    String[] campiCaricati = rigaCaricata.Split(';');
                    if (campiCaricati.Length == 7)
                    {
                        if (campiCaricati[3].Trim() == nomeUtenteDaCercare || campiCaricati[2].Trim() == nomeUtenteDaCercare)
                        {
                            if (txtBox_Password.Text == campiCaricati[6].Trim() || pwBox_password.Password == campiCaricati[6].Trim())
                            {
                                MessageBox.Show("accesso eseguito con successo, bentornato!");
                                player = new Giocatore(campiCaricati[0], campiCaricati[1], campiCaricati[2], campiCaricati[3], campiCaricati[4], double.Parse(campiCaricati[5]), campiCaricati[6]);
                                this.Close();
                            }
                            else if (txtBox_Password.Text != campiCaricati[6].Trim() || pwBox_password.Password != campiCaricati[6].Trim())
                            {
                                MessageBox.Show("password errata, riprova");
                            }
                            break;
                        }
                    }
                }
                    
                if (player == null)
                {
                    MessageBox.Show("nome utente non trovato, registrati per accedere");
                }
            }
            else
            {
                MessageBox.Show("Devi riempire tutti i campi per accedere");
            }
        }

        public Giocatore getGiocatore()
        {
            return player;
        }

        private void button_registrati_Click(object sender, RoutedEventArgs e)
        {
            PaginaRegistrazione p = new PaginaRegistrazione();
            p.ShowDialog();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            if (passwordVisibile)
            {
                pwBox_password.Password = txtBox_Password.Text;
                txtBox_Password.Visibility = Visibility.Collapsed;
                pwBox_password.Visibility = Visibility.Visible;
                passwordVisibile = false;
                immagine_pulsante.Source = new BitmapImage(new Uri("imgs/non_sento.png", UriKind.Relative));
            }
            else if (!passwordVisibile)
            {
                txtBox_Password.Text = pwBox_password.Password;
                pwBox_password.Visibility = Visibility.Collapsed;
                txtBox_Password.Visibility = Visibility.Visible;
                passwordVisibile = true;
                immagine_pulsante.Source = new BitmapImage(new Uri("imgs/non_vedo.png", UriKind.Relative));

            }
        }
    }
}
