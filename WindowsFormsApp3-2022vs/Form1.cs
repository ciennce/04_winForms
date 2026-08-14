using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading;
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
            Schema();
            log2.CollectionChanged += Log_CollectionChanged;
            history2.CollectionChanged += History2_CollectionChanged;
        }

        private void History2_CollectionChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
            Schema();
        }

        private void Log_CollectionChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
            TimeStamp();
        }

        List<string> log = new List<string>();

        ObservableCollection<string> log2 = new ObservableCollection<string>();

        public void TimeStamp()
        {
            string date = DateTime.Now.ToString("yyyy-MM-dd");
            string folderPath = $@"C:\Users\HoppeM\source\repos\ciennce\winForms\WindowsFormsApp3-2022vs\Log txt";
            string path = Path.Combine(folderPath, $"Log_{date}.txt");

            if (!Directory.Exists(folderPath))
            {
                Directory.CreateDirectory(folderPath);
            }
            if (!File.Exists(path))
            {
                using (StreamWriter sw = File.CreateText(path))
                {
                    sw.WriteLine(log2);
                }

            }
            else
            {
                File.AppendAllLines(path, log2);
            }

        }



        new List<double> history = new List<double>();

        private void calcBox_TextChanged(object sender, EventArgs e)
        {

        }

        const string ordnerpfad = "C:\\Users\\HoppeM\\source\\repos\\ciennce\\winForms\\WindowsFormsApp3-2022vs\\Daten XML";
        string dateipfad = Path.Combine(ordnerpfad, "daten.xml");
        



        const string orderpfad2 = "C:\\Users\\HoppeM\\source\\repos\\ciennce\\winForms\\WindowsFormsApp3-2022vs\\Daten XML";
        string dateipfad2 = Path.Combine(orderpfad2, "daten2.xml");

        ObservableCollection<double> history2 = new ObservableCollection<double>();

        private void Schema()
        {
            using (XmlWriter writer1 = XmlWriter.Create(dateipfad2, new XmlWriterSettings() { Indent = true }))

            {
                //string a = $@"C:\asdas{dateipfad}dasd";
                writer1.WriteStartDocument();
                writer1.WriteStartElement("Calculations");

                foreach (var op in log2)
                {
                    writer1.WriteStartElement("Calculation");
                    writer1.WriteAttributeString("Operator", op);
                    foreach (var item in history2)

                    {

                        writer1.WriteStartElement("Number");
                        writer1.WriteValue(item);
                        writer1.WriteEndElement();
                    }
                    writer1.WriteEndElement();
                }

                writer1.WriteEndElement();


            }
        }



        private void n0_Click(object sender, EventArgs e)
        {
            Zero();
            if (calcBox.Text == "0")
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
            Two();
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
        private void playMusic(string buttonText)
        {
            switch (buttonText)
            {
                case "0":
                    Zero();
                    break;
                case "1":
                    One();
                    break;
                case "2":
                    Two();
                    break;
                case "3":
                    Three();
                    break;
                case "4":
                    Four();
                    break;
                case "5":
                    Five();
                    break;
                case "6":
                    Six();
                    break;
                case "7":
                    Seven();
                    break;
                case "8":
                    Eight();
                    break;
                case "9":
                    Nine();
                    break;
            }
        }

        private void n3_Click(object sender, EventArgs e)
        {
            System.Windows.Forms.Button button = (System.Windows.Forms.Button) sender;
            MessageBox.Show($"Button clicked: {button.Text}");
            calcBox.Text= calcBox.Text.Equals("0")?button.Text:calcBox.Text+button.Text;
            calcBox.Text+=button.Text;
            playMusic(button.Text);
            /*Three();
            if (calcBox.Text == "0")
            {
                calcBox.Text = "3";
            }
            else
            {
                calcBox.Text += "3";
            }*/
            numCount.Add(Convert.ToDouble(button.Text));
            log.Add(button.Text);
        }

        private void n4_Click(object sender, EventArgs e)
        {
            Four();
            if (calcBox.Text == "0")
            {
                calcBox.Text = "4";
            }
            else
            {
                calcBox.Text += "4";
            }
            numCount.Add(4.0);
            log.Add("4");
        }

        private void n5_Click(object sender, EventArgs e)
        {
            Five();
            if (calcBox.Text == "0")
            {
                calcBox.Text = "5";
            }
            else
            {
                calcBox.Text += "5";
            }
            numCount.Add(5.0);
            log.Add("5");
        }

        private void n6_Click(object sender, EventArgs e)
        {
            Six();
            if (calcBox.Text == "0")
            {
                calcBox.Text = "6";
            }
            else
            {
                calcBox.Text += "6";
            }
            numCount.Add(6.0);
            log.Add("6");
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Seven();
            if (calcBox.Text == "0")
            {
                calcBox.Text = "7";
            }
            else
            {
                calcBox.Text += "7";
            }
            numCount.Add(7.0);
            log.Add("7");
        }

        private void n8_Click(object sender, EventArgs e)
        {
            Eight();
            if (calcBox.Text == "0")
            {
                calcBox.Text = "8";
            }
            else
            {
                calcBox.Text += "8";
            }
            numCount.Add(8.0);
            log.Add("8");
        }

        private void n9_Click(object sender, EventArgs e)
        {
            Nine();
            if (calcBox.Text == "0")
            {
                calcBox.Text = "9";
            }
            else
            {
                calcBox.Text += "9";
            }
            numCount.Add(9.0);
            log.Add("9");
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




        List<double> numCount = new List<double>();
        List<double> finalNumCount = new List<double>();

        private void Clear_Click(object sender, EventArgs e)
        {
            SmokeAlarmSound();
            Thread.Sleep(400);
            calcBox.Text = "0";
            finalNumCount.Clear();
            numCount.Clear();
            log.Clear();
            log2.Clear();

        }
        private void n1_Click_1(object sender, EventArgs e)
        {
            One();
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
            log.Add("-");
        }

        private void divide_Click(object sender, EventArgs e)
        {
            ProcessFinalNumCountLogic();

            operation = '/';
            calcBox.Text = operation.ToString();
            log.Add("/");
        }

        private void mulitply_Click(object sender, EventArgs e)
        {
            ProcessFinalNumCountLogic();

            operation = '*';
            calcBox.Text = operation.ToString();
            log.Add("*");
        }

        private void ProcessFinalNumCountLogic()
        {
            string combined = string.Concat(numCount); // bsp.: numCount = {1, 1, 1} -> combined = "111"

            double newValue = double.Parse(combined); // "111" -> newValue; newValue=111 // error wrong format

            finalNumCount.Add(newValue); //finalNumCount = {111}
            history2.Add(newValue);
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

            if (operation == '*')
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

            log2.Add(string.Concat(log));

        }

        private void Load_Click(object sender, EventArgs e)
        {
            calcBox.Text = history.Last().ToString();
        }

        private void SmokeAlarmSound()
        {
            SoundPlayer player = new SoundPlayer(@"C:\Users\HoppeM\source\repos\ciennce\winForms\WindowsFormsApp3-2022vs\sounds\smoke-alarm-beep.wav");
            player.Play();
        }

        private void CorrectAnswer()
        {
            SoundPlayer player = new SoundPlayer(@"C:\Users\HoppeM\source\repos\ciennce\winForms\WindowsFormsApp3-2022vs\sounds\correct_F5OqKUF.wav");
            player.Play();
        }

        private void Zero()
        {
            SoundPlayer player = new SoundPlayer(@"C:\Users\HoppeM\source\repos\ciennce\winForms\WindowsFormsApp3-2022vs\sounds\0.wav");
            player.Play();

        }

        private void One()
        {
            SoundPlayer player = new SoundPlayer(@"C:\Users\HoppeM\source\repos\ciennce\winForms\WindowsFormsApp3-2022vs\sounds\1.wav");
            player.Play();
        }

        private void Two()
        {
            SoundPlayer player = new SoundPlayer(@"C:\Users\HoppeM\source\repos\ciennce\winForms\WindowsFormsApp3-2022vs\sounds\2.wav");
            player.Play();
        }

        private void Three()
        {
            SoundPlayer player = new SoundPlayer(@"C:\Users\HoppeM\source\repos\ciennce\winForms\WindowsFormsApp3-2022vs\sounds\3.wav");
            player.Play();
        }

        private void Four()
        {
            SoundPlayer player = new SoundPlayer(@"C:\Users\HoppeM\source\repos\ciennce\winForms\WindowsFormsApp3-2022vs\sounds\4.wav");
            player.Play();
        }

        private void Five()
        {
            SoundPlayer player = new SoundPlayer(@"C:\Users\HoppeM\source\repos\ciennce\winForms\WindowsFormsApp3-2022vs\sounds\5.wav");
            player.Play();
        }

        private void Six()
        {
            SoundPlayer player = new SoundPlayer(@"C:\Users\HoppeM\source\repos\ciennce\winForms\WindowsFormsApp3-2022vs\sounds\6.wav");
            player.Play();
        }

        private void Seven()
        {
            SoundPlayer player = new SoundPlayer(@"C:\Users\HoppeM\source\repos\ciennce\winForms\WindowsFormsApp3-2022vs\sounds\7.wav");
            player.Play();
        }

        private void Eight()
        {
            SoundPlayer player = new SoundPlayer(@"C:\Users\HoppeM\source\repos\ciennce\winForms\WindowsFormsApp3-2022vs\sounds\8.wav");
            player.Play();
        }

        private void Nine()
        {
            SoundPlayer player = new SoundPlayer(@"C:\Users\HoppeM\source\repos\ciennce\winForms\WindowsFormsApp3-2022vs\sounds\9.wav");
            player.Play();
        }

        private void outro()
        {
            SoundPlayer player = new SoundPlayer(@"C:\Users\HoppeM\source\repos\ciennce\winForms\WindowsFormsApp3-2022vs\sounds\outro.wav");
            player.Play();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            SoundPlayer player = new SoundPlayer(@"C:\Users\HoppeM\source\repos\ciennce\winForms\WindowsFormsApp3-2022vs\sounds\speed.wav");
            player.Play();
            calcBox.Text = "*W SPEED* ❤️‍";
        }
    }
}
