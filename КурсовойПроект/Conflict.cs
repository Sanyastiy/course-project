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
    public partial class Conflict : Form
    {

        int pozition = 0;

        //массив для записи результатов
        bool[] result = new bool[30];


        //массив вопросов
        string[,] conflict = new string[30,2];
        //массив ответов
        string[] otvet = new string[11];


        public Conflict()
        {
            InitializeComponent();
            try
            { 
            int ii = 0;
            foreach (string line in File.ReadLines(@"Materials/Строки конфликтА.txt"))
            {
                conflict[ii,0] = line;
                ii++;
            }
            ii = 0;
            foreach (string line in File.ReadLines(@"Materials/Строки конфликтБ.txt"))
            {
                conflict[ii, 1] = line;
                ii++;
            }
            richTextBox2.Rtf = File.ReadAllText(@"Materials/Теория/Конфликт.rtf");
            }
            catch (Exception)
            { }
        }


        private void next(object sender, EventArgs e)
        {
            try
            {
            button9.Visible = false;
            if (pozition < 29)  //подсчет отвеченных вопросов
            {
                Button b = sender as Button;    //определение места откуда берется ответ
                result[pozition] = Convert.ToBoolean((b.Tag).ToString());   //запись в результ. массив ТЭГа кнопки, в котором записан ответ
                pozition++; //след вопрос
                richTextBox1.Text = "Вопрос №" + (pozition + 1).ToString();    //вывод след вопроса
                button2.Text = conflict[pozition, 0];
                button3.Text = conflict[pozition, 1];
            }
            else
            {
                int soper= sop();
                int sotrud = sot();
                int compr = comp();
                int izbeg = izb(); 
                int prisposob = pris();


                if ((soper+sotrud+compr/2)>=(prisposob+izbeg+compr/2))
                {
                    richTextBox1.Text = "В соответствии с результатами тестирования у вас шансов выиграть конфликт больше, чем у оппонента.";
                }
                else if ((soper + sotrud + compr / 2) < (prisposob + izbeg + compr / 2))
                {
                    richTextBox1.Text = "В соответствии с результатами тестирования у вас шансов выиграть конфликт меньше, чем у оппонента.";
                }
                richTextBox1.Text += Environment.NewLine + "Оптимальной стратегией в конфликте считается такая, когда применяются все пять тактик поведения, и каждая из них имеет значение в интервале от 5 до 7 баллов. Если ваш результат отличен от оптимального, то одни тактики выражены слабо - имеют значения ниже 5 баллов, другие - сильно - выше 7 баллов." + Environment.NewLine +
                    "Ваш результат" + Environment.NewLine +
                    "Баллов соперничества: " + soper.ToString() + Environment.NewLine +
                    "Баллов сотрудничества: " + sotrud.ToString() + Environment.NewLine +
                    "Баллов компромиса: " + compr.ToString() + Environment.NewLine +
                    "Баллов приспособления: " + prisposob.ToString() + Environment.NewLine +
                    "Баллов избегания: " + izbeg.ToString();
                richTextBox1.Height = 483;
                
                groupBox1.Visible = false;
            }
            }
            catch (Exception)
            { }
        }

        private int sop()
        {
            int soper = 0;
            try
            { 
            SortedSet<int> set = new SortedSet<int> { 2, 7, 9, 16, 24, 27 };

            foreach (int s in set)
            {
                if (result[s])
                {
                    soper++;
                }
            }
            SortedSet<int> irset = new SortedSet<int> { 5, 8, 12, 13, 15, 21 };
            foreach (int s in irset)
            {
                if (!result[s])
                {
                    soper++;
                }
            }
            }
            catch (Exception)
            { }
            return (soper);
        }

        private int sot()
        {
            int sot = 0;
            try
            { 
            SortedSet<int> set = new SortedSet<int> { 4, 10, 13, 18, 19, 22 };

            foreach (int s in set)
            {
                if (result[s])
                {
                    sot++;
                }
            }
            SortedSet<int> irset = new SortedSet<int> { 1, 7, 20, 25, 27, 29 };
            foreach (int s in irset)
            {
                if (!result[s])
                {
                    sot++;
                }
            }
            }
            catch (Exception)
            { }
            return (sot);
        }

        private int comp()
        {
            int comp = 0;
            try
            { 
            SortedSet<int> set = new SortedSet<int> { 1, 3, 12, 21, 25, 28 };

            foreach (int s in set)
            {
                if (result[s])
                {
                    comp++;
                }
            }
            SortedSet<int> irset = new SortedSet<int> { 6, 9, 11, 17, 19, 23 };
            foreach (int s in irset)
            {
                if (!result[s])
                {
                    comp++;
                }
            }
            }
            catch (Exception)
            { }
            return (comp);
        }

        private int izb()
        {
            int comp = 0;
            try
            { 
            SortedSet<int> set = new SortedSet<int> { 0, 5, 6, 8, 11, 26 };

            foreach (int s in set)
            {
                if (result[s])
                {
                    comp++;
                }
            }
            SortedSet<int> irset = new SortedSet<int> { 4, 14, 16, 18, 22, 28 };
            foreach (int s in irset)
            {
                if (!result[s])
                {
                    comp++;
                }
            }
            }
            catch (Exception)
            { }
            return (comp);
        }

        private int pris()
        {

            int comp = 0;
            try
            { 
            SortedSet<int> set = new SortedSet<int> { 14, 15, 17, 20, 23, 29 };

            foreach (int s in set)
            {
                if (result[s])
                {
                    comp++;
                }
            }
            SortedSet<int> irset = new SortedSet<int> { 0, 2, 3, 10, 24, 26 };
            foreach (int s in irset)
            {
                if (!result[s])
                {
                    comp++;
                }
            }
            }
            catch (Exception)
            { }
            return (comp);
        }

        private void label1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button8_Click(object sender, EventArgs e)
        { 
            try
            { 
            richTextBox1.Height = 163;
            richTextBox1.Visible = true;
            richTextBox2.Visible = false;
            groupBox1.Visible = true;
            button8.Visible = false;
            label1.Visible = true;

            button2.Text = conflict[pozition, 0];
            button3.Text = conflict[pozition, 1];
            }
            catch (Exception)
            { }
        }
    }
}
