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
    public partial class Locus : Form
    {
       
   
        //описание массивов строк для вывода в ответе
    string[] otvet = new string[7];

    //массив для записи результатов
    int[] result = new int[44];

    //массив вопросов
    string[] locus = new string[44];
        
        //объявление позиции (кол-во отвеченых вопросов)
        int pozition = 0;
        public Locus()
        {
            
                InitializeComponent();
                try
                {
                int ii = 0;
                foreach (string line in File.ReadLines(@"Materials/Строки локус контроля.txt"))
                {
                    locus[ii] = line;
                    ii++;
                }

                ii = 0;
                foreach (string line in File.ReadLines(@"Materials/Ответы локус контроля.txt"))
                {
                    otvet[ii] = line;
                    ii++;
                }
                
            }
            catch(Exception)
            { }
                try
                {
                    richTextBox2.Rtf = File.ReadAllText(@"Materials/Теория/Локус.rtf");
                }
                catch (Exception)
                { }
        }

       

        //надпись закончить в самом тесте
        private void label1_Click(object sender, EventArgs e)
        {
            try { 
            groupBox2.Visible = false;
            button8.Visible = true;
            richTextBox1.Visible = false;
            button2.Visible = false;
            button3.Visible = false;
            button4.Visible = false;
            button5.Visible = false;
            button6.Visible = false;
            button7.Visible = false;

            this.Close();
            }
            catch (Exception)
            { }
        }

      

        //кнопка начать, открывает кнопки ответов
        private void button8_Click(object sender, EventArgs e)
        {
            try
            { 
            richTextBox1.Height = 163;
            richTextBox1.Visible = true;
            button2.Visible = true;
            button3.Visible = true;
            button4.Visible = true;
            button5.Visible = true;
            button6.Visible = true;
            button7.Visible = true;
            button8.Visible = false;
            label1.Visible = true;
            //testbutton
            richTextBox2.Visible = false;
            //вывод первого вопроса
            richTextBox1.Text = "Вопрос №" + (pozition + 1).ToString() + ": " + locus[pozition];
            }
            catch (Exception)
            { }
        }

        //собсна вычисления, приписанные каждой кнопке ответов
        private void next(object sender, EventArgs e)
        {
            try {       
            if (pozition < 43)  //подсчет отвеченных вопросов
            {
                Button b = sender as Button;    //определение места откуда берется ответ
                result[pozition] = int.Parse((b.Tag).ToString());   //запись в результ. массив ТЭГа кнопки, в котором записан ответ
                pozition++; //след вопрос
                richTextBox1.Text = "Вопрос №" + (pozition + 1).ToString() + ": " + locus[pozition];    //вывод след вопроса
            }
            else
            {
                //расчет стенов. 
                int rezio = ИО(0);

                int rezid = ИД(0);

                int rezin = ИН(0);

                int rezis = ИС(0);

                int rezip = ИП(0);

                int rezim = ИМ(0);

                int reziz = ИЗ(0);
                //
                //вывод результатов
                richTextBox1.Height = 483;  

                richTextBox1.Text =
                    "Итоги (в баллах от 1 до 10):" + Environment.NewLine + Environment.NewLine + "Общая интернальность – " + rezio.ToString() + Environment.NewLine + otvet[0] + Environment.NewLine +
                    "Интернальность в области достижений – " + rezid.ToString() + Environment.NewLine + otvet[1] + Environment.NewLine +
                    "Интернальность в области неудач – " + rezin.ToString() + Environment.NewLine + otvet[2] + Environment.NewLine +
                    "Интернальность в области семейных отношений – " + rezis.ToString() + Environment.NewLine + otvet[3] + Environment.NewLine +
                    "Интернальность в области производственных отношений – " + rezip.ToString() + Environment.NewLine + otvet[4] + Environment.NewLine +
                    "Интернальность в области межличностных отношений – " + rezim.ToString() + Environment.NewLine + otvet[5] + Environment.NewLine +
                    "Интернальность в отношении здоровья и болезни – " + reziz.ToString() + Environment.NewLine + otvet[6];
                //
                

                //скрытие кнопков ответов
                button2.Visible = false;
                button3.Visible = false;
                button4.Visible = false;
                button5.Visible = false;
                button6.Visible = false;
                button7.Visible = false;
                //

            }


            }
            catch (Exception)
            { }
        }
        //функции расчета стенов
        private int ИО(int rez)
        {
            try { 
            rez = 0;
            int count = (result[1] + result[3] + result[10] + result[11] + result[12] + result[13] + result[15] + result[16] + result[18] + result[19] + result[21] + result[24] + result[26] + result[28] + result[30] + result[31] + result[33] + result[35] + result[36] + result[38] + result[41] + result[43] + ((result[0] + result[2] + result[4] + result[5] + result[6] + result[7] + result[8] + result[9] + result[13] + result[17] + result[20] + result[22] + result[23] + result[25] + result[27] + result[29] + result[32] + result[34] + result[37] + result[39] + result[40] + result[42]) * (-1)));
            if (count >= (-132)) { rez = 1; }
             if (count >= (-12)) { rez = 2; }
            if (count >= (-1)) { rez = 3; }
             if (count >= (11)) { rez = 4; }
             if (count >= (23)) { rez = 5; }
             if (count >= (34)) { rez = 6; }
             if (count >= (46)) { rez = 7; }
             if (count >= (58)) { rez = 8; }
             if (count >= (70)) { rez = 9; }
            if (count >= (81)) { rez = 10; }
            }
            catch (Exception)
            { }
            return (rez);
        }

        private int ИД(int rez)
        {
            try { 
            rez = 0;
            int count = (result[11] + result[14] + result[26] + result[31] + result[35] + result[36] + ((result[0] + result[4] + result[5] + result[13] + result[25] + result[42]) * (-1)));

            if (count >= (-36) )            {                rez = 1;            }
             if (count >= (-9) )            {                rez = 2;            }
             if (count >= (-5) )            {                rez = 3;            }
             if (count >= (-1) )            {                rez = 4;            }
             if (count >= (3) )            {                rez = 5;            }
             if (count >= (7) )            {                rez = 6;            }
             if (count >= (11) )            {                rez = 7;            }
             if (count >= (16) )            {                rez = 8;            }
             if (count >= (20) )            {                rez = 9;            }
             if (count >= (24) )            {                rez = 10;            }
            }
            catch (Exception)
            { } 
            return (rez);
        }

        private int ИН(int rez)
        {
            try { 
            rez = 0;
            int count = (result[1] + result[3] + result[19] + result[30] + result[41] + result[43] + ((result[6] + result[23] + result[32] + result[37] + result[39] + result[40]) * (-1)));

            if (count >= (-36) )            {                rez = 1;            }
            if (count >= (-6) )            {                rez = 2;            }
            if (count >= (-2) )            {                rez = 3;            }
            if (count >= (2))            {                rez = 4;            }
             if (count >= (6) )            {                rez = 5;            }
            if (count >= (9) )            {                rez = 6;            }
             if (count >= (13) )            {                rez = 7;            }
             if (count >= (17) )            {                rez = 8;            }
             if (count >= (21) )            {                rez = 9;            }
             if (count >= (25) )            {               rez = 10;            }
            }
            catch (Exception)
            { } 
            return (rez);
        }

        private int ИС(int rez)
        {
            try { 
            rez = 0;
            int count = (result[1] + result[15] + result[19] + result[31] + result[36] + ((result[6] + result[13] + result[25] + result[27] + result[40]) * (-1)));

            if (count >= (-30) )            {                rez = 1;            }
             if (count >= (-10) )            {                rez = 2;            }
             if (count >= (-6))            {                rez = 3;            }
             if (count >= (-3) )            {                rez = 4;            }
             if (count >= (1) )            {                rez = 5;            }
             if (count >= (5))            {               rez = 6;            }
             if (count >= (8) )            {                rez = 7;            }
             if (count >= (12) )            {                rez = 8;            }
            if (count >= (15) )            {                rez = 9;            }
             if (count >= (19) )           {                rez = 10;            }
            }
            catch (Exception)
            { } 
            return (rez);
        }

        private int ИП(int rez)
        {
            try { 
            rez = 0;
            int count = (result[18] + result[21] + result[24] + result[41] + result[35] + result[36] + ((result[0] + result[8] + result[9] + result[29] + result[25] + result[42]) * (-1)));

            if (count >= (-30) )            {                rez = 1;            }
             if (count >= (-3) )            {                rez = 2;            }
             if (count >= (1) )            {                rez = 3;            }
             if (count >= (5) )            {                rez = 4;            }
            if (count >= (9) )            {                rez = 5;            }
             if (count >= (13))           {                rez = 6;            }
             if (count >= (17) )            {                rez = 7;            }
             if (count >= (21) )            {                rez = 8;            }
             if (count >= (25))            {                rez = 9;            }
             if (count >= (29) )            {                rez = 10;            }
            }
            catch (Exception)
            { } 
            return (rez);
        }

        private int ИМ(int rez)
        {
            try { 
            rez = 0;
            int count = (result[3] + result[26] + ((result[5] + result[37]) * (-1)));

            if (count >= (-12) )            {                rez = 1;            }
            if (count >= (-5))            {                rez = 2;            }
             if (count >= (-3) )            {                rez = 3;            }
             if (count >= (-1) )            {                rez = 4;            }
             if (count >= (1))            {                rez = 5;            }
             if (count >= (3) )            {                rez = 6;            }
             if (count >= (6) )            {                rez = 7;            }
             if (count >= (8) )            {                rez = 8;            }
            if (count >= (10) )            {                rez = 9;            }
             if (count >= (12) )            {                rez = 10;            }
            }
            catch (Exception)
            { }
                return(rez);
        }

        private int ИЗ(int rez)
        {
            try { 
            rez = 0;
            int count = (result[12] + result[33] + ((result[2] + result[22]) * (-1)));

            if (count >= (-12) )            {                rez = 1;            }
             if (count >= (-2))            {                rez = 2;            }
             if (count >= (0) )            {                rez = 3;            }
             if (count >= (2) )            {                rez = 4;            }
             if (count >= (4) )            {                rez = 5;            }
             if (count >= (5) )            {                rez = 6;            }
             if (count >= (6) )            {                rez = 7;            }
             if (count >= (8) )            {                rez = 8;            }
             if (count >= (10) )            {                rez = 9;            }
             if (count >= (12))            {                rez = 10;            }
            }
            catch (Exception)
            { } 
            return (rez);
        }
        

    }
}
