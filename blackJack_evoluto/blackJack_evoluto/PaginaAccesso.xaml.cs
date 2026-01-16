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
        public PaginaAccesso()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            String riga = txtBox_nomeUtente.Text + ";" + txtBox_Password.Text;
            String[] campi = riga.Split(';');
            string path = "Utenti.csv";
            string nomeUtenteDaCercare = txtBox_nomeUtente.Text;
            string password = null;

            if (File.Exists(path))
            {
                if (campi.Length==2)
                {
                    foreach (var rigaCaricata in File.ReadLines(path).Skip(1))
                    {
                        var campiCaricati = rigaCaricata.Split(';');
                        if (campiCaricati.Length == 7)
                        {
                            if (campiCaricati[3].Trim() == nomeUtenteDaCercare)
                            {
                                if (txtBox_Password.Text == campiCaricati[6].Trim())
                                {
                                    MessageBox.Show("accesso eseguito con successo, bentornato!");
                                }
                                else if (txtBox_Password.Text == campiCaricati[6].Trim())
                                {
                                    MessageBox.Show("password errata, riprova");
                                }
                                break;
                            }
                        }
                    }
                    MessageBox.Show("nome utente non trovato, registrati");
                }
                else
                {
                    MessageBox.Show("Devi riempire tutti i campi per accedere");
                }
            }
        }

        private void button_registrati_Click(object sender, RoutedEventArgs e)
        {
            PaginaRegistrazione p = new PaginaRegistrazione();
            p.ShowDialog();
        }
    }
}
