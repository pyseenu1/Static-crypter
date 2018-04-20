using Bunifu.Framework.UI;
using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using WindowsFormsControlLibrary1;

namespace StaticCrypt4.Licensing
{
	public class Banned : Form
	{
		private IContainer components;

		private BunifuElipse bunifuElipse1;

		private Label label1;

		private PictureBox pictureBox2;

		public BunifuCustomTextbox bunifuCustomTextbox2;

		public BunifuCustomLabel bunifuCustomLabel1;

		private string _reason
		{
			get;
			set;
		}

		public Banned(string reason)
		{
			_reason = reason;
			InitializeComponent();
		}

		private void bunifuCustomLabel1_Click(object sender, EventArgs e)
		{
		}

		private void Banned_Load(object sender, EventArgs e)
		{
			bunifuCustomTextbox2.Text = _reason;
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
			label1.Location = new Point(360, 12);
			label1.Name = "label1";
			label1.Size = new Size(15, 13);
			label1.TabIndex = 82;
			label1.Text = "X";
			label1.Click += label1_Click;
			pictureBox2.BackColor = Color.FromArgb(229, 74, 78);
			pictureBox2.Location = new Point(357, 9);
			pictureBox2.Name = "pictureBox2";
			pictureBox2.Size = new Size(20, 20);
			pictureBox2.SizeMode = PictureBoxSizeMode.StretchImage;
			pictureBox2.TabIndex = 83;
			pictureBox2.TabStop = false;
			bunifuCustomTextbox2.AllowDrop = true;
			bunifuCustomTextbox2.BorderColor = Color.SeaGreen;
			bunifuCustomTextbox2.BorderStyle = BorderStyle.FixedSingle;
			bunifuCustomTextbox2.Font = new Font("Microsoft Sans Serif", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 0);
			bunifuCustomTextbox2.Location = new Point(12, 126);
			bunifuCustomTextbox2.Multiline = true;
			bunifuCustomTextbox2.Name = "bunifuCustomTextbox2";
			bunifuCustomTextbox2.Size = new Size(362, 188);
			bunifuCustomTextbox2.TabIndex = 81;
			bunifuCustomTextbox2.TextAlign = HorizontalAlignment.Center;
			bunifuCustomLabel1.AutoSize = true;
			bunifuCustomLabel1.Font = new Font("Microsoft Sans Serif", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 0);
			bunifuCustomLabel1.Location = new Point(12, 39);
			bunifuCustomLabel1.Name = "bunifuCustomLabel1";
			bunifuCustomLabel1.Size = new Size(335, 80);
			bunifuCustomLabel1.TabIndex = 80;
			bunifuCustomLabel1.Text = "Your access to our software has been revoked. You've \r\nviolate something of our terms of using. Please take the\r\ntime to read the ban reason.\r\n\r\nBan reason :";
			bunifuCustomLabel1.Click += bunifuCustomLabel1_Click;
			base.AutoScaleDimensions = new SizeF(6f, 13f);
			base.AutoScaleMode = AutoScaleMode.Font;
			BackColor = Color.White;
			base.ClientSize = new Size(392, 330);
			base.Controls.Add(label1);
			base.Controls.Add(pictureBox2);
			base.Controls.Add(bunifuCustomTextbox2);
			base.Controls.Add(bunifuCustomLabel1);
			base.FormBorderStyle = FormBorderStyle.None;
			base.Name = "Banned";
			Text = "Banned";
			base.Load += Banned_Load;
			((ISupportInitialize)pictureBox2).EndInit();
			base.ResumeLayout(false);
			base.PerformLayout();
		}
	}
}
