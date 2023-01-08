using System;
using System.Xml.Linq;
using ZeiterfassungM320;
using Zeiterfassungsprogramm;

namespace Zeiterfassungsprogramm
{
    public class Lernender : Arbeiter //Spezialisierte Klasse für Lernende. Sie haben spezielle Regelungen.
    {
        public Ausbilder Ausbilder { get; set; }
        public override int Ferienguthaben { get { return Ferienguthaben; } set { Ferienguthaben = Math.Max(value,40); } }

        //Konstruktor
        public Lernender(string vorname,string nachname,Ausbilder ausbilder,Funktion ausbildung):base(vorname,nachname,ausbilder,ausbildung,35) {

        }
        
    }

}