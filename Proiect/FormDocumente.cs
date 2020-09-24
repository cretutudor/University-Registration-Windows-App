using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using iText.IO.Image;
using iText.Kernel.Geom;
using iText.Kernel.Pdf;
using iText.Layout;
using iText.Layout.Element;

namespace Proiect
{
    public partial class FormDocumente : Form
    {
        List<Candidat> listaCandidati = new List<Candidat>();
        Candidat candidat = null;
        Document dosar = null;
        string[] fisiere = null;
        string connString = "Provider = Microsoft.ACE.OLEDB.12.0; Data Source = Studenti.accdb";


        public FormDocumente(List<Candidat> listaCandidati, Candidat c)
        {
            this.listaCandidati = listaCandidati;
            this.candidat = c;
            InitializeComponent();
            checkedListBox1.SelectionMode = SelectionMode.None;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (checkedListBox1.CheckedItems.Count == checkedListBox1.Items.Count)
            {
                if (dosar != null)
                {
                    listaCandidati.Add(this.candidat);
                    OleDbConnection conexiune = new OleDbConnection(connString);
                    try
                    {
                        conexiune.Open();
                        OleDbCommand comanda = new OleDbCommand();
                        comanda.Connection = conexiune;

                        comanda.CommandText = "SELECT MAX(nrcrt) FROM Studenti";
                        int nrCrt = Convert.ToInt32(comanda.ExecuteScalar());

                        comanda.CommandText = "INSERT INTO Studenti VALUES(?, ?, ?, ?, ?, ?, ?, ?, ?)";

                        comanda.Parameters.Add("nrcrt", OleDbType.Integer).Value = nrCrt + 1;
                        comanda.Parameters.Add("nume", OleDbType.VarChar).Value = candidat.nume;
                        comanda.Parameters.Add("initiala", OleDbType.Char, 5).Value = candidat.initialaTatalui;
                        comanda.Parameters.Add("prenume", OleDbType.VarChar).Value = candidat.prenume;
                        comanda.Parameters.Add("facultate", OleDbType.VarChar).Value = candidat.facultateAleasa.Nume;
                        comanda.Parameters.Add("specializare", OleDbType.VarChar).Value = candidat.optiuneFacultate;
                        comanda.Parameters.Add("medie BAC", OleDbType.Double).Value = candidat.medii.MedieBAC;
                        comanda.Parameters.Add("medie liceu", OleDbType.Double).Value = candidat.medii.MedieLiceu;
                        comanda.Parameters.Add("nota departajare", OleDbType.Double).Value = candidat.medii.NotaRomana;

                        comanda.ExecuteNonQuery();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                    finally
                    {
                        //conexiune.Close();
                        MessageBox.Show(candidat.afisareNumeComplet() + "a fost adaugat!");
                        this.Close();
                    }
                }
                else
                {
                    MessageBox.Show("Descarcati dosarul!");
                }
            }
            else
            {
                MessageBox.Show("Nu au fost introduse toate documentele!");
            }
        }

        private void listBox1_DragDrop(object sender, DragEventArgs e)
        {
            if (fisiere == null || listBox1.Items.Count < checkedListBox1.Items.Count)
            {   
                fisiere = (string[])e.Data.GetData(DataFormats.FileDrop, false);
                if (fisiere.Length <= (checkedListBox1.Items.Count - checkedListBox1.CheckedItems.Count)) //validare in caz ca sunt introduse prea multe fisiere in acelasi timp
                {
                    foreach (string f in fisiere)
                    {
                        listBox1.Items.Add(f);
                        bifeazaFisiere();
                    }
                }
                else
                {
                    MessageBox.Show("Introduceti mai putine fisiere!(Numar maxim: " +
                                    (checkedListBox1.Items.Count - checkedListBox1.CheckedItems.Count) + ")");
                }
            }
            else
            {
                MessageBox.Show("Au fost introduse toate documentele!");
            }
            
            
        }

        private void bifeazaFisiere()
        {
            for(int i = 0; i < listBox1.Items.Count; i++)
            {
                checkedListBox1.SetItemChecked(i, true);
            }
        }

        private void listBox1_DragEnter(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.All;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                if (listBox1.Items.Count == checkedListBox1.Items.Count)
                {
                    SaveFileDialog saveFileDialog = new SaveFileDialog();
                    saveFileDialog.Filter = "PDF|*.pdf";
                    if (saveFileDialog.ShowDialog() == DialogResult.OK)
                    {
                        PdfWriter pdfWriter = new PdfWriter(saveFileDialog.FileName);
                        PdfDocument pdfDocument = new PdfDocument(pdfWriter);
                        Document document = new Document(pdfDocument);

                        foreach (string s in listBox1.Items)
                        {
                            ImageData imageData = ImageDataFactory.Create(s);
                            iText.Layout.Element.Image pdfImg = new iText.Layout.Element.Image(imageData);
                            document.Add(pdfImg);
                        }
                        dosar = document;
                        document.Close();
                    }
                }
                else
                {
                    MessageBox.Show("Nu au fost introduse toate documentele!");
                }
            }
            catch
            {
                MessageBox.Show("Introduceti documentele!");
            }

        }

    }
}
