using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace OOP_Arena
{
    class Arena
    {
        private Bojovnik _bojovnik1;
        private Bojovnik _bojovnik2;
        private Kostka _kostka;

        public Arena(Bojovnik bojovnik1, Bojovnik bojovnik2, Kostka kostka)
        {
            this._bojovnik1 = bojovnik1;
            this._bojovnik2 = bojovnik2;
            this._kostka = kostka;
        }
        private void VykresliArenu()
        {
            Console.Clear();
            Console.WriteLine("  /$$$$$$                                         \r\n /$$__  $$                                        \r\n| $$  \\ $$  /$$$$$$   /$$$$$$  /$$$$$$$   /$$$$$$ \r\n| $$$$$$$$ /$$__  $$ /$$__  $$| $$__  $$ |____  $$\r\n| $$__  $$| $$  \\__/| $$$$$$$$| $$  \\ $$  /$$$$$$$\r\n| $$  | $$| $$      | $$_____/| $$  | $$ /$$__  $$\r\n| $$  | $$| $$      |  $$$$$$$| $$  | $$|  $$$$$$$\r\n|__/  |__/|__/       \\_______/|__/  |__/ \\_______/\r\n                                                  \r\n                                                  \r\n                                                  ");

            Console.WriteLine("Zdraví bojovníků: \n");
            Console.WriteLine("{0} {1}", _bojovnik1, _bojovnik1.VratGrafickyPekneZivoty());
            Console.WriteLine("{0} {1}", _bojovnik2, _bojovnik2.VratGrafickyPekneZivoty());
        }

        private void VypisZpravu(string zprava)
        {
            Console.WriteLine(zprava);
            Thread.Sleep(500);
        }
        public void SpustZapas()
        {
            Console.Clear();
            Console.WriteLine("  /$$$$$$                                         \r\n /$$__  $$                                        \r\n| $$  \\ $$  /$$$$$$   /$$$$$$  /$$$$$$$   /$$$$$$ \r\n| $$$$$$$$ /$$__  $$ /$$__  $$| $$__  $$ |____  $$\r\n| $$__  $$| $$  \\__/| $$$$$$$$| $$  \\ $$  /$$$$$$$\r\n| $$  | $$| $$      | $$_____/| $$  | $$ /$$__  $$\r\n| $$  | $$| $$      |  $$$$$$$| $$  | $$|  $$$$$$$\r\n|__/  |__/|__/       \\_______/|__/  |__/ \\_______/\r\n                                                  \r\n                                                  \r\n                                                  ");
            Console.WriteLine("Vítejte v aréně!");
            Console.WriteLine($"Dnes se utkají {_bojovnik1} a {_bojovnik2}! \n");
            Console.WriteLine("Zápas může začít...");
            Console.ReadKey();
            // cyklus s bojem
            while (_bojovnik1.JeNazivu() && _bojovnik2.JeNazivu())
            {
                _bojovnik1.Utoc(_bojovnik2);
                VykresliArenu();
                VypisZpravu(_bojovnik1.Zprava); // zpráva o útoku
                VypisZpravu(_bojovnik2.Zprava); // zpráva o obraně
                _bojovnik2.Utoc(_bojovnik1);
                VykresliArenu();
                VypisZpravu(_bojovnik2.Zprava); // zpráva o útoku
                VypisZpravu(_bojovnik1.Zprava); // zpráva o obraně
                Console.WriteLine();
            }
        }
    }


}
