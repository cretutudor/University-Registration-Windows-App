using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proiect
{
    public class Facultate : ICloneable
    {
        private string cod;
        private string nume;
        private int numarLocuri;
        public string[] listaSpecializari;
        private int numarSpecializari;

 
        public Facultate(string cod, string nume, int numarLocuri, string[] listaSpecializari, int numarSpecializari)
        {
            this.cod = cod;
            this.nume = nume;
            this.numarLocuri = numarLocuri;
            this.listaSpecializari = new string[numarSpecializari];
            for (int i = 0; i < numarSpecializari; i++)  
            {
                this.listaSpecializari[i] = listaSpecializari[i];
            }
            this.numarSpecializari = numarSpecializari;
        }

        public string Nume
        {
            get { return this.nume; }
        }

        public string Cod
        {
            get { return this.cod; }
        }


        public string this[int index]
        {
            get 
            {
                try
                {
                    return listaSpecializari[index];
                }
                catch (Exception ex)
                {
                    return ex.Message;
                }
                    
            }
            set { listaSpecializari[index] = value; }
        }

        public int NumarLocuri
        {
            get { return this.numarLocuri; }
            set { if (value > 0)
                    numarLocuri = value; }
        }

        public object Clone()
        {
            Facultate f = (Facultate)this.MemberwiseClone();

            string[] specializariNoi = (string[])listaSpecializari.Clone();
            f.listaSpecializari = specializariNoi;

            return f;
        }

    }
}
