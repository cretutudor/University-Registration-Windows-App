using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proiect
{
    public class Medii : IMedieAdmitere, ICloneable
    {
        private double medieBAC;
        private double medieLiceu;
        private double notaRomana;

        public Medii(double medieBAC, double medieLiceu, double notaRomana)
        {
            this.medieBAC = medieBAC;
            this.medieLiceu = medieLiceu;
            this.notaRomana = notaRomana;
        }

        public double MedieBAC
        {
            get { return medieBAC; }
            set { if (value > 0)
                    medieBAC = value; }
        }

        public double MedieLiceu
        {
            get { return medieLiceu; }
            set { if (value > 0) 
                    medieLiceu = value; }
        }

        public double NotaRomana
        {
            get { return notaRomana; }
            set { if (value > 0)
                    notaRomana = value; }
        }

        public double calculMedieAdmitere()
        {
            return ((0.7 * MedieBAC) + (0.3 * MedieLiceu)); 
        }

        public object Clone()
        {
            Medii m = (Medii)this.MemberwiseClone();

            return m;
        }
    }
}
