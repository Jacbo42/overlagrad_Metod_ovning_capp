using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Överlagrad_Metod_Övning_capp
{
    internal class Program
    {
        private static readonly Random random = new Random();

        static void Main(string[] args)
        {
            Console.WriteLine("Välkommen till tärningskastningsprogrammet!");

            int resultat1 = KastaTärning(3);

            Console.Write("Ange antal sidor: ");
            if (int.TryParse(Console.ReadLine(), out int sidor))
            {
                Console.Write("Ange antal kast: ");
                if (int.TryParse(Console.ReadLine(), out int kast))
                {
                    int resultat2 = KastaTärning(sidor, kast);

                    Console.Write("Ange antal kast (x) och antal sidor (y) i formatet XTY: ");
                    string tärning = Console.ReadLine();
                    int resultat3 = KastaTärning(tärning);

                    Console.WriteLine($"Resultatet av 3T6 är: {resultat1}");
                    Console.WriteLine($"Resultatet av {kast}T{sidor} är: {resultat2}");
                    Console.WriteLine($"Resultatet av {tärning} är: {resultat3}");
                }
                else
                {
                    Console.WriteLine("Ogiltigt antal kast.");
                }
            }
            else
            {
                Console.WriteLine("Ogiltigt antal sidor.");
            }

            Console.ReadLine();

        }

        static int KastaTärning(int antalGånger)
        {
            int totaltResultat = 0;

            for (int i = 0; i < antalGånger; i++)
            {
                int resultat = random.Next(1, 7);
                totaltResultat += resultat;
            }

            return totaltResultat;
        }
        static int KastaTärning(int antalsidor, int antalGånger)
        {
            int totaltResultat = 0;

            for (int i = 0; i < antalGånger; i++)
            {
                int resultat = random.Next(1, antalsidor + 1);
                totaltResultat += resultat;
            }

            return totaltResultat;
        }

        static int KastaTärning(string tärning)
        {
            string[] delar = tärning.Split('T');
            if (delar.Length != 2)
            {
                throw new ArgumentException("Felaktig format. Använd formatet 'XTY' där X är antal gånger och Y är antal sidor.");
            }

            int antalGånger = int.Parse(delar[0]);
            int antalSidor = int.Parse(delar[1]);

            return KastaTärning(antalSidor, antalGånger);
        }
    }
}
