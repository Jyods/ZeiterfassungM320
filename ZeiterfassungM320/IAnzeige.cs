using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zeiterfassungsprogramm
{
    interface IAnzeige
    {

        //  Zitat Chatbot GPT:
        //  Das Interface IAnzeige ermöglicht es, dass jede Klasse, die es implementiert, über eine Methode namens "Anzeige()" verfügt.
        //  Diese Methode kann dazu verwendet werden, um die Eigenschaften eines Objekts der Klasse anzuzeigen.
        //  Das Interface ist eine Art "Vereinbarung" darüber, dass jede Klasse, die es implementiert, eine Methode "Anzeige()" besitzen sollte, die bestimmte Informationen über das Objekt ausgibt.
        //  Durch das Interface wird sichergestellt, dass jede Klasse, die es implementiert, die gleiche Methode hat und somit die gleiche Funktionalität bietet.
        void Anzeige();
    }
}
