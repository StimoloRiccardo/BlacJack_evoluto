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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace blackJack_evoluto
{
    /// <summary>
    /// Logica di interazione per MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        bool accessoEseguito = false;
        Giocatore player;
        public MainWindow()
        {
            InitializeComponent();
            WindowState = WindowState.Maximized;
        }

        private void Image_Loaded(object sender, RoutedEventArgs e)
        {
            PaginaAccesso accesso = new PaginaAccesso();
            accesso.ShowDialog();
            player = accesso.getGiocatore();
            if (player!=null)
            {
                label_nomeUtente.Content = "Nome Utente: " + player.getNomeUtente();
                label_saldo.Content = "Saldo: " + player.getSaldo().ToString() + " €";
            }
        }

        public void setAccessoEseguito(bool accesso)
        {
            accessoEseguito = accesso;
        }
    }
}
