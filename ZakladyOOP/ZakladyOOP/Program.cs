
    using System;

    namespace ZákladyOOP
    {
        // TŘÍDA = Šablona pro hráče v hře
        public class Hrac
        {
            // 1. PRIVATE FIELD (soukromá proměnná) - skrytá před světem
            private int _zdravi;

            // 2. PUBLIC VLASTNOSTI (Properties) s GET a SET
            public string Jmeno { get; private set; } // Jméno jde přečíst odkudkoliv, ale měnit jen zevnitř

            public int Zdravi
            {
                get { return _zdravi; }
                private set
                {
                    // Validace v SETteru: zdraví nesmí klesnout pod 0 ani přesáhnout 100
                    if (value < 0) _zdravi = 0;
                    else if (value > 100) _zdravi = 100;
                    else _zdravi = value;
                }
            }

            // 3. KONSTRUKTOR (parametrický)
            public Hrac(string jmeno, int pocatecniZdravi)
            {
                Jmeno = jmeno;
                Zdravi = pocatecniZdravi; // Zavolá se náš setter s validací
            }

            // Přetížený konstruktor (využije defaultní hodnotu zdraví 100)
            public Hrac(string jmeno) : this(jmeno, 100)
            {
            }

            // Veřejná metoda (veřejné chování objektu)
            public void UtrpZraneni(int poskozeni)
            {
                Zdravi -= poskozeni; // Použije setter
                Console.WriteLine($"{Jmeno} utrpěl {poskozeni} zranění. Zbývá zdraví: {Zdravi}");
            }
        }

        class Program
        {
            static void Main()
            {
                // VYTVOŘENÍ INSTANCE / OBJEKTU pomocí konstruktoru a klíčového slova `new`
                Hrac hrac1 = new Hrac("Karel", 80);
                Hrac hrac2 = new Hrac("Petr"); // Použije druhý konstruktor (zdraví = 100)

                // Čtení přes public getter
                Console.WriteLine($"Hráč: {hrac1.Jmeno}, Zdraví: {hrac1.Zdravi}");

                // Změna stavu přes veřejnou metodu
                hrac1.UtrpZraneni(30);

                // TENTO ŘÁDEK BY SPŮSOBIL CHYBU KOMPILACE (private set):
                // hrac1.Zdravi = -50; 

                #region ke 4 a 5
                // === DEMO: struct vs class ===
                Console.WriteLine("--- STRUCT VS CLASS ---");

                // Structural copy (Kopírování hodnotou)
                BodStruct s1 = new BodStruct(10, 10);
                BodStruct s2 = s1; // Vytvoří se KOMPLETNÍ kopie
                s2.X = 99;
                Console.WriteLine($"Struct s1.X: {s1.X}"); // Zůstane 10!

                // Reference copy (Kopírování odkazem)
                BodClass c1 = new BodClass(10, 10);
                BodClass c2 = c1; // Zkopíruje se pouze ODKAZ (obě ukazují na stejný objekt)
                c2.X = 99;
                Console.WriteLine($"Class c1.X: {c1.X}");   // Změní se na 99!


                // === DEMO: static ===
                Console.WriteLine("\n--- STATIC ---");
                Uzivatel u1 = new Uzivatel("Anna");
                Uzivatel u2 = new Uzivatel("Ema");

                // Voláme přímo přes NÁZEV TŘÍDY, ne přes u1 nebo u2
                Console.WriteLine($"Celkový počet uživatelů: {Uzivatel.PocetUzivatelu}");
                #endregion

            }
        }

        // --- 4. STRUCT VS CLASS ---
        public struct BodStruct
        {
            public int X { get; set; }
            public int Y { get; set; }

            public BodStruct(int x, int y)
            {
                X = x;
                Y = y;
            }
        }

        public class BodClass
        {
            public int X { get; set; }
            public int Y { get; set; }

            public BodClass(int x, int y)
            {
                X = x;
                Y = y;
            }
        }

        // --- 5. STATIC ---
        public class Uzivatel
        {
            public string Jmeno { get; set; }

            // Statická proměnná sdílená pro VŠECHNY instance
            public static int PocetUzivatelu { get; private set; } = 0;

            public Uzivatel(string jmeno)
            {
                Jmeno = jmeno;
                PocetUzivatelu++; // Při každém vytvoření instance zvýšíme společné počítadlo
            }
        }
    }

