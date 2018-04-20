using Bunifu.Framework.UI;
using Properties;
using StaticCrypt4.Properties;
using StaticCrypt4.Utilies;
using System;
using System.ComponentModel;
using System.Drawing;
using System.Net;
using System.Windows.Forms;
using WindowsFormsControlLibrary1;

namespace StaticCrypt4.Licensing
{
	public class HWID : Form
	{
		private IContainer components;

		private BunifuElipse bunifuElipse1;

		private Label label1;

		private PictureBox pictureBox2;

		public BunifuFlatButton bunifuFlatButton3;

		public BunifuCustomTextbox bunifuCustomTextbox2;

		public BunifuCustomLabel bunifuCustomLabel1;

		public HWID()
		{
			InitializeComponent();
		}

		private void HWID_Load(object sender, EventArgs e)
		{
			bunifuCustomTextbox2.Text = Program._Licence.Hwid;
		}

		private void bunifuFlatButton3_Click(object sender, EventArgs e)
		{
			try
			{
				using (WebClient webClient = new WebClient())
				{
					if (!webClient.DownloadString("http://staticsoftwares.pro/StaticCrypt4/hwid.txt").Contains(Program._Licence.Hwid))
					{
						WebRequest.Create("http://staticsoftwares.pro/StaticCrypt4/changehwid.php?w=" + Utiles.SealUsername + ":" + Program._Licence.Hwid + Environment.NewLine).GetResponse();
					}
					else
					{
						MessageBox.Show("You've already asked for a HWID reset, please await.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
					}
				}
			}
			catch (Exception ex)
			{
				MessageBox.Show("Something went wrong :\n" + ex.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand);
			}
		}

		private void label1_Click(object sender, EventArgs e)
		{
			Environment.Exit(0);
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
			components = new Container();
			bunifuElipse1 = new BunifuElipse(components);
			label1 = new Label();
			pictureBox2 = new PictureBox();
			bunifuFlatButton3 = new BunifuFlatButton();
			bunifuCustomTextbox2 = new BunifuCustomTextbox();
			bunifuCustomLabel1 = new BunifuCustomLabel();
			((ISupportInitialize)pictureBox2).BeginInit();
			base.SuspendLayout();
			bunifuElipse1.ElipseRadius = 5;
			bunifuElipse1.TargetControl = this;
			label1.AutoSize = true;
			label1.BackColor = Color.FromArgb(229, 74, 78);
			label1.Font = new Font("Microsoft Sans Serif", 8.25f, FontStyle.Bold, GraphicsUnit.Point, 0);
			label1.ForeColor = Color.White;
			label1.Location = new Point(360, 10);
			label1.Name = "label1";
			label1.Size = new Size(15, 13);
			label1.TabIndex = 78;
			label1.Text = "X";
			label1.Click += label1_Click;
			pictureBox2.BackColor = Color.FromArgb(229, 74, 78);
			pictureBox2.Location = new Point(357, 7);
			pictureBox2.Name = "pictureBox2";
			pictureBox2.Size = new Size(20, 20);
			pictureBox2.SizeMode = PictureBoxSizeMode.StretchImage;
			pictureBox2.TabIndex = 79;
			pictureBox2.TabStop = false;
			bunifuFlatButton3.Activecolor = Color.FromArgb(23, 27, 35);
			bunifuFlatButton3.BackColor = Color.FromArgb(23, 27, 35);
			bunifuFlatButton3.BackgroundImageLayout = ImageLayout.Stretch;
			bunifuFlatButton3.BorderRadius = 0;
			bunifuFlatButton3.ButtonText = " Enter";
			bunifuFlatButton3.Cursor = Cursors.Hand;
			bunifuFlatButton3.Iconcolor = Color.Transparent;
			bunifuFlatButton3.Iconimage = Resources._null;
			bunifuFlatButton3.Iconimage_right = null;
			bunifuFlatButton3.Iconimage_right_Selected = null;
			bunifuFlatButton3.Iconimage_Selected = null;
			bunifuFlatButton3.IconZoom = 500.0;
			bunifuFlatButton3.IsTab = false;
			bunifuFlatButton3.Location = new Point(15, 105);
			bunifuFlatButton3.Name = "bunifuFlatButton3";
			bunifuFlatButton3.Normalcolor = Color.FromArgb(23, 27, 35);
			bunifuFlatButton3.OnHovercolor = Color.FromArgb(23, 27, 35);
			bunifuFlatButton3.OnHoverTextColor = Color.White;
			bunifuFlatButton3.selected = false;
			bunifuFlatButton3.Size = new Size(362, 29);
			bunifuFlatButton3.TabIndex = 77;
			bunifuFlatButton3.Textcolor = Color.White;
			bunifuFlatButton3.TextFont = new Font("Microsoft Sans Serif", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 0);
			bunifuFlatButton3.Click += bunifuFlatButton3_Click;
			bunifuCustomTextbox2.AllowDrop = true;
			bunifuCustomTextbox2.BorderColor = Color.SeaGreen;
			bunifuCustomTextbox2.BorderStyle = BorderStyle.FixedSingle;
			bunifuCustomTextbox2.Font = new Font("Microsoft Sans Serif", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 0);
			bunifuCustomTextbox2.Location = new Point(15, 63);
			bunifuCustomTextbox2.Multiline = true;
			bunifuCustomTextbox2.Name = "bunifuCustomTextbox2";
			bunifuCustomTextbox2.Size = new Size(362, 29);
			bunifuCustomTextbox2.TabIndex = 76;
			bunifuCustomTextbox2.TextAlign = HorizontalAlignment.Center;
			bunifuCustomLabel1.AutoSize = true;
			bunifuCustomLabel1.Font = new Font("Microsoft Sans Serif", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 0);
			bunifuCustomLabel1.Location = new Point(12, 37);
			bunifuCustomLabel1.Name = "bunifuCustomLabel1";
			bunifuCustomLabel1.Size = new Size(362, 16);
			bunifuCustomLabel1.TabIndex = 75;
			bunifuCustomLabel1.Text = "Your HWID has changed. Please send a request for a reset.";
			base.AutoScaleDimensions = new SizeF(6f, 13f);
			base.AutoScaleMode = AutoScaleMode.Font;
			BackColor = Color.White;
			base.ClientSize = new Size(386, 145);
			base.Controls.Add(label1);
			base.Controls.Add(pictureBox2);
			base.Controls.Add(bunifuFlatButton3);
			base.Controls.Add(bunifuCustomTextbox2);
			base.Controls.Add(bunifuCustomLabel1);
			base.FormBorderStyle = FormBorderStyle.None;
			base.Name = "HWID";
			Text = "HWID";
			base.Load += HWID_Load;
			((ISupportInitialize)pictureBox2).EndInit();
			base.ResumeLayout(false);
			base.PerformLayout();
		}
	}
}
