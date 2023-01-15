using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zeiterfassungsprogramm
{

    // Interface für Administrative Tätigkeiten.
    public interface IAdministrativ {

        int PermissionLevel { get; set; }

        //Methoden
        void SetFerien(Arbeiter arbeiter,int ferientage);
        void SetLohnzuschlag(Arbeiter arbeiter,int zuschlag);

    }

}
