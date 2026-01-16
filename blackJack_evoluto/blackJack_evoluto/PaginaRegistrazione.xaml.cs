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
    /// Logica di interazione per PaginaRegistrazione.xaml
    /// </summary>
    public partial class PaginaRegistrazione : Window
    {
        Giocatore g;
        public PaginaRegistrazione()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            String riga = txtBox_nome.Text + ";" + txtBox_cognome.Text + ";" + txtBox_email.Text + ";" + txtBox_nomeUtente.Text + ";" + txtBox_numeroTelefono.Text + ";" + txtBox_SaldoIniziale.Text + ";" + txtBox_Password.Text;
            String[] campi = riga.Split(';');
            string path = "Utenti.csv";

            if (campi.Length == 7)
            {
                using (StreamWriter sw = new StreamWriter(path)) { 
                    if (!File.Exists(path))
                    {
                        File.CreateText(path);
                        sw.WriteLine("Nome ; Cognome; Email ; Nome Utente ; Numero telefono ; Saldo iniziale ; Password");
                        File.AppendAllText(path, riga + Environment.NewLine);
                    }
                    else
                    {
                        File.AppendAllText(path, riga + Environment.NewLine);
                    }
                }
            }
            else
            {
                MessageBox.Show("Per registrarti devi riempire tutti i campi");
            }
        }
    }
}
