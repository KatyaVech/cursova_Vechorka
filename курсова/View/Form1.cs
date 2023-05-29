
using System;
using System.Drawing;
using System.Windows.Forms;

namespace курсова
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            pictureBox1.Image = Image.FromFile("photo.png");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
            listBox2.Items.Clear();
            // Створення об'єкта контролера і передача введених даних з текстових полів
            Controller contrl = new Controller(textBox1.Text, textBox2.Text, textBox3.Text);
            // Перевірка на синтаксичні помилки
            if (contrl.SyntaxErrors() == true)
                MessageBox.Show("Були введені некоректні дані", "Помилка при введенні даних", MessageBoxButtons.OK, MessageBoxIcon.Error);
            // Перевірка на логічні помилки
            else if (contrl.LogicErrors() == true)
            // Перевірка на помилки
                MessageBox.Show("Були ввведені не вірні значення табуляції", "Помилка при введенні даних", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else if (contrl.Errors() == true)
                MessageBox.Show("Дані не задовільняють ОДЗ", "Помилка при введенні даних", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else
            {
                double[,] mas = contrl.Calculate();
                if (contrl.q <= 0.5 && contrl.q > 0)
                {
                    for (int i = 0; i < contrl.count; ++i)
                    {
                        listBox1.Items.Add($"x= {mas[i, 0]:F2} q= {contrl.q:F2} y= {mas[i, 1]:F7}");
                    }
                }
                else if (contrl.q <= 1 && contrl.q > 0.5)
                {
                    for (int i = 0; i < ((Convert.ToInt32(textBox2.Text) - Convert.ToInt32(textBox1.Text)) / Convert.ToInt32(textBox3.Text)) + 1; ++i)
                    {
                        listBox2.Items.Add($"x= {mas[i, 0]:F2} q= {contrl.q:F2}  y= {mas[i, 1]:F7}");
                    }
                }
            }
        }
        private void listBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }
    }
}

