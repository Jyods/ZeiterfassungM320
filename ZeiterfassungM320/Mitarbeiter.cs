using System;
using Zeiterfassung;
using Zeiterfassungsprogramm;

namespace Zeiterfassungsprogramm
{
    public class Mitarbeiter : Person
    {
        public int Resturlaub { get; set; }
        public int abgezogenerUrlaub { get; set; }
        public string Arbeit { get; set; }
        public int Urlaub { get; set; }
        public int Arbeitsstunden { get; set; }

        public Mitarbeiter(string name, int alter, string arbeit, int urlaub, int arbeitsstunden) : base(name, alter)
        {
            this.Arbeit = arbeit;
            this.Urlaub = urlaub;
            this.Arbeitsstunden = arbeitsstunden;
        }

        public virtual int ArbeitsstundenModifizieren(int stunden)
        {
            this.Arbeitsstunden = stunden;
            return this.Arbeitsstunden;
        }

        public int UrlaubAbziehen(int anzahlTage)
        {
            if ((this.Urlaub - anzahlTage) < 0)
            {
                Console.Clear();
                // Mitarbeiter kann nicht in den Minus-Bereich gehen
                Console.WriteLine("Fehler: Mitarbeiter kann nicht in den Minus-Bereich gehen." + (this.Urlaub - anzahlTage));
                return this.Urlaub;
            }
            else
            {
                Console.Clear();
                // Urlaubstage abziehen
                this.Urlaub -= anzahlTage;
                Console.WriteLine($"{anzahlTage} Urlaubstage wurden von {Name} abgezogen.");
                Console.WriteLine($"Resturlaub: " + this.Urlaub);
                return this.Urlaub;
            }
        }

        public void UrlaubHinzufügen(int tage)
        {
            this.Urlaub += tage;
        }


    }

}
