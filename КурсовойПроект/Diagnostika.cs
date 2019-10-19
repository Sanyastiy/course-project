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
    public partial class Diagnostika : Form
    {
        //описание массивов строк для вывода в ответе
        string[] otvet = new string[13];

        //массив для записи результатов
        bool?[] result = new bool?[70];

        int[,] rez = new int[70,3];

        //массив вопросов
        string[] diag = new string[70];

        //объявление позиции (кол-во отвеченых вопросов)
        int pozition = 0;

        public Diagnostika()
        {
            InitializeComponent();
            try { 
            int ii = 0;
            foreach (string line in File.ReadLines(@"Materials/Строки диагностика.txt"))
            {
                diag[ii] = line;
                ii++;
            }

            ii = 0;
            foreach (string line in File.ReadLines(@"Materials/Ответы диагностика.txt"))
            {
                otvet[ii] = line;
                ii++;
            }
            richTextBox2.Rtf = File.ReadAllText(@"Materials/Теория/Диагностика.rtf");
            }
            catch (Exception)
            { }
        }

        private void label1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void next(object sender, EventArgs e)
        {
            try
            {
                
            if (pozition < 69)  //подсчет отвеченных вопросов
            {
                Button b = sender as Button;    //определение места откуда берется ответ
                result[pozition] = bool.Parse((b.Tag).ToString());   //запись в результ. массив ТЭГа кнопки, в котором записан ответ
                pozition++; //след вопрос
                richTextBox1.Text = "Вопрос №" + (pozition + 1).ToString() + ": " + diag[pozition];    //вывод след вопроса
            }
            else
            {
                final(sender, e);
            }
            }
            catch (Exception)
            { }
        }

        private void nextdontknow(object sender,EventArgs e)
        {
            try { 
            if (pozition < 69)  //подсчет отвеченных вопросов
            {                
                pozition++; //след вопрос
                richTextBox1.Text = "Вопрос №" + (pozition + 1).ToString() + ": " + diag[pozition];    //вывод след вопроса
            }
            else
            {
                final(sender, e);
            }
            }
            catch (Exception)
            { }
        }

        private void final(object sender, EventArgs e)
        {
            groupBox1.Visible = false;
            button8.Visible = false;
            try
            {
            bool?[] rez = new bool?[70];
            bool?[] rak = new bool?[70];
            int[,] exint = new int[70, 3];

            int p = 0;
            try
            {
                foreach (bool? pack in result)
                {
                    
                    if (pack == false)
                    {
                        rez[p] = true;
                    }
                    if (pack == null)
                    {
                        rak[p] = true;
                    }

                    //+
                    exint[p, 0] = Convert.ToInt16(result[p]);
                    //-
                    exint[p, 1] = Convert.ToInt16(rez[p]);
                    //хз
                    exint[p, 2] = Convert.ToInt16(rak[p]);
                    p++;
                }
            }
            catch (DivideByZeroException)
            { }

            int rock1 = (exint[1, 0] + exint[2, 0] + exint[5, 0] + exint[8, 0] + exint[12, 0] + exint[20, 0] + exint[31, 0] + exint[39, 0] + exint[41, 0] + exint[42, 0] + exint[46, 0] + exint[50, 0] + exint[51, 0] + exint[54, 0] + exint[59, 0] + exint[69, 0] + exint[0, 1] + exint[13, 1] + exint[19, 1] + exint[26, 1] + exint[36, 1] + exint[62, 1] + exint[65, 1] + exint[66, 1]) * 2;
            int rock2 = (exint[3, 0] + exint[9, 0] + exint[10, 0] + exint[15, 0] + exint[16, 0] + exint[17, 0] + exint[22, 0] + exint[23, 0] + exint[24, 0] + exint[27, 0] + exint[29, 0] + exint[32, 0] + exint[33, 0] + exint[37, 0] + exint[43, 0] + exint[45, 0] + exint[48, 0] + exint[53, 0] + exint[56, 0] + exint[57, 0] + exint[58, 0] + exint[61, 0] + exint[63, 0] + exint[67, 0]) * 2;
            int rock3 = (exint[4, 0] + exint[11, 0] + exint[18, 0] + exint[28, 0] + exint[34, 0] + exint[38, 0] + exint[55, 0] + exint[64, 0] + exint[7, 1] + exint[14, 1] + exint[21, 1] + exint[25, 1] + exint[30, 1] + exint[40, 1] + exint[44, 1] + exint[47, 1] + exint[49, 1] + exint[52, 1] + exint[60, 1] + exint[68, 1]) * 2;

            richTextBox1.Text = "Ваш результат (в баллах до 48):" + Environment.NewLine;
            if (rock1 >= 0 & rock1 <= 16)
            {
                richTextBox1.Text += "Экстраверсия/интроверсия: чистый интроверт (" + rock1.ToString() + ")" + Environment.NewLine;
            }
            else if (rock1 >= 17 & rock1 <= 32)
            {
                richTextBox1.Text += "Экстраверсия/интроверсия: амбивалентность, неопределённость (" + rock1.ToString() + ")" + Environment.NewLine;
            }
            else if (rock1 >= 33 & rock1 <= 48)
            {
                richTextBox1.Text += "Экстраверсия/интроверсия: чистый экстраверт (" + rock1.ToString() + ")" + Environment.NewLine;
            }


            if (rock2 >= 0 & rock2 <= 16)
            {
                richTextBox1.Text += "Нейротизм: эмоциональная устойчивость (" + rock2.ToString() + ")" + Environment.NewLine;
            }
            else if (rock2 >= 17 & rock2 <= 32)
            {
                richTextBox1.Text += "Нейротизм: средний балл (" + rock2.ToString() + ")" + Environment.NewLine;
            }
            else if (rock2 >= 33 & rock2 <= 48)
            {
                richTextBox1.Text += "Нейротизм: ярко выраженный нейротизм (" + rock2.ToString() + ")" + Environment.NewLine;
            }


            if (rock3 >= 0 & rock3 <= 4)
            {
                richTextBox1.Text += "Ложь: сомнительный результат (" + rock2.ToString() + ")" + Environment.NewLine;
            }
            else if (rock3 >= 5 & rock3 <= 15)
            {
                richTextBox1.Text += "Ложь: достоверный результат (" + rock2.ToString() + ")" + Environment.NewLine;
            }
            else if (rock3 >= 16 & rock3 <= 20)
            {
                richTextBox1.Text += "Ложь: сомнительный результат (" + rock2.ToString() + ")" + Environment.NewLine;
            }
            else if (rock3 >= 20)
            {
                richTextBox1.Text += "Ложь: абсолютная недостоверность результатов (" + rock2.ToString() + ")" + Environment.NewLine;
            }
        }
            catch (Exception)
            { }}


        private void button8_Click(object sender, EventArgs e)
        {
            try 
            { 
            richTextBox2.Visible = false;
            richTextBox1.Height = 163;
            richTextBox1.Visible = true;
            groupBox1.Visible = true;
            richTextBox1.Text = "Вопрос №" + (pozition + 1).ToString() + ": " + diag[pozition];
            }
            catch (Exception)
            { }
        }
    }
}
