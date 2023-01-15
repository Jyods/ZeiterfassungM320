using System;
using System.Xml.Linq;
using Zeiterfassungsprogramm;

namespace Zeiterfassungsprogramm
{
    //Spezialisierte Klasse für Lernende. Sie haben spezielle Regelungen.
    public class Lernender : Arbeiter
    {
        private Ausbilder _ausbilder;

        //Konstruktor
        public Lernender(string vorname, string nachname, int alter, Ausbilder ausbilder, Funktion ausbildung) : base(vorname, nachname, alter, ausbilder, ausbildung,40) {
            SetAusbilder(ausbilder);
        }
        public Lernender(string vorname, string nachname, int alter, Ausbilder ausbilder, Funktion ausbildung, int ferientage) : base(vorname, nachname, alter, ausbilder, ausbildung, ferientage) {
            SetAusbilder(ausbilder);
        }

        //Methoden
        public override void Anzeige()
        {
            base.Anzeige();
            Console.WriteLine($"Ausbilder: {GetAusbilder().GetGanzerName()}");
        }

        #region Getter & Setter
        //Ausbilder
        public Arbeiter GetAusbilder() { return _ausbilder; } //Gibt den Ausbilder als Arbeiter zurück -> Polymorphie
        public void SetAusbilder(Ausbilder ausbilder) { _ausbilder = ausbilder; }

        //Ferienguthaben
        public override void SetFerienguthaben(int guthaben) {
            if(guthaben < 35) {
                Console.WriteLine("Lernende müssen mindestens 35 Ferientage haben!");
                Console.ReadKey();
            } else {
                base.SetFerienguthaben(guthaben);
            }
        }

        //Arbeitsstunden
        public override void SetArbeitsstunden(int stunden) {
            if(stunden > 10) {
                Console.WriteLine("Lernende dürfen maximal 10 Arbeitsstunden haben!");
                Console.ReadKey();
            } else {
                base.SetArbeitsstunden(stunden);
            }
        }
        #endregion
    }
}