using Bunifu.Framework.UI;
using StaticCrypt4.Properties;
using StaticCrypt4.Utilies;
using System;
using System.ComponentModel;
using System.Drawing;
using System.Net;
using System.Windows.Forms;
using WindowsFormsControlLibrary1;

namespace StaticCrypt4.Forms
{
	public class HomeFrm : Form
	{
		public IContainer components;

		public BunifuCustomTextbox bunifuCustomTextbox1;

		public BunifuCustomLabel bunifuCustomLabel1;

		public BunifuCustomLabel bunifuCustomLabel2;

		public BunifuCustomLabel bunifuCustomLabel3;

		public BunifuCustomLabel bunifuCustomLabel4;

		public BunifuSeparator bunifuSeparator1;

		public PictureBox pictureBox1;

		public BunifuCustomLabel bunifuCustomLabel5;

		public BunifuSeparator bunifuSeparator2;

		public HomeFrm()
		{
			InitializeComponent();
		}

		private void bunifuThinButton1_Click(object sender, EventArgs e)
		{
		}

		private void HomeFrm_Load(object sender, EventArgs e)
		{
			try
			{
				using (WebClient webClient = new WebClient())
				{
					bunifuCustomTextbox1.Text = webClient.DownloadString("http://pastebin.com/raw/vCxFskU0");
					bunifuCustomLabel3.Text = Utiles.BuilderUpdate;
					bunifuCustomLabel2.Text = Utiles.StubUpdate;
				}
			}
			catch
			{
			}
		}

		private void bunifuCustomLabel2_Click(object sender, EventArgs e)
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
			bunifuCustomLabel1 = new BunifuCustomLabel();
			bunifuCustomLabel2 = new BunifuCustomLabel();
			bunifuCustomLabel3 = new BunifuCustomLabel();
			bunifuCustomLabel4 = new BunifuCustomLabel();
			bunifuSeparator1 = new BunifuSeparator();
			pictureBox1 = new PictureBox();
			bunifuCustomLabel5 = new BunifuCustomLabel();
			bunifuSeparator2 = new BunifuSeparator();
			((ISupportInitialize)pictureBox1).BeginInit();
			base.SuspendLayout();
			bunifuCustomTextbox1.BackColor = Color.White;
			bunifuCustomTextbox1.BorderColor = Color.SeaGreen;
			bunifuCustomTextbox1.BorderStyle = BorderStyle.FixedSingle;
			bunifuCustomTextbox1.Font = new Font("Microsoft Sans Serif", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 0);
			bunifuCustomTextbox1.Location = new Point(16, 12);
			bunifuCustomTextbox1.Multiline = true;
			bunifuCustomTextbox1.Name = "bunifuCustomTextbox1";
			bunifuCustomTextbox1.ScrollBars = ScrollBars.Horizontal;
			bunifuCustomTextbox1.Size = new Size(345, 402);
			bunifuCustomTextbox1.TabIndex = 0;
			bunifuCustomLabel1.AutoSize = true;
			bunifuCustomLabel1.Font = new Font("Microsoft Sans Serif", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 0);
			bunifuCustomLabel1.Location = new Point(390, 54);
			bunifuCustomLabel1.Name = "bunifuCustomLabel1";
			bunifuCustomLabel1.Size = new Size(117, 16);
			bunifuCustomLabel1.TabIndex = 1;
			bunifuCustomLabel1.Text = "Last Stub Update :";
			bunifuCustomLabel2.AutoSize = true;
			bunifuCustomLabel2.Font = new Font("Microsoft Sans Serif", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 0);
			bunifuCustomLabel2.Location = new Point(525, 54);
			bunifuCustomLabel2.Name = "bunifuCustomLabel2";
			bunifuCustomLabel2.Size = new Size(70, 16);
			bunifuCustomLabel2.TabIndex = 2;
			bunifuCustomLabel2.Text = "25 - 11 - 16";
			bunifuCustomLabel2.Click += bunifuCustomLabel2_Click;
			bunifuCustomLabel3.AutoSize = true;
			bunifuCustomLabel3.Font = new Font("Microsoft Sans Serif", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 0);
			bunifuCustomLabel3.Location = new Point(525, 16);
			bunifuCustomLabel3.Name = "bunifuCustomLabel3";
			bunifuCustomLabel3.Size = new Size(70, 16);
			bunifuCustomLabel3.TabIndex = 4;
			bunifuCustomLabel3.Text = "25 - 11 - 16";
			bunifuCustomLabel4.AutoSize = true;
			bunifuCustomLabel4.Font = new Font("Microsoft Sans Serif", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 0);
			bunifuCustomLabel4.Location = new Point(390, 16);
			bunifuCustomLabel4.Name = "bunifuCustomLabel4";
			bunifuCustomLabel4.Size = new Size(132, 16);
			bunifuCustomLabel4.TabIndex = 3;
			bunifuCustomLabel4.Text = "Last Builder Update :";
			bunifuSeparator1.BackColor = Color.Transparent;
			bunifuSeparator1.LineColor = Color.FromArgb(105, 105, 105);
			bunifuSeparator1.LineThickness = 1;
			bunifuSeparator1.Location = new Point(393, 241);
			bunifuSeparator1.Name = "bunifuSeparator1";
			bunifuSeparator1.Size = new Size(273, 35);
			bunifuSeparator1.TabIndex = 5;
			bunifuSeparator1.Transparency = 255;
			bunifuSeparator1.Vertical = false;
		//	pictureBox1.Image = Resources.user_icon;
			pictureBox1.Location = new Point(393, 285);
			pictureBox1.Name = "pictureBox1";
			pictureBox1.Size = new Size(100, 100);
			pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
			pictureBox1.TabIndex = 6;
			pictureBox1.TabStop = false;
			bunifuCustomLabel5.AutoSize = true;
			bunifuCustomLabel5.Font = new Font("Microsoft Sans Serif", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 0);
			bunifuCustomLabel5.Location = new Point(502, 287);
			bunifuCustomLabel5.Name = "bunifuCustomLabel5";
			bunifuCustomLabel5.Size = new Size(109, 16);
			bunifuCustomLabel5.TabIndex = 7;
			bunifuCustomLabel5.Text = "User : Username";
			bunifuSeparator2.BackColor = Color.Transparent;
			bunifuSeparator2.LineColor = Color.FromArgb(105, 105, 105);
			bunifuSeparator2.LineThickness = 1;
			bunifuSeparator2.Location = new Point(393, 391);
			bunifuSeparator2.Name = "bunifuSeparator2";
			bunifuSeparator2.Size = new Size(273, 35);
			bunifuSeparator2.TabIndex = 10;
			bunifuSeparator2.Transparency = 255;
			bunifuSeparator2.Vertical = false;
			base.AutoScaleDimensions = new SizeF(6f, 13f);
			base.AutoScaleMode = AutoScaleMode.Font;
			AutoScroll = true;
			BackColor = Color.White;
			base.ClientSize = new Size(710, 426);
			base.Controls.Add(bunifuSeparator2);
			base.Controls.Add(bunifuCustomLabel5);
			base.Controls.Add(pictureBox1);
			base.Controls.Add(bunifuSeparator1);
			base.Controls.Add(bunifuCustomLabel3);
			base.Controls.Add(bunifuCustomLabel4);
			base.Controls.Add(bunifuCustomLabel2);
			base.Controls.Add(bunifuCustomLabel1);
			base.Controls.Add(bunifuCustomTextbox1);
			base.FormBorderStyle = FormBorderStyle.None;
			base.Name = "HomeFrm";
			Text = "HomeFrm";
			base.Load += HomeFrm_Load;
			((ISupportInitialize)pictureBox1).EndInit();
			base.ResumeLayout(false);
			base.PerformLayout();
		}
	}
}
