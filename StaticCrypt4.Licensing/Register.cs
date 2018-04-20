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
	public class Register : Form
	{
		private IContainer components;

		private BunifuElipse bunifuElipse1;

		private Label label1;

		private PictureBox pictureBox2;

		public BunifuCustomLabel bunifuCustomLabel3;

		public BunifuCustomTextbox bunifuCustomTextbox1;

		public BunifuCustomTextbox bunifuCustomTextbox2;

		public BunifuFlatButton btnRegister;

		public BunifuCustomLabel bunifuCustomLabel2;

		public BunifuCustomLabel bunifuCustomLabel1;

		private BunifuDragControl bunifuDragControl1;

		public Register()
		{
			InitializeComponent();
		}

		private void bunifuCustomTextbox3_TextChanged(object sender, EventArgs e)
		{
		}

		private void bunifuCustomLabel4_Click(object sender, EventArgs e)
		{
		}

		private void label1_Click(object sender, EventArgs e)
		{
			Environment.Exit(0);
		}

		private void btnRegister_Click(object sender, EventArgs e)
		{
			switch (Program._Licence.Register(bunifuCustomTextbox1.Text, bunifuCustomTextbox2.Text))
			{
			case "0":
				MessageBox.Show("Sorry, but this user is already taken, please enter a new username.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand);
				break;
			case "1":
				MessageBox.Show("Your account has been created", "Succes", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
				base.Hide();
				Program.log.Show();
				break;
			case "2":
				MessageBox.Show("You already got an account.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand);
				break;
			default:
				MessageBox.Show("An error has occured, please try later", "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand);
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
			label1 = new Label();
			pictureBox2 = new PictureBox();
			bunifuCustomLabel3 = new BunifuCustomLabel();
			bunifuCustomTextbox1 = new BunifuCustomTextbox();
			bunifuCustomTextbox2 = new BunifuCustomTextbox();
			btnRegister = new BunifuFlatButton();
			bunifuCustomLabel2 = new BunifuCustomLabel();
			bunifuCustomLabel1 = new BunifuCustomLabel();
			bunifuDragControl1 = new BunifuDragControl(components);
			((ISupportInitialize)pictureBox2).BeginInit();
			base.SuspendLayout();
			bunifuElipse1.ElipseRadius = 5;
			bunifuElipse1.TargetControl = this;
			label1.AutoSize = true;
			label1.BackColor = Color.FromArgb(229, 74, 78);
			label1.Font = new Font("Microsoft Sans Serif", 8.25f, FontStyle.Bold, GraphicsUnit.Point, 0);
			label1.ForeColor = Color.White;
			label1.Location = new Point(296, 9);
			label1.Name = "label1";
			label1.Size = new Size(15, 13);
			label1.TabIndex = 8;
			label1.Text = "X";
			label1.Click += label1_Click;
			pictureBox2.BackColor = Color.FromArgb(229, 74, 78);
			pictureBox2.Location = new Point(293, 6);
			pictureBox2.Name = "pictureBox2";
			pictureBox2.Size = new Size(20, 20);
			pictureBox2.SizeMode = PictureBoxSizeMode.StretchImage;
			pictureBox2.TabIndex = 9;
			pictureBox2.TabStop = false;
			bunifuCustomLabel3.AutoSize = true;
			bunifuCustomLabel3.Font = new Font("Microsoft Sans Serif", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 0);
			bunifuCustomLabel3.Location = new Point(12, 8);
			bunifuCustomLabel3.Name = "bunifuCustomLabel3";
			bunifuCustomLabel3.Size = new Size(224, 16);
			bunifuCustomLabel3.TabIndex = 80;
			bunifuCustomLabel3.Text = "Static Crypt - Register a new account";
			bunifuCustomTextbox1.AllowDrop = true;
			bunifuCustomTextbox1.BorderColor = Color.SeaGreen;
			bunifuCustomTextbox1.BorderStyle = BorderStyle.FixedSingle;
			bunifuCustomTextbox1.Font = new Font("Microsoft Sans Serif", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 0);
			bunifuCustomTextbox1.Location = new Point(100, 55);
			bunifuCustomTextbox1.Multiline = true;
			bunifuCustomTextbox1.Name = "bunifuCustomTextbox1";
			bunifuCustomTextbox1.Size = new Size(211, 29);
			bunifuCustomTextbox1.TabIndex = 86;
			bunifuCustomTextbox1.TextAlign = HorizontalAlignment.Center;
			bunifuCustomTextbox2.AllowDrop = true;
			bunifuCustomTextbox2.BorderColor = Color.SeaGreen;
			bunifuCustomTextbox2.BorderStyle = BorderStyle.FixedSingle;
			bunifuCustomTextbox2.Font = new Font("Microsoft Sans Serif", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 0);
			bunifuCustomTextbox2.Location = new Point(100, 104);
			bunifuCustomTextbox2.Multiline = true;
			bunifuCustomTextbox2.Name = "bunifuCustomTextbox2";
			bunifuCustomTextbox2.Size = new Size(211, 29);
			bunifuCustomTextbox2.TabIndex = 85;
			bunifuCustomTextbox2.TextAlign = HorizontalAlignment.Center;
			bunifuCustomTextbox2.UseSystemPasswordChar = true;
			btnRegister.Activecolor = Color.FromArgb(23, 27, 35);
			btnRegister.BackColor = Color.FromArgb(23, 27, 35);
			btnRegister.BackgroundImageLayout = ImageLayout.Stretch;
			btnRegister.BorderRadius = 0;
			btnRegister.ButtonText = "Register";
			btnRegister.Cursor = Cursors.Hand;
			btnRegister.Iconcolor = Color.Transparent;
			btnRegister.Iconimage = Resources._null;
			btnRegister.Iconimage_right = null;
			btnRegister.Iconimage_right_Selected = null;
			btnRegister.Iconimage_Selected = null;
			btnRegister.IconZoom = 130.0;
			btnRegister.IsTab = false;
			btnRegister.Location = new Point(157, 152);
			btnRegister.Name = "btnRegister";
			btnRegister.Normalcolor = Color.FromArgb(23, 27, 35);
			btnRegister.OnHovercolor = Color.FromArgb(23, 27, 35);
			btnRegister.OnHoverTextColor = Color.White;
			btnRegister.selected = false;
			btnRegister.Size = new Size(154, 29);
			btnRegister.TabIndex = 83;
			btnRegister.Textcolor = Color.White;
			btnRegister.TextFont = new Font("Microsoft Sans Serif", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 0);
			btnRegister.Click += btnRegister_Click;
			bunifuCustomLabel2.AutoSize = true;
			bunifuCustomLabel2.Font = new Font("Microsoft Sans Serif", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 0);
			bunifuCustomLabel2.Location = new Point(17, 108);
			bunifuCustomLabel2.Name = "bunifuCustomLabel2";
			bunifuCustomLabel2.Size = new Size(74, 16);
			bunifuCustomLabel2.TabIndex = 82;
			bunifuCustomLabel2.Text = "Password :";
			bunifuCustomLabel1.AutoSize = true;
			bunifuCustomLabel1.Font = new Font("Microsoft Sans Serif", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 0);
			bunifuCustomLabel1.Location = new Point(17, 57);
			bunifuCustomLabel1.Name = "bunifuCustomLabel1";
			bunifuCustomLabel1.Size = new Size(77, 16);
			bunifuCustomLabel1.TabIndex = 81;
			bunifuCustomLabel1.Text = "Username :";
			bunifuDragControl1.Fixed = true;
			bunifuDragControl1.Horizontal = true;
			bunifuDragControl1.TargetControl = this;
			bunifuDragControl1.Vertical = true;
			base.AutoScaleDimensions = new SizeF(6f, 13f);
			base.AutoScaleMode = AutoScaleMode.Font;
			BackColor = Color.White;
			base.ClientSize = new Size(326, 198);
			base.Controls.Add(bunifuCustomTextbox1);
			base.Controls.Add(bunifuCustomTextbox2);
			base.Controls.Add(btnRegister);
			base.Controls.Add(bunifuCustomLabel2);
			base.Controls.Add(bunifuCustomLabel1);
			base.Controls.Add(bunifuCustomLabel3);
			base.Controls.Add(label1);
			base.Controls.Add(pictureBox2);
			base.FormBorderStyle = FormBorderStyle.None;
			base.Name = "Register";
			base.StartPosition = FormStartPosition.CenterParent;
			Text = "Register";
			((ISupportInitialize)pictureBox2).EndInit();
			base.ResumeLayout(false);
			base.PerformLayout();
		}
	}
}
