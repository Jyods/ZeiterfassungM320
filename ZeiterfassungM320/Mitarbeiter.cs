using System;
using Zeiterfassung;
using Zeiterfassung;
using Zeiterfassungsprogramm_old;

namespace Zeiterfassungsprogramm_old
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
            if (this.Resturlaub - anzahlTage < 0)
            {
                // Mitarbeiter kann nicht in den Minus-Bereich gehen
                Console.WriteLine("Fehler: Mitarbeiter kann nicht in den Minus-Bereich gehen.");
                return this.Resturlaub;
            }
            else
            {
                // Urlaubstage abziehen
                this.abgezogenerUrlaub += anzahlTage;
                return this.Resturlaub;
            }
        }

        public void UrlaubHinzufügen(int tage)
        {
            this.Urlaub += tage;
        }


    }

}
