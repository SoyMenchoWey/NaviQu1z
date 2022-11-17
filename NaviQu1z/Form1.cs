using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NaviQu1z
{
    public partial class Form1 : Form
    {
        private List<cuestion> encuesta = new List<cuestion>();
        private int val1 = 0;
        private int val2 = 5;
        private int val3 = 10;
        private int val4 = 15;
        private int numPreg = 0;
        private int sumResp = 0;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            llenaEncuesta();
        }
        private void llenaEncuesta()
        {
            cuestion pregunta = new cuestion();

            encuesta.Add(new cuestion
            {
                concepto = "¿Que tanto te gusta la navidad?",
                resp1 = "Me encanta :D",
                valor1 = val1,
                resp2 = "Pues me gusta el ponche",
                valor2 = val2,
                resp3 = "No la celebro seguido",
                valor3 = val3,
                resp4 = "¿Que es la navidad?",
                valor4 = val4
            });
            encuesta.Add(new cuestion
            {
                concepto = "¿Tienes un arbol de navidad?",
                resp1 = "Tengo 2",
                valor1 = val1,
                resp2 = "Si, tengo 1",
                valor2 = val2,
                resp3 = "No acostumbro ponerlo",
                valor3 = val3,
                resp4 = "No lo celebramos :(",
                valor4 = val4
            });
            encuesta.Add(new cuestion
            {
                concepto = "¿Que alimentos se comen en navidad?",
                resp1 = "Leche y Galletas",
                valor1 = val1,
                resp2 = "Leche y cereales",
                valor2 = val2,
                resp3 = "Tamales y ponche",
                valor3 = val3,
                resp4 = "No lo celebramos :(",
                valor4 = val4
            });
            encuesta.Add(new cuestion
            {
                concepto = "¿Cuantos renos tiene Santa Claus?",
                resp1 = "6",
                valor1 = val1,
                resp2 = "9",
                valor2 = val2,
                resp3 = "4",
                valor3 = val3,
                resp4 = "0",
                valor4 = val4
            });
            encuesta.Add(new cuestion
            {
                concepto = "¿Rompen piañata en tu familia?",
                resp1 = "SII, es bellisimo",
                valor1 = val1,
                resp2 = "No muy seguido",
                valor2 = val2,
                resp3 = "No lo practicamos :(",
                valor3 = val3,
                resp4 = "F mi pana",
                valor4 = val4
            });
            encuesta.Add(new cuestion
            {
                concepto = "¿Celebran la Navidad con amigos y familia?",
                resp1 = "Si,hasta el vecino xd",
                valor1 = val1,
                resp2 = "Solo familia",
                valor2 = val2,
                resp3 = "Solo amigos",
                valor3 = val3,
                resp4 = "Valorate mas Rey :)",
                valor4 = val4
            });
            encuesta.Add(new cuestion
            {
                concepto = "¿Que tan probable es que intercambien regalos?",
                resp1 = "Muy probable",
                valor1 = val1,
                resp2 = "No lo acostumbramos ",
                valor2 = val2,
                resp3 = "Aqui no hacemos eso .JPG",
                valor3 = val3,
                resp4 = "No lo celebramos :(",
                valor4 = val4
            });
        }

        private void radioButton4_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void btnIniciar_Click(object sender, EventArgs e)
        {
            numPreg = 0;
            sumResp = 0;
            lblResultado.Visible = false;
            progressBar1.Value = 0;
            progressBar1.Visible = false;
            realizaPregunta();
        }
        private void realizaPregunta()
        {
            cuestion pregunta = new cuestion();
            pregunta = encuesta[numPreg];
            lblPregunta.Text = pregunta.concepto;
            lblPregunta.Visible = true;
            radioButton1.Text = pregunta.resp1;
            radioButton1.Checked = false;
            radioButton1.Visible = true;
            radioButton2.Text = pregunta.resp2;
            radioButton2.Checked = false;
            radioButton2.Visible = true;
            radioButton3.Text = pregunta.resp3;
            radioButton3.Checked = false;
            radioButton3.Visible = true;
            radioButton4.Text = pregunta.resp4;
            radioButton4.Checked = false;
            radioButton4.Visible = true;
            btnSiguiente.Visible = true;
        }

        private void btnSiguiente_Click(object sender, EventArgs e)
        {
            cuestion pregunta = new cuestion();
            pregunta=encuesta[numPreg];
            if (radioButton1.Checked == true) { sumResp += pregunta.valor1; }
            if (radioButton2.Checked == true) { sumResp += pregunta.valor2; }
            if (radioButton3.Checked == true) { sumResp += pregunta.valor3; }
            if (radioButton4.Checked == true) { sumResp += pregunta.valor4; }
            if (numPreg < encuesta.Count() - 1)
            {
                numPreg++;
                realizaPregunta();
            }
            else
            { presentaResultado(); }

        }
        private void presentaResultado()
        {
            lblPregunta.Visible = false;
            radioButton1.Visible = false;
            radioButton2.Visible = false;
            radioButton3.Visible =false;
            radioButton4.Visible =false;
            btnSiguiente.Visible=false;
            numPreg++;
            int lim1 = numPreg * val1;
            int lim3 = numPreg * val2;
            int lim5 = numPreg * val3;
            int lim7 = numPreg * val4;
            int lim2 = (lim3 - lim1) / 2 + lim1;
            int lim4 = (lim5 - lim3) / 2 + lim3;
            int lim6 = (lim7-lim5)+ lim5;
            if (sumResp <= lim2)
            { lblResultado.Text = "Eres un grinch xd"; }
            if (sumResp >= lim2 && sumResp <= lim4)
            { lblResultado.Text = "Echele ganas mijo"; }
            if (sumResp >= lim4 && sumResp <= lim6)
            { lblResultado.Text = "Buen espiritu navideño"; }
            if (sumResp >= lim6)
            { lblResultado.Text = "Eres santa acaso?"; }
            lblResultado.Visible = true;
            double avance = (double)sumResp / (double)lim7 * 100.0;
            progressBar1.Value = (int)avance;
          progressBar1.Visible = true;
        }
    }
}
