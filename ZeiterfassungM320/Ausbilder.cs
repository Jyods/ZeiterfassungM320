using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zeiterfassungsprogramm
{

    //Spezialisierte Klasse für Ausbilder. Sie haben Zeiterfassung aber auch Administrative funktionen.
    public class Ausbilder:Arbeiter, IAdministrativ {

        public int PermissionLevel { get; set; }

        public void SetFerien(Arbeiter arbeiter,int ferientage) {
            if(arbeiter.Vorgesetzter == this) {
                arbeiter.Ferienguthaben = ferientage;
            }
        }

        public void SetLohnzuschlag(Arbeiter arbeiter,int zuschlag) {
            if(arbeiter.Vorgesetzter == this) {
                arbeiter.LohnZuschlag = zuschlag;
            }
        }

        //Konstruktoren
        public Ausbilder(string vorname,string nachname,int alter,Arbeiter vorgesetzter,Funktion funktion):base(vorname,nachname,alter,vorgesetzter,funktion) {
            PermissionLevel = 5;
        }
        public Ausbilder(string vorname,string nachname, int alter, Arbeiter vorgesetzter,Funktion funktion,int permissionLevel) : base(vorname,nachname,alter,vorgesetzter,funktion) {
            PermissionLevel = Math.Max(permissionLevel,5);
        }

    }

}
