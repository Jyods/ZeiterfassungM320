using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zeiterfassung {

    // Interface für Administrative Tätigkeiten.
    public interface IAdministrativ {

        int PermissionLevel { get; set; }

        void SetFerien(Arbeiter arbeiter,int ferientage);
        void SetLohnzuschlag(Arbeiter arbeiter,int zuschlag);

    }

    //IMPORTANT TODO: 
    //(maybe) anstatt administrativ Interface ein interface für ZEITERFASSUNG machen!!! MAKES MORE SENSE! Arbeiter implements dann IZeiterfassung
    //Klasse für CEO machen
}
