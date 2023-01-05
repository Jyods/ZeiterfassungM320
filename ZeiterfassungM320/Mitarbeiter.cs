using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZeiterfassungM320
{
    class Mitarbeiter
    {

            // Eigenschaften der Klasse Mitarbeiter
            public string Name { get; set; }
            public int Alter { get; set; }
            public string Arbeit { get; set; }
            public int Urlaub { get; set; }
            public int Arbeitszeit { get; set; }

            // Konstruktor für die Klasse Mitarbeiter
            public Mitarbeiter(string name, int alter, string arbeit, int urlaub, int arbeitszeit)
            {
                Name = name;
                Alter = alter;
                Arbeit = arbeit;
                Urlaub = urlaub;
                Arbeitszeit = arbeitszeit;
            }

            // Methode zum Hinzufügen von Arbeitszeit
            public void AddArbeitszeit(int arbeitszeit)
            {
                Arbeitszeit += arbeitszeit;
            }

        public void SubtractUrlaub(int urlaub)
        {
            if (Urlaub - urlaub >= 0)
            {
                Urlaub -= urlaub;
            }
            else
            {
                Console.WriteLine("Der Mitarbeiter hat nicht genügend Urlaubstage übrig. Trotzdem fortfahren? (j/n)");
                string input = Console.ReadLine();
                if (input == "j")
                {
                    Urlaub -= urlaub;
                }
                else
                {
                    Console.WriteLine("Abgebrochen");
                    Console.ReadKey();
                }
            }
        }

        public void AddUrlaub(int urlaub)
        {
   
                Console.WriteLine($"Sicher dass Sie dem Mitarbeiter {urlaub} hinzufügen möchten? (j/n)");
                string input = Console.ReadLine();
                if (input == "j")
                {
                    Urlaub += urlaub;
                }
            else
            {
                Console.WriteLine("Abgebrochen");
                Console.ReadKey();
            }
            }
        }
    }
