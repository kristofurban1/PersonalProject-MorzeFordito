using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows;

namespace MorzeFordito1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private void groupBox1_Enter(object sender, EventArgs e)
        {
            //no
        }
        private void textBoxOutput_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void textBoxTO_MouseDoubleClick(object sender, MouseEventArgs e)
        {

        }
        private void textBoxTO_TextChanged(object sender, EventArgs e)
        {

        }
        private void button2_Click(object sender, EventArgs e)
        {

        }




        public string[] abc = new string[54] { "a", "b", "c", "d", "e", "f", "g", "h", "i", "j", "k", "l", "m", "n", "o", "p", "q", "r", "s", "t", "u", "v", "w", "x", "y", "z", "0", "1", "2", "3", "4", "5", "6", "7", "8", "9", "!", "\"", "&", "\'", ")", "(", ",", "-", "+", ".", "/", ":", ";", "=", "?", "@", "_", "*" };
        public string[] ABC = new string[26] { "A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K", "L", "M", "N", "O", "P", "Q", "R", "S", "T", "U", "V", "W", "X", "Y", "Z" };
        public string[] morze = new string[54] { ".-", "-...", "-.-.", "-..", ".", "..-.", "--.", "....", "..", ".---", "-.-", ".-..", "--", "-.", "---", ".--.", "--.-", ".-.", "...", "-", "..-", "...-", ".--", "-..-", "-.--", "--..", "-----", ".----", "..---", "...--", "....-", ".....", "-....", "--...", "---..", "----.", "--.--", ".-..-.", "...-..-", ".----.", "-.--.-", "-.--.", "--..--", "-....-", ".-.-.", ".-.-.-", "-..-.", "---...", "-.-.-.", "-...-", "..--..", ".--.-.", "..--.-", "-..-" };


        private void Form1_Load(object sender, EventArgs e)
        {
            textBoxSzoveg.Text = "";
            textBoxMorze.Text = "";

            radioSzoveg.Checked = true;
        }
        private void fordit_Click(object sender, EventArgs e)
        {
            if (radioSzoveg.Checked == true && textBoxSzoveg.Text != "" || radioMorze.Checked == true && textBoxMorze.Text != "")
            {
                errorProvider1.Clear();
                if (radioSzoveg.Checked == true)
                {
                    //Szöveg
                    textBoxMorze.Text = "";

                    string selected = "";
                    int pos = 0;
                    string trans = "";
                    string morze0 = "";

                    for (int i = 0; i < textBoxSzoveg.TextLength; i++)
                    {
                        selected = textBoxSzoveg.Text.Substring(i, 1);

                        if (abc.Contains(selected) == true)
                        {
                            pos = Array.IndexOf(abc, selected);

                            trans = morze[pos].ToString() + " ";
                        }
                        else if (ABC.Contains(selected) == true)
                        {
                            pos = Array.IndexOf(ABC, selected);

                            trans = morze[pos].ToString() + " ";
                        }
                        else
                        {
                            switch (selected)
                            {
                                case "á": trans = morze[0]; break;
                                case "é": trans = morze[4]; break;
                                case "í": trans = morze[8]; break;
                                case "ó": trans = morze[14]; break;
                                case "ö": trans = morze[14]; break;
                                case "ő": trans = morze[14]; break;
                                case "ú": trans = morze[20]; break;
                                case "ü": trans = morze[20]; break;
                                case "ű": trans = morze[20]; break;
                                default: trans = "/"; break;
                            }
                            trans = trans + " ";

                        }
                        morze0 = morze0 + trans;
                    }

                    textBoxMorze.Text = morze0;
                }
                else
                {
                    //morze
                    textBoxSzoveg.Text = "";

                    int pos = 0;
                    string trans = "";
                    string szo = "";
                    string text0 = "";

                    string[] szavak = textBoxMorze.Text.Split('/');

                    for (int i = 0; i < szavak.Length; i++)
                    {
                        string[] betuk = szavak[i].Split(' ');

                        for (int x = 0; x < betuk.Length; x++)
                        {
                            if (betuk[x] != "")
                            {
                                if (morze.Contains(betuk[x]) == true)
                                {
                                    pos = Array.IndexOf(morze, betuk[x]);

                                    trans = abc[pos];
                                }
                                else
                                {
                                    trans = " ";
                                }
                                szo = szo + trans;
                            }
                        }

                        if (i != 0 || i != szavak.Length - 1)
                        {
                            szo = szo + " ";
                        }

                        text0 = text0 + szo;
                        szo = "";

                    }
                    textBoxSzoveg.Text = text0;
                }
            }
            else
            {
                errorProvider1.SetError(fordit, @"Irj valamit a kijelölt oldaltra!");
            }
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            //Realtime On?
            if (checkBox1.Checked == true)
            {
                textBoxInput.Enabled = true;
                textBoxOutput.Enabled = true;
            }
            else
            {
                textBoxInput.Enabled = false;
                textBoxOutput.Enabled = false;
                textBoxOutput.Text = "";
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            string rawText = textBoxInput.Text;

            if (checkBox2.Checked != true)
            {
                int pos = -1;
                string text = "";

                if (abc.Contains(rawText) == true)
                {
                    pos = Array.IndexOf(abc, rawText);

                    text = morze[pos].ToString() + " ";
                }
                else if (ABC.Contains(rawText) == true)
                {
                    pos = Array.IndexOf(ABC, rawText);

                    text = morze[pos].ToString() + " ";
                }
                else
                {
                    switch (rawText)
                    {
                        case "á": text = morze[0]; break;
                        case "é": text = morze[4]; break;
                        case "í": text = morze[8]; break;
                        case "ó": text = morze[14]; break;
                        case "ö": text = morze[14]; break;
                        case "ő": text = morze[14]; break;
                        case "ú": text = morze[20]; break;
                        case "ü": text = morze[20]; break;
                        case "ű": text = morze[20]; break;
                        case " ": text = "/"; break;
                        default:; break;
                    }
                    text = text + " ";
                }
                textBoxOutput.Text = textBoxOutput.Text + text;
                textBoxInput.Text = "";
            }
            else
            {
                if (rawText.Substring(rawText.Length - 1, 1) == " ")
                {
                    int pos = -1;
                    string text = "";

                    if (abc.Contains(rawText) == true)
                    {
                        pos = Array.IndexOf(abc, rawText);

                        text = morze[pos].ToString() + " ";
                    }
                    else if (ABC.Contains(rawText) == true)
                    {
                        pos = Array.IndexOf(ABC, rawText);

                        text = morze[pos].ToString() + " ";
                    }
                    else
                    {
                        switch (rawText)
                        {
                            case "á": text = morze[0]; break;
                            case "é": text = morze[4]; break;
                            case "í": text = morze[8]; break;
                            case "ó": text = morze[14]; break;
                            case "ö": text = morze[14]; break;
                            case "ő": text = morze[14]; break;
                            case "ú": text = morze[20]; break;
                            case "ü": text = morze[20]; break;
                            case "ű": text = morze[20]; break;
                            case " ": text = "/"; break;
                            default:; break;
                        }
                        text = text + " ";
                    }
                    textBoxOutput.Text = textBoxOutput.Text + text;
                    textBoxInput.Text = "";
                }
            }
        }

        private void textBoxOutput_DoubleClick(object sender, EventArgs e)
        {
            textBoxOutput.Text = "";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            textBoxMorze.Text = "";
            textBoxMorze.Text = textBoxOutput.Text;
            fordit_Click(sender, e);
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            radioMorze.Checked = true;
        }

        private void textBoxSzoveg_TextChanged(object sender, EventArgs e)
        {
            radioSzoveg.Checked = true;
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            Clipboard.SetText(textBoxOutput.Text);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Clipboard.SetText(textBoxMorze.Text);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            textBoxMorze.Text = Clipboard.GetText();
        }
    }
}
