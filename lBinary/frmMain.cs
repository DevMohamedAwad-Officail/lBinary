using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace lBinary
{
    public partial class frmMain : Form
    {
        public frmMain()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            try
            {

                byte[] btText;
                btText = System.Text.Encoding.UTF8.GetBytes(richTextBoxPlain_W.Text);
                Array.Reverse(btText);
                BitArray bit = new BitArray(btText);
                StringBuilder sb = new StringBuilder();


                for (int i = bit.Length - 1; i >= 0; i--)
                {
                    if (bit[i] == true)
                    {
                        sb.Append(1);
                    }
                    else
                    {
                        sb.Append(0);
                    }
                }


                richTextBoxBinary_R.Text = sb.ToString();
            }
            catch 
            {

            }
        }
       
        public string BinaryToString(string binary)
        {
            try
            {
                if (string.IsNullOrEmpty(binary))
                    throw new ArgumentNullException("binary");

                if ((binary.Length % 8) != 0)
                    throw new ArgumentException("Binary string invalid (must divide by 8)", "binary");

                StringBuilder builder = new StringBuilder();
                for (int i = 0; i < binary.Length; i += 8)
                {
                    string section = binary.Substring(i, 8);
                    int ascii = 0;
                    try
                    {
                        ascii = Convert.ToInt32(section, 2);
                    }
                    catch
                    {
                        throw new ArgumentException("Binary string contains invalid section: " + section, "binary");
                    }
                    builder.Append((char)ascii);
                }
                return builder.ToString();
            }
            catch 
            {
                return null;
            }
        }
        private void button2_Click(object sender, EventArgs e)
        {

            
            
            richTextBoxBPlain_R.Text = BinaryToString(richTextBoxBinary_W.Text);
            //richTextBoxBPlain_R.Text = richTextBoxBinary_W.Text.Replace( "0100000"," ").Replace( "0100001","!").Replace( "0100010","\"").Replace("0100011","#" ).Replace("0100100", "$").Replace("0100101", "%")
            //     .Replace("0101000",")").Replace("0101001","(").Replace( "0101010", "*").Replace( "0101011","+").Replace("0101101","-").Replace("0110000","0").Replace("0110001","1").Replace("0110010","2")
            //     .Replace( "0110011", "3").Replace( "0110100", "4").Replace( "0110101", "5").Replace( "0110110", "6").Replace( "0110111", "7").Replace( "0111000", "8").Replace( "0111001", "9").Replace( "0111010", ":")
            //     .Replace("0111011",";").Replace("1100001","a" ).Replace("1100010","b").Replace("1100011","c").Replace("1100100","d").Replace("0111100",">").Replace("0111101","=").Replace("0111110","<")
            //     .Replace( "0111111", "?").Replace( "1000001", "A").Replace( "1000010", "B").Replace( "1000011", "C").Replace( "1000100", "D").Replace( "1000101", "E").Replace( "1000110", "F").Replace( "1000111", "G")
            //     .Replace( "1001000", "H").Replace( "1001001", "I").Replace( "1001010", "J").Replace( "1001011", "K").Replace( "1001100", "L").Replace( "1001101", "M").Replace( "1001110", "N").Replace( "1001111", "O")
            //     .Replace( "1010000", "P").Replace( "1010001", "Q").Replace( "1010010", "R").Replace( "1010011", "S").Replace( "1010100", "T").Replace( "1010101", "U").Replace( "1010110", "V").Replace( "1010111", "W")
            //     .Replace( "1011000", "X").Replace( "1011001","U").Replace( "1011010", "Z").Replace( "1100101", "e").Replace( "1100110", "f").Replace( "1100111", "g").Replace( "1101000", "h").Replace( "1101001", "i")
            //     .Replace( "1101010", "j").Replace( "1101011", "k").Replace( "1101100", "i").Replace( "1101101", "m").Replace( "1101110", "n").Replace( "1101111", "o").Replace( "1110000", "p").Replace( "1110001", "q")
            //     .Replace( "1110010", "r").Replace( "1110011", "s").Replace( "1110100", "t").Replace( "1110101", "u").Replace( "1110110", "v").Replace( "1110111", "w").Replace( "1111000", "x").Replace( "1111001", "y")
            //     .Replace( "1111010", "z").Replace( "1111101", "{").Replace( "1111011", "}").Replace( "1111100", "|").Replace( "1100000","`").Replace( "1011011","]").Replace( "1011101", "[").Replace( "1011110", "^")
            //     .Replace( "1011111", "_").Replace( "1111110", "~").Replace( "1000000", "@");
        }
    

        private void button3_Click(object sender, EventArgs e)
        {
            AboutBox1 ab = new AboutBox1();
            ab.Show();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {try
            { Clipboard.SetText(richTextBoxBinary_R.Text); }
            catch { }
        }

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            try {
                Clipboard.SetText(richTextBoxBPlain_R.Text);
            }
            catch { }

        }

        private void linkLabel3_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            try {
                richTextBoxBinary_W.Text = Clipboard.GetText();
            }
            catch { }
        }

        private void linkLabel4_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            try
            {
                richTextBoxPlain_W.Text = Clipboard.GetText();
            }
            catch { }
        }

        private void linkLabel6_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            richTextBoxBinary_W.Text = richTextBoxBPlain_R.Text = "";
        }

        private void linkLabel5_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            richTextBoxBinary_R.Text = richTextBoxPlain_W.Text = "";
        }
    }
}
