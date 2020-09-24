using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Proiect
{
    public partial class FormMeniuPrincipal : Form
    {
        List<Facultate> listaFacultati = new List<Facultate>();
        List<Candidat> listaCandidati = new List<Candidat>();

        static FormMeniuPrincipal form;

        public static FormMeniuPrincipal Instanta
        {
            get
            {
                if(form == null)
                {
                    form = new FormMeniuPrincipal();
                }
                return form;
            }
        }


        public FormMeniuPrincipal()
        {
            adaugareFacultati();
            preluareDate();
            InitializeComponent();
        }

        public void modificaPanel(UserControl userControl)
        {
            panel1.Controls.Clear();
            panel1.Controls.Add(userControl);
        }

        private void button1_Click(object sender, EventArgs e)
        {

            this.Width = 925;
            UserControl1 userControl1 = new UserControl1(listaFacultati);
            modificaPanel(userControl1);

            //adaugarea in lista candidatilor a fiecarui candidat care completeaza formularul de inscriere
            foreach (Candidat c in userControl1.listaCandidati)
            {
                listaCandidati.Add(c);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Width = 1310;
            panel1.Width = 1090;
            panel1.Width = this.Width;
            UserControl2 userControl2 = new UserControl2(listaCandidati, listaFacultati);
            modificaPanel(userControl2);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Width = 1160;
            panel1.Width = 1160;
            UserControl3 userControl3 = new UserControl3(listaCandidati, listaFacultati);
            modificaPanel(userControl3);
        }


        //functie care adauga facultatile intr-o lista
        public List<Facultate> adaugareFacultati()
        {
            //lista facultati si specializari din ase
            Facultate FABIZ = new Facultate("FABIZ", "Facultatea de Administrarea Afacerilor, cu predare in limbi straine", 580, new string[]
                                            {"Administrarea Afacerilor","Administrarea afacerilor - Engleza","Administrarea afacerilor - Franceza",
                                            "Administrarea afacerilor - Germana" }, 4);
            Facultate FAMP = new Facultate("FAMP", "Facultatea de Administratie si Management Public", 467, new string[]
                                            {"Administratie Publica","Resurse Umane" }, 2);
            Facultate BT = new Facultate("BT", "Facultatea de Business si Turism", 586, new string[]
                                          {"Administrarea afacerilor in comert, turism, servicii, merceologie si managementul calitatii",
                                           "Administrarea afacerilor in comert, turism, servicii, merceologie si managementul calitatii - Engleza" }, 2);
            Facultate CSIE = new Facultate("CSIE", "Facultatea de Cibernetica, Statistica si Informatica Economica", 914, new string[]
                                            {"Informatica Economica","Informatica Economica - Engleza","Cibernetica Economica",
                                             "Statistica si Previziune Economica" }, 4);
            Facultate CIG = new Facultate("CIG", "Facultatea de Contabilitate si Informatica de Gestiune", 645, new string[]
                                          {"Contabilitate si Informatica de gestiune","Contabilitate si Informatica de gestiune - Engleza" }, 2);
            Facultate FE = new Facultate("FE", "Facultatea de Economie Teoretica si Aplicata", 290, new string[]
                                         {"Economie si comunicare economica in afaceri" }, 1);
            Facultate FEAM = new Facultate("FEAM", "Facultatea de Economie Agroalimentara si a Mediului", 370, new string[]
                                           {"Economie agroalimentara si a mediului" }, 1);
            Facultate FABBV = new Facultate("FABBV", "Facultatea de Finante, Asigurari, Banci si Burse de Valori", 585, new string[]
                                            { "Finante si banci","Finante si banci - Engleza" }, 2);
            Facultate MAN = new Facultate("MAN", "Facultatea de Management", 690, new string[]
                                          { "Management","Management - Engleza" }, 2);
            Facultate MK = new Facultate("MK", "Facultatea de Marketing", 545, new string[] { "Marketing", "Marketing - Engleza" }, 2);
            Facultate REI = new Facultate("REI", "Facultatea de Relatii Economice Internationale", 650, new string[]
                                          { "Economie si afaceri internationale","Economie si afaceri internationale - Engleza","Limbi moderne aplicate" }, 3);
            listaFacultati.Add(FABIZ);
            listaFacultati.Add(FAMP);
            listaFacultati.Add(BT);
            listaFacultati.Add(CSIE);
            listaFacultati.Add(CIG);
            listaFacultati.Add(FE);
            listaFacultati.Add(FEAM);
            listaFacultati.Add(FABBV);
            listaFacultati.Add(MAN);
            listaFacultati.Add(MK);
            listaFacultati.Add(REI);

            return listaFacultati;
        }

        public void preluareDate()
        {
            string connString = "Provider = Microsoft.ACE.OLEDB.12.0; Data Source = Studenti.accdb";

            OleDbConnection conexiune = new OleDbConnection(connString);
            try
            {
                conexiune.Open();
                OleDbCommand comanda = new OleDbCommand("SELECT * FROM Studenti");
                comanda.Connection = conexiune;

                OleDbDataReader reader = comanda.ExecuteReader();
                while (reader.Read())
                {
                    string nume;
                    string initiala;
                    string prenume;
                    Facultate facultateAleasa = null;
                    string optiuneFacultate;

                    nume = reader["nume"].ToString();
                    initiala = reader["initiala"].ToString();
                    prenume = reader["prenume"].ToString();

                    foreach(Facultate f in listaFacultati)
                    {
                        if(reader["facultate"].ToString().Equals(f.Nume))
                        {
                            facultateAleasa = f;
                        }
                    }

                    optiuneFacultate = reader["specializare"].ToString();

                    double medieBAC = (double)reader["medie BAC"];
                    double medieLiceu = (double)reader["medie liceu"];
                    double notaRomana = (double)reader["nota departajare"];

                    Medii medii = new Medii(medieBAC, medieLiceu, notaRomana);

                    Candidat c = new Candidat(nume, initiala, prenume, facultateAleasa, medii, optiuneFacultate);
                    listaCandidati.Add(c);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                conexiune.Close();
            }
        }
    }
}
