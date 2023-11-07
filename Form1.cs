using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Promedio
{
    public partial class Form1 : Form
    {
        private List<TextBox> textBoxNotas = new List<TextBox>();
        private List<TextBox> textBoxPonderaciones = new List<TextBox>();

        public Form1()
        {
            InitializeComponent();

            textBoxNotas.Add(textBoxNota);
            textBoxPonderaciones.Add(textBoxPonderacion);
        }

        private void btnPromediar_Click(object sender, EventArgs e)
        {
            int sumaPonderada = 0;
            int sumaPonderaciones = 0;

            // Incluir el TextBox original si existe
            if (textBoxNotas.Count > 0 && textBoxPonderaciones.Count > 0)
            {
                if (int.TryParse(textBoxNotas[0].Text, out int nota) && int.TryParse(textBoxPonderaciones[0].Text, out int ponderacion))
                {
                    sumaPonderada += nota * ponderacion;
                    sumaPonderaciones += ponderacion;
                }
            }

            for (int i = 1; i < textBoxNotas.Count; i++)
            {
                if (int.TryParse(textBoxNotas[i].Text, out int nota) && int.TryParse(textBoxPonderaciones[i].Text, out int ponderacion))
                {
                    sumaPonderada += nota * ponderacion;
                    sumaPonderaciones += ponderacion;
                }
            }

            if (sumaPonderaciones > 0)
            {
                int promedio = sumaPonderada / sumaPonderaciones;
                txtPromedio.Text = promedio.ToString();

                if (promedio < 30)
                {
                    MessageBox.Show("Reprobado");
                }
                else
                {
                    MessageBox.Show("Aprobado");
                }
            }
            else
            {
                MessageBox.Show("No se ingresaron notas o ponderaciones válidas.");
            }
        }
        int indiceLabel = 2;
        private void button1_Click(object sender, EventArgs e)
        {

            Label label = new Label();

            label.Text = "Nota " + indiceLabel;
            label.Location = new System.Drawing.Point(359, 15 + indiceLabel * 40);
            label.Width = 40;

            TextBox notaBox = new TextBox();
            notaBox.Name = "textBoxNota" + textBoxNotas.Count; // Asigna nombres únicos
            notaBox.Location = new System.Drawing.Point(404, 55 + textBoxNotas.Count * 40);



            Label label2 = new Label();
            label2.Text = "Ponderacion  " + indiceLabel;
            label2.Location = new System.Drawing.Point(557, 15 + indiceLabel * 40);
            label2.Width = 76;
            TextBox ponderacionBox = new TextBox();
            ponderacionBox.Name = "textBoxPonderacion" + textBoxPonderaciones.Count;        
            ponderacionBox.Location = new System.Drawing.Point(633, 55 + textBoxPonderaciones.Count * 40);

            this.Controls.Add(label);
            this.Controls.Add(label2);
            this.Controls.Add(notaBox);
            this.Controls.Add(ponderacionBox);
            indiceLabel++;
            textBoxNotas.Add(notaBox);
            textBoxPonderaciones.Add(ponderacionBox);


            if (textBoxNotas.Count >= 10)
            {
                MessageBox.Show("Se ha alcanzado el límite de 10 notas.");
                button1.Enabled = false; // Desactiva el botón
            }
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            // Restablecer los TextBox de notas y ponderaciones
            foreach (TextBox notaBox in textBoxNotas)
            {
                notaBox.Text = string.Empty;
            }
            foreach (TextBox ponderacionBox in textBoxPonderaciones)
            {
                ponderacionBox.Text = string.Empty;
            }

            // Habilitar el botón de agregar nuevamente (si se había deshabilitado)
            button1.Enabled = true;

            // Limpia cualquier otro control que desees restablecer
            txtPromedio.Text = string.Empty;
        }
    }
}
