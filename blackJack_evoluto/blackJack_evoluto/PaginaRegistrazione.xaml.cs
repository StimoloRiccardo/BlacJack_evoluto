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
            String riga = txtBox_nome.Text + ";" + txtBox_cognome.Text + ";" + txtBox_email.Text + ";" + txtBox_nomeUtente + ";" + txtBox_numeroTelefono + ";" + ;
            String[] campi = riga.Split(';');

            if (campi.Length == 7)
            {

            }
        }
    }
}
