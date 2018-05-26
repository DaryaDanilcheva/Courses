using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;

namespace ДЗ2
{
    public partial class Form1 : Form
    {
        int height = 40;
        int width = 40;
        int size = 0;
        string sign = "O";
        int count = 0;
        CrossZero cz = new CrossZero();

        public Form1()
        {
            InitializeComponent();
        }

        private void lbl_Click(object sender, EventArgs e)
        {

            string winner = "";
            if (count <= cz.Size * cz.Size)
            {
                Label lbl = sender as Label;

                if (lbl.Text == ".")
                {
                    sign = sign == "X" ? "O" : "X";
                    cz.Field[int.Parse(lbl.Name[0].ToString()), int.Parse(lbl.Name[1].ToString())] = sign;
                    lbl.Text = sign;
                    count++;
                }

                if ((winner = cz.Win()) != ".")
                {
                    MessageBox.Show("Победил игрок, ходящий знаком " + winner);
                    Clear();
                }

                if (count == cz.Size * cz.Size)
                {
                    if ((winner = cz.Win()) == ".")
                        MessageBox.Show("Ничья");
                    Clear();
                }
            }
        }

        void Clear()
        {
            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                {
                    Controls.RemoveByKey(i.ToString() + j.ToString());
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Clear();
            count = 0;
            try
            {
                size = Convert.ToInt32(textBox1.Text);
                if (size >= 3 && size <= 5)
                {
                    Label lb;

                    cz.Fill(size);
                    for (int i = 0; i < size; i++)
                    {
                        for (int j = 0; j < size; j++)
                        {
                            lb = new Label
                            {
                                Name = i.ToString() + j.ToString(),
                                Text = ".",
                                Height = height,
                                Width = width,
                                Location = new Point(height * i + 100, width * j + 100)
                            };
                            lb.Click += lbl_Click;
                            Controls.Add(lb);
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Введите число от 3 до 5");
                    textBox1.Text = "";
                }
            }
            catch
            {
                MessageBox.Show("Введите число от 3 до 5");
                textBox1.Text = "";
            }
        }
    }   
}
