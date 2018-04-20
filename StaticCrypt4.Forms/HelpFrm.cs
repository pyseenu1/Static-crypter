using Properties;
using StaticCrypt4.Properties;
using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using WindowsFormsControlLibrary1;

namespace StaticCrypt4.Forms
{
	public class HelpFrm : Form
	{
		private IContainer components;

		public BunifuCustomTextbox bunifuCustomTextbox1;

		private LinkLabel linkLabel1;

		private LinkLabel linkLabel3;

		private LinkLabel linkLabel4;

		private LinkLabel linkLabel5;

		private LinkLabel linkLabel6;

		private LinkLabel linkLabel8;

		private LinkLabel linkLabel9;

		private LinkLabel linkLabel10;

		private LinkLabel linkLabel11;

		public HelpFrm()
		{
			InitializeComponent();
		}

		private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
		{
			bunifuCustomTextbox1.Text = Resources.String1;
		}

		private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
		{
			bunifuCustomTextbox1.Text = Resources.String2;
		}

		private void linkLabel3_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
		{
			bunifuCustomTextbox1.Text = Resources.String3;
		}

		private void linkLabel4_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
		{
			bunifuCustomTextbox1.Text = Resources.String4;
		}

		private void HelpFrm_Load(object sender, EventArgs e)
		{
		}

		private void linkLabel5_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
		{
			bunifuCustomTextbox1.Text = Resources.String5;
		}

		private void linkLabel6_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
		{
			bunifuCustomTextbox1.Text = Resources.String6;
		}

		private void linkLabel7_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
		{
			bunifuCustomTextbox1.Text = Resources.String7;
		}

		private void linkLabel8_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
		{
			bunifuCustomTextbox1.Text = Resources.String8;
		}

		private void linkLabel9_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
		{
			bunifuCustomTextbox1.Text = Resources.String9;
		}

		private void linkLabel10_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
		{
			bunifuCustomTextbox1.Text = Resources.String10;
		}

		private void linkLabel11_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
		{
			bunifuCustomTextbox1.Text = Resources.String11;
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
			bunifuCustomTextbox1 = new BunifuCustomTextbox();
			linkLabel1 = new LinkLabel();
			linkLabel3 = new LinkLabel();
			linkLabel4 = new LinkLabel();
			linkLabel5 = new LinkLabel();
			linkLabel6 = new LinkLabel();
			linkLabel8 = new LinkLabel();
			linkLabel9 = new LinkLabel();
			linkLabel10 = new LinkLabel();
			linkLabel11 = new LinkLabel();
			base.SuspendLayout();
			bunifuCustomTextbox1.BorderColor = Color.SeaGreen;
			bunifuCustomTextbox1.BorderStyle = BorderStyle.FixedSingle;
			bunifuCustomTextbox1.Font = new Font("Microsoft Sans Serif", 9f, FontStyle.Regular, GraphicsUnit.Point, 0);
			bunifuCustomTextbox1.Location = new Point(296, 12);
			bunifuCustomTextbox1.Multiline = true;
			bunifuCustomTextbox1.Name = "bunifuCustomTextbox1";
			bunifuCustomTextbox1.Size = new Size(400, 402);
			bunifuCustomTextbox1.TabIndex = 28;
			linkLabel1.AutoSize = true;
			linkLabel1.LinkColor = Color.Black;
			linkLabel1.Location = new Point(44, 60);
			linkLabel1.Name = "linkLabel1";
			linkLabel1.Size = new Size(145, 13);
			linkLabel1.TabIndex = 29;
			linkLabel1.TabStop = true;
			linkLabel1.Text = "How can I get a FUD result ?";
			linkLabel1.VisitedLinkColor = Color.Black;
			linkLabel1.LinkClicked += linkLabel1_LinkClicked;
			linkLabel3.AutoSize = true;
			linkLabel3.LinkColor = Color.Black;
			linkLabel3.Location = new Point(44, 91);
			linkLabel3.Name = "linkLabel3";
			linkLabel3.Size = new Size(208, 13);
			linkLabel3.TabIndex = 31;
			linkLabel3.TabStop = true;
			linkLabel3.Text = "How can I use the custom code function ?";
			linkLabel3.VisitedLinkColor = Color.Black;
			linkLabel3.LinkClicked += linkLabel3_LinkClicked;
			linkLabel4.AutoSize = true;
			linkLabel4.LinkColor = Color.Black;
			linkLabel4.Location = new Point(44, 126);
			linkLabel4.Name = "linkLabel4";
			linkLabel4.Size = new Size(125, 13);
			linkLabel4.TabIndex = 32;
			linkLabel4.TabStop = true;
			linkLabel4.Text = "Why use a downloader ?";
			linkLabel4.VisitedLinkColor = Color.Black;
			linkLabel4.LinkClicked += linkLabel4_LinkClicked;
			linkLabel5.AutoSize = true;
			linkLabel5.LinkColor = Color.Black;
			linkLabel5.Location = new Point(44, 163);
			linkLabel5.Name = "linkLabel5";
			linkLabel5.Size = new Size(144, 13);
			linkLabel5.TabIndex = 33;
			linkLabel5.TabStop = true;
			linkLabel5.Text = ".NET itself won't work, why ?";
			linkLabel5.VisitedLinkColor = Color.Black;
			linkLabel5.LinkClicked += linkLabel5_LinkClicked;
			linkLabel6.AutoSize = true;
			linkLabel6.LinkColor = Color.Black;
			linkLabel6.Location = new Point(44, 197);
			linkLabel6.Name = "linkLabel6";
			linkLabel6.Size = new Size(105, 13);
			linkLabel6.TabIndex = 34;
			linkLabel6.TabStop = true;
			linkLabel6.Text = "Scantime Detections";
			linkLabel6.VisitedLinkColor = Color.Black;
			linkLabel6.LinkClicked += linkLabel6_LinkClicked;
			linkLabel8.AutoSize = true;
			linkLabel8.LinkColor = Color.Black;
			linkLabel8.Location = new Point(44, 233);
			linkLabel8.Name = "linkLabel8";
			linkLabel8.Size = new Size(123, 13);
			linkLabel8.TabIndex = 36;
			linkLabel8.TabStop = true;
			linkLabel8.Text = "Auto Pump Stub Method";
			linkLabel8.VisitedLinkColor = Color.Black;
			linkLabel8.LinkClicked += linkLabel8_LinkClicked;
			linkLabel9.AutoSize = true;
			linkLabel9.LinkColor = Color.Black;
			linkLabel9.Location = new Point(44, 270);
			linkLabel9.Name = "linkLabel9";
			linkLabel9.Size = new Size(163, 13);
			linkLabel9.TabIndex = 37;
			linkLabel9.TabStop = true;
			linkLabel9.Text = "My crypted file won't work, why ?";
			linkLabel9.VisitedLinkColor = Color.Black;
			linkLabel9.LinkClicked += linkLabel9_LinkClicked;
			linkLabel10.AutoSize = true;
			linkLabel10.LinkColor = Color.Black;
			linkLabel10.Location = new Point(44, 307);
			linkLabel10.Name = "linkLabel10";
			linkLabel10.Size = new Size(165, 13);
			linkLabel10.TabIndex = 38;
			linkLabel10.TabStop = true;
			linkLabel10.Text = "Found a bug, how can I repport ?";
			linkLabel10.VisitedLinkColor = Color.Black;
			linkLabel10.LinkClicked += linkLabel10_LinkClicked;
			linkLabel11.AutoSize = true;
			linkLabel11.LinkColor = Color.Black;
			linkLabel11.Location = new Point(44, 342);
			linkLabel11.Name = "linkLabel11";
			linkLabel11.Size = new Size(99, 13);
			linkLabel11.TabIndex = 39;
			linkLabel11.TabStop = true;
			linkLabel11.Text = "Settings description";
			linkLabel11.VisitedLinkColor = Color.Black;
			linkLabel11.LinkClicked += linkLabel11_LinkClicked;
			base.AutoScaleDimensions = new SizeF(6f, 13f);
			base.AutoScaleMode = AutoScaleMode.Font;
			BackColor = Color.White;
			base.ClientSize = new Size(710, 426);
			base.Controls.Add(linkLabel11);
			base.Controls.Add(linkLabel10);
			base.Controls.Add(linkLabel9);
			base.Controls.Add(linkLabel8);
			base.Controls.Add(linkLabel6);
			base.Controls.Add(linkLabel5);
			base.Controls.Add(linkLabel4);
			base.Controls.Add(linkLabel3);
			base.Controls.Add(linkLabel1);
			base.Controls.Add(bunifuCustomTextbox1);
			base.FormBorderStyle = FormBorderStyle.None;
			base.Name = "HelpFrm";
			Text = "HelpFrm";
			base.Load += HelpFrm_Load;
			base.ResumeLayout(false);
			base.PerformLayout();
		}
	}
}
