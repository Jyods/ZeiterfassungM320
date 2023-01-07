using System;
using Zeiterfassung;
using Zeiterfassungsprogramm;

namespace Zeiterfassungsprogramm
{
    public class Mitarbeiter : IMitarbeiter
    {
        public string Name { get; set; }
        public int Alter { get; set; }
        public string Arbeit { get; set; }
        public int Urlaub { get; set; }
        public int Arbeitsstunden { get; set; }

        public Mitarbeiter(string name, int alter, string arbeit, int urlaub, int arbeitsstunden)
        {
            Name = name;
            Alter = alter;
            Arbeit = arbeit;
            Urlaub = urlaub;
            Arbeitsstunden = arbeitsstunden;
            return;
        }

        public int UrlaubAbziehen(int anzahl)
        {
            if (Urlaub - anzahl < 0)
            {
                Console.WriteLine("Der Mitarbeiter hat nicht genug Urlaubstage.");
                return Urlaub;
            }
            else
            {
                Urlaub -= anzahl;
                return Urlaub;
            }
        }

        public int ArbeitsstundenBerechnen()
        {
            return this.Arbeitsstunden;
        }

        public void UrlaubHinzufuegen(int stunden)
        {
            this.Urlaub += stunden;
            return;
        }

        void IMitarbeiter.UrlaubAbziehen(int stunden)
        {
            throw new NotImplementedException();
        }
    }
}
