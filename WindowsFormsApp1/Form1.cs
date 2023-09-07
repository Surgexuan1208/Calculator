using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection.Emit;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        Int64 ibuff = 0;
        double dbuff = 0D;
        int statue=0;
        private bool contain(string str,char target)
        {
            for(int i = 0; i < str.Length; i++)
            {
                if (str[i] == target)
                {
                    return true;
                }
            }
            return false;
        }
        private string selecter(string str,int size)
        {
            string sbuff = "";
            int compare=0;
            if (size > str.Length)
            {
                compare=str.Length;
            }
            else
            {
                compare=size;
            }
            for(int i = 0; i < compare; i++)
            {
                sbuff += str[i];
            }
            return sbuff;
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            textBox1.Text = "0";
        }
        private void button_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "")
            {
                textBox2.TextAlign = HorizontalAlignment.Right;
                textBox2.Text = (sender as Button).Text;
                if (contain(textBox1.Text,'.'))
                {
                    dbuff = double.Parse(textBox1.Text);
                    label1.Text=dbuff.ToString()+" double";
                }
                else
                {
                    ibuff = int.Parse(textBox1.Text);
                    label1.Text = ibuff.ToString() + " int";
                }
                statue=1;
            }
            
        }
        private void numbutton_Click(object sender, EventArgs e)
        {
            if((sender as Button).Text == "0"&&textBox2.Text== "➗")
            {
                return;
            }
            if (textBox2.Text.Length!=0 && statue == 1)
            {
                textBox1.Text = "";
                statue = 0;
            }
            if (statue == 2)
            {
                textBox1.Text = "";
                textBox2.Text = "";
                statue = 0;
                dbuff = 0D;
                ibuff = 0;
            }
            if (textBox1.Text.Length == 1&&textBox1.Text.Length<13)
            {
                if (textBox1.Text[0] =='0')
                {
                    textBox1.Text = (sender as Button).Text;
                }
                else{
                    textBox1.Text += (sender as Button).Text;
                }
            }
            else
            {
                if (textBox1.Text.Length > 11)
                {
                    
                }
                else
                {
                    textBox1.Text += (sender as Button).Text;
                }
            }
        }
        private void backbtn(object sender, EventArgs e)
        {
            textBox2.TextAlign = HorizontalAlignment.Right;
            textBox2.Text = "";
            if (textBox1.Text != "")
            {
                string str="";
                for(int i=0;i<textBox1.Text.Length-1;i++)
                {
                    str += textBox1.Text[i];
                }
                textBox1.Text = str;
                if (textBox1.Text == "-")
                {
                    textBox1.Text = "0";
                }
            }
            else
            {
                textBox1.Text = "0";
            }
            if(textBox1.Text == "")
            {
                textBox1.Text = "0";
                textBox2.Text = "";
            }
        }

        private void signedbtn(object sender, EventArgs e)
        {   
            if(textBox1.Text != "0")
            {   
                string str = "";
                if(contain(textBox1.Text, '.'))
                {
                    if (double.Parse(textBox1.Text) > 0)
                    {
                        str += "-";
                        for (int i = 0; i < textBox1.Text.Length; i++)
                        {
                            str += textBox1.Text[i];
                        }
                    }
                    else
                    {
                        for (int i = 1; i < textBox1.Text.Length; i++)
                        {
                            str += textBox1.Text[i];
                        }
                    }
                }
                else
                {
                    if (int.Parse(textBox1.Text) > 0)
                    {
                        str += "-";
                        for (int i = 0; i < textBox1.Text.Length; i++)
                        {
                            str += textBox1.Text[i];
                        }
                    }
                    else
                    {
                        for (int i = 1; i < textBox1.Text.Length; i++)
                        {
                            str += textBox1.Text[i];
                        }
                    }
                }
                textBox1.Text = str;
            }
        }

        private void button8_Click(object sender, EventArgs e)
        {   
            textBox1.Text = "0";         
            if (statue == 2)
            {
                textBox2.Text = "";
                textBox2.TextAlign = HorizontalAlignment.Right;
                dbuff = 0D;
                ibuff = 0;
                statue = 0;
            }
        }

        private void button14_Click(object sender, EventArgs e)
        {
            textBox1.Text = "0";
            textBox2.Text = "";
            textBox2.TextAlign = HorizontalAlignment.Right;
            dbuff = 0D;
            ibuff = 0;
            statue = 0;
        }

        private void button19_Click(object sender, EventArgs e)
        {
            if (contain(textBox1.Text,'.'))
            {
                if (contain(textBox1.Text, '-'))
                {
                    string str = "";
                    for (int i = 1; i < textBox1.Text.Length; i++)
                    {
                        str += textBox1.Text[i];
                    }
                    dbuff = double.Parse(str);
                    dbuff = Math.Pow(dbuff, 0.5);
                    textBox1.Text = selecter(dbuff.ToString(), 12);
                    textBox2.TextAlign = HorizontalAlignment.Left;
                    textBox2.Text = "E";
                    statue = 2;
                }
                else
                 {
                    dbuff=double.Parse(textBox1.Text);
                    dbuff = Math.Pow(dbuff, 0.5);
                    textBox1.Text = selecter(dbuff.ToString(), 12);
                    textBox2.Text = "=";
                    statue = 2;
                }
            }
            else
            {
                if (contain(textBox1.Text, '-'))
                {
                    string str = "";
                    for (int i = 1; i < textBox1.Text.Length; i++)
                    {
                        str += textBox1.Text[i];
                    }
                    ibuff = Int64.Parse(str);
                    dbuff = Math.Pow(ibuff, 0.5);
                    textBox1.Text = selecter(dbuff.ToString(), 12);
                    textBox2.TextAlign = HorizontalAlignment.Left;
                    textBox2.Text = "E";
                    statue = 2;
                }
                else
                {
                    ibuff =Int64.Parse(textBox1.Text);
                    dbuff = Math.Pow(ibuff, 0.5);
                    textBox1.Text = selecter(dbuff.ToString(),12);
                    textBox2.Text = "=";
                    statue = 2;
                }
            }
        }
        private void button13_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        private void equal_Click(object sender, EventArgs e)
        {
            if (textBox1.Text.Length != 0)
            {
                if (contain(dbuff.ToString(), '.')||contain(textBox1.Text,'.'))
                {
                    switch (textBox2.Text)
                    {
                        case "➕":
                            dbuff = dbuff + double.Parse(textBox1.Text);
                            label1.Text=dbuff.ToString();
                            break;
                        case "➖":
                            dbuff = dbuff - double.Parse(textBox1.Text);
                            break;
                        case "✖️":
                            dbuff = dbuff * double.Parse(textBox1.Text);
                            break;
                        case "➗":
                            dbuff = dbuff / double.Parse(textBox1.Text);
                            textBox1.Text = selecter(dbuff.ToString(), 12);
                            break;
                    }
                    textBox1.Text =dbuff.ToString();
                }
                else
                {
                    switch (textBox2.Text)
                    {
                        case "➕":
                            ibuff = ibuff + int.Parse(textBox1.Text);
                            textBox1.Text = ibuff.ToString();
                            break;
                        case "➖":
                            ibuff = ibuff - int.Parse(textBox1.Text);
                            textBox1.Text = ibuff.ToString();
                            break;
                        case "✖️":
                            ibuff = ibuff * int.Parse(textBox1.Text);
                            textBox1.Text = ibuff.ToString();
                            break;
                        case "➗":
                            dbuff = (double)ibuff / double.Parse(textBox1.Text);
                            textBox1.Text = selecter(dbuff.ToString(), 12);
                            break;
                    }
                }
                textBox2.Text = "=";
                statue = 2;
            }
        }
        private void button12_Click(object sender, EventArgs e)
        {
            if (!contain(textBox1.Text, '.'))
            {
                textBox1.Text += '.';
            }
        }
    }
}