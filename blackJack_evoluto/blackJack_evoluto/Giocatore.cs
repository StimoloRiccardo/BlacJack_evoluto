using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace blackJack_evoluto
{
    public class Giocatore
    {
        private string nomeUtente, password, email, nome, cognome;
        private double saldo;
        private int numeroVittorie;

        public Giocatore(string nome, string cognome, string email, string nomeUtente, double saldo, string password)
        {
            this.nome = nome;
            this.cognome = cognome;
            this.nomeUtente = nomeUtente;
            this.password = password;
            this.email = email;
            this.saldo = saldo;
        }

        public string getNomeUtente()
        {
            return nomeUtente;
        }   

        public double getSaldo()
        {
            return saldo;
        }
    }
}
