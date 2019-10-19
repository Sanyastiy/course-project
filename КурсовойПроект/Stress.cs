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
    public partial class Stress : Form
    {
        //массив для записи результатов
        //в будущем добавить разделение результатов по годам
        int[] result = new int[43] 
        { 
            100,73,65,63,63,53,50,47,45,45,44,40,40,39,39,38,37,36,35,31,30,29,29,29,28,26,26,25,24,23,20,20,20,19,19,18,17,16,15,15,13,12,11 
        };

        //объявление позиции (кол-во отвеченых вопросов) и результата
        int pozition = 0;
        int summa = 0;
        string opisanie = "";

        //массив вопросов
        string[] stres = new string[43];

        public Stress()
        {
            InitializeComponent();

            try
            {
                int ii = 0;
                foreach (string line in File.ReadLines(@"Materials/Строки стресс.txt"))
                {
                    stres[ii] = line;
                    ii++;
                }
                richTextBox2.Rtf = File.ReadAllText(@"Materials/Теория/Стрессоустойчивость.rtf");
            }
            catch (Exception)
            { }
        }

        //собсна вычисления, приписанные каждой кнопке ответов
        private void next(object sender, EventArgs e)
        {
            try
            {
                if (pozition < 42)  //подсчет отвеченных вопросов
                {
                    Button b = sender as Button;    //определение места откуда берется ответ
                    summa += result[pozition] * int.Parse((b.Tag).ToString());  //запись в результ. массив ТЭГа кнопки, в котором записан ответ
                    pozition++; //след вопрос
                    richTextBox1.Text = "Вопрос №" + (pozition + 1).ToString() + ": " + stres[pozition];    //вывод след вопроса
                }
                else
                {
                    //
                    //вывод результатов
                    richTextBox1.Height = 483;
                    opisanie = ИЗ("");
                    richTextBox1.Text =
                        "Итоги, всего баллов:" + summa.ToString() + Environment.NewLine + Environment.NewLine + "ваша сопротивляемость стрессу: " + opisanie;
                    //

                    //скрытие кнопков ответов
                    button2.Visible = false;
                    button3.Visible = false;
                    button4.Visible = false;
                    button7.Visible = false;
                    groupBox1.Visible = false;
                    label2.Visible = false;

                }
            }
            catch (Exception)
            { }
        }

        //определение сопротивляемости
        private string ИЗ(string opis)
        {
            try
            {
                opis = "";
                int count = summa;

                if (count >= (150) && count <= (199))
                {
                    opis = "высокая";
                }
                else if (count >= (200) && count <= (299))
                {
                    opis = "пороговая";
                }
                else if (count > (300))
                {
                    opis = "низкая";
                }
                else
                {
                    opis = "выше высокого 0_0";
                }
            }
            catch (Exception)
            { }
                return (opis);
            
        }

        //кнопка начать, открывает кнопки ответов
        private void button8_Click(object sender, EventArgs e)
        {
            try
            {
                richTextBox1.Height = 163;
                richTextBox1.Visible = true;
                richTextBox2.Visible = false;
                groupBox1.Visible = true;
                label2.Visible = true;
                button2.Visible = true;
                button3.Visible = true;
                button4.Visible = true;
                button7.Visible = true;
                button8.Visible = false;
                label1.Visible = true;

                //
                //вывод первого вопроса
                richTextBox1.Text = "Вопрос №" + (pozition + 1).ToString() + ": " + stres[pozition];
            }
            catch (Exception)
            { }
        }

        private void label1_Click(object sender, EventArgs e)
        {
            this.Close();
        }


    }
}
