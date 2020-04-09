using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoffeeAppOOP
{
    public class Prodotto
    {

        public string NomeProdotto { get; set; }
        public double PrezzoUnita { get; set; }
        public int Quantita { get; set; }
        public double PrezzoTot { get; set; }
        /// <summary>
        /// Istanza base
        /// </summary>
        public Prodotto()
        {

        }
        /// <summary>
        /// Crea un oggetto Prodotto -> elemento da inserire nel menu
        /// </summary>
        /// <param name="nome"></param>
        /// <param name="prezzo"></param>
        public Prodotto(string nome, double prezzo)
        {
            NomeProdotto = nome;
            PrezzoUnita = prezzo;
        }

        /// <summary>
        /// Crea un oggetto Prodotto -> elemento selezionato dal menu
        /// </summary>
        /// <param name="nome">Nome prodotto</param>
        /// <param name="prezzo">Prezzo unitario</param>
        /// <param name="qta">Quantità di acquisto desiderata </param>
        public Prodotto(string nome, double prezzo, int qta)
        {
            NomeProdotto = nome;
            PrezzoUnita = prezzo;
            Quantita = qta;
            PrezzoTot = CalcPrezzoTotProd(prezzo, qta);
        }


        public double CalcPrezzoTotProd(double prz, int quantita)
        {
            return prz * quantita;
        }
    }
}
