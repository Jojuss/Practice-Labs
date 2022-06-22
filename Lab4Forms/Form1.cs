using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Diagnostics;

namespace Lab4Forms
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            timer1.Interval = 1000;
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                using (StreamReader sr = new StreamReader(openFileDialog1.FileName, Encoding.GetEncoding("utf-8")))
                {
                    string s = sr.ReadLine();
                    Debug.WriteLine(s);
                    int balance = 0;
                    Queue<int> opBrckts = new Queue<int>();
                    for (int i = 0; i < s.Length; i++)
                    {
                        if (s[i] == '(') balance++;
                        if (s[i] == ')') balance--;
                        if (balance < 0)
                        {
                            label1.Text = "First inappropriate closing bracket at: " + i;
                            break;
                        }
                    }
                    if (balance > 0)
                    {
                        string l = "-1\nMissing closing brackets for opening brackets at: ";
                        for (int i = s.Length - 1; i >= 0; i--)
                        {
                            if (s[i] == ')')
                            {
                                int j = i-1;
                                while (s[j] != '(') j--;
                                opBrckts.Enqueue(j);
                            }
                            if (s[i] == '(' && !opBrckts.Contains(i)) l += Convert.ToString(i) + " ";
                        }
                        label1.Text = l;
                    }
                    if (balance == 0) label1.Text = "0";
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string text = "";
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                using (StreamReader sr = new StreamReader(openFileDialog1.FileName, Encoding.GetEncoding(1251)))
                {
                    string s;
                    string[] latin = new string[] { "a", "b", "v", "g", "d", "e", "yo", "zh", "z", "i", "ii", "k", "l", "m", "n", "o", "p", "r", "s", "t", "u", "f", "h", "c", "ch", "sh", "sh", "i", "y", "i", "a", "yu", "ya",
                                                    "A", "B", "V", "G", "D", "E", "YO", "ZH", "Z", "I", "II", "K", "L", "M", "N", "O", "P", "R", "S", "T", "U", "F", "H", "C", "CH", "SH", "SH", "I", "Y", "I", "A", "YU", "YA",};
                    char[] cyrillic = new char[] {  'а', 'б', 'в', 'г', 'д', 'е', 'ё', 'ж', 'з', 'и', 'й', 'к', 'л', 'м', 'н', 'о', 'п', 'р', 'с', 'т', 'у', 'ф', 'х', 'ц', 'ч', 'ш', 'щ', 'ъ', 'ы', 'ь', 'э', 'ю', 'я',
                                                    'А', 'Б', 'В', 'Г', 'Д', 'Е', 'Ё', 'Ж', 'З', 'И', 'Й', 'К', 'Л', 'М', 'Н', 'О', 'П', 'Р', 'С', 'Т', 'У', 'Ф', 'Х', 'Ц', 'Ч', 'Ш', 'Щ', 'Ъ', 'Ы', 'Ь', 'Э', 'Ю', 'Я',};
                    while ((s = sr.ReadLine()) != null)
                    {
                        Debug.WriteLine(s);
                        for (int i = 0; i < s.Length; i++)
                        {
                            text += latin[(Array.FindIndex(cyrillic, item => item == s[i]) + (cyrillic.Length / 2)) % cyrillic.Length];
                        }
                        text += Environment.NewLine;
                    }
                    label1.Text = text;
                }
            }
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                using (StreamWriter sw = File.CreateText(saveFileDialog1.FileName))
                {
                    
                    //Forming a list of words
                    List<string> words = new List<string>();
                    string word;
                    for (int i = 0; i < text.Length - 1; i++)
                    {
                        word = "";
                        while (i < text.Length - 1 && text[i] != ' ' && Convert.ToString(text[i]) != Environment.NewLine)
                        {
                            word += text[i];
                            i++;
                        }
                        words.Add(word);
                    }

                    //Shuffle list
                    Random rand = new Random();
                    int n = words.Count;
                    while (n > 1)
                    {
                        n--;
                        int k = rand.Next(n + 1);
                        string temp = words[k];
                        words[k] = words[n];
                        words[n] = temp;
                    }

                    //Reforming text
                    text = "";
                    foreach (var item in words) text += item + ' ';
                    sw.Write(text);
                }
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            int n = 0;
            string the_text = "";
            HashSet<Dictionary<char, int>> vowel_string_set = new HashSet<Dictionary<char, int>>();
            try
            {
                n = Convert.ToInt32(textBox1.Text);
                if (openFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    using (StreamReader sr = new StreamReader(openFileDialog1.FileName, Encoding.GetEncoding(1251)))
                    {
                        string[] text = new string[n];
                        int i = 0;
                        string s;
                        double sum = 0;
                        while ((s = sr.ReadLine()) != null && i < n)
                        {
                            sum += s.Length;
                            text[i] = s;
                            i++;
                        }
                        sum /= (double)n;

                        string remaining_text = Environment.NewLine + s;
                        while ((s = sr.ReadLine()) != null)
                        {
                            remaining_text += s + Environment.NewLine;
                        }


                        Dictionary<char, int> vowels = new Dictionary<char, int>();
                        string init_text_string = String.Join("\n", text);
                        Debug.WriteLine(init_text_string);
                        for (i = 0; i < n; i++)
                        {
                            if (text[i].Length <= sum) text[i] = null;
                            if (text[i] != null)
                            {
                                //Saving the old string
                                string init_row = text[i];
                                StringBuilder sb = new StringBuilder(text[i]);
                                vowels = new Dictionary<char, int> { { 'а', 0 }, { 'е', 0 }, { 'о', 0 }, { 'у', 0 }, { 'ё', 0 }, { 'ы', 0 }, { 'э', 0 }, { 'я', 0 }, { 'и', 0 }, { 'ю', 0 } };
                                for (int j = 0; j < text[i].Length; j++)
                                {
                                    if (vowels.ContainsKey(char.ToLower(text[i][j]))) vowels[char.ToLower(text[i][j])]++;
                                }
                                foreach (KeyValuePair<char, int> entry in vowels)
                                {
                                    if (entry.Value > 1)
                                    {
                                        for (int j = 0; j < text[i].Length; j++)
                                            if (char.ToLower(text[i][j]) == entry.Key)
                                            {
                                                sb[j] = char.IsUpper(text[i][j]) ? char.ToLower(text[i][j]) : char.ToUpper(text[i][j]);
                                                text[i] = sb.ToString();
                                            }
                                        vowel_string_set.Add(vowels);
                                    }
                                }

                                //Inverting the string
                                for (int j = 0; j < (text[i].Length / 2); j++)
                                {
                                    sb = new StringBuilder(text[i]);
                                    char temp = sb[j];
                                    sb[j] = sb[sb.Length - j - 1];
                                    sb[sb.Length - j - 1] = temp;
                                    text[i] = sb.ToString();
                                }
                                init_text_string = init_text_string.Replace(init_row, text[i]);
                            }
                        }
                        the_text = init_text_string + remaining_text;
                        Debug.WriteLine(the_text);
                    }
                    File.WriteAllLines(openFileDialog1.FileName, the_text.Split('\n'));
                }

                if (saveFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    using (StreamWriter sw = File.CreateText(saveFileDialog1.FileName))
                    {
                        foreach (var item in vowel_string_set)
                        {
                            List<char> keys = new List<char>(item.Keys);
                            List<int> values = new List<int>(item.Values);

                            int temp = 0;
                            char temp_char;
                            for (int i = 0; i < values.Count; i++)
                            {
                                for (int j = 0; j < values.Count - 1; j++)
                                {
                                    if (values[j] > values[j + 1])
                                    {
                                        temp = values[j + 1];
                                        values[j + 1] = values[j];
                                        values[j] = temp;

                                        temp_char = keys[j + 1];
                                        keys[j + 1] = keys[j];
                                        keys[j] = temp_char;
                                    }
                                }
                            }

                            for (int i = 0; i < keys.Count; i++)
                            {
                                sw.Write("" + keys[i] + " = " + values[i] + " ");
                            }
                            sw.Write(Environment.NewLine);
                        }
                    }
                }
            }
            catch(Exception ex)
            {
                label2.ForeColor = Color.Red;
                label2.Text = ex.Message;
                timer1.Start();
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            label2.ForeColor = Color.White;
            label2.Text = "<- number of rows to read";
            timer1.Stop();
        }
    }
}
