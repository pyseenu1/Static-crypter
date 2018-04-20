using Bunifu.Framework.UI;
using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using WindowsFormsControlLibrary1;

namespace StaticCrypt4.Forms.Crypt
{
	public class FileFrm : Form
	{
		public IContainer components;

		public BunifuCustomLabel bunifuCustomLabel7;

		public BunifuCheckbox bunifuCheckbox5;

		public BunifuCustomLabel bunifuCustomLabel6;

		public BunifuCustomTextbox bunifuCustomTextbox1;

		public BunifuCustomTextbox bunifuCustomTextbox2;

		public BunifuCustomTextbox bunifuCustomTextbox3;

		public ThirteenComboBox thirteenComboBox1;

		public ThirteenComboBox thirteenComboBox2;

		public BunifuCustomLabel bunifuCustomLabel1;

		public BunifuCustomLabel bunifuCustomLabel2;

		public BunifuCheckbox bunifuCheckbox1;

		public BunifuCustomLabel bunifuCustomLabel3;

		public BunifuCheckbox bunifuCheckbox2;

		public BunifuCustomLabel bunifuCustomLabel4;

		public BunifuCheckbox bunifuCheckbox3;

		public BunifuCustomTextbox bunifuCustomTextbox4;

		public ChromeRadioButton chromeRadioButton3;

		public ChromeRadioButton chromeRadioButton4;

		public BunifuCustomLabel bunifuCustomLabel5;

		public BunifuCheckbox bunifuCheckbox4;

		public ThirteenComboBox thirteenComboBox3;

		public BunifuCustomLabel bunifuCustomLabel12;

		public BunifuCheckbox bunifuCheckbox9;

		public BunifuCustomLabel bunifuCustomLabel8;

		public BunifuCustomLabel bunifuCustomLabel9;

		public BunifuCustomLabel bunifuCustomLabel10;

		public BunifuCustomLabel bunifuCustomLabel11;

		public FileFrm()
		{
			InitializeComponent();
		}

		private void FileFrm_Load(object sender, EventArgs e)
		{
			Helpers.TabNumber = 3;
		}

		private void bunifuCheckbox5_OnChange(object sender, EventArgs e)
		{
			if (bunifuCheckbox5.Checked)
			{
				bunifuCheckbox1.Enabled = true;
				bunifuCheckbox2.Enabled = true;
				bunifuCheckbox4.Enabled = true;
				bunifuCheckbox9.Enabled = true;
			}
			else
			{
				bunifuCheckbox1.Enabled = false;
				bunifuCheckbox2.Enabled = false;
				bunifuCheckbox4.Enabled = false;
				bunifuCheckbox9.Enabled = false;
				bunifuCheckbox1.Checked = false;
				bunifuCheckbox2.Checked = false;
				bunifuCheckbox4.Checked = false;
				bunifuCheckbox9.Checked = false;
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
			bunifuCustomLabel7 = new BunifuCustomLabel();
			bunifuCheckbox5 = new BunifuCheckbox();
			bunifuCustomLabel6 = new BunifuCustomLabel();
			bunifuCustomTextbox1 = new BunifuCustomTextbox();
			bunifuCustomTextbox2 = new BunifuCustomTextbox();
			bunifuCustomTextbox3 = new BunifuCustomTextbox();
			bunifuCustomLabel1 = new BunifuCustomLabel();
			bunifuCustomLabel2 = new BunifuCustomLabel();
			bunifuCheckbox1 = new BunifuCheckbox();
			bunifuCustomLabel3 = new BunifuCustomLabel();
			bunifuCheckbox2 = new BunifuCheckbox();
			bunifuCustomLabel4 = new BunifuCustomLabel();
			bunifuCheckbox3 = new BunifuCheckbox();
			bunifuCustomTextbox4 = new BunifuCustomTextbox();
			bunifuCustomLabel5 = new BunifuCustomLabel();
			bunifuCheckbox4 = new BunifuCheckbox();
			bunifuCustomLabel12 = new BunifuCustomLabel();
			bunifuCheckbox9 = new BunifuCheckbox();
			thirteenComboBox3 = new ThirteenComboBox();
			chromeRadioButton4 = new ChromeRadioButton();
			chromeRadioButton3 = new ChromeRadioButton();
			thirteenComboBox2 = new ThirteenComboBox();
			thirteenComboBox1 = new ThirteenComboBox();
			bunifuCustomLabel8 = new BunifuCustomLabel();
			bunifuCustomLabel9 = new BunifuCustomLabel();
			bunifuCustomLabel10 = new BunifuCustomLabel();
			bunifuCustomLabel11 = new BunifuCustomLabel();
			base.SuspendLayout();
			bunifuCustomLabel7.AutoSize = true;
			bunifuCustomLabel7.Font = new Font("Microsoft Sans Serif", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 0);
			bunifuCustomLabel7.Location = new Point(57, 45);
			bunifuCustomLabel7.Name = "bunifuCustomLabel7";
			bunifuCustomLabel7.Size = new Size(104, 16);
			bunifuCustomLabel7.TabIndex = 37;
			bunifuCustomLabel7.Text = "Add To Startup :";
			bunifuCheckbox5.BackColor = Color.SeaGreen;
			bunifuCheckbox5.ChechedOffColor = Color.SeaGreen;
			bunifuCheckbox5.Checked = false;
			bunifuCheckbox5.CheckedOnColor = Color.SeaGreen;
			bunifuCheckbox5.ForeColor = Color.White;
			bunifuCheckbox5.Location = new Point(31, 43);
			bunifuCheckbox5.Name = "bunifuCheckbox5";
			bunifuCheckbox5.Size = new Size(20, 20);
			bunifuCheckbox5.TabIndex = 36;
			bunifuCheckbox5.OnChange += bunifuCheckbox5_OnChange;
			bunifuCustomLabel6.AutoSize = true;
			bunifuCustomLabel6.Font = new Font("Microsoft Sans Serif", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 0);
			bunifuCustomLabel6.Location = new Point(8, 9);
			bunifuCustomLabel6.Name = "bunifuCustomLabel6";
			bunifuCustomLabel6.Size = new Size(48, 16);
			bunifuCustomLabel6.TabIndex = 35;
			bunifuCustomLabel6.Text = "Install :";
			bunifuCustomTextbox1.BorderColor = Color.SeaGreen;
			bunifuCustomTextbox1.BorderStyle = BorderStyle.FixedSingle;
			bunifuCustomTextbox1.Font = new Font("Microsoft Sans Serif", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 0);
			bunifuCustomTextbox1.Location = new Point(161, 177);
			bunifuCustomTextbox1.Multiline = true;
			bunifuCustomTextbox1.Name = "bunifuCustomTextbox1";
			bunifuCustomTextbox1.Size = new Size(137, 23);
			bunifuCustomTextbox1.TabIndex = 38;
			bunifuCustomTextbox1.Text = "Registry Name";
			bunifuCustomTextbox1.TextAlign = HorizontalAlignment.Center;
			bunifuCustomTextbox2.BorderColor = Color.SeaGreen;
			bunifuCustomTextbox2.BorderStyle = BorderStyle.FixedSingle;
			bunifuCustomTextbox2.Font = new Font("Microsoft Sans Serif", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 0);
			bunifuCustomTextbox2.Location = new Point(161, 222);
			bunifuCustomTextbox2.Multiline = true;
			bunifuCustomTextbox2.Name = "bunifuCustomTextbox2";
			bunifuCustomTextbox2.Size = new Size(137, 23);
			bunifuCustomTextbox2.TabIndex = 39;
			bunifuCustomTextbox2.Text = "Folder Name";
			bunifuCustomTextbox2.TextAlign = HorizontalAlignment.Center;
			bunifuCustomTextbox3.BorderColor = Color.SeaGreen;
			bunifuCustomTextbox3.BorderStyle = BorderStyle.FixedSingle;
			bunifuCustomTextbox3.Font = new Font("Microsoft Sans Serif", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 0);
			bunifuCustomTextbox3.Location = new Point(161, 262);
			bunifuCustomTextbox3.Multiline = true;
			bunifuCustomTextbox3.Name = "bunifuCustomTextbox3";
			bunifuCustomTextbox3.Size = new Size(137, 23);
			bunifuCustomTextbox3.TabIndex = 40;
			bunifuCustomTextbox3.Text = "File Name";
			bunifuCustomTextbox3.TextAlign = HorizontalAlignment.Center;
			bunifuCustomLabel1.AutoSize = true;
			bunifuCustomLabel1.Font = new Font("Microsoft Sans Serif", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 0);
			bunifuCustomLabel1.Location = new Point(48, 317);
			bunifuCustomLabel1.Name = "bunifuCustomLabel1";
			bunifuCustomLabel1.Size = new Size(109, 16);
			bunifuCustomLabel1.TabIndex = 45;
			bunifuCustomLabel1.Text = "Install Extension :";
			bunifuCustomLabel2.AutoSize = true;
			bunifuCustomLabel2.Font = new Font("Microsoft Sans Serif", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 0);
			bunifuCustomLabel2.Location = new Point(393, 45);
			bunifuCustomLabel2.Name = "bunifuCustomLabel2";
			bunifuCustomLabel2.Size = new Size(121, 16);
			bunifuCustomLabel2.TabIndex = 47;
			bunifuCustomLabel2.Text = "Hide Parent Folder";
			bunifuCheckbox1.BackColor = Color.SeaGreen;
			bunifuCheckbox1.ChechedOffColor = Color.SeaGreen;
			bunifuCheckbox1.Checked = false;
			bunifuCheckbox1.CheckedOnColor = Color.SeaGreen;
			bunifuCheckbox1.Enabled = false;
			bunifuCheckbox1.ForeColor = Color.White;
			bunifuCheckbox1.Location = new Point(367, 43);
			bunifuCheckbox1.Name = "bunifuCheckbox1";
			bunifuCheckbox1.Size = new Size(20, 20);
			bunifuCheckbox1.TabIndex = 46;
			bunifuCustomLabel3.AutoSize = true;
			bunifuCustomLabel3.Font = new Font("Microsoft Sans Serif", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 0);
			bunifuCustomLabel3.Location = new Point(393, 91);
			bunifuCustomLabel3.Name = "bunifuCustomLabel3";
			bunifuCustomLabel3.Size = new Size(62, 16);
			bunifuCustomLabel3.TabIndex = 49;
			bunifuCustomLabel3.Text = "Hide File";
			bunifuCheckbox2.BackColor = Color.SeaGreen;
			bunifuCheckbox2.ChechedOffColor = Color.SeaGreen;
			bunifuCheckbox2.Checked = false;
			bunifuCheckbox2.CheckedOnColor = Color.SeaGreen;
			bunifuCheckbox2.Enabled = false;
			bunifuCheckbox2.ForeColor = Color.White;
			bunifuCheckbox2.Location = new Point(367, 89);
			bunifuCheckbox2.Name = "bunifuCheckbox2";
			bunifuCheckbox2.Size = new Size(20, 20);
			bunifuCheckbox2.TabIndex = 48;
			bunifuCustomLabel4.AutoSize = true;
			bunifuCustomLabel4.Font = new Font("Microsoft Sans Serif", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 0);
			bunifuCustomLabel4.Location = new Point(393, 279);
			bunifuCustomLabel4.Name = "bunifuCustomLabel4";
			bunifuCustomLabel4.Size = new Size(151, 16);
			bunifuCustomLabel4.TabIndex = 51;
			bunifuCustomLabel4.Text = "Enable Startup Backup :";
			bunifuCheckbox3.BackColor = Color.SeaGreen;
			bunifuCheckbox3.ChechedOffColor = Color.SeaGreen;
			bunifuCheckbox3.Checked = false;
			bunifuCheckbox3.CheckedOnColor = Color.SeaGreen;
			bunifuCheckbox3.ForeColor = Color.White;
			bunifuCheckbox3.Location = new Point(367, 277);
			bunifuCheckbox3.Name = "bunifuCheckbox3";
			bunifuCheckbox3.Size = new Size(20, 20);
			bunifuCheckbox3.TabIndex = 50;
			bunifuCustomTextbox4.BorderColor = Color.SeaGreen;
			bunifuCustomTextbox4.BorderStyle = BorderStyle.FixedSingle;
			bunifuCustomTextbox4.Font = new Font("Microsoft Sans Serif", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 0);
			bunifuCustomTextbox4.Location = new Point(532, 317);
			bunifuCustomTextbox4.Multiline = true;
			bunifuCustomTextbox4.Name = "bunifuCustomTextbox4";
			bunifuCustomTextbox4.Size = new Size(144, 23);
			bunifuCustomTextbox4.TabIndex = 52;
			bunifuCustomTextbox4.Text = "File Name";
			bunifuCustomTextbox4.TextAlign = HorizontalAlignment.Center;
			bunifuCustomLabel5.AutoSize = true;
			bunifuCustomLabel5.Font = new Font("Microsoft Sans Serif", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 0);
			bunifuCustomLabel5.Location = new Point(393, 135);
			bunifuCustomLabel5.Name = "bunifuCustomLabel5";
			bunifuCustomLabel5.Size = new Size(133, 16);
			bunifuCustomLabel5.TabIndex = 56;
			bunifuCustomLabel5.Text = "Exit At First Execution";
			bunifuCheckbox4.BackColor = Color.SeaGreen;
			bunifuCheckbox4.ChechedOffColor = Color.SeaGreen;
			bunifuCheckbox4.Checked = false;
			bunifuCheckbox4.CheckedOnColor = Color.SeaGreen;
			bunifuCheckbox4.Enabled = false;
			bunifuCheckbox4.ForeColor = Color.White;
			bunifuCheckbox4.Location = new Point(367, 133);
			bunifuCheckbox4.Name = "bunifuCheckbox4";
			bunifuCheckbox4.Size = new Size(20, 20);
			bunifuCheckbox4.TabIndex = 55;
			bunifuCustomLabel12.AutoSize = true;
			bunifuCustomLabel12.Font = new Font("Microsoft Sans Serif", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 0);
			bunifuCustomLabel12.Location = new Point(559, 45);
			bunifuCustomLabel12.Name = "bunifuCustomLabel12";
			bunifuCustomLabel12.Size = new Size(110, 16);
			bunifuCustomLabel12.TabIndex = 70;
			bunifuCustomLabel12.Text = "Remove Zone ID";
			bunifuCheckbox9.BackColor = Color.SeaGreen;
			bunifuCheckbox9.ChechedOffColor = Color.SeaGreen;
			bunifuCheckbox9.Checked = false;
			bunifuCheckbox9.CheckedOnColor = Color.SeaGreen;
			bunifuCheckbox9.Enabled = false;
			bunifuCheckbox9.ForeColor = Color.White;
			bunifuCheckbox9.Location = new Point(536, 43);
			bunifuCheckbox9.Name = "bunifuCheckbox9";
			bunifuCheckbox9.Size = new Size(20, 20);
			bunifuCheckbox9.TabIndex = 69;
			thirteenComboBox3.AccentColor = Color.White;
			thirteenComboBox3.BackColor = Color.FromArgb(255, 255, 255);
			thirteenComboBox3.ColorScheme = ThirteenComboBox.ColorSchemes.Dark;
			thirteenComboBox3.DrawMode = DrawMode.OwnerDrawFixed;
			thirteenComboBox3.DropDownStyle = ComboBoxStyle.DropDownList;
			thirteenComboBox3.Font = new Font("Microsoft Sans Serif", 9.75f);
			thirteenComboBox3.ForeColor = Color.Black;
			thirteenComboBox3.FormattingEnabled = true;
			thirteenComboBox3.Items.AddRange(new object[3]
			{
				"AppData",
				"ProgramData",
				"Temp"
			});
			thirteenComboBox3.Location = new Point(382, 317);
			thirteenComboBox3.Name = "thirteenComboBox3";
			thirteenComboBox3.Size = new Size(144, 23);
			thirteenComboBox3.TabIndex = 57;
			chromeRadioButton4.Checked = false;
			chromeRadioButton4.Customization = "AAAA////////////AAAA/wAAAP8=";
			chromeRadioButton4.Field = 23;
			chromeRadioButton4.Font = new Font("Microsoft Sans Serif", 9.75f);
			chromeRadioButton4.Image = null;
			chromeRadioButton4.Location = new Point(169, 89);
			chromeRadioButton4.Name = "chromeRadioButton4";
			chromeRadioButton4.NoRounding = false;
			chromeRadioButton4.Size = new Size(128, 23);
			chromeRadioButton4.TabIndex = 54;
			chromeRadioButton4.Text = "File Shortcut";
			chromeRadioButton4.Transparent = false;
			chromeRadioButton3.Checked = false;
			chromeRadioButton3.Customization = "AAAA////////////AAAA/wAAAP8=";
			chromeRadioButton3.Field = 23;
			chromeRadioButton3.Font = new Font("Microsoft Sans Serif", 9.75f);
			chromeRadioButton3.Image = null;
			chromeRadioButton3.Location = new Point(51, 89);
			chromeRadioButton3.Name = "chromeRadioButton3";
			chromeRadioButton3.NoRounding = false;
			chromeRadioButton3.Size = new Size(112, 23);
			chromeRadioButton3.TabIndex = 53;
			chromeRadioButton3.Text = "Registry Key";
			chromeRadioButton3.Transparent = false;
			thirteenComboBox2.AccentColor = Color.White;
			thirteenComboBox2.BackColor = Color.FromArgb(255, 255, 255);
			thirteenComboBox2.ColorScheme = ThirteenComboBox.ColorSchemes.Dark;
			thirteenComboBox2.DrawMode = DrawMode.OwnerDrawFixed;
			thirteenComboBox2.DropDownStyle = ComboBoxStyle.DropDownList;
			thirteenComboBox2.Font = new Font("Microsoft Sans Serif", 9.75f);
			thirteenComboBox2.ForeColor = Color.Black;
			thirteenComboBox2.FormattingEnabled = true;
			thirteenComboBox2.Items.AddRange(new object[3]
			{
				".exe",
				".scr",
				".com"
			});
			thirteenComboBox2.Location = new Point(161, 314);
			thirteenComboBox2.Name = "thirteenComboBox2";
			thirteenComboBox2.Size = new Size(56, 23);
			thirteenComboBox2.TabIndex = 44;
			thirteenComboBox1.AccentColor = Color.White;
			thirteenComboBox1.BackColor = Color.FromArgb(255, 255, 255);
			thirteenComboBox1.ColorScheme = ThirteenComboBox.ColorSchemes.Dark;
			thirteenComboBox1.DrawMode = DrawMode.OwnerDrawFixed;
			thirteenComboBox1.DropDownStyle = ComboBoxStyle.DropDownList;
			thirteenComboBox1.Font = new Font("Microsoft Sans Serif", 9.75f);
			thirteenComboBox1.ForeColor = Color.Black;
			thirteenComboBox1.FormattingEnabled = true;
			thirteenComboBox1.Items.AddRange(new object[3]
			{
				"AppData",
				"ProgramData",
				"Temp"
			});
			thirteenComboBox1.Location = new Point(161, 136);
			thirteenComboBox1.Name = "thirteenComboBox1";
			thirteenComboBox1.Size = new Size(137, 23);
			thirteenComboBox1.TabIndex = 41;
			bunifuCustomLabel8.AutoSize = true;
			bunifuCustomLabel8.Font = new Font("Microsoft Sans Serif", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 0);
			bunifuCustomLabel8.Location = new Point(49, 264);
			bunifuCustomLabel8.Name = "bunifuCustomLabel8";
			bunifuCustomLabel8.Size = new Size(70, 16);
			bunifuCustomLabel8.TabIndex = 71;
			bunifuCustomLabel8.Text = "Filename :";
			bunifuCustomLabel9.AutoSize = true;
			bunifuCustomLabel9.Font = new Font("Microsoft Sans Serif", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 0);
			bunifuCustomLabel9.Location = new Point(49, 225);
			bunifuCustomLabel9.Name = "bunifuCustomLabel9";
			bunifuCustomLabel9.Size = new Size(87, 16);
			bunifuCustomLabel9.TabIndex = 72;
			bunifuCustomLabel9.Text = "Foldername :";
			bunifuCustomLabel10.AutoSize = true;
			bunifuCustomLabel10.Font = new Font("Microsoft Sans Serif", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 0);
			bunifuCustomLabel10.Location = new Point(49, 180);
			bunifuCustomLabel10.Name = "bunifuCustomLabel10";
			bunifuCustomLabel10.Size = new Size(98, 16);
			bunifuCustomLabel10.TabIndex = 73;
			bunifuCustomLabel10.Text = "Registryname :";
			bunifuCustomLabel11.AutoSize = true;
			bunifuCustomLabel11.Font = new Font("Microsoft Sans Serif", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 0);
			bunifuCustomLabel11.Location = new Point(49, 139);
			bunifuCustomLabel11.Name = "bunifuCustomLabel11";
			bunifuCustomLabel11.Size = new Size(68, 16);
			bunifuCustomLabel11.TabIndex = 74;
			bunifuCustomLabel11.Text = "Directory :";
			base.AutoScaleDimensions = new SizeF(6f, 13f);
			base.AutoScaleMode = AutoScaleMode.Font;
			BackColor = Color.White;
			base.ClientSize = new Size(710, 370);
			base.Controls.Add(bunifuCustomLabel11);
			base.Controls.Add(bunifuCustomLabel10);
			base.Controls.Add(bunifuCustomLabel9);
			base.Controls.Add(bunifuCustomLabel8);
			base.Controls.Add(bunifuCustomLabel12);
			base.Controls.Add(bunifuCheckbox9);
			base.Controls.Add(thirteenComboBox3);
			base.Controls.Add(bunifuCustomLabel5);
			base.Controls.Add(bunifuCheckbox4);
			base.Controls.Add(chromeRadioButton4);
			base.Controls.Add(chromeRadioButton3);
			base.Controls.Add(bunifuCustomTextbox4);
			base.Controls.Add(bunifuCustomLabel4);
			base.Controls.Add(bunifuCheckbox3);
			base.Controls.Add(bunifuCustomLabel3);
			base.Controls.Add(bunifuCheckbox2);
			base.Controls.Add(bunifuCustomLabel2);
			base.Controls.Add(bunifuCheckbox1);
			base.Controls.Add(bunifuCustomLabel1);
			base.Controls.Add(thirteenComboBox2);
			base.Controls.Add(thirteenComboBox1);
			base.Controls.Add(bunifuCustomTextbox3);
			base.Controls.Add(bunifuCustomTextbox2);
			base.Controls.Add(bunifuCustomTextbox1);
			base.Controls.Add(bunifuCustomLabel7);
			base.Controls.Add(bunifuCheckbox5);
			base.Controls.Add(bunifuCustomLabel6);
			base.FormBorderStyle = FormBorderStyle.None;
			base.Name = "FileFrm";
			Text = "FileFrm";
			base.Load += FileFrm_Load;
			base.ResumeLayout(false);
			base.PerformLayout();
		}
	}
}
