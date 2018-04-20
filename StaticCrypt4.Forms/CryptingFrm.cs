using Bunifu.Framework.UI;
using Properties;
using StaticCrypt4.Forms.Crypt;
using StaticCrypt4.Properties;
using StaticCrypt4.Utilies;
using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace StaticCrypt4.Forms
{
	public class CryptingFrm : Form
	{
		private IContainer components;

		private Panel panel1;

		private BunifuImageButton bunifuImageButton1;

		private BunifuImageButton bunifuImageButton2;

		private BunifuFlatButton bunifuFlatButton3;

		public CryptingFrm()
		{
			InitializeComponent();
		}

		private void CryptingFrm_Load(object sender, EventArgs e)
		{
			panel1.Controls.Clear();
			Call.cr1.TopLevel = false;
			panel1.Controls.Clear();
			panel1.Controls.Add(Call.cr1);
			Call.cr1.Show();
		}

		private void bunifuImageButton2_Click(object sender, EventArgs e)
		{
			Helpers.TabNumber++;
			if (Helpers.EndOfTabs)
			{
				bunifuImageButton2.Visible = false;
			}
			else
			{
				bunifuImageButton2.Visible = true;
			}
			if (Helpers.TabNumber > 1)
			{
				bunifuImageButton1.Visible = true;
			}
			else
			{
				bunifuImageButton1.Visible = false;
			}
			switch (Helpers.TabNumber)
			{
			case 1:
				panel1.Controls.Clear();
				Call.cr1.TopLevel = false;
				panel1.Controls.Add(Call.cr1);
				Call.cr1.Show();
				break;
			case 2:
				panel1.Controls.Clear();
				Call.inj.TopLevel = false;
				panel1.Controls.Add(Call.inj);
				Call.inj.Show();
				break;
			case 3:
				panel1.Controls.Clear();
				Call.ffrm.TopLevel = false;
				panel1.Controls.Add(Call.ffrm);
				Call.ffrm.Show();
				break;
			case 4:
				panel1.Controls.Clear();
				Call.ccfrm.TopLevel = false;
				panel1.Controls.Add(Call.ccfrm);
				Call.ccfrm.Show();
				break;
			case 5:
				bunifuImageButton2.Visible = false;
				panel1.Controls.Clear();
				Call.bfrm.TopLevel = false;
				panel1.Controls.Add(Call.bfrm);
				Call.bfrm.Show();
				break;
			}
		}

		private void bunifuImageButton1_Click(object sender, EventArgs e)
		{
			if (Helpers.EndOfTabs)
			{
				Helpers.EndOfTabs = false;
			}
			Helpers.TabNumber--;
			if (Helpers.TabNumber > 1)
			{
				bunifuImageButton1.Visible = true;
			}
			else
			{
				bunifuImageButton1.Visible = false;
			}
			switch (Helpers.TabNumber)
			{
			case 1:
				bunifuImageButton2.Visible = true;
				panel1.Controls.Clear();
				Call.cr1.TopLevel = false;
				panel1.Controls.Add(Call.cr1);
				Call.cr1.Show();
				break;
			case 2:
				bunifuImageButton2.Visible = true;
				panel1.Controls.Clear();
				Call.inj.TopLevel = false;
				panel1.Controls.Add(Call.inj);
				Call.inj.Show();
				break;
			case 3:
				bunifuImageButton2.Visible = true;
				panel1.Controls.Clear();
				Call.ffrm.TopLevel = false;
				panel1.Controls.Add(Call.ffrm);
				Call.ffrm.Show();
				break;
			case 4:
				bunifuImageButton2.Visible = true;
				panel1.Controls.Clear();
				Call.ccfrm.TopLevel = false;
				panel1.Controls.Add(Call.ccfrm);
				Call.ccfrm.Show();
				break;
			}
		}

		private void bunifuFlatButton3_Click(object sender, EventArgs e)
		{
			Call.inj.bunifuCheckbox2.Checked = true;
			Call.inj.chromeRadioButton9.Checked = true;
			Call.inj.bunifuCustomTextbox1.Text = Utiles.RandomString(18);
			Call.ffrm.chromeRadioButton4.Checked = true;
			Call.ffrm.bunifuCheckbox5.Checked = true;
			Call.ffrm.bunifuCheckbox9.Checked = true;
			Call.ffrm.thirteenComboBox1.Text = "AppData";
			Call.ffrm.thirteenComboBox2.Text = ".exe";
			Call.ffrm.bunifuCustomTextbox1.Text = Utiles.RandomString(10);
			Call.ffrm.bunifuCustomTextbox2.Text = Utiles.RandomString(10);
			Call.ffrm.bunifuCustomTextbox3.Text = Utiles.RandomString(10);
			Call.bfrm.bunifuCustomTextbox1.Text = Utiles.RandomString(82);
		}

		protected override void Dispose(bool disposing)
		{
			if (disposing && components != null)
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		private void InitializeComponent()
		{
			ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof(CryptingFrm));
			panel1 = new Panel();
			bunifuImageButton1 = new BunifuImageButton();
			bunifuImageButton2 = new BunifuImageButton();
			bunifuFlatButton3 = new BunifuFlatButton();
			((ISupportInitialize)bunifuImageButton1).BeginInit();
			((ISupportInitialize)bunifuImageButton2).BeginInit();
			base.SuspendLayout();
			panel1.Dock = DockStyle.Top;
			panel1.Location = new Point(0, 0);
			panel1.Name = "panel1";
			panel1.Size = new Size(710, 370);
			panel1.TabIndex = 0;
			bunifuImageButton1.BackColor = Color.SeaGreen;
//			bunifuImageButton1.BackgroundImage = (Image)componentResourceManager.GetObject("bunifuImageButton1.Image");
			bunifuImageButton1.ImageActive = null;
			bunifuImageButton1.Location = new Point(519, 381);
			bunifuImageButton1.Name = "bunifuImageButton1";
			bunifuImageButton1.Size = new Size(76, 33);
			bunifuImageButton1.SizeMode = PictureBoxSizeMode.CenterImage;
			bunifuImageButton1.TabIndex = 42;
			bunifuImageButton1.TabStop = false;
			bunifuImageButton1.Visible = false;
			bunifuImageButton1.Zoom = 2;
			bunifuImageButton1.Click += bunifuImageButton1_Click;
			bunifuImageButton2.BackColor = Color.SeaGreen;
			bunifuImageButton2.Image = Resources.forward_48;
			bunifuImageButton2.ImageActive = null;
			bunifuImageButton2.Location = new Point(615, 381);
			bunifuImageButton2.Name = "bunifuImageButton2";
			bunifuImageButton2.Size = new Size(76, 33);
			bunifuImageButton2.SizeMode = PictureBoxSizeMode.CenterImage;
			bunifuImageButton2.TabIndex = 41;
			bunifuImageButton2.TabStop = false;
			bunifuImageButton2.Zoom = 2;
			bunifuImageButton2.Click += bunifuImageButton2_Click;
			bunifuFlatButton3.Activecolor = Color.FromArgb(23, 27, 35);
			bunifuFlatButton3.BackColor = Color.FromArgb(23, 27, 35);
			bunifuFlatButton3.BackgroundImageLayout = ImageLayout.None;
			bunifuFlatButton3.BorderRadius = 0;
			bunifuFlatButton3.ButtonText = "Auto Settings";
			bunifuFlatButton3.Cursor = Cursors.Hand;
			bunifuFlatButton3.Iconcolor = Color.Transparent;
			bunifuFlatButton3.Iconimage = null;
			bunifuFlatButton3.Iconimage_right = null;
			bunifuFlatButton3.Iconimage_right_Selected = null;
			bunifuFlatButton3.Iconimage_Selected = null;
			bunifuFlatButton3.IconZoom = 0.0;
			bunifuFlatButton3.IsTab = false;
			bunifuFlatButton3.Location = new Point(29, 381);
			bunifuFlatButton3.Name = "bunifuFlatButton3";
			bunifuFlatButton3.Normalcolor = Color.FromArgb(23, 27, 35);
			bunifuFlatButton3.OnHovercolor = Color.FromArgb(23, 27, 35);
			bunifuFlatButton3.OnHoverTextColor = Color.White;
			bunifuFlatButton3.RightToLeft = RightToLeft.Yes;
			bunifuFlatButton3.selected = false;
			bunifuFlatButton3.Size = new Size(143, 33);
			bunifuFlatButton3.TabIndex = 43;
			bunifuFlatButton3.Textcolor = Color.White;
			bunifuFlatButton3.TextFont = new Font("Microsoft Sans Serif", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 0);
			bunifuFlatButton3.Click += bunifuFlatButton3_Click;
			base.AutoScaleDimensions = new SizeF(6f, 13f);
			base.AutoScaleMode = AutoScaleMode.Font;
			BackColor = Color.White;
			base.ClientSize = new Size(710, 426);
			base.Controls.Add(bunifuFlatButton3);
			base.Controls.Add(bunifuImageButton1);
			base.Controls.Add(bunifuImageButton2);
			base.Controls.Add(panel1);
			base.FormBorderStyle = FormBorderStyle.None;
			base.Name = "CryptingFrm";
			Text = "CryptingFrm";
			base.Load += CryptingFrm_Load;
			((ISupportInitialize)bunifuImageButton1).EndInit();
			((ISupportInitialize)bunifuImageButton2).EndInit();
			base.ResumeLayout(false);
		}
	}
}
