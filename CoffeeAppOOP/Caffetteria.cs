using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoffeeAppOOP
{
    public class Caffetteria
    {
        public List<Prodotto> ProdottiSelezionati = new List<Prodotto>();
        public double CalcolaTotalePagamento()
        {
            double TotDaPagare = 0;
            foreach (var elem in ProdottiSelezionati)
                TotDaPagare += elem.PrezzoTot;

            return TotDaPagare;
        }
    }
}

