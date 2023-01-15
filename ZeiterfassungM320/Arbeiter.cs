using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zeiterfassungsprogramm;

namespace Zeiterfassungsprogramm
{
    public class Arbeiter : User, IAnzeige {

        public virtual Arbeiter Vorgesetzter { get; set; }
        public virtual Funktion Funktion { get; set; }
        public virtual int LohnZuschlag { get; set; }
        public virtual int PeroenlicherLohn { get { return Funktion.Lohn + LohnZuschlag; } }
        public int Alter { get; set; }

        private int _ferienguthaben;
        //public virtual int Ferienguthaben { get { return _ferienguthaben; } set { _ferienguthaben = Math.Max(value,35); } }
        public virtual int Ferienguthaben { get; set; }
        public virtual int Ferienbezug { get; set; }
        public int Arbeitsstunden { get; set; }

        // Konstruktor
        public Arbeiter(string vorname,string nachname,int alter,Arbeiter vorgesetzer,Funktion funktion) : base(nachname+vorname,vorname,nachname) {
            Vorgesetzter = vorgesetzer;
            Funktion = funktion;
            Ferienguthaben = 35;
            Alter = alter;
        }
        public Arbeiter(string vorname,string nachname,int alter,Arbeiter vorgesetzer,Funktion funktion,int ferienguthaben) : base(nachname+vorname,vorname,nachname) {
            Vorgesetzter = vorgesetzer;
            Funktion = funktion;
            Ferienguthaben = ferienguthaben;
            Alter = alter;
        }

        public virtual int ArbeitsstundenModifizieren(int stunden)
        {
            this.Arbeitsstunden = stunden;
            return this.Arbeitsstunden;
        }

        public int UrlaubAbziehen(int anzahlTage)
        {
            if ((this.Ferienguthaben - anzahlTage) < 0)
            {
                Console.Clear();
                // Mitarbeiter kann nicht in den Minus-Bereich gehen
                Console.WriteLine("Fehler: Mitarbeiter kann nicht in den Minus-Bereich gehen." + (this.Ferienguthaben - anzahlTage));
                return this.Ferienguthaben;
            }
            else
            {
                Console.Clear();
                // Urlaubstage abziehen
                this.Ferienguthaben -= anzahlTage;
                Console.WriteLine($"{anzahlTage} Urlaubstage wurden von {GanzerName} abgezogen.");
                Console.WriteLine($"Resturlaub: " + this.Ferienguthaben);
                return this.Ferienguthaben;
            }
        }

        public void UrlaubHinzufügen(int tage)
        {
            this.Ferienguthaben += tage;
        }

        public virtual void Anzeige()
        {
            Console.WriteLine($"Name: {GanzerName}");
            Console.WriteLine($"Alter: {Alter}");
            Console.WriteLine($"Arbeit: {Funktion.Bezeichnung}");
            Console.WriteLine($"Resturlaub: {Ferienguthaben}");
            Console.WriteLine($"Überzeit: {Arbeitsstunden}");
        }

        //TODO: add functions for anfrage, ... 🤖🤖🤖

    }
}
