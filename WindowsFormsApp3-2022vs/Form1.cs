using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml; //XML
using static System.Windows.Forms.VisualStyles.VisualStyleElement;



namespace WindowsFormsApp3_2022vs
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            TimeStamp();
            log.CollectionChanged += Log_CollectionChanged;
        }

        private void Log_CollectionChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
            TimeStamp();
        }

        ObservableCollection<string> log = new ObservableCollection<string>();
        public void TimeStamp()
        {
            string date = DateTime.Now.ToString("yyyy-MM-dd");
            string folderPath = $@"C:\Users\HoppeM\source\repos\ciennce\winForms\WindowsFormsApp3-2022vs\Log txt";
            string path = Path.Combine(folderPath, $"Log_{date}.txt");

            if (!Directory.Exists(folderPath))
            {
                Directory.CreateDirectory(folderPath);
            }

            string combinedLog = string.Concat(log);



            if (!File.Exists(path))
            {
                using (StreamWriter sw = File.CreateText(path))
                {
                    sw.WriteLine(combinedLog);
                }

            }
            else
            {
                using(StreamWriter sw = File.AppendText(path))
                {
                    sw.WriteLine(combinedLog);
                }
            }

        }



        new List<double> history = new List<double>();

        private void calcBox_TextChanged(object sender, EventArgs e)
        {

        }




        const string ordnerpfad = "C:\\Users\\HoppeM\\source\\repos\\ciennce\\winForms\\WindowsFormsApp3-2022vs\\Daten XML";
        string dateipfad = Path.Combine(ordnerpfad, "daten.xml");




        

        string input = string.Empty;


        private void n0_Click(object sender, EventArgs e)
        {
            if(calcBox.Text == "0")
            {
                calcBox.Text = "0";
            }
            else
            {
                calcBox.Text += "0";
            }
            
            numCount.Add(0.0);
            log.Add("0");
        }

        private void button8_Click(object sender, EventArgs e)
        {
            if (calcBox.Text == "0")
            {
                calcBox.Text = "2";
            }
            else
            {
                calcBox.Text += "2";
            }
            numCount.Add(2.0);
            log.Add("2");
        }

        private void n3_Click(object sender, EventArgs e)
        {
            if (calcBox.Text == "0")
            {
                calcBox.Text = "3";
            }
            else
            {
                calcBox.Text += "3";
            }
            numCount.Add(3.0);
        }

        private void n4_Click(object sender, EventArgs e)
        {
            if (calcBox.Text == "0")
            {
                calcBox.Text = "4";
            }
            else
            {
                calcBox.Text += "4";
            }
            numCount.Add(4.0);
        }

        private void n5_Click(object sender, EventArgs e)
        {
            if (calcBox.Text == "0")
            {
                calcBox.Text = "5";
            }
            else
            {
                calcBox.Text += "5";
            }
            numCount.Add(5.0);
        }

        private void n6_Click(object sender, EventArgs e)
        {
            if (calcBox.Text == "0")
            {
                calcBox.Text = "6";
            }
            else
            {
                calcBox.Text += "6";
            }
            numCount.Add(6.0);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (calcBox.Text == "0")
            {
                calcBox.Text = "7";
            }
            else
            {
                calcBox.Text += "7";
            }
            numCount.Add(7.0);
        }

        private void n8_Click(object sender, EventArgs e)
        {
            if (calcBox.Text == "0")
            {
                input = "8";
            }
            else
            {
                input += "8";
            }
            calcBox.Text = input;
        }

        private void n9_Click(object sender, EventArgs e)
        {
            if (calcBox.Text == "0")
            {
                calcBox.Text = "9";
            }
            else
            {
                calcBox.Text += "9";
            }
            numCount.Add(9.0);
        }

        private void button15_Click(object sender, EventArgs e)
        {
            using (XmlWriter writer = XmlWriter.Create(dateipfad, new XmlWriterSettings() { Indent = true }))

            {

                writer.WriteStartDocument();
                writer.WriteStartElement("Datenbank");
                writer.WriteStartElement("History");

                foreach (var item in history)

                {

                    writer.WriteStartElement("Ergebnis");
                    writer.WriteValue(item);
                    writer.WriteEndElement();

                }

                writer.WriteEndElement();
                writer.WriteEndElement();

            }

        }

        private void dot_Click(object sender, EventArgs e)  //FIX!!! "." notation klappt nicht, konkantinierung umbauen. Logic ändern.
        {
            if (calcBox.Text == "0")
            {
                calcBox.Text = ".";
            }
            else
            {
                calcBox.Text += ".";
            }
 
        }

        
        string operator1 = string.Empty;
        string operator2 = string.Empty;
        double result = 0.0;






        List<double> numCount = new List<double>();
        List<double> finalNumCount = new List<double>();

        private void Clear_Click(object sender, EventArgs e)
        {
            calcBox.Text = "0";
            finalNumCount.Clear();
            numCount.Clear();
            log.Clear();
        }
        private void n1_Click_1(object sender, EventArgs e)
        {
            if (calcBox.Text == "0")
            {
                calcBox.Text = "1";
            }
            else
            {
                calcBox.Text += "1";
            }
            numCount.Add(1.0);
            log.Add("1");
            
        } //Number 1

        char operation;
        private void plus_Click(object sender, EventArgs e) //+
        {
            ProcessFinalNumCountLogic();

            operation = '+';
            calcBox.Text = operation.ToString();
            log.Add("+");
        }

        private void minus_Click(object sender, EventArgs e)
        {
            ProcessFinalNumCountLogic();

            operation = '-';
            calcBox.Text = operation.ToString();
        }

        private void divide_Click(object sender, EventArgs e)
        {
            ProcessFinalNumCountLogic();

            operation = '/';
            calcBox.Text = operation.ToString();
        }

        private void mulitply_Click(object sender, EventArgs e)
        {
            ProcessFinalNumCountLogic();

            operation = '*';
            calcBox.Text = operation.ToString();
        }

        private void ProcessFinalNumCountLogic()
        {
            string combined = string.Concat(numCount); // bsp.: numCount = {1, 1, 1} -> combined = "111"

            double newValue = double.Parse(combined); // "111" -> newValue; newValue=111 // error wrong format

            finalNumCount.Add(newValue); //finalNumCount = {111}
            numCount.Clear();
        }

        private void equals_Click(object sender, EventArgs e) //=
        {
            log.Add("=");

            ProcessFinalNumCountLogic();
            if (operation == '+')
            {

                double result = 0.0;
                for (int i = 0; i < finalNumCount.Count; i++)
                {
                    result += finalNumCount[i];
                }
                calcBox.Text = result.ToString();
                history.Add(result);
                log.Add(result.ToString());
                finalNumCount.Clear();
            }

            if (operation == '-')
            {

                double result = finalNumCount[0];
                for (int i = 1; i < finalNumCount.Count; i++)
                {
                    result -= finalNumCount[i];   
                }
                calcBox.Text = result.ToString();
                history.Add(result);
                log.Add(result.ToString());
                finalNumCount.Clear();
            }


            if (operation == '/')
            {

                double result = finalNumCount[0];
                for (int i = 1; i < finalNumCount.Count; i++)
                {
                    result /= finalNumCount[i];   
                }
                calcBox.Text = result.ToString();
                history.Add(result);
                log.Add(result.ToString());
                finalNumCount.Clear();
            }

            if(operation == '*')
            {
                double result = finalNumCount[0];
                for (int i = 1; i < finalNumCount.Count; i++)
                {
                    result *= finalNumCount[i];   
                }
                calcBox.Text = result.ToString();
                history.Add(result);
                log.Add(result.ToString());
                finalNumCount.Clear();
            }

        }

        private void Load_Click(object sender, EventArgs e)
        {
            calcBox.Text = history.Last().ToString();
        }

        
    }


}
