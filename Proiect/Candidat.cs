using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using iText.Layout;

namespace Proiect
{
    public class Candidat : IComparable<Candidat>, ICloneable
    {
        public string nume;
        public string initialaTatalui;
        public string prenume;
        public char sex;
        private long cnp;
        private string serie;
        private int numar;
        public int telefon;
        private string email;
        private string tara;
        private string judet;
        private string localitate;
        private string adresa;
        public Facultate facultateAleasa;
        public Medii medii;
        public string optiuneFacultate;
        public Document dosar;

        public Candidat(string nume, string initiala, string prenume, char sex, long cnp, string serie, int numar, 
                        int telefon, string email, string tara, string judet, string localitate, string adresa, 
                        Facultate facultateAleasa, Medii medii, string optiuneFacultate, Document dosar)
 
        {
            this.nume = nume;
            this.initialaTatalui = initiala;
            this.prenume = prenume;
            this.sex = sex;
            this.cnp = cnp;
            this.serie = serie;
            this.numar = numar;
            this.telefon = telefon;
            this.email = email;
            this.tara = tara;
            this.judet = judet;
            this.localitate = localitate;
            this.adresa = adresa;
            this.facultateAleasa = facultateAleasa;
            this.medii = medii;
            this.optiuneFacultate = optiuneFacultate;
            this.dosar = dosar;
        }
        
        //constructor doar cu elementele din listView
        public Candidat(string nume, string initiala, string prenume, Facultate facultateAleasa, Medii medii, string optiuneFacultate)
        {
            this.nume = nume;
            this.initialaTatalui = initiala;
            this.prenume = prenume;
            this.facultateAleasa = facultateAleasa;
            this.medii = medii;
            this.optiuneFacultate = optiuneFacultate;
            
        }

        public string afisareNumeComplet()
        {
            return this.nume + " " + this.initialaTatalui + ". " + this.prenume;
        }

        public static explicit operator double(Candidat c)
        {
            return c.medii.calculMedieAdmitere();
        }

        public object Clone()
        {
            Candidat c = (Candidat)this.MemberwiseClone();

            Medii mediiNoi = (Medii)medii.Clone();
            medii = mediiNoi;

            Facultate facultateNoua = (Facultate)facultateAleasa.Clone();
            facultateAleasa = facultateNoua;
            
            return c;
        }

        //folosit in implementarea clasei cu care se sorteaza candidatii
        public int CompareTo(Candidat c)
        {
            if ((double)this > (double)c)
            {
                return -1;
            }
            else if ((double)this < (double)c)
            {
                return 1;
            }
            else
            {
                if (this.medii.NotaRomana > c.medii.NotaRomana)
                {
                    return -1;
                }
                else if (this.medii.NotaRomana < c.medii.NotaRomana)
                {
                    return 1;
                }
                else
                {
                    return 0;
                }
            }
        }

        //proprietati
        public long CNP
        {
            get { return cnp; }
            set
            {
                if (value > 0)
                    cnp = value;
            }
        }

        public string Serie
        {
            get { return serie; }
            set
            {
                if (value != null)
                    serie = value;
            }
        }

        public int Numar
        {
            get { return numar; }
            set
            {
                if (value > 0)
                    numar = value;
            }
        }

        public Document Dosar
        { 
            get { return this.dosar; }        
        }

    }
}
