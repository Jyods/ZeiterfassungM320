using System;
using System.Xml.Linq;
using Zeiterfassungsprogramm;

namespace Zeiterfassungsprogramm
{
    public class Lernender : Arbeiter //Spezialisierte Klasse für Lernende. Sie haben spezielle Regelungen.
    {
        // mem
        int _Ferienguthaben = 0;

        // mmeth
        public Ausbilder Ausbilder { get; set; }
        public override int Ferienguthaben { get { return _Ferienguthaben; } set { _Ferienguthaben = Math.Max(value, 40); } }

        public int Resturlaub { get; private set; }

        //Konstruktor
        public Lernender(string vorname, string nachname, int alter, Ausbilder ausbilder, Funktion ausbildung) : base(vorname, nachname, alter, ausbilder, ausbildung,40)
        {
            Ausbilder = ausbilder;
        }
        public Lernender(string vorname, string nachname, int alter, Ausbilder ausbilder, Funktion ausbildung, int urlaub) : base(vorname, nachname, alter, ausbilder, ausbildung, urlaub)
        {
            Ausbilder = ausbilder;
        }
        public override int ArbeitsstundenModifizieren(int stunden)
        {
            if (stunden > 10)
            {
                Console.WriteLine("Lernende dürfen maximal 10 Arbeitsstunden haben. Bitte geben Sie eine gültige Anzahl ein.");
                Console.ReadKey();
                return this.Arbeitsstunden;
            }
            else
            {
                return base.ArbeitsstundenModifizieren(stunden);
            }
        }

        public void UrlaubHinzufügen(int tage)
        {
            this.Resturlaub += tage;
        }

        public override void Anzeige()
        {
            base.Anzeige();
            Console.WriteLine($"Ausbilder: {Ausbilder.GanzerName}");
        }
    }
}