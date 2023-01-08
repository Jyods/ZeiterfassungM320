using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zeiterfassung {

    //Klasse für Administratoren. Sie haben keine Zeiterfassung aber haben Administrative funktionen.
    public class Admin:User, IAdministrativ {

        public int PermissionLevel { get; set; }

        public void SetFerien(Arbeiter arbeiter,int ferientage) {
            arbeiter.Ferienguthaben = ferientage;
        }

        public void SetLohnzuschlag(Arbeiter arbeiter,int zuschlag) {
            arbeiter.LohnZuschlag = zuschlag;
        }

        // Konstruktoren
        public Admin(string username):base(username) {
            PermissionLevel = 1;
        }
        public Admin(string username,int permissionLevel) : base(username) {
            PermissionLevel = permissionLevel;
        }
        public Admin(string username,string vorname,string nachname) : base(username,vorname,nachname) {
            PermissionLevel = 1;
        }
        public Admin(string username,string vorname,string nachname,int permissionLevel) : base(username,vorname,nachname) {
            PermissionLevel = permissionLevel;
        }

    }
}
