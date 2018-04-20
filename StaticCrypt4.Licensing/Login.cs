using Bunifu.Framework.UI;
using Properties;
using StaticCrypt4.Properties;
using StaticCrypt4.Utilies;
using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;
using WindowsFormsControlLibrary1;

namespace StaticCrypt4.Licensing
{
	public class Login : Form
	{
		private static MainFrm mf;

		private IContainer components;

		private BunifuElipse bunifuElipse1;

		public BunifuCustomLabel bunifuCustomLabel2;

		public BunifuCustomLabel bunifuCustomLabel1;

		public BunifuFlatButton btnLogin;

		public BunifuFlatButton btnRegister;

		public BunifuCustomTextbox bunifuCustomTextbox1;

		public BunifuCustomTextbox bunifuCustomTextbox2;

		public BunifuCustomLabel bunifuCustomLabel3;

		private Label label1;

		private PictureBox pictureBox2;

		private BunifuDragControl bunifuDragControl1;

		public Login()
		{
			InitializeComponent();
		}

		private void btnRegister_Click(object sender, EventArgs e)
		{
			Program.re.StartPosition = FormStartPosition.CenterScreen;
			Program.re.Show();
			base.Hide();
		}

		private void label1_Click(object sender, EventArgs e)
		{
			Environment.Exit(0);
		}

		private void btnLogin_Click(object sender, EventArgs e)
		{
			string[] array = Program._Licence.Login(bunifuCustomTextbox1.Text, bunifuCustomTextbox2.Text);
			Utiles.SealUsername = bunifuCustomTextbox1.Text;
			string a = array[0];
			if (a == "0")
			{
				MessageBox.Show("Invalid account", "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand);
			}
			else if (a == "1")
			{
				base.Hide();
				Banned banned = new Banned(array[1]);
				banned.StartPosition = FormStartPosition.CenterScreen;
				banned.ShowDialog();
				Process.GetCurrentProcess().Kill();
			}
			else if (a == "2")
			{
				base.Hide();
				Program.hw.StartPosition = FormStartPosition.CenterScreen;
				Program.hw.Show();
			}
			else
			{
				base.Hide();
				Program.ns.Show();
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
			bunifuCustomLabel2 = new BunifuCustomLabel();
			btnRegister = new BunifuFlatButton();
			btnLogin = new BunifuFlatButton();
			bunifuCustomTextbox2 = new BunifuCustomTextbox();
			bunifuCustomTextbox1 = new BunifuCustomTextbox();
			label1 = new Label();
			pictureBox2 = new PictureBox();
			bunifuCustomLabel3 = new BunifuCustomLabel();
			bunifuDragControl1 = new BunifuDragControl(components);
			((ISupportInitialize)pictureBox2).BeginInit();
			base.SuspendLayout();
			bunifuElipse1.ElipseRadius = 5;
			bunifuElipse1.TargetControl = this;
			bunifuCustomLabel1.AutoSize = true;
			bunifuCustomLabel1.Font = new Font("Microsoft Sans Serif", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 0);
			bunifuCustomLabel1.Location = new Point(12, 99);
			bunifuCustomLabel1.Name = "bunifuCustomLabel1";
			bunifuCustomLabel1.Size = new Size(77, 16);
			bunifuCustomLabel1.TabIndex = 3;
			bunifuCustomLabel1.Text = "Username :";
			bunifuCustomLabel2.AutoSize = true;
			bunifuCustomLabel2.Font = new Font("Microsoft Sans Serif", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 0);
			bunifuCustomLabel2.Location = new Point(12, 150);
			bunifuCustomLabel2.Name = "bunifuCustomLabel2";
			bunifuCustomLabel2.Size = new Size(74, 16);
			bunifuCustomLabel2.TabIndex = 4;
			bunifuCustomLabel2.Text = "Password :";
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
			btnRegister.Location = new Point(175, 195);
			btnRegister.Name = "btnRegister";
			btnRegister.Normalcolor = Color.FromArgb(23, 27, 35);
			btnRegister.OnHovercolor = Color.FromArgb(23, 27, 35);
			btnRegister.OnHoverTextColor = Color.White;
			btnRegister.selected = false;
			btnRegister.Size = new Size(154, 29);
			btnRegister.TabIndex = 73;
			btnRegister.Textcolor = Color.White;
			btnRegister.TextFont = new Font("Microsoft Sans Serif", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 0);
			btnRegister.Click += btnRegister_Click;
			btnLogin.Activecolor = Color.FromArgb(23, 27, 35);
			btnLogin.BackColor = Color.FromArgb(23, 27, 35);
			btnLogin.BackgroundImageLayout = ImageLayout.Stretch;
			btnLogin.BorderRadius = 0;
			btnLogin.ButtonText = "Login";
			btnLogin.Cursor = Cursors.Hand;
			btnLogin.Iconcolor = Color.Transparent;
			btnLogin.Iconimage = Resources._null;
			btnLogin.Iconimage_right = null;
			btnLogin.Iconimage_right_Selected = null;
			btnLogin.Iconimage_Selected = null;
			btnLogin.IconZoom = 170.0;
			btnLogin.IsTab = false;
			btnLogin.Location = new Point(12, 195);
			btnLogin.Name = "btnLogin";
			btnLogin.Normalcolor = Color.FromArgb(23, 27, 35);
			btnLogin.OnHovercolor = Color.FromArgb(23, 27, 35);
			btnLogin.OnHoverTextColor = Color.White;
			btnLogin.selected = false;
			btnLogin.Size = new Size(154, 29);
			btnLogin.TabIndex = 74;
			btnLogin.Textcolor = Color.White;
			btnLogin.TextFont = new Font("Microsoft Sans Serif", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 0);
			btnLogin.Click += btnLogin_Click;
			bunifuCustomTextbox2.AllowDrop = true;
			bunifuCustomTextbox2.BorderColor = Color.SeaGreen;
			bunifuCustomTextbox2.BorderStyle = BorderStyle.FixedSingle;
			bunifuCustomTextbox2.Font = new Font("Microsoft Sans Serif", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 0);
			bunifuCustomTextbox2.Location = new Point(95, 146);
			bunifuCustomTextbox2.Multiline = true;
			bunifuCustomTextbox2.Name = "bunifuCustomTextbox2";
			bunifuCustomTextbox2.Size = new Size(234, 29);
			bunifuCustomTextbox2.TabIndex = 75;
			bunifuCustomTextbox2.TextAlign = HorizontalAlignment.Center;
			bunifuCustomTextbox2.UseSystemPasswordChar = true;
			bunifuCustomTextbox1.AllowDrop = true;
			bunifuCustomTextbox1.BorderColor = Color.SeaGreen;
			bunifuCustomTextbox1.BorderStyle = BorderStyle.FixedSingle;
			bunifuCustomTextbox1.Font = new Font("Microsoft Sans Serif", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 0);
			bunifuCustomTextbox1.Location = new Point(95, 97);
			bunifuCustomTextbox1.Multiline = true;
			bunifuCustomTextbox1.Name = "bunifuCustomTextbox1";
			bunifuCustomTextbox1.Size = new Size(234, 29);
			bunifuCustomTextbox1.TabIndex = 76;
			bunifuCustomTextbox1.TextAlign = HorizontalAlignment.Center;
			label1.AutoSize = true;
			label1.BackColor = Color.FromArgb(229, 74, 78);
			label1.Font = new Font("Microsoft Sans Serif", 8.25f, FontStyle.Bold, GraphicsUnit.Point, 0);
			label1.ForeColor = Color.White;
			label1.Location = new Point(314, 10);
			label1.Name = "label1";
			label1.Size = new Size(15, 13);
			label1.TabIndex = 77;
			label1.Text = "X";
			label1.Click += label1_Click;
			pictureBox2.BackColor = Color.FromArgb(229, 74, 78);
			pictureBox2.Location = new Point(311, 7);
			pictureBox2.Name = "pictureBox2";
			pictureBox2.Size = new Size(20, 20);
			pictureBox2.SizeMode = PictureBoxSizeMode.StretchImage;
			pictureBox2.TabIndex = 78;
			pictureBox2.TabStop = false;
			bunifuCustomLabel3.AutoSize = true;
			bunifuCustomLabel3.Font = new Font("Microsoft Sans Serif", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 0);
			bunifuCustomLabel3.Location = new Point(12, 10);
			bunifuCustomLabel3.Name = "bunifuCustomLabel3";
			bunifuCustomLabel3.Size = new Size(118, 16);
			bunifuCustomLabel3.TabIndex = 79;
			bunifuCustomLabel3.Text = "Static Crypt - Login";
			bunifuDragControl1.Fixed = true;
			bunifuDragControl1.Horizontal = true;
			bunifuDragControl1.TargetControl = this;
			bunifuDragControl1.Vertical = true;
			base.AutoScaleDimensions = new SizeF(6f, 13f);
			base.AutoScaleMode = AutoScaleMode.Font;
			BackColor = Color.White;
			base.ClientSize = new Size(344, 243);
			base.Controls.Add(bunifuCustomLabel3);
			base.Controls.Add(label1);
			base.Controls.Add(pictureBox2);
			base.Controls.Add(bunifuCustomTextbox1);
			base.Controls.Add(bunifuCustomTextbox2);
			base.Controls.Add(btnLogin);
			base.Controls.Add(btnRegister);
			base.Controls.Add(bunifuCustomLabel2);
			base.Controls.Add(bunifuCustomLabel1);
			base.FormBorderStyle = FormBorderStyle.None;
			base.Name = "Login";
			base.StartPosition = FormStartPosition.CenterScreen;
			Text = "Login";
			((ISupportInitialize)pictureBox2).EndInit();
			base.ResumeLayout(false);
			base.PerformLayout();
		}

		static Login()
		{
			mf = new MainFrm();
		}
	}
}
