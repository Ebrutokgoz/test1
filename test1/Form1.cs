using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO.Ports;
using System.Drawing;

namespace test1
{
    public partial class MainForm : Form
    {
        private string data;
        private string gps, acx, acy, acz, pres, angx, angy, angz;
        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            textBox1.ReadOnly = true;
            string[] ports = SerialPort.GetPortNames();
            foreach (string port in ports)
                comboBox1.Items.Add(port);

            serialPort1.DataReceived += new SerialDataReceivedEventHandler(serialPort1_DataReceived_1);
        }
        private void serialPort1_DataReceived_1(object sender, SerialDataReceivedEventArgs e)
        {
            data = serialPort1.ReadLine();
            this.Invoke(new EventHandler(displayData_event));
        }
       
        private void displayData_event(object sender, EventArgs e)
        {
            //G-14-X-5-Y-5-Z-5
            //P-7-X-7-Y-7-Z-7
            //progressBar1.Value = Convert.ToInt16(data);
            
            //textBox1.Text += data + "\n";
            //label1.Text = data;
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                serialPort1.PortName = comboBox1.Text;
                serialPort1.BaudRate = 9600;
                serialPort1.Open();
                button2.Enabled = true;
                button1.Enabled = false;
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Hata");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            serialPort1.Close();
            button2.Enabled = false;
            button1.Enabled = true;
        }
        

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                string filelocation = @"C:\Users\ebrut\Desktop\testdosyasi\";
                string filename = "test.txt";
                System.IO.File.WriteAllText(filelocation + filename, "Değer  " + textBox1.Text);
                MessageBox.Show("Kaydetme başarılı", "Mesaj");
            }
            catch (Exception ex2)
            {
                MessageBox.Show(ex2.Message, "Hata");
            }
        }

        private void MainForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (serialPort1.IsOpen)
                serialPort1.Close();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            textBox1.ResetText();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }
    }
}
