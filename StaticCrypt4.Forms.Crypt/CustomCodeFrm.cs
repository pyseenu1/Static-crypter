using Bunifu.Framework.UI;
using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using WindowsFormsControlLibrary1;

namespace StaticCrypt4.Forms.Crypt
{
	public class CustomCodeFrm : Form
	{
		public IContainer components;

		public BunifuCustomTextbox bunifuCustomTextbox1;

		public BunifuCustomLabel bunifuCustomLabel7;

		public BunifuCheckbox bunifuCheckbox5;

		public ChromeRadioButton chromeRadioButton8;

		public ChromeRadioButton chromeRadioButton2;

		public ChromeRadioButton chromeRadioButton3;

		public ChromeRadioButton chromeRadioButton4;

		public BunifuCustomLabel bunifuCustomLabel1;

		public BunifuCheckbox bunifuCheckbox1;

		public CustomCodeFrm()
		{
			InitializeComponent();
		}

		private void CustomCodeFrm_Load(object sender, EventArgs e)
		{
			Helpers.TabNumber = 4;
		}

		private void bunifuCustomTextbox1_TextChanged(object sender, EventArgs e)
		{
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
			bunifuCustomTextbox1 = new BunifuCustomTextbox();
			bunifuCustomLabel7 = new BunifuCustomLabel();
			bunifuCheckbox5 = new BunifuCheckbox();
			bunifuCustomLabel1 = new BunifuCustomLabel();
			bunifuCheckbox1 = new BunifuCheckbox();
			chromeRadioButton4 = new ChromeRadioButton();
			chromeRadioButton3 = new ChromeRadioButton();
			chromeRadioButton2 = new ChromeRadioButton();
			chromeRadioButton8 = new ChromeRadioButton();
			base.SuspendLayout();
			bunifuCustomTextbox1.AllowDrop = true;
			bunifuCustomTextbox1.BackColor = Color.White;
			bunifuCustomTextbox1.BorderColor = Color.SeaGreen;
			bunifuCustomTextbox1.BorderStyle = BorderStyle.FixedSingle;
			bunifuCustomTextbox1.Font = new Font("Microsoft Sans Serif", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 0);
			bunifuCustomTextbox1.Location = new Point(12, 48);
			bunifuCustomTextbox1.Multiline = true;
			bunifuCustomTextbox1.Name = "bunifuCustomTextbox1";
			bunifuCustomTextbox1.ScrollBars = ScrollBars.Horizontal;
			bunifuCustomTextbox1.Size = new Size(686, 265);
			bunifuCustomTextbox1.TabIndex = 1;
			bunifuCustomTextbox1.TextChanged += bunifuCustomTextbox1_TextChanged;
			bunifuCustomLabel7.AutoSize = true;
			bunifuCustomLabel7.Font = new Font("Microsoft Sans Serif", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 0);
			bunifuCustomLabel7.Location = new Point(39, 17);
			bunifuCustomLabel7.Name = "bunifuCustomLabel7";
			bunifuCustomLabel7.Size = new Size(125, 16);
			bunifuCustomLabel7.TabIndex = 39;
			bunifuCustomLabel7.Text = "Add Custome Code";
			bunifuCheckbox5.BackColor = Color.SeaGreen;
			bunifuCheckbox5.ChechedOffColor = Color.SeaGreen;
			bunifuCheckbox5.Checked = false;
			bunifuCheckbox5.CheckedOnColor = Color.SeaGreen;
			bunifuCheckbox5.ForeColor = Color.White;
			bunifuCheckbox5.Location = new Point(13, 15);
			bunifuCheckbox5.Name = "bunifuCheckbox5";
			bunifuCheckbox5.Size = new Size(20, 20);
			bunifuCheckbox5.TabIndex = 38;
			bunifuCustomLabel1.AutoSize = true;
			bunifuCustomLabel1.Font = new Font("Microsoft Sans Serif", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 0);
			bunifuCustomLabel1.Location = new Point(492, 332);
			bunifuCustomLabel1.Name = "bunifuCustomLabel1";
			bunifuCustomLabel1.Size = new Size(69, 16);
			bunifuCustomLabel1.TabIndex = 46;
			bunifuCustomLabel1.Text = "Obfuscate";
			bunifuCustomLabel1.Visible = false;
			bunifuCheckbox1.BackColor = Color.SeaGreen;
			bunifuCheckbox1.ChechedOffColor = Color.SeaGreen;
			bunifuCheckbox1.Checked = false;
			bunifuCheckbox1.CheckedOnColor = Color.SeaGreen;
			bunifuCheckbox1.ForeColor = Color.White;
			bunifuCheckbox1.Location = new Point(467, 330);
			bunifuCheckbox1.Name = "bunifuCheckbox1";
			bunifuCheckbox1.Size = new Size(20, 20);
			bunifuCheckbox1.TabIndex = 45;
			bunifuCheckbox1.Visible = false;
			chromeRadioButton4.Checked = false;
			chromeRadioButton4.Customization = "AAAA////////////AAAA/wAAAP8=";
			chromeRadioButton4.Field = 23;
			chromeRadioButton4.Font = new Font("Microsoft Sans Serif", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 0);
			chromeRadioButton4.Image = null;
			chromeRadioButton4.Location = new Point(131, 330);
			chromeRadioButton4.Name = "chromeRadioButton4";
			chromeRadioButton4.NoRounding = false;
			chromeRadioButton4.Size = new Size(97, 23);
			chromeRadioButton4.TabIndex = 44;
			chromeRadioButton4.Text = "After Delay";
			chromeRadioButton4.Transparent = false;
			chromeRadioButton3.Checked = false;
			chromeRadioButton3.Customization = "AAAA////////////AAAA/wAAAP8=";
			chromeRadioButton3.Field = 23;
			chromeRadioButton3.Font = new Font("Microsoft Sans Serif", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 0);
			chromeRadioButton3.Image = null;
			chromeRadioButton3.Location = new Point(234, 330);
			chromeRadioButton3.Name = "chromeRadioButton3";
			chromeRadioButton3.NoRounding = false;
			chromeRadioButton3.Size = new Size(114, 23);
			chromeRadioButton3.TabIndex = 43;
			chromeRadioButton3.Text = "Before Startup";
			chromeRadioButton3.Transparent = false;
			chromeRadioButton2.Checked = false;
			chromeRadioButton2.Customization = "AAAA////////////AAAA/wAAAP8=";
			chromeRadioButton2.Field = 23;
			chromeRadioButton2.Font = new Font("Microsoft Sans Serif", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 0);
			chromeRadioButton2.Image = null;
			chromeRadioButton2.Location = new Point(354, 330);
			chromeRadioButton2.Name = "chromeRadioButton2";
			chromeRadioButton2.NoRounding = false;
			chromeRadioButton2.Size = new Size(104, 23);
			chromeRadioButton2.TabIndex = 42;
			chromeRadioButton2.Text = "After Startup";
			chromeRadioButton2.Transparent = false;
			chromeRadioButton8.Checked = false;
			chromeRadioButton8.Customization = "AAAA////////////AAAA/wAAAP8=";
			chromeRadioButton8.Field = 23;
			chromeRadioButton8.Font = new Font("Microsoft Sans Serif", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 0);
			chromeRadioButton8.Image = null;
			chromeRadioButton8.Location = new Point(13, 330);
			chromeRadioButton8.Name = "chromeRadioButton8";
			chromeRadioButton8.NoRounding = false;
			chromeRadioButton8.Size = new Size(112, 23);
			chromeRadioButton8.TabIndex = 40;
			chromeRadioButton8.Text = " Script Header";
			chromeRadioButton8.Transparent = false;
			base.AutoScaleDimensions = new SizeF(6f, 13f);
			base.AutoScaleMode = AutoScaleMode.Font;
			BackColor = Color.White;
			base.ClientSize = new Size(710, 370);
			base.Controls.Add(bunifuCustomLabel1);
			base.Controls.Add(bunifuCheckbox1);
			base.Controls.Add(chromeRadioButton4);
			base.Controls.Add(chromeRadioButton3);
			base.Controls.Add(chromeRadioButton2);
			base.Controls.Add(chromeRadioButton8);
			base.Controls.Add(bunifuCustomLabel7);
			base.Controls.Add(bunifuCheckbox5);
			base.Controls.Add(bunifuCustomTextbox1);
			base.FormBorderStyle = FormBorderStyle.None;
			base.Name = "CustomCodeFrm";
			Text = "v";
			base.Load += CustomCodeFrm_Load;
			base.ResumeLayout(false);
			base.PerformLayout();
		}
	}
}
