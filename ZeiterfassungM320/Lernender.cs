using System;
using System.Xml.Linq;
using ZeiterfassungM320;
using Zeiterfassungsprogramm;

namespace Zeiterfassungsprogramm
{
    public class Lernender : Mitarbeiter
    {
        public Ausbilder Ausbilder { get; set; }

        public Lernender(string name, int alter, string arbeit, int urlaub, int arbeitsstunden, Ausbilder ausbilder) : base(name, alter, arbeit, urlaub, arbeitsstunden)
        {
            this.Ausbilder = ausbilder;
        }

        public override int ArbeitsstundenModifizieren(int stunden)
        {
            if (stunden > 10)
            {
                Console.WriteLine("Lernende dürfen maximal 10 Arbeitsstunden haben. Bitte geben Sie eine gültige Anzahl ein.");
                return this.Arbeitsstunden;
            }
            else
            {
                return base.ArbeitsstundenModifizieren(stunden);
            }
        }

        public void UrlaubHinzufügen(int tage)
        {
            this.Urlaub += tage;
        }
    }

}