using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;

namespace Lab6
{
    public partial class Form1 : Form
    {
        StudentGroup pibd13;
        public Form1()
        {
            InitializeComponent();
            pibd13 = new StudentGroup();
            comboBox1.Items.Add("Name");
            comboBox1.Items.Add("Age");
            comboBox1.Items.Add("Median");

            comboBox2.Items.Add("Name");
            comboBox2.Items.Add("Age");
            comboBox2.Items.Add("Median");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                pibd13.students.Add(new Student(Convert.ToInt32(textBox2.Text), textBox1.Text, Convert.ToDouble(textBox3.Text)));
                listBox1.Items.Clear();
                listBox1.Items.AddRange(pibd13.students.ToArray());
            }
            catch (Exception ex)
            {
                label4.Text = ex.Message;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Debug.WriteLine(comboBox1.SelectedItem.ToString());
            switch(comboBox1.SelectedItem.ToString())
            {
                case "Name":
                    {
                        listBox1.Items.Clear();
                        listBox1.Items.AddRange(pibd13.StreamSort(2).ToArray());
                    }
                    break;
                case "Age":
                    {
                        listBox1.Items.Clear();
                        listBox1.Items.AddRange(pibd13.StreamSort(1).ToArray());
                    }
                    break;
                case "Median":
                    {
                        listBox1.Items.Clear();
                        listBox1.Items.AddRange(pibd13.StreamSort(3).ToArray());
                    }
                    break;
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            switch (comboBox2.SelectedItem.ToString())
            {
                case "Name":
                    {
                        try
                        {
                            listBox1.Items.Clear();
                            listBox1.Items.AddRange(pibd13.StreamFilter(1, textBox4.Text).ToArray());
                        }
                        catch (Exception ex)
                        {
                            label4.Text = ex.Message;
                            listBox1.Items.Clear();
                            listBox1.Items.AddRange(pibd13.students.ToArray());
                        }
                    }
                    break;
                case "Age":
                    {
                        try
                        {
                            listBox1.Items.Clear();
                            listBox1.Items.AddRange(pibd13.StreamFilter(2, textBox4.Text).ToArray());
                        }
                        catch (Exception ex)
                        {
                            label4.Text = ex.Message;
                            listBox1.Items.Clear();
                            listBox1.Items.AddRange(pibd13.students.ToArray());
                        }
                    }
                    break;
                case "Median":
                    {
                        try
                        {
                            listBox1.Items.Clear();
                            listBox1.Items.AddRange(pibd13.StreamFilter(3, textBox4.Text).ToArray());
                        }
                        catch (Exception ex)
                        {
                            label4.Text = ex.Message;
                            listBox1.Items.Clear();
                            listBox1.Items.AddRange(pibd13.students.ToArray());
                        }
                    }
                    break;
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
            listBox1.Items.AddRange(pibd13.students.ToArray());
        }
    }

    
}
