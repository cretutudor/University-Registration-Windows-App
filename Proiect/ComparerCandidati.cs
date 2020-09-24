using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proiect
{
    class ComparerCandidati : IComparer<Candidat>
    {
        //metoda folosita la sortarea candidatilor
        public int Compare(Candidat x, Candidat y)
        {
            if ((double)x > (double)y)
            {
                return -1;
            }
            else if ((double)x < (double)y)
            {
                return 1;
            }
            else
            {
                if (x.medii.NotaRomana > y.medii.NotaRomana)
                {
                    return -1;
                }
                else if (x.medii.NotaRomana < y.medii.NotaRomana)
                {
                    return 1;
                }
                else
                {
                    return 0;
                }

            }

        }
    }
}
