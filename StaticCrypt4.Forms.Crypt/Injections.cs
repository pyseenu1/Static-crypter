using Bunifu.Framework.UI;
using StaticCrypt4.Utilies;
using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using WindowsFormsControlLibrary1;

namespace StaticCrypt4.Forms.Crypt
{
	public class Injections : Form
	{
		public IContainer components;

		public GroupBox groupBox1;

		public BunifuCheckbox bunifuCheckbox1;

		public BunifuCustomLabel bunifuCustomLabel5;

		public BunifuCustomLabel bunifuCustomLabel1;

		public BunifuCustomLabel bunifuCustomLabel2;

		public BunifuCheckbox bunifuCheckbox2;

		public BunifuCustomTextbox bunifuCustomTextbox1;

		public BunifuCustomLabel bunifuCustomLabel3;

		public BunifuCheckbox bunifuCheckbox3;

		public BunifuCustomTextbox bunifuCustomTextbox2;

		public BunifuCustomLabel bunifuCustomLabel4;

		public BunifuCheckbox bunifuCheckbox4;

		public BunifuCustomLabel bunifuCustomLabel6;

		public BunifuCustomLabel bunifuCustomLabel7;

		public BunifuCheckbox bunifuCheckbox5;

		public BunifuCustomLabel bunifuCustomLabel8;

		public BunifuCheckbox bunifuCheckbox6;

		public BunifuCustomLabel bunifuCustomLabel9;

		public BunifuCheckbox bunifuCheckbox7;

		public BunifuCustomLabel bunifuCustomLabel10;

		public BunifuCustomLabel bunifuCustomLabel11;

		public GroupBox groupBox2;

		public ChromeRadioButton chromeRadioButton8;

		public ChromeRadioButton chromeRadioButton7;

		public ChromeRadioButton chromeRadioButton6;

		public ChromeRadioButton chromeRadioButton5;

		public ChromeRadioButton chromeRadioButton4;

		public ChromeRadioButton chromeRadioButton13;

		public ChromeRadioButton chromeRadioButton12;

		public ChromeRadioButton chromeRadioButton11;

		public ChromeRadioButton chromeRadioButton9;

		public ChromeRadioButton chromeRadioButton10;

		public Injections()
		{
			InitializeComponent();
		}

		private void Injections_Load(object sender, EventArgs e)
		{
			Helpers.TabNumber = 2;
		}

		private void chromeRadioButton11_CheckedChanged(object sender)
		{
			if (chromeRadioButton11.Checked)
			{
				chromeRadioButton4.Checked = true;
				if (chromeRadioButton7.Visible && chromeRadioButton8.Visible)
				{
					chromeRadioButton7.Visible = false;
					chromeRadioButton8.Visible = false;
				}
				chromeRadioButton4.Visible = true;
				chromeRadioButton5.Visible = true;
				chromeRadioButton6.Visible = true;
			}
		}

		private void chromeRadioButton12_CheckedChanged(object sender)
		{
			if (chromeRadioButton12.Checked)
			{
				chromeRadioButton4.Checked = true;
				if (chromeRadioButton7.Visible && chromeRadioButton8.Visible)
				{
					chromeRadioButton7.Visible = false;
					chromeRadioButton8.Visible = false;
				}
				chromeRadioButton4.Visible = true;
				chromeRadioButton5.Visible = true;
				chromeRadioButton6.Visible = true;
			}
		}

		private void chromeRadioButton13_CheckedChanged(object sender)
		{
			if (chromeRadioButton13.Checked)
			{
				chromeRadioButton6.Checked = true;
				if (chromeRadioButton4.Visible && chromeRadioButton5.Visible)
				{
					chromeRadioButton4.Visible = false;
					chromeRadioButton5.Visible = false;
				}
				chromeRadioButton6.Visible = true;
				chromeRadioButton7.Visible = true;
				chromeRadioButton8.Visible = true;
			}
		}

		private void bunifuCheckbox2_OnChange(object sender, EventArgs e)
		{
			bunifuCustomTextbox1.Text = Utiles.RandomString(18);
		}

		private void chromeRadioButton4_CheckedChanged(object sender)
		{
			if (chromeRadioButton12.Checked)
			{
				StaticCrypt4.Utilies.Crypt.InjectPath = "\"2\"";
			}
			else
			{
				StaticCrypt4.Utilies.Crypt.InjectPath = "\"1\"";
			}
			StaticCrypt4.Utilies.Crypt.IsRequiertPacker = false;
		}

		private void chromeRadioButton5_CheckedChanged(object sender)
		{
			if (chromeRadioButton12.Checked)
			{
				StaticCrypt4.Utilies.Crypt.InjectPath = "\"4\"";
			}
			else
			{
				StaticCrypt4.Utilies.Crypt.InjectPath = "\"3\"";
			}
			StaticCrypt4.Utilies.Crypt.IsRequiertPacker = false;
		}

		private void chromeRadioButton7_CheckedChanged(object sender)
		{
			StaticCrypt4.Utilies.Crypt.InjectPath = "\"5\"";
		}

		private void chromeRadioButton8_CheckedChanged(object sender)
		{
			StaticCrypt4.Utilies.Crypt.InjectPath = "\"6\"";
		}

		private void chromeRadioButton6_CheckedChanged(object sender)
		{
			StaticCrypt4.Utilies.Crypt.InjectPath = "\"7\"";
			StaticCrypt4.Utilies.Crypt.IsRequiertPatch = true;
			if (chromeRadioButton11.Checked || chromeRadioButton12.Checked)
			{
				StaticCrypt4.Utilies.Crypt.IsRequiertPacker = true;
			}
			else
			{
				StaticCrypt4.Utilies.Crypt.IsRequiertPacker = false;
			}
		}

		protected override void Dispose(bool disposing)
		{
			if (disposing && components != null)
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		public void InitializeComponent()
		{
			groupBox1 = new GroupBox();
			chromeRadioButton8 = new ChromeRadioButton();
			chromeRadioButton7 = new ChromeRadioButton();
			chromeRadioButton6 = new ChromeRadioButton();
			chromeRadioButton5 = new ChromeRadioButton();
			chromeRadioButton4 = new ChromeRadioButton();
			bunifuCheckbox1 = new BunifuCheckbox();
			bunifuCustomLabel5 = new BunifuCustomLabel();
			bunifuCustomLabel1 = new BunifuCustomLabel();
			bunifuCustomLabel2 = new BunifuCustomLabel();
			bunifuCheckbox2 = new BunifuCheckbox();
			bunifuCustomTextbox1 = new BunifuCustomTextbox();
			bunifuCustomLabel3 = new BunifuCustomLabel();
			bunifuCheckbox3 = new BunifuCheckbox();
			bunifuCustomTextbox2 = new BunifuCustomTextbox();
			bunifuCustomLabel4 = new BunifuCustomLabel();
			bunifuCheckbox4 = new BunifuCheckbox();
			bunifuCustomLabel6 = new BunifuCustomLabel();
			bunifuCustomLabel7 = new BunifuCustomLabel();
			bunifuCheckbox5 = new BunifuCheckbox();
			bunifuCustomLabel8 = new BunifuCustomLabel();
			bunifuCheckbox6 = new BunifuCheckbox();
			bunifuCustomLabel9 = new BunifuCustomLabel();
			bunifuCheckbox7 = new BunifuCheckbox();
			bunifuCustomLabel10 = new BunifuCustomLabel();
			bunifuCustomLabel11 = new BunifuCustomLabel();
			groupBox2 = new GroupBox();
			chromeRadioButton13 = new ChromeRadioButton();
			chromeRadioButton12 = new ChromeRadioButton();
			chromeRadioButton11 = new ChromeRadioButton();
			chromeRadioButton10 = new ChromeRadioButton();
			chromeRadioButton9 = new ChromeRadioButton();
			groupBox1.SuspendLayout();
			groupBox2.SuspendLayout();
			base.SuspendLayout();
			groupBox1.Controls.Add(chromeRadioButton8);
			groupBox1.Controls.Add(chromeRadioButton7);
			groupBox1.Controls.Add(chromeRadioButton6);
			groupBox1.Controls.Add(chromeRadioButton5);
			groupBox1.Controls.Add(chromeRadioButton4);
			groupBox1.Location = new Point(129, 10);
			groupBox1.Name = "groupBox1";
			groupBox1.Size = new Size(127, 156);
			groupBox1.TabIndex = 3;
			groupBox1.TabStop = false;
			chromeRadioButton8.Checked = false;
			chromeRadioButton8.Customization = "AAAA////////////AAAA/wAAAP8=";
			chromeRadioButton8.Field = 23;
			chromeRadioButton8.Font = new Font("Microsoft Sans Serif", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 0);
			chromeRadioButton8.Image = null;
			chromeRadioButton8.Location = new Point(17, 70);
			chromeRadioButton8.Name = "chromeRadioButton8";
			chromeRadioButton8.NoRounding = false;
			chromeRadioButton8.Size = new Size(81, 23);
			chromeRadioButton8.TabIndex = 4;
			chromeRadioButton8.Text = "Dllhost";
			chromeRadioButton8.Transparent = false;
			chromeRadioButton8.Visible = false;
			chromeRadioButton8.CheckedChanged += chromeRadioButton8_CheckedChanged;
			chromeRadioButton7.Checked = false;
			chromeRadioButton7.Customization = "AAAA////////////AAAA/wAAAP8=";
			chromeRadioButton7.Field = 23;
			chromeRadioButton7.Font = new Font("Microsoft Sans Serif", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 0);
			chromeRadioButton7.Image = null;
			chromeRadioButton7.Location = new Point(17, 38);
			chromeRadioButton7.Name = "chromeRadioButton7";
			chromeRadioButton7.NoRounding = false;
			chromeRadioButton7.Size = new Size(81, 23);
			chromeRadioButton7.TabIndex = 3;
			chromeRadioButton7.Text = "Svchost";
			chromeRadioButton7.Transparent = false;
			chromeRadioButton7.Visible = false;
			chromeRadioButton7.CheckedChanged += chromeRadioButton7_CheckedChanged;
			chromeRadioButton6.Checked = false;
			chromeRadioButton6.Customization = "AAAA////////////AAAA/wAAAP8=";
			chromeRadioButton6.Field = 23;
			chromeRadioButton6.Font = new Font("Microsoft Sans Serif", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 0);
			chromeRadioButton6.Image = null;
			chromeRadioButton6.Location = new Point(17, 103);
			chromeRadioButton6.Name = "chromeRadioButton6";
			chromeRadioButton6.NoRounding = false;
			chromeRadioButton6.Size = new Size(81, 23);
			chromeRadioButton6.TabIndex = 2;
			chromeRadioButton6.Text = "ItSelf";
			chromeRadioButton6.Transparent = false;
			chromeRadioButton6.Visible = false;
			chromeRadioButton6.CheckedChanged += chromeRadioButton6_CheckedChanged;
			chromeRadioButton5.Checked = false;
			chromeRadioButton5.Customization = "AAAA////////////AAAA/wAAAP8=";
			chromeRadioButton5.Field = 23;
			chromeRadioButton5.Font = new Font("Microsoft Sans Serif", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 0);
			chromeRadioButton5.Image = null;
			chromeRadioButton5.Location = new Point(17, 70);
			chromeRadioButton5.Name = "chromeRadioButton5";
			chromeRadioButton5.NoRounding = false;
			chromeRadioButton5.Size = new Size(81, 23);
			chromeRadioButton5.TabIndex = 1;
			chromeRadioButton5.Text = "MSBuild";
			chromeRadioButton5.Transparent = false;
			chromeRadioButton5.Visible = false;
			chromeRadioButton5.CheckedChanged += chromeRadioButton5_CheckedChanged;
			chromeRadioButton4.Checked = false;
			chromeRadioButton4.Customization = "AAAA////////////AAAA/wAAAP8=";
			chromeRadioButton4.Field = 23;
			chromeRadioButton4.Font = new Font("Microsoft Sans Serif", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 0);
			chromeRadioButton4.Image = null;
			chromeRadioButton4.Location = new Point(17, 38);
			chromeRadioButton4.Name = "chromeRadioButton4";
			chromeRadioButton4.NoRounding = false;
			chromeRadioButton4.Size = new Size(81, 23);
			chromeRadioButton4.TabIndex = 0;
			chromeRadioButton4.Text = "RegAsm";
			chromeRadioButton4.Transparent = false;
			chromeRadioButton4.Visible = false;
			chromeRadioButton4.CheckedChanged += chromeRadioButton4_CheckedChanged;
			bunifuCheckbox1.BackColor = Color.SeaGreen;
			bunifuCheckbox1.ChechedOffColor = Color.SeaGreen;
			bunifuCheckbox1.Checked = false;
			bunifuCheckbox1.CheckedOnColor = Color.SeaGreen;
			bunifuCheckbox1.ForeColor = Color.White;
			bunifuCheckbox1.Location = new Point(413, 52);
			bunifuCheckbox1.Name = "bunifuCheckbox1";
			bunifuCheckbox1.Size = new Size(20, 20);
			bunifuCheckbox1.TabIndex = 4;
			bunifuCustomLabel5.AutoSize = true;
			bunifuCustomLabel5.Font = new Font("Microsoft Sans Serif", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 0);
			bunifuCustomLabel5.Location = new Point(28, 14);
			bunifuCustomLabel5.Name = "bunifuCustomLabel5";
			bunifuCustomLabel5.Size = new Size(63, 16);
			bunifuCustomLabel5.TabIndex = 22;
			bunifuCustomLabel5.Text = "Injection :";
			bunifuCustomLabel1.AutoSize = true;
			bunifuCustomLabel1.Font = new Font("Microsoft Sans Serif", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 0);
			bunifuCustomLabel1.Location = new Point(439, 53);
			bunifuCustomLabel1.Name = "bunifuCustomLabel1";
			bunifuCustomLabel1.Size = new Size(132, 16);
			bunifuCustomLabel1.TabIndex = 23;
			bunifuCustomLabel1.Text = "Process Persistence";
			bunifuCustomLabel2.AutoSize = true;
			bunifuCustomLabel2.Font = new Font("Microsoft Sans Serif", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 0);
			bunifuCustomLabel2.Location = new Point(439, 97);
			bunifuCustomLabel2.Name = "bunifuCustomLabel2";
			bunifuCustomLabel2.Size = new Size(77, 16);
			bunifuCustomLabel2.TabIndex = 25;
			bunifuCustomLabel2.Text = "Use Mutex :";
			bunifuCheckbox2.BackColor = Color.SeaGreen;
			bunifuCheckbox2.ChechedOffColor = Color.SeaGreen;
			bunifuCheckbox2.Checked = false;
			bunifuCheckbox2.CheckedOnColor = Color.SeaGreen;
			bunifuCheckbox2.ForeColor = Color.White;
			bunifuCheckbox2.Location = new Point(413, 96);
			bunifuCheckbox2.Name = "bunifuCheckbox2";
			bunifuCheckbox2.Size = new Size(20, 20);
			bunifuCheckbox2.TabIndex = 24;
			bunifuCheckbox2.OnChange += bunifuCheckbox2_OnChange;
			bunifuCustomTextbox1.BorderColor = Color.SeaGreen;
			bunifuCustomTextbox1.BorderStyle = BorderStyle.FixedSingle;
			bunifuCustomTextbox1.Font = new Font("Microsoft Sans Serif", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 0);
			bunifuCustomTextbox1.Location = new Point(441, 133);
			bunifuCustomTextbox1.Multiline = true;
			bunifuCustomTextbox1.Name = "bunifuCustomTextbox1";
			bunifuCustomTextbox1.Size = new Size(208, 23);
			bunifuCustomTextbox1.TabIndex = 26;
			bunifuCustomTextbox1.Text = "** Key **";
			bunifuCustomTextbox1.TextAlign = HorizontalAlignment.Center;
			bunifuCustomLabel3.AutoSize = true;
			bunifuCustomLabel3.Font = new Font("Microsoft Sans Serif", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 0);
			bunifuCustomLabel3.Location = new Point(439, 175);
			bunifuCustomLabel3.Name = "bunifuCustomLabel3";
			bunifuCustomLabel3.Size = new Size(85, 16);
			bunifuCustomLabel3.TabIndex = 28;
			bunifuCustomLabel3.Text = "Bypass UAC";
			bunifuCheckbox3.BackColor = Color.SeaGreen;
			bunifuCheckbox3.ChechedOffColor = Color.SeaGreen;
			bunifuCheckbox3.Checked = false;
			bunifuCheckbox3.CheckedOnColor = Color.SeaGreen;
			bunifuCheckbox3.ForeColor = Color.White;
			bunifuCheckbox3.Location = new Point(413, 174);
			bunifuCheckbox3.Name = "bunifuCheckbox3";
			bunifuCheckbox3.Size = new Size(20, 20);
			bunifuCheckbox3.TabIndex = 27;
			bunifuCustomTextbox2.BorderColor = Color.SeaGreen;
			bunifuCustomTextbox2.BorderStyle = BorderStyle.FixedSingle;
			bunifuCustomTextbox2.Font = new Font("Microsoft Sans Serif", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 0);
			bunifuCustomTextbox2.Location = new Point(522, 223);
			bunifuCustomTextbox2.Multiline = true;
			bunifuCustomTextbox2.Name = "bunifuCustomTextbox2";
			bunifuCustomTextbox2.Size = new Size(41, 23);
			bunifuCustomTextbox2.TabIndex = 31;
			bunifuCustomTextbox2.Text = "5";
			bunifuCustomTextbox2.TextAlign = HorizontalAlignment.Center;
			bunifuCustomLabel4.AutoSize = true;
			bunifuCustomLabel4.Font = new Font("Microsoft Sans Serif", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 0);
			bunifuCustomLabel4.Location = new Point(439, 225);
			bunifuCustomLabel4.Name = "bunifuCustomLabel4";
			bunifuCustomLabel4.Size = new Size(78, 16);
			bunifuCustomLabel4.TabIndex = 30;
			bunifuCustomLabel4.Text = "Use Delay :";
			bunifuCheckbox4.BackColor = Color.SeaGreen;
			bunifuCheckbox4.ChechedOffColor = Color.SeaGreen;
			bunifuCheckbox4.Checked = false;
			bunifuCheckbox4.CheckedOnColor = Color.SeaGreen;
			bunifuCheckbox4.ForeColor = Color.White;
			bunifuCheckbox4.Location = new Point(413, 223);
			bunifuCheckbox4.Name = "bunifuCheckbox4";
			bunifuCheckbox4.Size = new Size(20, 20);
			bunifuCheckbox4.TabIndex = 29;
			bunifuCustomLabel6.AutoSize = true;
			bunifuCustomLabel6.Font = new Font("Microsoft Sans Serif", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 0);
			bunifuCustomLabel6.Location = new Point(28, 221);
			bunifuCustomLabel6.Name = "bunifuCustomLabel6";
			bunifuCustomLabel6.Size = new Size(43, 16);
			bunifuCustomLabel6.TabIndex = 32;
			bunifuCustomLabel6.Text = "Antis :";
			bunifuCustomLabel7.AutoSize = true;
			bunifuCustomLabel7.Font = new Font("Microsoft Sans Serif", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 0);
			bunifuCustomLabel7.Location = new Point(77, 261);
			bunifuCustomLabel7.Name = "bunifuCustomLabel7";
			bunifuCustomLabel7.Size = new Size(73, 16);
			bunifuCustomLabel7.TabIndex = 34;
			bunifuCustomLabel7.Text = "Sandboxie";
			bunifuCheckbox5.BackColor = Color.SeaGreen;
			bunifuCheckbox5.ChechedOffColor = Color.SeaGreen;
			bunifuCheckbox5.Checked = false;
			bunifuCheckbox5.CheckedOnColor = Color.SeaGreen;
			bunifuCheckbox5.ForeColor = Color.White;
			bunifuCheckbox5.Location = new Point(51, 259);
			bunifuCheckbox5.Name = "bunifuCheckbox5";
			bunifuCheckbox5.Size = new Size(20, 20);
			bunifuCheckbox5.TabIndex = 33;
			bunifuCustomLabel8.AutoSize = true;
			bunifuCustomLabel8.Font = new Font("Microsoft Sans Serif", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 0);
			bunifuCustomLabel8.Location = new Point(77, 298);
			bunifuCustomLabel8.Name = "bunifuCustomLabel8";
			bunifuCustomLabel8.Size = new Size(137, 16);
			bunifuCustomLabel8.TabIndex = 36;
			bunifuCustomLabel8.Text = "Virtual Environnement";
			bunifuCheckbox6.BackColor = Color.SeaGreen;
			bunifuCheckbox6.ChechedOffColor = Color.SeaGreen;
			bunifuCheckbox6.Checked = false;
			bunifuCheckbox6.CheckedOnColor = Color.SeaGreen;
			bunifuCheckbox6.ForeColor = Color.White;
			bunifuCheckbox6.Location = new Point(51, 296);
			bunifuCheckbox6.Name = "bunifuCheckbox6";
			bunifuCheckbox6.Size = new Size(20, 20);
			bunifuCheckbox6.TabIndex = 35;
			bunifuCustomLabel9.AutoSize = true;
			bunifuCustomLabel9.Font = new Font("Microsoft Sans Serif", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 0);
			bunifuCustomLabel9.Location = new Point(77, 334);
			bunifuCustomLabel9.Name = "bunifuCustomLabel9";
			bunifuCustomLabel9.Size = new Size(69, 16);
			bunifuCustomLabel9.TabIndex = 38;
			bunifuCustomLabel9.Text = "Wireshark";
			bunifuCheckbox7.BackColor = Color.SeaGreen;
			bunifuCheckbox7.ChechedOffColor = Color.SeaGreen;
			bunifuCheckbox7.Checked = false;
			bunifuCheckbox7.CheckedOnColor = Color.SeaGreen;
			bunifuCheckbox7.ForeColor = Color.White;
			bunifuCheckbox7.Location = new Point(51, 332);
			bunifuCheckbox7.Name = "bunifuCheckbox7";
			bunifuCheckbox7.Size = new Size(20, 20);
			bunifuCheckbox7.TabIndex = 37;
			bunifuCustomLabel10.AutoSize = true;
			bunifuCustomLabel10.Font = new Font("Microsoft Sans Serif", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 0);
			bunifuCustomLabel10.Location = new Point(393, 14);
			bunifuCustomLabel10.Name = "bunifuCustomLabel10";
			bunifuCustomLabel10.Size = new Size(115, 16);
			bunifuCustomLabel10.TabIndex = 39;
			bunifuCustomLabel10.Text = "Process Settings :";
			bunifuCustomLabel11.AutoSize = true;
			bunifuCustomLabel11.Font = new Font("Microsoft Sans Serif", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 0);
			bunifuCustomLabel11.Location = new Point(393, 263);
			bunifuCustomLabel11.Name = "bunifuCustomLabel11";
			bunifuCustomLabel11.Size = new Size(144, 16);
			bunifuCustomLabel11.TabIndex = 40;
			bunifuCustomLabel11.Text = "Stub Runtime Method : ";
			groupBox2.Controls.Add(chromeRadioButton13);
			groupBox2.Controls.Add(chromeRadioButton12);
			groupBox2.Controls.Add(chromeRadioButton11);
			groupBox2.Controls.Add(groupBox1);
			groupBox2.Location = new Point(31, 36);
			groupBox2.Name = "groupBox2";
			groupBox2.Size = new Size(271, 175);
			groupBox2.TabIndex = 43;
			groupBox2.TabStop = false;
			chromeRadioButton13.Checked = false;
			chromeRadioButton13.Customization = "AAAA////////////AAAA/wAAAP8=";
			chromeRadioButton13.Field = 23;
			chromeRadioButton13.Font = new Font("Microsoft Sans Serif", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 0);
			chromeRadioButton13.Image = null;
			chromeRadioButton13.Location = new Point(20, 125);
			chromeRadioButton13.Name = "chromeRadioButton13";
			chromeRadioButton13.NoRounding = false;
			chromeRadioButton13.Size = new Size(95, 23);
			chromeRadioButton13.TabIndex = 6;
			chromeRadioButton13.Text = " Native";
			chromeRadioButton13.Transparent = false;
			chromeRadioButton13.CheckedChanged += chromeRadioButton13_CheckedChanged;
			chromeRadioButton12.Checked = false;
			chromeRadioButton12.Customization = "AAAA////////////AAAA/wAAAP8=";
			chromeRadioButton12.Field = 23;
			chromeRadioButton12.Font = new Font("Microsoft Sans Serif", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 0);
			chromeRadioButton12.Image = null;
			chromeRadioButton12.Location = new Point(19, 81);
			chromeRadioButton12.Name = "chromeRadioButton12";
			chromeRadioButton12.NoRounding = false;
			chromeRadioButton12.Size = new Size(95, 23);
			chromeRadioButton12.TabIndex = 5;
			chromeRadioButton12.Text = " .NET 4.0";
			chromeRadioButton12.Transparent = false;
			chromeRadioButton12.CheckedChanged += chromeRadioButton12_CheckedChanged;
			chromeRadioButton11.Checked = false;
			chromeRadioButton11.Customization = "AAAA////////////AAAA/wAAAP8=";
			chromeRadioButton11.Field = 23;
			chromeRadioButton11.Font = new Font("Microsoft Sans Serif", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 0);
			chromeRadioButton11.Image = null;
			chromeRadioButton11.Location = new Point(20, 32);
			chromeRadioButton11.Name = "chromeRadioButton11";
			chromeRadioButton11.NoRounding = false;
			chromeRadioButton11.Size = new Size(95, 23);
			chromeRadioButton11.TabIndex = 4;
			chromeRadioButton11.Text = " .NET 2.0";
			chromeRadioButton11.Transparent = false;
			chromeRadioButton11.CheckedChanged += chromeRadioButton11_CheckedChanged;
			chromeRadioButton10.Checked = false;
			chromeRadioButton10.Customization = "AAAA////////////AAAA/wAAAP8=";
			chromeRadioButton10.Field = 23;
			chromeRadioButton10.Font = new Font("Microsoft Sans Serif", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 0);
			chromeRadioButton10.Image = null;
			chromeRadioButton10.Location = new Point(413, 327);
			chromeRadioButton10.Name = "chromeRadioButton10";
			chromeRadioButton10.NoRounding = false;
			chromeRadioButton10.Size = new Size(95, 23);
			chromeRadioButton10.TabIndex = 44;
			chromeRadioButton10.Text = " Auto Pump";
			chromeRadioButton10.Transparent = false;
			chromeRadioButton9.Checked = false;
			chromeRadioButton9.Customization = "AAAA////////////AAAA/wAAAP8=";
			chromeRadioButton9.Field = 23;
			chromeRadioButton9.Font = new Font("Microsoft Sans Serif", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 0);
			chromeRadioButton9.Image = null;
			chromeRadioButton9.Location = new Point(413, 298);
			chromeRadioButton9.Name = "chromeRadioButton9";
			chromeRadioButton9.NoRounding = false;
			chromeRadioButton9.Size = new Size(95, 23);
			chromeRadioButton9.TabIndex = 7;
			chromeRadioButton9.Text = " Simple";
			chromeRadioButton9.Transparent = false;
			base.AutoScaleDimensions = new SizeF(6f, 13f);
			base.AutoScaleMode = AutoScaleMode.Font;
			BackColor = Color.White;
			base.ClientSize = new Size(710, 370);
			base.Controls.Add(chromeRadioButton10);
			base.Controls.Add(chromeRadioButton9);
			base.Controls.Add(groupBox2);
			base.Controls.Add(bunifuCustomLabel11);
			base.Controls.Add(bunifuCustomLabel10);
			base.Controls.Add(bunifuCustomLabel9);
			base.Controls.Add(bunifuCheckbox7);
			base.Controls.Add(bunifuCustomLabel8);
			base.Controls.Add(bunifuCheckbox6);
			base.Controls.Add(bunifuCustomLabel7);
			base.Controls.Add(bunifuCheckbox5);
			base.Controls.Add(bunifuCustomLabel6);
			base.Controls.Add(bunifuCustomTextbox2);
			base.Controls.Add(bunifuCustomLabel4);
			base.Controls.Add(bunifuCheckbox4);
			base.Controls.Add(bunifuCustomLabel3);
			base.Controls.Add(bunifuCheckbox3);
			base.Controls.Add(bunifuCustomTextbox1);
			base.Controls.Add(bunifuCustomLabel2);
			base.Controls.Add(bunifuCheckbox2);
			base.Controls.Add(bunifuCustomLabel1);
			base.Controls.Add(bunifuCustomLabel5);
			base.Controls.Add(bunifuCheckbox1);
			base.FormBorderStyle = FormBorderStyle.None;
			base.Name = "Injections";
			Text = "Injections";
			base.Load += Injections_Load;
			groupBox1.ResumeLayout(false);
			groupBox2.ResumeLayout(false);
			base.ResumeLayout(false);
			base.PerformLayout();
		}
	}
}
