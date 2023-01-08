using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZeiterfassungM320 {

    // Interface für Administrative Tätigkeiten.
    public interface IAdministrativ {

        int PermissionLevel { get; set; }

        void SetFerien(Arbeiter arbeiter,int ferientage);
        void SetLohnzuschlag(Arbeiter arbeiter,int zuschlag);

    }
}
