using System;
using System.Xml.Linq;
using Zeiterfassungsprogramm;

namespace Zeiterfassung {
    public class Lernender : Arbeiter //Spezialisierte Klasse für Lernende. Sie haben spezielle Regelungen.
    {
        public Ausbilder Ausbilder { get; set; }
        public override int Ferienguthaben { get { return Ferienguthaben; } set { Ferienguthaben = Math.Max(value,40); } }

        //Konstruktor
        public Lernender(string vorname,string nachname,Ausbilder ausbilder,Funktion ausbildung):base(vorname,nachname,ausbilder,ausbildung,35) {

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
            this.Urlaub += tage;
        }

        public override void Anzeige()
        {
            base.Anzeige();
            Console.WriteLine($"Ausbilder: {Ausbilder.Name}");
        }
    }

}