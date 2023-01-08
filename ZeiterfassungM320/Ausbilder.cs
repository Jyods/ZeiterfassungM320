using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zeiterfassungsprogramm;

namespace ZeiterfassungM320 {

    public class Ausbilder : Mitarbeiter
    {
        public List<Lernender> LernenderListe { get; set; }

        public Ausbilder(string name, int alter, string arbeit, int urlaub, int arbeitszeit) : base(name, alter, arbeit, urlaub, arbeitszeit)
        {
            this.LernenderListe = new List<Lernender>();
        }

        public void AddLernender(Lernender lernender)
        {
            this.LernenderListe.Add(lernender);
        }
    }

}
