using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace Proiect
{
    public partial class UserControl2 : UserControl
    {
        ComparerCandidati comparer = new ComparerCandidati();
        List<Candidat> listaCandidati;
        List<Facultate> listaFacultati;
        ToolStripMenuItem[] listaToolMenuStrip = new ToolStripMenuItem[11];
        List<Candidat> listaStudentiFacultati = new List<Candidat>();
        int i = 1;

        public UserControl2(List<Candidat> listaCandidati, List<Facultate> listaFacultati)
        {
            InitializeComponent();
            this.listaCandidati = listaCandidati;
            this.listaFacultati = listaFacultati;
            listaCandidati.Sort(comparer.Compare);
            afiseazaCandidati(listaCandidati);
            populeazaMenuStrip();
            apelareClick();
        }

        private void afiseazaCandidati(List<Candidat> listaPrimita)
        {
            foreach (Candidat c in listaPrimita)
            {
                ListViewItem itm = new ListViewItem(i.ToString());
                itm.SubItems.Add(c.nume);
                itm.SubItems.Add(c.initialaTatalui);
                itm.SubItems.Add(c.prenume);
                itm.SubItems.Add(c.facultateAleasa.Nume);
                itm.SubItems.Add(c.optiuneFacultate);
                itm.SubItems.Add(c.medii.calculMedieAdmitere().ToString());

                listView1.Items.Add(itm);
                i++;
            }
        }


        //populare menu strip cu facultatile
        private void populeazaMenuStrip()
        {
            int i = 0;
            foreach (Facultate f in listaFacultati)
            {
                listaToolMenuStrip[i] = new ToolStripMenuItem(f.Cod);
                i++;
            }
            facultateaToolStripMenuItem.DropDownItems.AddRange(listaToolMenuStrip);
        }

        //evenimentul pentru click pe general
        private void generalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            listView1.Items.Clear();
            i = 1;
            afiseazaCandidati(listaCandidati);
        }

        //evenimentul pentru click pe una din facultati
        private void FacultateToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (Candidat c in listaCandidati)
            {
                if (c.facultateAleasa.Cod == sender.ToString())
                {
                    listaStudentiFacultati.Add(c);
                }
            }
            listView1.Items.Clear();
            i = 1;
            afiseazaCandidati(listaStudentiFacultati);
            listaStudentiFacultati.Clear();
        }

        //functia de apelare a evenimentului de click pe una din facultati
        public void apelareClick()
        {
            foreach (ToolStripMenuItem toolStripMenuItem in listaToolMenuStrip)
            {
                toolStripMenuItem.Click += new System.EventHandler(this.FacultateToolStripMenuItem_Click);
            }
        }

        //salvare in fisier text
        private void salveazăToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog dlg = new SaveFileDialog();
            dlg.Filter = "(.txt)|*.txt";
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                using (StreamWriter sw = new StreamWriter(dlg.FileName))
                {
                    foreach (ListViewItem item in listView1.Items)
                    {
                        for (int i = 0; i < item.SubItems.Count; i++)
                        {
                            sw.Write(item.SubItems[i].Text + "\t");
                        }
                        sw.WriteLine();
                    }
                }
            }
        }
    }
}
