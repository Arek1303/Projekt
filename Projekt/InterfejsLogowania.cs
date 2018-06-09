using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projekt
{
    //  Interfejs odpowiedzialny za logowanie
    interface InterfejsLogowania
    {
        int sprawdzPacjent(string username, string password);
        int sprawdzLekarz(string username, string password);
    }
}
