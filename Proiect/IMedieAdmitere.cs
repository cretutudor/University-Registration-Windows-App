using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proiect
{
    interface IMedieAdmitere
    {
        double MedieBAC
        {
            get;
            set;
        }

        double MedieLiceu
        {
            get;
            set;
        }

        double NotaRomana
        {
            get;
            set;
        }

        double calculMedieAdmitere();
    }
}
