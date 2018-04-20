using Bunifu.Framework.UI;
using Properties;
using StaticCrypt4.Properties;
using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using WindowsFormsControlLibrary1;

namespace StaticCrypt4.Licensing
{
	public class NewSerial : Form
	{
		private static string _username;

		private static string _password;

		private IContainer components;

		private BunifuElipse bunifuElipse1;

		public BunifuCustomLabel bunifuCustomLabel1;

		public BunifuCustomTextbox bunifuCustomTextbox2;

		public BunifuFlatButton bunifuFlatButton3;

		private Label label1;

		private PictureBox pictureBox2;

		private BunifuDragControl bunifuDragControl1;

		public NewSerial()
		{
			InitializeComponent();
		}

		public void AddCredentials(string user, string pass)
		{
			_username = user;
			_password = pass;
		}

		private void label1_Click(object sender, EventArgs e)
		{
			Environment.Exit(0);
		}

		private void bunifuFlatButton3_Click(object sender, EventArgs e)
		{
			string text = Program._Licence.Redeem(bunifuCustomTextbox2.Text);
			switch (text)
			{
			default:
				if (text == "4")
				{
					MessageBox.Show("Something went wrong, please contact an administrator", "error", MessageBoxButtons.OK, MessageBoxIcon.Hand);
				}
				break;
			case "0":
				MessageBox.Show("Not Logged");
				break;
			case "2":
			{
				MainFrm mainFrm = new MainFrm();
				mainFrm.StartPosition = FormStartPosition.CenterScreen;
				mainFrm.Show();
				base.Hide();
				break;
			}
			case "1":
				MessageBox.Show("Please enter a valide serial", "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand);
				break;
			case "3":
				MessageBox.Show("Sorry, but this serial is already used", "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand);
				break;
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

		private void InitializeComponent()
		{
			components = new Container();
			bunifuElipse1 = new BunifuElipse(components);
			bunifuCustomLabel1 = new BunifuCustomLabel();
			bunifuCustomTextbox2 = new BunifuCustomTextbox();
			bunifuFlatButton3 = new BunifuFlatButton();
			label1 = new Label();
			pictureBox2 = new PictureBox();
			bunifuDragControl1 = new BunifuDragControl(components);
			((ISupportInitialize)pictureBox2).BeginInit();
			base.SuspendLayout();
			bunifuElipse1.ElipseRadius = 5;
			bunifuElipse1.TargetControl = this;
			bunifuCustomLabel1.AutoSize = true;
			bunifuCustomLabel1.Font = new Font("Microsoft Sans Serif", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 0);
			bunifuCustomLabel1.Location = new Point(16, 36);
			bunifuCustomLabel1.Name = "bunifuCustomLabel1";
			bunifuCustomLabel1.Size = new Size(352, 16);
			bunifuCustomLabel1.TabIndex = 2;
			bunifuCustomLabel1.Text = "Your License has expired, please enter a new valid serial :";
			bunifuCustomTextbox2.AllowDrop = true;
			bunifuCustomTextbox2.BorderColor = Color.SeaGreen;
			bunifuCustomTextbox2.BorderStyle = BorderStyle.FixedSingle;
			bunifuCustomTextbox2.Font = new Font("Microsoft Sans Serif", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 0);
			bunifuCustomTextbox2.Location = new Point(19, 66);
			bunifuCustomTextbox2.Multiline = true;
			bunifuCustomTextbox2.Name = "bunifuCustomTextbox2";
			bunifuCustomTextbox2.Size = new Size(349, 29);
			bunifuCustomTextbox2.TabIndex = 69;
			bunifuCustomTextbox2.TextAlign = HorizontalAlignment.Center;
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
			bunifuFlatButton3.Location = new Point(19, 108);
			bunifuFlatButton3.Name = "bunifuFlatButton3";
			bunifuFlatButton3.Normalcolor = Color.FromArgb(23, 27, 35);
			bunifuFlatButton3.OnHovercolor = Color.FromArgb(23, 27, 35);
			bunifuFlatButton3.OnHoverTextColor = Color.White;
			bunifuFlatButton3.selected = false;
			bunifuFlatButton3.Size = new Size(349, 29);
			bunifuFlatButton3.TabIndex = 72;
			bunifuFlatButton3.Textcolor = Color.White;
			bunifuFlatButton3.TextFont = new Font("Microsoft Sans Serif", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 0);
			bunifuFlatButton3.Click += bunifuFlatButton3_Click;
			label1.AutoSize = true;
			label1.BackColor = Color.FromArgb(229, 74, 78);
			label1.Font = new Font("Microsoft Sans Serif", 8.25f, FontStyle.Bold, GraphicsUnit.Point, 0);
			label1.ForeColor = Color.White;
			label1.Location = new Point(364, 9);
			label1.Name = "label1";
			label1.Size = new Size(15, 13);
			label1.TabIndex = 73;
			label1.Text = "X";
			label1.Click += label1_Click;
			pictureBox2.BackColor = Color.FromArgb(229, 74, 78);
			pictureBox2.Location = new Point(361, 6);
			pictureBox2.Name = "pictureBox2";
			pictureBox2.Size = new Size(20, 20);
			pictureBox2.SizeMode = PictureBoxSizeMode.StretchImage;
			pictureBox2.TabIndex = 74;
			pictureBox2.TabStop = false;
			bunifuDragControl1.Fixed = true;
			bunifuDragControl1.Horizontal = true;
			bunifuDragControl1.TargetControl = this;
			bunifuDragControl1.Vertical = true;
			base.AutoScaleDimensions = new SizeF(6f, 13f);
			base.AutoScaleMode = AutoScaleMode.Font;
			BackColor = Color.White;
			base.ClientSize = new Size(391, 158);
			base.Controls.Add(label1);
			base.Controls.Add(pictureBox2);
			base.Controls.Add(bunifuFlatButton3);
			base.Controls.Add(bunifuCustomTextbox2);
			base.Controls.Add(bunifuCustomLabel1);
			base.FormBorderStyle = FormBorderStyle.None;
			base.Name = "NewSerial";
			base.StartPosition = FormStartPosition.CenterScreen;
			Text = "NewSerial";
			((ISupportInitialize)pictureBox2).EndInit();
			base.ResumeLayout(false);
			base.PerformLayout();
		}
	}
}
