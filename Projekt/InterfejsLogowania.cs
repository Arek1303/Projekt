using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projekt
{
    //  Interfejs odpowiedzialny za logowanie
    interface IInterfejsLogowania
    {
        int CheckPatient(string username, string password);
        int ChecKDoctor(string username, string password);
    }
}
