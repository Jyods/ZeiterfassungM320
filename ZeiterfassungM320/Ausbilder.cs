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

        //Konstruktoren
        public Ausbilder(string vorname,string nachname,int alter,Arbeiter vorgesetzter,Funktion funktion):base(vorname,nachname,alter,vorgesetzter,funktion) {
            PermissionLevel = 5;
        }

        //Methoden
        public void SetFerien(Arbeiter arbeiter,int ferientage) {
            if(arbeiter.GetVorgesetzer() == this) {
                arbeiter.SetFerienguthaben(ferientage);
                Console.WriteLine($"{GetGanzerName()} hat das Ferienguthaben {arbeiter.GetGanzerName()} auf {ferientage} gesetzt.");
            } else {
                Console.WriteLine($"{GetGanzerName()} kann nicht die Ferien von {arbeiter.GetGanzerName()} verändern!");
            }
        }

        public void SetLohnzuschlag(Arbeiter arbeiter,int zuschlag) {
            if(arbeiter.GetVorgesetzer() == this) {
                arbeiter.SetLohnZuschlag(zuschlag);
                Console.WriteLine($"{GetGanzerName()} hat {arbeiter.GetGanzerName()} einen Lohnzuschlag von {zuschlag} gegeben.");
            } else {
                Console.WriteLine($"{GetGanzerName()} kann nicht den Lohnzuschlag von {arbeiter.GetGanzerName()} verändern!");
            }
        }


    }

}
