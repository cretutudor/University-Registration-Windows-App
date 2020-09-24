using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Proiect
{
    public partial class UserControl3 : UserControl
    {
        List<Candidat> listaCandidati = new List<Candidat>();
        List<Facultate> listaFacultati = new List<Facultate>();

        //variabile pt pie chart
        int nrLocuri = 6322;
        int nrLocuriOcupate = 0;

        //variabile pt column chart
        int candidatiFacultate = 0;

        const int marg = 30;
        Color culoare = Color.Blue;
        Font font = new Font(FontFamily.GenericSansSerif, 12);
        Brush blackBrush = new SolidBrush(Color.Black);

        public UserControl3(List<Candidat> listaCandidati, List<Facultate> listaFacultati)
        {
            this.listaCandidati = listaCandidati;
            this.listaFacultati = listaFacultati;
            nrLocuriOcupate = this.listaCandidati.Count;
            InitializeComponent();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

            Graphics g = e.Graphics;

            //pie chart cu locuri ocupate
            Rectangle pieCharRect = new Rectangle(panel1.ClientRectangle.X + marg, panel1.ClientRectangle.Y + marg,
                                                  300, 200);

            //titlul graficului
            g.DrawString("Situatia ocupării locurilor", font, blackBrush,
                         pieCharRect.X + 60, pieCharRect.Y - 25);

            Brush brush1 = new SolidBrush(Color.DarkBlue);
            Brush brush2 = new SolidBrush(Color.DarkRed);

            g.FillPie(brush1, pieCharRect, 0, 360);
            g.FillPie(brush2, pieCharRect, 0, ((float)nrLocuriOcupate / nrLocuri) * 360); //portiunea din pie chart cu locurile ocupate 

            g.FillRectangle(brush1, pieCharRect.X + pieCharRect.Width / 5,
                            pieCharRect.Y + pieCharRect.Height + 50,
                            10, 10);
            g.FillRectangle(brush2, pieCharRect.X + pieCharRect.Width / 5,
                            pieCharRect.Y + pieCharRect.Height + 90,
                            10, 10);

            g.DrawString("Locuri disponibile", font, brush1, (pieCharRect.X + pieCharRect.Width / 5) + 15, pieCharRect.Y + pieCharRect.Height + 45);
            g.DrawString("Locuri ocupate", font, brush2, (pieCharRect.X + pieCharRect.Width / 5) + 15, pieCharRect.Y + pieCharRect.Height + 85);


            //column chart grad ocupare locuri
            Rectangle columnChartRect = new Rectangle(panel1.ClientRectangle.X + panel1.ClientRectangle.Width / 2,
                                                      panel1.ClientRectangle.Y + panel1.ClientRectangle.Height / 3 + 30,
                                                      (panel1.ClientRectangle.Width / 2) - marg, 250);
            Pen pen = new Pen(Color.Black);
            Font fontColumnChart = new Font(FontFamily.GenericSansSerif, 10, FontStyle.Bold);

            //titlul graficului
            g.DrawString("Gradul de ocupare a locurilor în fiecare facultate", font, blackBrush,
                         columnChartRect.X + 25, columnChartRect.Y - 35);

            //linie verticala a graficului
            g.DrawLine(pen, columnChartRect.X, columnChartRect.Y + columnChartRect.Height,
                            columnChartRect.X, columnChartRect.Y);

            StringFormat stringFormat = new StringFormat();
            stringFormat.FormatFlags = StringFormatFlags.DirectionVertical;

            g.DrawString("Procentul de ocupare a locurilor", font, blackBrush, columnChartRect.X - 25, columnChartRect.Y, stringFormat);

            //linia orizontala a graficului
            g.DrawLine(pen, columnChartRect.X, columnChartRect.Y + columnChartRect.Height,
                            columnChartRect.X + columnChartRect.Width, columnChartRect.Y + columnChartRect.Height);
            g.DrawString("Facultatea", font, blackBrush,
                         columnChartRect.X + columnChartRect.Width / 3 + 20,
                         columnChartRect.Y + columnChartRect.Height + 5);

            double latime = columnChartRect.Width / listaFacultati.Count / 2;
            double distanta = (columnChartRect.Width - latime) / (listaFacultati.Count + 1);

            int i = 0;

            Rectangle[] recs = new Rectangle[listaFacultati.Count];
            //desenarea graficului
            foreach (Facultate f in listaFacultati)
            {
                foreach (Candidat c in listaCandidati)
                {
                    if (c.facultateAleasa.Nume == f.Nume)
                    {
                        candidatiFacultate++;
                    }
                }
                recs[i] = new Rectangle((int)(columnChartRect.X + distanta * (i + 1)),
                                                columnChartRect.Y + (columnChartRect.Height - ((candidatiFacultate * columnChartRect.Height) / f.NumarLocuri)),
                                                (int)latime,
                                                (candidatiFacultate * columnChartRect.Height) / f.NumarLocuri);
                if (f.Cod.Length > 3)
                {
                    g.DrawString(f.Cod, fontColumnChart, brush1, new Point(recs[i].Location.X - 13, recs[i].Location.Y - Font.Height - 1));
                }
                else
                if (f.Cod.Length > 2)
                {
                    g.DrawString(f.Cod, fontColumnChart, brush1, new Point(recs[i].Location.X - 5, recs[i].Location.Y - Font.Height - 1));

                }
                else
                {
                    g.DrawString(f.Cod, fontColumnChart, brush1, new Point(recs[i].Location.X - 3, recs[i].Location.Y - Font.Height - 1));
                }
                i++;
                candidatiFacultate = 0;
            }
            g.FillRectangles(brush1, recs);

        }
    }
}
