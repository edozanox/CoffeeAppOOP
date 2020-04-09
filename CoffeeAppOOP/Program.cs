using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoffeeAppOOP
{
    class Program
    {   
        
        public const string Accesso = "BENVENUTO!";
        public const string Errore = "ERROR: Voce selezionata inesistente!";
        public const string GuidaMenuUno = "Digita la voce desiderata: ";
        public const string GuidaMenuProdotto = "Digita il prodotto richiesto: ";
        public const string GuidaAnotherTime = "Desideri acquistare altro? (Y/N)";
        public const string GuidaMenuQuantita = "Quantita desiderata: ";
        public enum TipoMenu { SNACK, DRINK, CAFFETTERIA };



        static void Main()
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            Caffetteria bar = new Caffetteria();
            //Prodotto acquisto = new Prodotto();
            bool AnotherTime, IsOK = false;
            double importo_totale;
            string selezione;
            int num;

            List<Prodotto> ListaDrinks = new List<Prodotto>
            {
                new Prodotto("VINO ROSSO 0,5 L", 8.50),
                new Prodotto("VINO BIANCO 0,5 L", 10.50),
                new Prodotto("SPRITZ", 2.50)
            };
            List<Prodotto> ListaSnack = new List<Prodotto>
            {
                new Prodotto("TOAST", 5.60),
                new Prodotto("PIADINA", 5.80),
                new Prodotto("PANINO", 5.70)
            };
            List<Prodotto> ListaBevandeCalde = new List<Prodotto>
            {
                new Prodotto("CIOCCOLATA CALDA", 3.50),
                new Prodotto("THE VERDE", 2.20),
                new Prodotto("THE BIANCO", 2.30)
            };

            Console.WriteLine(Accesso);
            do
            {
                Console.WriteLine("\n");
                foreach (var voce in Enum.GetValues(typeof(TipoMenu)))
                {
                    Console.WriteLine(voce.ToString());
                }

                Console.WriteLine("\n");
                Console.Write(GuidaMenuUno);
                selezione = Console.ReadLine();

                //NemesisList.Any(n => n.Dex_ID == IdToCheck)

                switch (selezione)
                {
                    case "DRINK":
                        foreach (var elem in ListaDrinks)
                            Console.WriteLine($"{elem.NomeProdotto } - {elem.PrezzoUnita} €");

                        do
                        {
                            Console.WriteLine("\n");
                            Console.Write(GuidaMenuProdotto);
                            selezione = Console.ReadLine();

                            foreach (var elem in ListaDrinks)
                            {
                                if (elem.NomeProdotto == selezione)
                                {
                                    IsOK = true;
                                    Console.Write(GuidaMenuQuantita);
                                    num = Int32.Parse(Console.ReadLine());
                                    Prodotto prodSel = new Prodotto(elem.NomeProdotto, elem.PrezzoUnita, num);
                                    bar.ProdottiSelezionati.Add(prodSel);
                                }
                            }

                        } while (!IsOK);

                        break;

                    case "SNACK":

                        foreach (var prod in ListaSnack)
                            Console.WriteLine(prod.NomeProdotto + " - " + prod.PrezzoUnita + " €");
                                                
                            Console.WriteLine("\n");
                            Console.Write(GuidaMenuProdotto);
                            selezione = Console.ReadLine();

                            foreach (var elem in ListaSnack)
                            {
                                if (elem.NomeProdotto == selezione)
                                {
                                    IsOK = true;
                                    Console.Write(GuidaMenuQuantita);
                                    num = Int32.Parse(Console.ReadLine());
                                    Prodotto prodSel = new Prodotto(elem.NomeProdotto, elem.PrezzoUnita, num);
                                    bar.ProdottiSelezionati.Add(prodSel);
                                    
                                }
                            }

                        if (!IsOK)
                            Console.WriteLine("PRODOTTO NON TROVATO");

                        break;

                    case "CAFFETTERIA":

                        foreach (var prod in ListaBevandeCalde)
                            Console.WriteLine(prod.NomeProdotto + " - " + prod.PrezzoUnita + " €");

                        do
                        {
                            Console.WriteLine("\n");
                            Console.Write(GuidaMenuProdotto);
                            selezione = Console.ReadLine();

                            foreach (var elem in ListaBevandeCalde)
                            {
                                if (elem.NomeProdotto == selezione)
                                {
                                    IsOK = true;
                                    Console.Write(GuidaMenuQuantita);
                                    num = Int32.Parse(Console.ReadLine());
                                    Prodotto prodSel = new Prodotto(elem.NomeProdotto, elem.PrezzoUnita, num);
                                    bar.ProdottiSelezionati.Add(prodSel);
                                }
                            }
                        } while (!IsOK);

                        break;

                    default:
                        Console.WriteLine(Errore);
                        Console.ReadLine();
                        break;
                }

                Console.Write(GuidaAnotherTime);
                selezione = Console.ReadLine();
                if (selezione == "y" || selezione == "Y")
                    AnotherTime = true;
                else
                    AnotherTime = false;

            } while (AnotherTime);

            importo_totale = bar.CalcolaTotalePagamento();
            Console.WriteLine("-----------------------------------");
            Console.WriteLine("RIEPILOGO:");

            foreach (var elem_cassa in bar.ProdottiSelezionati)
                Console.WriteLine($">>{elem_cassa.Quantita}  x {elem_cassa.NomeProdotto} = {elem_cassa.PrezzoTot} €");

            Console.WriteLine("\n");
            Console.WriteLine("NUM PRODOTTI: 00" + bar.ProdottiSelezionati.Count);
            Console.WriteLine("TOT.........€" + importo_totale);
            Console.WriteLine("ARRIVEDERCI E GRAZIE!");
            Console.WriteLine("-----------------------------------");
            Console.ReadLine();

        }
    }
}
