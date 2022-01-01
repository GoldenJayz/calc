using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace remoter
{
    public partial class Form1 : Form
    {
        public string conc;
        public int[] numeros = {};
        public string operation = "";


        public Form1()
        {
            InitializeComponent();
            button1.Click += button_click;
            button2.Click += button_click;
            button4.Click += button_click;
            button5.Click += button_click;
            button8.Click += button_click;
            button7.Click += button_click;
            button6.Click += button_click;
            button11.Click += button_click;
            button10.Click += button_click;
            button9.Click += button_click;
        }

        public void button_click(object sender, EventArgs e)
        {
            string num = "";

            switch ((sender as Button).Name)
            {
                case "button1":
                    num = "0";
                    break;
                case "button2":
                    num = "1";
                    break;
                case "button4":
                    num = "2";
                    break;
                case "button5":
                    num = "3";
                    break;
                case "button8":
                    num = "4";
                    break;
                case "button7":
                    num = "5";
                    break;
                case "button6":
                    num = "6";
                    break;
                case "button11":
                    num = "7";
                    break;
                case "button10":
                    num = "8";
                    break;
                case "button9":
                    num = "9";
                    break;
            }

            conc += num;
            int f = convert(conc);
            if (f != -1) label1.Text = conc;
            else label1.Text = "Number is too large!";
        }

        private int convert(string button)
        {
            int retval = 0;

            try
            {
                retval = Int32.Parse(button);
            }
            catch (OverflowException)
            {
                retval = -1;
            }

            return retval;
        }

        void array_dump(string mode)
        {
            try
            {
                if (conc != "")
                {
                    int number = Int32.Parse(conc);
                    numeros = numeros.Concat(new int[] { number }).ToArray();
                }
            }
            catch (OverflowException) { label1.Text = "Output Number is too big"; }
            catch (ArgumentNullException) { label1.Text = "0"; }
            conc = "";
            operation = mode;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            label1.Text = "0";
            conc = "";
            Array.Clear(numeros, 0, numeros.Length);
        }

        private void button12_Click(object sender, EventArgs e)
        {
            array_dump("add");
        }

        private void button13_Click(object sender, EventArgs e)
        {
            array_dump("sub");
        }

        private void button14_Click(object sender, EventArgs e)
        {
            array_dump("mul");
        }

        private void button15_Click(object sender, EventArgs e)
        {
            array_dump("div");
        }

        private void button16_Click(object sender, EventArgs e)
        {
            if (conc != "")
            {
                int number = Int32.Parse(conc);
                numeros = numeros.Concat(new int[] { number }).ToArray();
                int result = 0;
                for (int i = 0; i < numeros.Length; i++)
                {
                    switch (operation)
                    {
                        case "add":
                            result = result + numeros[i];
                            break;
                        case "sub":
                            if (i == 0) result = numeros[i];
                            else result = result - numeros[i];
                            break;
                        case "mul":
                            if (i == 0) result = numeros[i];
                            else result = result * numeros[i];
                            break;
                        case "div":
                            if (i == 0) result = numeros[i];
                            else result = result / numeros[i];
                            break;
                    }
                }
                conc = "";
                label1.Text = result.ToString();
                Array.Clear(numeros, 0, numeros.Length);
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}