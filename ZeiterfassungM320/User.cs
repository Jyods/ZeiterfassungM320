using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zeiterfassungsprogramm {

    //Basisklasse für alle Benutzer
    public abstract class User {

        private string _username;
        private string _vorname;
        private string _nachname;

        // Konstruktoren
        public User(string username) {
            SetUsername(username);
        }
        public User(string username,string vorname,string nachname) {
            SetUsername(username);
            SetVorname(vorname);
            SetNachname(nachname);
        }

        #region Getter & Setter
        //Username
        public string GetUsername() { return _username;}
        public void SetUsername(string username) { _username = username; }

        //Vorname
        public string GetVorname() { return _vorname; }
        public void SetVorname(string vorname) { _vorname = vorname; }

        //Nachname
        public string GetNachname() { return _nachname; }
        public void SetNachname(string nachname) { _nachname = nachname; }

        //Ganzer Name
        public string GetGanzerName() { return _vorname+" "+_nachname; }
        #endregion
    }
}
