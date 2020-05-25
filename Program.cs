using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Geldscheinprüfung
{
    class Program
    {
        static void Main(string[] args)
        {
            //Einlesen:
            Console.WriteLine("Seriennummernprüfung von Eurobanknoten");
            string seriennummer;
            bool eingabeFalsch = true;
            do
            {
                Console.WriteLine("Seriennummer eingeben:");
                seriennummer = Console.ReadLine().ToUpper();
                //Eingabeformat überprüfen
                bool BedingungZiffern = true;
                for (int i = 2; i < seriennummer.Length; i++)
                {
                   if(!Char.IsDigit(seriennummer[i]))
                    {
                        BedingungZiffern = false;
                    }
                }

                if(seriennummer.Length!=12)
                {
                    Console.WriteLine("Die eingegebene Seriennummer hat nicht die richtige Länge.");
                    Console.WriteLine("Die Seriennummer hat das Format XX0000000000, wobei X für Buchstaben (A-Z) und 0 für Ziffern (0-9) steht.");
                    eingabeFalsch = true;
                }
                else if (!Char.IsLetter(seriennummer[0]) || !Char.IsLetter(seriennummer[1]))
                    // ! Umkehrung von Wahrheitswerten
                {
                    Console.WriteLine("Die eingegebene Seriennummer muss an den ersten beiden Stellen Buchstaben enthalten.");
                    Console.WriteLine("Die Seriennummer hat das Format XX0000000000, wobei X für Buchstaben (A-Z) und 0 für Ziffern (0-9) steht.");
                    eingabeFalsch = true;
                }
                else if (!BedingungZiffern)
                {
                    Console.WriteLine("Die eingegebene Seriennummer muss an den letzten zehn Stellen Ziffern enthalten.");
                    Console.WriteLine("Die Seriennummer hat das Format XX0000000000, wobei X für Buchstaben (A-Z) und 0 für Ziffern (0-9) steht.");
                    eingabeFalsch = true;
                }
                else
                {
                    Console.WriteLine("Folgende Seriennummer wird überprüft: " + seriennummer);
                    eingabeFalsch = false;
                }
            } while (eingabeFalsch);

            string Prüfnummer="";      
            for (int i = 0; i < seriennummer.Length; i++)
            {
                if (i < 2)
                {
                    Prüfnummer += Convert.ToString(Convert.ToInt32(seriennummer[i]) - 64);
                }
                else
                {
                    Prüfnummer += seriennummer[i];
                }
            }

            //Console.WriteLine("Prüfnummer: "+Prüfnummer);
            int Quersumme=0;
            for (int i = 0; i < Prüfnummer.Length-1; i++)
            {
                Quersumme += Convert.ToInt32(Prüfnummer[i].ToString());
            }
            //Console.WriteLine("Quersumme: " + Quersumme);

            int Rest = Quersumme % 9;
            //Console.WriteLine("Rest: "+Rest);
            int Differenz = 7 - Rest;
            //Console.WriteLine("Differenz: "+Differenz);

            int Prüfziffer;

            if (Differenz == 0) Prüfziffer = 9;
            else if (Differenz == -1) Prüfziffer = 8;
            else Prüfziffer = Differenz;

            //Console.WriteLine("Prüfziffer: " + Prüfziffer);//".gjklrhwiregn" = '5', 'g', .... => "5,7"
            //Console.WriteLine("Letzte Stelle: " + Convert.ToInt32(Convert.ToString(Prüfnummer[Prüfnummer.Length - 1])));
            //Console.WriteLine("CharToString: " + Convert.ToString(Prüfnummer[Prüfnummer.Length - 1]));
            if (Prüfziffer == Convert.ToInt32(Convert.ToString(Prüfnummer[Prüfnummer.Length - 1])))
            {
                Console.WriteLine("Seriennummer ist echt.");
            }
            else
            {
                Console.WriteLine("Seriennummer ist falsch.");
            }

            //Console.WriteLine(Prüfnummer);
            //Console.WriteLine(Quersumme);





            Console.ReadKey();
        }
    }
}
