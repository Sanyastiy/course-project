using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace КурсовойПроект
{
    public partial class kot : Form
    {
        int pozition = 0;
        int ball = 0;
        int ballkonc = 0;
        int ballosved = 0;
        int ballnauk = 0;
        int ballprost = 0;
        string osh = "";
        //массив ответов
        string[,] answer = new string[5, 10];

        string[] otvet = new string[32];
        bool g = false;

        public kot()
        {
            InitializeComponent();
            try
            {
                
            richTextBox1.Rtf = File.ReadAllText(@"Materials/Кот/1.rtf");
            richTextBox2.Rtf = File.ReadAllText(@"Materials/Теория/Кот.rtf");
            }
            catch (Exception)
            { }

        }



        private void label1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            try
        { 
            if (!g)
            {
                g = true;
                button8.Text = "Начать";
                richTextBox2.Rtf = File.ReadAllText(@"Materials/Кот/Описание.rtf");
            }
            else
            {
                richTextBox1.Visible = true;
                label2.Visible = true;
                panel1.Visible = true;
                panel2.Visible = true;
                button8.Visible = false;
                richTextBox2.Visible = false;
                radioButton1.Checked = true;
                timer1.Enabled = true;
            }
        }
        catch (Exception)
        { }
        }

        private void radioButton_CheckedChanged(object sender, EventArgs e)
        {
            try { 
            RadioButton b = sender as RadioButton;
            pozition = b.TabIndex;
            textBox1.Text = answer[0, pozition];
            textBox2.Text = answer[1, pozition];
            textBox3.Text = answer[2, pozition];
            textBox4.Text = answer[3, pozition];
            textBox5.Text = answer[4, pozition];
            richTextBox1.Rtf = File.ReadAllText(@"Materials/Кот/" + ((b.TabIndex + 1).ToString()) + ".rtf");
            }
            catch (Exception)
            { }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        { answer[0, pozition] = textBox1.Text; }

        private void textBox2_TextChanged(object sender, EventArgs e)
        { answer[1, pozition] = textBox2.Text; }

        private void textBox3_TextChanged(object sender, EventArgs e)
        { answer[2, pozition] = textBox3.Text; }

        private void textBox4_TextChanged(object sender, EventArgs e)
        { answer[3, pozition] = textBox4.Text; }

        private void textBox5_TextChanged(object sender, EventArgs e)
        { answer[4, pozition] = textBox5.Text; }

        private void timer1_Tick(object sender, EventArgs e)
        {
            timer1.Enabled = false;
            richTextBox2.Visible = true;
            panel1.Visible = false;
            panel2.Visible = false;
            rez();
        }

        private void rez()
        {
            try { 
            if (answer[0, 0] == "3") { ball++; }
            if (answer[1, 0] == "3") { ball++; ballosved++; }
            if ((answer[2, 0] == "2") || (answer[2, 0] == "4")) { ball++; }
            if ((answer[3, 0] == "да") || (answer[2, 0] == "Да") || (answer[2, 0] == "ДА") || (answer[2, 0] == "дА")) { ball++; }
            if (answer[4, 0] == "4") { ball++; ballosved++; }

            if (answer[0, 1] == "2") { ball++; ballosved++; }
            if (answer[1, 1] == "4") { ball++; ballosved++; }
            if (answer[2, 1] == "1") { ball++; }
            if (answer[3, 1] == "5") { ball++; ballosved++; }
            if (answer[4, 1] == "40") { ball++; ballkonc++; }

            if (answer[0, 2] == "3") { ball++; ballosved++; }
            if (answer[1, 2] == "270") { ball++; }
            if (answer[2, 2] == "4") { ball++; ballkonc++; ballnauk++; }
            if (answer[3, 2] == "3") { ball++; }
            if ((answer[4, 2] == "0,31") || (answer[4, 2] == "0.31") || (answer[4, 2] == "031")) { ball++; }

            if ((answer[0, 3] == "ни") || (answer[2, 0] == "Ни") || (answer[2, 0] == "НИ") || (answer[2, 0] == "нИ")) { ball++; ballosved++; }
            if (answer[1, 3] == "4") { ball++; ballnauk++; }
            if (answer[2, 3] == "4") { ball++; }
            if (answer[3, 3] == "3") { ball++; ballosved++; }
            if ((answer[4, 3] == "Н") || (answer[2, 0] == "н")) { ball++; }

            if ((answer[0, 4] == "3,5") || (answer[2, 0] == "3 5") || (answer[2, 0] == "3.5") || (answer[2, 0] == "35")) { ball++; }
            if (answer[1, 4] == "31") { ball++; ballnauk++; }
            if (answer[2, 4] == "2") { ball++; }
            if (answer[3, 4] == "1") { ball++; ballosved++; }
            if ((answer[4, 4] == "15") || (answer[2, 0] == "1500")) { ball++; }
            //
            if (answer[0, 5] == "1") { ball++; }
            if (answer[1, 5] == "1") { ball++; ballnauk++; }
            if (answer[2, 5] == "1") { ball++; ballosved++; }
            if ((answer[3, 5] == "2,13") || (answer[2, 0] == "2 13") || (answer[2, 0] == "2.13")) { ball++; ballprost++; }
            if (answer[4, 5] == "3") { ball++; ballosved++; }

            if (answer[0, 6] == "1600") { ball++; }
            if ((answer[1, 6] == "1,2,4") || (answer[2, 0] == "1 2 4") || (answer[2, 0] == "124") || (answer[2, 0] == "1.2.4")) { ball++; ballprost++; }
            if (answer[2, 6] == "18") { ball++; ballnauk++; }
            if (answer[3, 6] == "3") { ball++; }
            if (answer[4, 6] == "1") { ball++; }

            if (answer[0, 7] == "1") { ball++; }
            if ((answer[1, 7] == "0,48") || (answer[2, 0] == "048") || (answer[2, 0] == "0.48") || (answer[4, 2] == "0,04") || (answer[2, 0] == "004") || (answer[2, 0] == "0.04")) { ball++; }
            if (answer[2, 7] == "1") { ball++; }
            if (answer[3, 7] == "20") { ball++; }
            if ((answer[4, 7] == "1/8") || (answer[2, 0] == "0,125") || (answer[2, 0] == "0.125") || (answer[2, 0] == "18") || (answer[2, 0] == "0125")) { ball++; }

            if (answer[0, 8] == "3") { ball++; }
            if (answer[1, 8] == "14") { ball++; ballnauk++; }
            if (answer[2, 8] == "1") { ball++; ballosved++; }
            if (answer[3, 8] == "800") { ball++; ballnauk++; }
            if ((answer[4, 8] == "1/10") || (answer[2, 0] == "0,1") || (answer[2, 0] == "01")) { ball++; }

            if (answer[0, 9] == "280") { ball++; ballnauk++; }
            if ((answer[1, 9] == "4,5") || (answer[2, 0] == "4 5") || (answer[2, 0] == "4.5") || (answer[2, 0] == "45")) { ball++; ballosved++; }
            if (answer[2, 9] == "1") { ball++; ballosved++; }
            if (answer[3, 9] == "3") { ball++; ballprost++; }
            if (answer[4, 9] == "17") { ball++; ballnauk++; }

            if (ball <= 13) { osh = "низкий (5-6 класс)"; }
            if (ball <= 18) { osh = "ниже среднего (7-8 класс)"; }
            if (ball <= 24) { osh = "средний (9 класс и выше)"; }
            if (ball <= 29) { osh = "выше среднего"; }
            if (ball >= 30) { osh = "высокий"; }

            richTextBox2.Text = "Общий уровень умственных способностей: " + osh+" "+ball.ToString()+" баллов из 50" + Environment.NewLine + "Качественный анализ" + Environment.NewLine + "Задания 10,13 на развитие произвольности, высокой концентрации и распределения внимания: " + ballkonc.ToString() + " из 2" +
                Environment.NewLine + "Задания 2, 5, 6, 7, 9, 11, 16, 19, 24, 28, 30, 43, 47, 48 определяют общий уровень осведомленности и развития лингвистических способностей: " + ballosved.ToString() + " из 14" +
                Environment.NewLine + "Задания 13, 17, 22, 27, 33, 42, 44, 46, 50 из области точных наук: " + ballnauk.ToString() + " из 9" +
                Environment.NewLine + "Задания 29, 32, 49 свидетельствуют об уровне пространственного ориентирования и абстрактно-логического мышления: " + ballprost.ToString()+" из 3";
            }
            catch (Exception)
            { }
        }
    }
}
