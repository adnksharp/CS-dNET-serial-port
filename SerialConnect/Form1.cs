using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SerialConnect
{
	public partial class Form1 : Form
	{
		bool connect = false;
		public Form1()
		{
			InitializeComponent();
		}

		private void Form1_Load(object sender, EventArgs e)
		{
			label1.Text = "Conexión por puerto serie";
			button1.Text = "Conectar";
			button2.Text = "Buscar puertos";
			label2.Text = "Velocidad de conexión:";
			label3.Text = "Puerto:";
			label4.Text = "";
			SetComboBox();
		}

		private void B1C(object sender, EventArgs e)
		{
			connect = !connect;
			if (connect && !serialPort1.IsOpen)
			{
				if (comboBox2.SelectedItem != null)
				{
					serialPort1.PortName = comboBox2.SelectedItem.ToString();
					serialPort1.BaudRate = int.Parse(comboBox1.SelectedItem.ToString());
					try
					{
						serialPort1.Open();
						button1.Text = "Desconectar";
						label4.Text = "Conexión con el puerto " + comboBox2.SelectedItem.ToString() + " exitosa";
					}
					catch
					{
						label4.Text = "Error al conectarse al puerto " + comboBox2.SelectedItem.ToString();
					}
				}
				else
					label4.Text = "Puerto serie no valido";
			}
			else if (serialPort1.IsOpen)
			{
				button1.Text = "Conectar";
				serialPort1.Close();
				label4.Text = "Conexión finalizada";
			}
		}

		private void B2C(object sender, EventArgs e)
		{
			SetComboBox();
		}

		public void SetComboBox()
		{
			string[] ports = System.IO.Ports.SerialPort.GetPortNames();
			comboBox1.Items.Clear();
			comboBox2.Items.Clear();

			for (int i = 1; i < Math.Pow(2, 6); i *= 2)
				comboBox1.Items.Add(300 * i);
			comboBox1.Items.Add(14400);
			comboBox1.Items.Add(19200);
			for (byte i = 1; i < 4; i++)
				comboBox1.Items.Add((i * 9600) + 19200);
			comboBox1.Items.Add(57600);
			comboBox1.Items.Add(115200);
			foreach (string port in ports)
				comboBox2.Items.Add(port);

			comboBox1.SelectedIndex = 5;
			if (comboBox2.Items.Count > 0)
				comboBox2.SelectedIndex = 0;
		}
	}
}
