using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing.Printing;
using iText.Layout;

namespace Proiect
{
    public partial class UserControl1 : UserControl
    {
        List<Panel> panelList = new List<Panel>();
        List<Facultate> listaFacultati;
        public List<Candidat> listaCandidati = new List<Candidat>();


        int index = 0;

        public UserControl1(List<Facultate> listaFacultati)
        {
            this.listaFacultati = listaFacultati;
            InitializeComponent();
            populareListBoxFacultati(this.listaFacultati);
        }

        private void UserControl1_Load(object sender, EventArgs e)
        {
            panelList.Add(panel1);
            panelList.Add(panel2);
            panelList[index].BringToFront();
        }


        //trecere la panel-ul urmator
        private void button1_Click(object sender, EventArgs e)
        {
            //pentru campuri goale
            if (verificareCampuri() == true)
            {

                if (cbSex.SelectedIndex == -1)
                    errorProvider1.SetError(cbSex, "Selectati o varianta!");
                else
                if (lbFacultati.SelectedIndex == -1)
                    errorProvider1.SetError(lbFacultati, "Selectati facultatea!");
                else
                {
                    if (index < panelList.Count - 1) //trecere la urmatorul panel
                    {
                        panelList[++index].BringToFront();
                    }
                    label9.Text = lbFacultati.SelectedItem.ToString();

                    errorProvider1.Clear();
                }
            }
        }

        //functie care goleste formularul
        private void resetareFormular()
        {
            tbNume.Clear();
            tbInitiala.Clear();
            tbPrenume.Clear();
            cbSex.ResetText();
            tbCNP.Clear();
            tbSerie.Clear();
            tbNumar.Clear();
            tbTelefon.Clear();
            tbEmail.Clear();
            tbTara.Clear();
            tbJudet.Clear();
            tbLocalitate.Clear();
            tbAdresa.Clear();
            tbMedieBAC.Clear();
            tbMedieLiceu.Clear();
            tbNotaRomana.Clear();

        }


        //trecere la panel-ul anterior
        private void button3_Click(object sender, EventArgs e)
        {
            if (index > 0)
            {
                panelList[--index].BringToFront();
            }
        }

        //adaugare candidat
        private void button2_Click(object sender, EventArgs e)
        {
            if (checkedListBox1.SelectedIndex == -1)
                errorProvider1.SetError(checkedListBox1, "Selectati o optiune!");
            else
            if (tbMedieBAC.Text == "")
                errorProvider1.SetError(tbMedieBAC, "Introduceti media de BAC!");
            else
            if (tbMedieLiceu.Text == "")
                errorProvider1.SetError(tbMedieLiceu, "Introduceti media din liceu!");
            else
            if (tbNotaRomana.Text == "")
                errorProvider1.SetError(tbNotaRomana, "Introduceti nota!");
            else
            {
                try
                {
                    string nume = tbNume.Text;
                    string initialaTatalui = tbInitiala.Text;
                    string prenume = tbPrenume.Text;
                    char sex = Convert.ToChar(cbSex.SelectedItem.ToString());
                    long cnp = Convert.ToInt64(tbCNP.Text);
                    string serie = tbSerie.Text;
                    int numar = Convert.ToInt32(tbNumar.Text);
                    int telefon = Convert.ToInt32(tbTelefon.Text);
                    string email = tbEmail.Text;
                    string tara = tbTara.Text;
                    string judet = tbJudet.Text;
                    string localitate = tbLocalitate.Text;
                    string adresa = tbAdresa.Text;

                    Facultate facultateAleasa = null;
                    foreach (Facultate f in listaFacultati)
                    {
                        if (lbFacultati.SelectedItem.ToString() == f.Nume)
                            facultateAleasa = f;
                    }

                    string optiuneAleasa = checkedListBox1.CheckedItems[0].ToString();

                    double medieBAC = 0;
                    double notaRomana = 0;
                    double medieLiceu = 0;

                    if (Convert.ToDouble(tbMedieBAC.Text) > 10 || Convert.ToDouble(tbMedieLiceu.Text) > 10 ||
                        Convert.ToDouble(tbNotaRomana.Text) > 10)
                        MessageBox.Show("Nota este prea mare!");
                    else
                    {
                        medieBAC = Convert.ToDouble(tbMedieBAC.Text);
                        medieLiceu = Convert.ToDouble(tbMedieLiceu.Text);
                        notaRomana = Convert.ToDouble(tbNotaRomana.Text);

                        Medii medii = new Medii(medieBAC, medieLiceu, notaRomana);

                        Document dosar = null;

                        Candidat c = new Candidat(nume, initialaTatalui, prenume, sex, cnp, serie, numar, telefon, email, tara, judet,
                                                  localitate, adresa, facultateAleasa, medii, optiuneAleasa, dosar);

                        MessageBox.Show("Datele pentru " + c.afisareNumeComplet() + " au fost introduse cu succes!");

                        FormDocumente form4 = new FormDocumente(listaCandidati, c);
                        form4.Show();

                        resetareFormular();
                    }
                }
                catch
                {
                    MessageBox.Show("Exista campuri completate incorect!");
                }
                finally
                {
                    errorProvider1.Clear();
                }
            }
        }

        private void populareListBoxFacultati(List<Facultate> listaFacultati)
        {
            foreach (Facultate f in listaFacultati)
            {
                this.lbFacultati.Items.Add(f.Nume);
            }
        }

        //schimba imaginea si specializarile in functie de facultatea aleasa
        private void lbFacultati_SelectedValueChanged(object sender, EventArgs e)
        {
            checkedListBox1.Items.Clear();
            for (int i = 0; i < listaFacultati.Count; i++)
            {
                if (lbFacultati.SelectedItem.Equals(listaFacultati[i].Nume))
                {
                    foreach (string specializare in listaFacultati[i].listaSpecializari)
                        checkedListBox1.Items.Add(specializare);
                }
            }
            switch (lbFacultati.SelectedItem.ToString())
            {

                case ("Facultatea de Administrarea Afacerilor, cu predare in limbi straine"):
                    pbFacultateAleasa.BackgroundImage = Image.FromFile("facultati/FABIZ.png");
                    break;
                case ("Facultatea de Administratie si Management Public"):
                    pbFacultateAleasa.BackgroundImage = Image.FromFile("facultati/FAMP.png");
                    break;
                case ("Facultatea de Business si Turism"):
                    pbFacultateAleasa.BackgroundImage = Image.FromFile("facultati/FBT.png");
                    break;
                case ("Facultatea de Cibernetica, Statistica si Informatica Economica"):
                    pbFacultateAleasa.BackgroundImage = Image.FromFile("facultati/CSIE.png");
                    break;
                case ("Facultatea de Contabilitate si Informatica de Gestiune"):
                    pbFacultateAleasa.BackgroundImage = Image.FromFile("facultati/CIG.png");
                    break;
                case ("Facultatea de Economie Teoretica si Aplicata"):
                    pbFacultateAleasa.BackgroundImage = Image.FromFile("facultati/FE.png");
                    break;
                case ("Facultatea de Economie Agroalimentara si a Mediului"):
                    pbFacultateAleasa.BackgroundImage = Image.FromFile("facultati/FEAM.png");
                    break;
                case ("Facultatea de Finante, Asigurari, Banci si Burse de Valori"):
                    pbFacultateAleasa.BackgroundImage = Image.FromFile("facultati/FABBV.png");
                    break;
                case ("Facultatea de Management"):
                    pbFacultateAleasa.BackgroundImage = Image.FromFile("facultati/MAN.png");
                    break;
                case ("Facultatea de Marketing"):
                    pbFacultateAleasa.BackgroundImage = Image.FromFile("facultati/MK.png");
                    break;
                case ("Facultatea de Relatii Economice Internationale"):
                    pbFacultateAleasa.BackgroundImage = Image.FromFile("facultati/REI.png");
                    break;
            }

        }


        private bool verificareCampuri()
        {
            List<TextBox> listaTB = new List<TextBox>();
            listaTB.Add(tbNume);
            listaTB.Add(tbInitiala);
            listaTB.Add(tbPrenume);
            listaTB.Add(tbCNP);
            listaTB.Add(tbSerie);
            listaTB.Add(tbNumar);
            listaTB.Add(tbTelefon);
            listaTB.Add(tbEmail);
            listaTB.Add(tbTara);
            listaTB.Add(tbJudet);
            listaTB.Add(tbLocalitate);
            listaTB.Add(tbAdresa);

            foreach (TextBox t in listaTB)
            {
                if (t.Text == "")
                {
                    errorProvider1.SetError(t, "Introduceti datele!");
                }
            }
            return true;
        }

        //conditii de introducere a datelor in campuri
        private void tbCNP_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
                e.Handled = true;
        }

        private void tbNume_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsLetter(e.KeyChar) && e.KeyChar != '-' && !char.IsControl(e.KeyChar))
                e.Handled = true;
        }

        private void tbInitiala_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsUpper(e.KeyChar) && !char.IsControl(e.KeyChar) && e.KeyChar != '-')
                e.Handled = true;
        }

        private void tbMedieBAC_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != '.' && !char.IsControl(e.KeyChar))
                e.Handled = true;
        }

        private void tb_MouseHover(object sender, EventArgs e)
        {
            toolTip1.SetToolTip(tbInitiala, "Literele trebuie sa fie majuscule");
            toolTip1.SetToolTip(tbSerie, "Literele trebuie sa fie majuscule");
        }

        private void golestePaginaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            resetareFormular();
        }

        //print pentru formularul completat
        private void printeazaFormularulToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (checkedListBox1.SelectedItem == null)
            {
                MessageBox.Show("Formularul trebuie completat integral!");
            }
            else
            {
                PrintDocument pd = new PrintDocument();
                pd.PrintPage += new PrintPageEventHandler(pd_print);
                PrintPreviewDialog dlg = new PrintPreviewDialog();
                dlg.Document = pd;
                dlg.ShowDialog();
            }
        }

        private void pd_print(object sender, PrintPageEventArgs e)
        {
            int margine = 70;
            int distanta = 30;

            Label labelOptiune = new Label();
            string text = checkedListBox1.CheckedItems[0].ToString();
            labelOptiune.Text = text;
            Font tnr = new Font("Times New Roman", 12F, FontStyle.Italic);
            labelOptiune.Font = tnr;
            labelOptiune.BackColor = Color.White;

            Bitmap bitmap = new Bitmap(840, 1188);

            //antet
            pbASE.DrawToBitmap(bitmap, new Rectangle(bitmap.Width - pbASE.Width - margine, distanta, pbASE.Width, pbASE.Height));
            pbFacultateAleasa.DrawToBitmap(bitmap, new Rectangle(margine, distanta, pbFacultateAleasa.Width, pbFacultateAleasa.Height));
            label9.DrawToBitmap(bitmap, new Rectangle(margine, distanta + pbASE.Height, label9.Width, label9.Height));

            //titlu
            labelTitlu.DrawToBitmap(bitmap, new Rectangle(4 * margine, 4 * distanta + pbASE.Height, labelTitlu.Width, labelTitlu.Height));

            //datele
            groupBox3.DrawToBitmap(bitmap, new Rectangle(margine, 7 * distanta + pbASE.Height, groupBox3.Width, groupBox3.Height));
            groupBox1.DrawToBitmap(bitmap, new Rectangle(margine, 11 * distanta + groupBox3.Height, groupBox1.Width, groupBox1.Height));
            groupBox2.DrawToBitmap(bitmap, new Rectangle(10 + margine + groupBox1.Width, 11 * distanta + groupBox3.Height,
                                                         groupBox2.Width, groupBox2.Height));
            groupBox4.DrawToBitmap(bitmap, new Rectangle(margine, 12 * distanta + groupBox3.Height + groupBox2.Height,
                                                         groupBox4.Width, groupBox4.Height));

            labelOptiune.DrawToBitmap(bitmap, new Rectangle(margine, distanta + pbASE.Height + 20,
                                                            300, labelOptiune.Height));

            e.Graphics.DrawImage(bitmap, 0, 0);
            bitmap.Dispose();
        }

        private void checkedListBox1_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            for (int i = 0; i < checkedListBox1.Items.Count; ++i)
            {
                if (i != e.Index)
                {
                    checkedListBox1.SetItemChecked(i, false);
                }
            }
        }
    }
}

