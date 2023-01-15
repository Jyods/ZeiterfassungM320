using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zeiterfassungsprogramm {

    //Klasse für den CEO. Administrative funktionen, ohne zeiterfassung
    public class CEO:User, IAdministrativ {

        public int PermissionLevel { get; set; }

        //Kunstruktoren
        public CEO(string vorname,string nachname) : base(nachname+vorname,vorname,nachname) {
            PermissionLevel = 100;
        }

        //Methoden
        public void SetFerien(Arbeiter arbeiter,int ferientage) {
            arbeiter.SetFerienguthaben(ferientage);
            Console.WriteLine($"CEO {GetGanzerName()} hat das Ferienguthaben {arbeiter.GetGanzerName()} auf {ferientage} gesetzt.");
        }

        public void SetLohnzuschlag(Arbeiter arbeiter,int zuschlag) {
            arbeiter.SetLohnZuschlag(zuschlag);
            Console.WriteLine($"CEO {GetGanzerName()} hat {arbeiter.GetGanzerName()} einen Lohnzuschlag von {zuschlag} gegeben.");
        }

        public void SetPermissionLevel(IAdministrativ adminUser,int permissionLevel) {
            adminUser.PermissionLevel = permissionLevel;
        }
    }
}
