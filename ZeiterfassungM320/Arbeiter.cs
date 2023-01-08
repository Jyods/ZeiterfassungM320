using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZeiterfassungM320 {

    //Klasse für User mit Zeiterfassung.
    public class Arbeiter : User {

        public virtual Arbeiter Vorgesetzter { get; set; }
        public virtual Funktion Funktion { get; set; }
        public virtual int LohnZuschlag { get; set; }
        public virtual int PeroenlicherLohn { get { return Funktion.Lohn + LohnZuschlag; } }

        public virtual int Ferienguthaben { get { return Ferienguthaben; } set { Ferienguthaben = Math.Max(value,35); } }
        public virtual int Ferienbezug { get; set; }

        // Konstruktor
        public Arbeiter(string vorname,string nachname,Arbeiter vorgesetzer,Funktion funktion) : base(nachname+vorname,vorname,nachname) {
            Vorgesetzter = vorgesetzer;
            Funktion = funktion;
            Ferienguthaben = 35;
        }
        public Arbeiter(string vorname,string nachname,Arbeiter vorgesetzer,Funktion funktion,int ferienguthaben) : base(nachname+vorname,vorname,nachname) {
            Vorgesetzter = vorgesetzer;
            Funktion = funktion;
            Ferienguthaben = ferienguthaben;
        }

        //TODO: add functions for anfrage, ... 🤖🤖🤖

    }
}
