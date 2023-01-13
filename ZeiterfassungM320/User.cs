using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zeiterfassungsprogramm {

    //Basisklasse für alle Benutzer
    public abstract class User {

        public string Username { get; set; }
        public string Vorname { get; set; }
        public string Nachname { get; set; }
        public string GanzerName { get { return Vorname+" "+Nachname; } }

        // Konstruktoren
        public User(string username) {
            Username = username;
        }
        public User(string username,string vorname,string nachname) {
            Username = username;
            Vorname = vorname;
            Nachname = nachname;
        }

    }
}
