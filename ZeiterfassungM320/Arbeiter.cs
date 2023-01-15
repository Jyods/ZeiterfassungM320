using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zeiterfassungsprogramm
{
    //Klasse für User mit Zeiterfassung.
    public class Arbeiter : User, IAnzeige {

        private Arbeiter _vorgesetzter;
        private Funktion _funktion;
        private int _lohnZuschlag;
        private int _alter;
        private int _ferienguthaben;
        private int _ferienbezug;
        private int _arbeitsstunden;

        // Konstruktor
        public Arbeiter(string vorname,string nachname,int alter,Arbeiter vorgesetzer,Funktion funktion) : base(nachname+vorname,vorname,nachname) {
            SetVorgesetzer(vorgesetzer);
            SetFunktion(funktion);
            SetFerienguthaben(35);
            SetAlter(alter);
        }
        public Arbeiter(string vorname,string nachname,int alter,Arbeiter vorgesetzer,Funktion funktion,int ferienguthaben) : base(nachname+vorname,vorname,nachname) {
            SetVorgesetzer(vorgesetzer);
            SetFunktion(funktion);
            SetFerienguthaben(ferienguthaben);
            SetAlter(alter);
        }

        //Methoden
        public virtual void Anzeige()
        {
            Console.WriteLine($"Name: {GetGanzerName()}");
            Console.WriteLine($"Alter: {GetAlter()}");
            Console.WriteLine($"Arbeit: {GetFunktion().Bezeichnung}");
            Console.WriteLine($"Resturlaub: {GetFerienguthaben()}");
            Console.WriteLine($"Überzeit: {GetArbeitsstunden()}");
        }


        #region Getter & Setter
        //Vorgesetzer
        public virtual Arbeiter GetVorgesetzer() { return _vorgesetzter; }
        public virtual void SetVorgesetzer(Arbeiter vorgesetzer) { _vorgesetzter = vorgesetzer; }

        //Funktion;
        public virtual Funktion GetFunktion() { return _funktion; }
        public virtual void SetFunktion(Funktion funktion) { _funktion = funktion; }

        //Lohnzuschlag;
        public virtual int GetLohnZuschlag() { return _lohnZuschlag; }
        public virtual void SetLohnZuschlag(int zuschlag) {
			if(zuschlag >= 0) {
                _lohnZuschlag = zuschlag;
            } else {
                _lohnZuschlag = 0;
                Console.WriteLine("Lohnzuschlag kann nicht negativ sein!");
			}
        }

        //Alter;
        public virtual int GetAlter() { return _alter; }
        public virtual void SetAlter(int alter) { _alter = alter; }

        //Ferienguthaben;
        public virtual int GetFerienguthaben() { return _ferienguthaben; }
        public virtual void SetFerienguthaben(int guthaben) {
            if(guthaben < 30) {
                Console.WriteLine("Arbeiter müssen mindestens 30 Ferientage haben!");
                _ferienguthaben = 30;
            } else {
                _ferienguthaben = guthaben;
            }
        }

        //Ferienbezug;
        public virtual int GetFerienbezug() { return _ferienbezug; }
        public virtual void SetFerienbezug(int bezug) { _ferienbezug = bezug; }

        //Arbeitsstunden;
        public virtual int GetArbeitsstunden() { return _arbeitsstunden; }
        public virtual void SetArbeitsstunden(int stunden) { _arbeitsstunden = stunden; }

        //Persönlicher Lohn
        public virtual int GetPeroenlichenLohn() { return GetFunktion().Lohn + GetLohnZuschlag(); }
        #endregion
    }
}
