using Bunifu.Framework.UI;
using StaticCrypt4.Forms;
using StaticCrypt4.Properties;
using StaticCrypt4.Utilies;
using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Net;
using System.Threading;
using System.Windows.Forms;

namespace StaticCrypt4
{
	public class MainFrm : Form
	{
		private IContainer components;

		private BunifuElipse bunifuElipse1;

		private BunifuGradientPanel bunifuGradientPanel1;

		private BunifuFlatButton bunifuFlatButton6;

		private BunifuFlatButton bunifuFlatButton5;

		private BunifuFlatButton bunifuFlatButton4;

		private BunifuFlatButton bunifuFlatButton3;

		private BunifuFlatButton bunifuFlatButton1;

		private BunifuFlatButton bunifuFlatButton2;

		private BunifuDragControl bunifuDragControl1;

		private PictureBox pictureBox1;

		private PictureBox pictureBox2;

		private BunifuCustomLabel bunifuCustomLabel1;

		private BunifuGradientPanel bunifuGradientPanel2;

		private Panel panel1;

		private BunifuCustomLabel bunifuCustomLabel2;

		private Label label1;

		public MainFrm()
		{
			InitializeComponent();
			Helpers.TabNumber = 1;
		}

		private void pictureBox2_Click(object sender, EventArgs e)
		{
			Environment.Exit(0);
		}

		private void bunifuFlatButton2_Click(object sender, EventArgs e)
		{
			FrmClass.hfrm.TopLevel = false;
			panel1.Controls.Clear();
			panel1.Controls.Add(FrmClass.hfrm);
			FrmClass.hfrm.Show();
		}

		private void bunifuFlatButton1_Click(object sender, EventArgs e)
		{
			panel1.Controls.Clear();
			FrmClass.crfrm.TopLevel = false;
			panel1.Controls.Clear();
			panel1.Controls.Add(FrmClass.crfrm);
			FrmClass.crfrm.Show();
		}

		private void bunifuFlatButton3_Click(object sender, EventArgs e)
		{
			panel1.Controls.Clear();
			FrmClass.exfrm.TopLevel = false;
			panel1.Controls.Clear();
			panel1.Controls.Add(FrmClass.exfrm);
			FrmClass.exfrm.Show();
		}

		private void MainFrm_Load(object sender, EventArgs e)
		{
			if (File.Exists("update.vbs"))
			{
				File.Delete("update.vbs");
			}
			using (WebClient webClient = new WebClient())
			{
				Thread.Sleep(100);
				if ("1.3" != webClient.DownloadString("http://www.staticsoftwares.pro/StaticCrypt4/update.txt"))
				{
					webClient.DownloadFile("http://www.staticsoftwares.pro/StaticCrypt4/staticCrypt.bin", "static_update.exe");
					string str = "Dim Fso" + Environment.NewLine;
					str = str + "Set Fso = WScript.CreateObject(\"Scripting.FileSystemObject\")" + Environment.NewLine;
					str = str + "Fso.DeleteFile(\"StaticCrypt4.exe\")" + Environment.NewLine;
					str = str + "Fso.MoveFile \"static_update.exe\", \"StaticCrypt4.exe\"" + Environment.NewLine;
					str += "CreateObject(\"WScript.Shell\").Run \"StaticCrypt4.exe\"";
					File.WriteAllText("update.vbs", str);
					Process.Start("update.vbs");
					Process.GetCurrentProcess().Kill();
				}
				Thread.Sleep(100);
			}
			FrmClass.hfrm.bunifuCustomLabel5.Text = "User : " + Utiles.SealUsername;
			Utiles.BuilderUpdate = Program._Licence.Variable("BuilderUpdate");
			Utiles.StubUpdate = Program._Licence.Variable("StubUpdate");
			Utiles.StubBlackListed = Program._Licence.Variable("StubBlacklisted");
			Utiles.StubWhiteListed = Program._Licence.Variable("StubReal");
			Utiles.DownloaderStub = Program._Licence.Variable("DownloaderStub");
			FrmClass.hfrm.TopLevel = false;
			panel1.Controls.Clear();
			panel1.Controls.Add(FrmClass.hfrm);
			FrmClass.hfrm.Show();
			if (!Directory.Exists(FileUtils.StaticPath))
			{
				Directory.CreateDirectory(FileUtils.StaticPath);
			}
			MessageBox.Show("Thank you for using Static Crypt, we remember that VT scans are totaly forbidens and you will get your account limited.\nStarting now, any crypted file found on virustotal having a name as 'pdf.exe', 'order.pdf.exe', 'picture.jpg.exe', etc and file as 'nanocore-cracked.exe' or anything like that, will get their account limited without any refund. If you have any antivirus software on your computer please uninstall it for the best using of Static Crypt by customers.\nThank You.\nBest Regards", "Static Crypt - Customers Message", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
			Process[] processes = Process.GetProcesses();
			for (int i = 0; i < processes.Length; i++)
			{
				if (processes[i].ToString().Contains("ekrn"))
				{
					MessageBox.Show("ESET antivirus has been detect on your system. For continue to use Static Crypt, you have to uninstall it against any files distribution.", "Static Crypt", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
					Environment.Exit(0);
				}
			}
		}

		private void panel1_Paint(object sender, PaintEventArgs e)
		{
		}

		private void bunifuFlatButton4_Click(object sender, EventArgs e)
		{
			panel1.Controls.Clear();
			FrmClass.scfrm.TopLevel = false;
			panel1.Controls.Clear();
			panel1.Controls.Add(FrmClass.scfrm);
			FrmClass.scfrm.Show();
		}

		private void bunifuFlatButton5_Click(object sender, EventArgs e)
		{
			panel1.Controls.Clear();
			FrmClass.csfrm.TopLevel = false;
			panel1.Controls.Clear();
			panel1.Controls.Add(FrmClass.csfrm);
			FrmClass.csfrm.Show();
		}

		private void bunifuFlatButton6_Click(object sender, EventArgs e)
		{
			panel1.Controls.Clear();
			FrmClass.hpfrm.TopLevel = false;
			panel1.Controls.Clear();
			panel1.Controls.Add(FrmClass.hpfrm);
			FrmClass.hpfrm.Show();
		}

		private void bunifuGradientPanel1_Paint(object sender, PaintEventArgs e)
		{
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
			ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof(MainFrm));
			bunifuElipse1 = new BunifuElipse(components);
			bunifuDragControl1 = new BunifuDragControl(components);
			bunifuGradientPanel2 = new BunifuGradientPanel();
			label1 = new Label();
			pictureBox2 = new PictureBox();
			panel1 = new Panel();
			bunifuGradientPanel1 = new BunifuGradientPanel();
			bunifuCustomLabel2 = new BunifuCustomLabel();
			bunifuCustomLabel1 = new BunifuCustomLabel();
			pictureBox1 = new PictureBox();
			bunifuFlatButton6 = new BunifuFlatButton();
			bunifuFlatButton5 = new BunifuFlatButton();
			bunifuFlatButton4 = new BunifuFlatButton();
			bunifuFlatButton3 = new BunifuFlatButton();
			bunifuFlatButton1 = new BunifuFlatButton();
			bunifuFlatButton2 = new BunifuFlatButton();
			bunifuGradientPanel2.SuspendLayout();
			((ISupportInitialize)pictureBox2).BeginInit();
			bunifuGradientPanel1.SuspendLayout();
			((ISupportInitialize)pictureBox1).BeginInit();
			base.SuspendLayout();
			bunifuElipse1.ElipseRadius = 5;
			bunifuElipse1.TargetControl = this;
			bunifuDragControl1.Fixed = true;
			bunifuDragControl1.Horizontal = true;
			bunifuDragControl1.TargetControl = bunifuGradientPanel2;
			bunifuDragControl1.Vertical = true;
//			bunifuGradientPanel2.BackgroundImage = (Image)componentResourceManager.GetObject("bunifuGradientPanel2.BackgroundImage");
			bunifuGradientPanel2.BackgroundImageLayout = ImageLayout.Stretch;
			bunifuGradientPanel2.Controls.Add(label1);
			bunifuGradientPanel2.Controls.Add(pictureBox2);
			bunifuGradientPanel2.Dock = DockStyle.Top;
			bunifuGradientPanel2.GradientBottomLeft = Color.White;
			bunifuGradientPanel2.GradientBottomRight = Color.White;
			bunifuGradientPanel2.GradientTopLeft = Color.White;
			bunifuGradientPanel2.GradientTopRight = Color.White;
			bunifuGradientPanel2.Location = new Point(208, 0);
			bunifuGradientPanel2.Name = "bunifuGradientPanel2";
			bunifuGradientPanel2.Quality = 10;
			bunifuGradientPanel2.Size = new Size(710, 31);
			bunifuGradientPanel2.TabIndex = 8;
			label1.AutoSize = true;
			label1.BackColor = Color.FromArgb(229, 74, 78);
			label1.Font = new Font("Microsoft Sans Serif", 8.25f, FontStyle.Bold, GraphicsUnit.Point, 0);
			label1.ForeColor = Color.White;
			label1.Location = new Point(682, 10);
			label1.Name = "label1";
			label1.Size = new Size(15, 13);
			label1.TabIndex = 0;
			label1.Text = "X";
			label1.Click += label1_Click;
			pictureBox2.BackColor = Color.FromArgb(229, 74, 78);
			pictureBox2.Location = new Point(679, 7);
			pictureBox2.Name = "pictureBox2";
			pictureBox2.Size = new Size(20, 20);
			pictureBox2.SizeMode = PictureBoxSizeMode.StretchImage;
			pictureBox2.TabIndex = 7;
			pictureBox2.TabStop = false;
			pictureBox2.Click += pictureBox2_Click;
			panel1.Dock = DockStyle.Fill;
			panel1.Location = new Point(208, 31);
			panel1.Name = "panel1";
			panel1.Size = new Size(710, 432);
			panel1.TabIndex = 9;
			panel1.Paint += panel1_Paint;
//			bunifuGradientPanel1.BackgroundImage = (Image)componentResourceManager.GetObject("bunifuGradientPanel1.BackgroundImage");
			bunifuGradientPanel1.BackgroundImageLayout = ImageLayout.Stretch;
			bunifuGradientPanel1.Controls.Add(bunifuCustomLabel2);
			bunifuGradientPanel1.Controls.Add(bunifuCustomLabel1);
			bunifuGradientPanel1.Controls.Add(pictureBox1);
			bunifuGradientPanel1.Controls.Add(bunifuFlatButton6);
			bunifuGradientPanel1.Controls.Add(bunifuFlatButton5);
			bunifuGradientPanel1.Controls.Add(bunifuFlatButton4);
			bunifuGradientPanel1.Controls.Add(bunifuFlatButton3);
			bunifuGradientPanel1.Controls.Add(bunifuFlatButton1);
			bunifuGradientPanel1.Controls.Add(bunifuFlatButton2);
			bunifuGradientPanel1.Dock = DockStyle.Left;
			bunifuGradientPanel1.GradientBottomLeft = Color.FromArgb(23, 27, 35);
			bunifuGradientPanel1.GradientBottomRight = Color.FromArgb(23, 27, 35);
			bunifuGradientPanel1.GradientTopLeft = Color.FromArgb(23, 27, 35);
			bunifuGradientPanel1.GradientTopRight = Color.FromArgb(23, 27, 35);
			bunifuGradientPanel1.Location = new Point(0, 0);
			bunifuGradientPanel1.Name = "bunifuGradientPanel1";
			bunifuGradientPanel1.Quality = 10;
			bunifuGradientPanel1.Size = new Size(208, 463);
			bunifuGradientPanel1.TabIndex = 0;
			bunifuGradientPanel1.Paint += bunifuGradientPanel1_Paint;
			bunifuCustomLabel2.AutoSize = true;
			bunifuCustomLabel2.BackColor = Color.Transparent;
			bunifuCustomLabel2.Font = new Font("Microsoft Sans Serif", 15.75f, FontStyle.Bold, GraphicsUnit.Point, 0);
			bunifuCustomLabel2.ForeColor = Color.White;
			bunifuCustomLabel2.Location = new Point(97, 56);
			bunifuCustomLabel2.Name = "bunifuCustomLabel2";
			bunifuCustomLabel2.Size = new Size(68, 25);
			bunifuCustomLabel2.TabIndex = 7;
			bunifuCustomLabel2.Text = "Crypt";
			bunifuCustomLabel1.AutoSize = true;
			bunifuCustomLabel1.BackColor = Color.Transparent;
			bunifuCustomLabel1.Font = new Font("Microsoft Sans Serif", 15.75f, FontStyle.Bold, GraphicsUnit.Point, 0);
			bunifuCustomLabel1.ForeColor = Color.White;
			bunifuCustomLabel1.Location = new Point(87, 31);
			bunifuCustomLabel1.Name = "bunifuCustomLabel1";
			bunifuCustomLabel1.Size = new Size(72, 25);
			bunifuCustomLabel1.TabIndex = 1;
			bunifuCustomLabel1.Text = "Static";
			pictureBox1.BackColor = Color.Transparent;
//			pictureBox1.Image = Resources.icondisplay;
			pictureBox1.Location = new Point(12, 12);
			pictureBox1.Name = "pictureBox1";
			pictureBox1.Size = new Size(71, 86);
			pictureBox1.SizeMode = PictureBoxSizeMode.CenterImage;
			pictureBox1.TabIndex = 1;
			pictureBox1.TabStop = false;
			bunifuFlatButton6.Activecolor = Color.LightGray;
			bunifuFlatButton6.BackColor = Color.Transparent;
			bunifuFlatButton6.BackgroundImageLayout = ImageLayout.Stretch;
			bunifuFlatButton6.BorderRadius = 0;
			bunifuFlatButton6.ButtonText = "     Help";
			bunifuFlatButton6.Cursor = Cursors.Hand;
			bunifuFlatButton6.Iconcolor = Color.Transparent;
//			bunifuFlatButton6.Iconimage = Resources.help__;
			bunifuFlatButton6.Iconimage_right = null;
			bunifuFlatButton6.Iconimage_right_Selected = null;
			bunifuFlatButton6.Iconimage_Selected = null;
			bunifuFlatButton6.IconZoom = 50.0;
			bunifuFlatButton6.IsTab = true;
			bunifuFlatButton6.Location = new Point(2, 344);
			bunifuFlatButton6.Name = "bunifuFlatButton6";
			bunifuFlatButton6.Normalcolor = Color.Transparent;
			bunifuFlatButton6.OnHovercolor = Color.LightGray;
			bunifuFlatButton6.OnHoverTextColor = Color.White;
			bunifuFlatButton6.selected = false;
			bunifuFlatButton6.Size = new Size(205, 48);
			bunifuFlatButton6.TabIndex = 6;
			bunifuFlatButton6.Textcolor = Color.White;
			bunifuFlatButton6.TextFont = new Font("Microsoft Sans Serif", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 0);
			bunifuFlatButton6.Click += bunifuFlatButton6_Click;
			bunifuFlatButton5.Activecolor = Color.LightGray;
			bunifuFlatButton5.BackColor = Color.Transparent;
			bunifuFlatButton5.BackgroundImageLayout = ImageLayout.Stretch;
			bunifuFlatButton5.BorderRadius = 0;
			bunifuFlatButton5.ButtonText = "    ToS";
			bunifuFlatButton5.Cursor = Cursors.Hand;
			bunifuFlatButton5.Iconcolor = Color.Transparent;
//			bunifuFlatButton5.Iconimage = Resources.CS_Icon_Terms_And_Conditions;
			bunifuFlatButton5.Iconimage_right = null;
			bunifuFlatButton5.Iconimage_right_Selected = null;
			bunifuFlatButton5.Iconimage_Selected = null;
			bunifuFlatButton5.IconZoom = 50.0;
			bunifuFlatButton5.IsTab = true;
			bunifuFlatButton5.Location = new Point(2, 296);
			bunifuFlatButton5.Name = "bunifuFlatButton5";
			bunifuFlatButton5.Normalcolor = Color.Transparent;
			bunifuFlatButton5.OnHovercolor = Color.LightGray;
			bunifuFlatButton5.OnHoverTextColor = Color.White;
			bunifuFlatButton5.selected = false;
			bunifuFlatButton5.Size = new Size(205, 48);
			bunifuFlatButton5.TabIndex = 5;
			bunifuFlatButton5.Textcolor = Color.White;
			bunifuFlatButton5.TextFont = new Font("Microsoft Sans Serif", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 0);
			bunifuFlatButton5.Click += bunifuFlatButton5_Click;
			bunifuFlatButton4.Activecolor = Color.LightGray;
			bunifuFlatButton4.BackColor = Color.Transparent;
			bunifuFlatButton4.BackgroundImageLayout = ImageLayout.Stretch;
			bunifuFlatButton4.BorderRadius = 0;
			bunifuFlatButton4.ButtonText = "     Scanner";
			bunifuFlatButton4.Cursor = Cursors.Hand;
			bunifuFlatButton4.Iconcolor = Color.Transparent;
///			bunifuFlatButton4.Iconimage = Resources.search;
			bunifuFlatButton4.Iconimage_right = null;
			bunifuFlatButton4.Iconimage_right_Selected = null;
			bunifuFlatButton4.Iconimage_Selected = null;
			bunifuFlatButton4.IconZoom = 40.0;
			bunifuFlatButton4.IsTab = true;
			bunifuFlatButton4.Location = new Point(2, 248);
			bunifuFlatButton4.Name = "bunifuFlatButton4";
			bunifuFlatButton4.Normalcolor = Color.Transparent;
			bunifuFlatButton4.OnHovercolor = Color.LightGray;
			bunifuFlatButton4.OnHoverTextColor = Color.White;
			bunifuFlatButton4.selected = false;
			bunifuFlatButton4.Size = new Size(205, 48);
			bunifuFlatButton4.TabIndex = 4;
			bunifuFlatButton4.Textcolor = Color.White;
			bunifuFlatButton4.TextFont = new Font("Microsoft Sans Serif", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 0);
			bunifuFlatButton4.Click += bunifuFlatButton4_Click;
			bunifuFlatButton3.Activecolor = Color.LightGray;
			bunifuFlatButton3.BackColor = Color.Transparent;
			bunifuFlatButton3.BackgroundImageLayout = ImageLayout.Stretch;
			bunifuFlatButton3.BorderRadius = 0;
			bunifuFlatButton3.ButtonText = " Extras";
			bunifuFlatButton3.Cursor = Cursors.Hand;
			bunifuFlatButton3.Iconcolor = Color.Transparent;
//			bunifuFlatButton3.Iconimage = (Image)componentResourceManager.GetObject("bunifuFlatButton3.Iconimage");
			bunifuFlatButton3.Iconimage_right = null;
			bunifuFlatButton3.Iconimage_right_Selected = null;
			bunifuFlatButton3.Iconimage_Selected = null;
			bunifuFlatButton3.IconZoom = 90.0;
			bunifuFlatButton3.IsTab = true;
			bunifuFlatButton3.Location = new Point(2, 200);
			bunifuFlatButton3.Name = "bunifuFlatButton3";
			bunifuFlatButton3.Normalcolor = Color.Transparent;
			bunifuFlatButton3.OnHovercolor = Color.LightGray;
			bunifuFlatButton3.OnHoverTextColor = Color.White;
			bunifuFlatButton3.selected = false;
			bunifuFlatButton3.Size = new Size(205, 48);
			bunifuFlatButton3.TabIndex = 3;
			bunifuFlatButton3.Textcolor = Color.White;
			bunifuFlatButton3.TextFont = new Font("Microsoft Sans Serif", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 0);
			bunifuFlatButton3.Click += bunifuFlatButton3_Click;
			bunifuFlatButton1.Activecolor = Color.LightGray;
			bunifuFlatButton1.BackColor = Color.Transparent;
			bunifuFlatButton1.BackgroundImageLayout = ImageLayout.Stretch;
			bunifuFlatButton1.BorderRadius = 0;
			bunifuFlatButton1.ButtonText = "     Crypt";
			bunifuFlatButton1.Cursor = Cursors.Hand;
			bunifuFlatButton1.Iconcolor = Color.Transparent;
//			bunifuFlatButton1.Iconimage = Resources.Crypt_;
			bunifuFlatButton1.Iconimage_right = null;
			bunifuFlatButton1.Iconimage_right_Selected = null;
			bunifuFlatButton1.Iconimage_Selected = null;
			bunifuFlatButton1.IconZoom = 50.0;
			bunifuFlatButton1.IsTab = true;
			bunifuFlatButton1.Location = new Point(2, 152);
			bunifuFlatButton1.Name = "bunifuFlatButton1";
			bunifuFlatButton1.Normalcolor = Color.Transparent;
			bunifuFlatButton1.OnHovercolor = Color.LightGray;
			bunifuFlatButton1.OnHoverTextColor = Color.White;
			bunifuFlatButton1.selected = false;
			bunifuFlatButton1.Size = new Size(205, 48);
			bunifuFlatButton1.TabIndex = 2;
			bunifuFlatButton1.Textcolor = Color.White;
			bunifuFlatButton1.TextFont = new Font("Microsoft Sans Serif", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 0);
			bunifuFlatButton1.Click += bunifuFlatButton1_Click;
			bunifuFlatButton2.Activecolor = Color.LightGray;
			bunifuFlatButton2.BackColor = Color.Transparent;
			bunifuFlatButton2.BackgroundImageLayout = ImageLayout.Stretch;
			bunifuFlatButton2.BorderRadius = 0;
			bunifuFlatButton2.ButtonText = "     Home";
			bunifuFlatButton2.Cursor = Cursors.Hand;
			bunifuFlatButton2.Iconcolor = Color.Transparent;
//			bunifuFlatButton2.Iconimage = Resources.Home___1;
			bunifuFlatButton2.Iconimage_right = null;
			bunifuFlatButton2.Iconimage_right_Selected = null;
			bunifuFlatButton2.Iconimage_Selected = null;
			bunifuFlatButton2.IconZoom = 40.0;
			bunifuFlatButton2.IsTab = true;
			bunifuFlatButton2.Location = new Point(2, 104);
			bunifuFlatButton2.Name = "bunifuFlatButton2";
			bunifuFlatButton2.Normalcolor = Color.Transparent;
			bunifuFlatButton2.OnHovercolor = Color.LightGray;
			bunifuFlatButton2.OnHoverTextColor = Color.White;
			bunifuFlatButton2.selected = false;
			bunifuFlatButton2.Size = new Size(205, 48);
			bunifuFlatButton2.TabIndex = 1;
			bunifuFlatButton2.Textcolor = Color.White;
			bunifuFlatButton2.TextFont = new Font("Microsoft Sans Serif", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 0);
			bunifuFlatButton2.Click += bunifuFlatButton2_Click;
			base.AutoScaleDimensions = new SizeF(6f, 13f);
			base.AutoScaleMode = AutoScaleMode.Font;
			BackColor = Color.White;
			base.ClientSize = new Size(918, 463);
			base.Controls.Add(panel1);
			base.Controls.Add(bunifuGradientPanel2);
			base.Controls.Add(bunifuGradientPanel1);
			base.FormBorderStyle = FormBorderStyle.None;
			base.Name = "MainFrm";
			base.StartPosition = FormStartPosition.CenterScreen;
			Text = "Form1";
			base.Load += MainFrm_Load;
			bunifuGradientPanel2.ResumeLayout(false);
			bunifuGradientPanel2.PerformLayout();
			((ISupportInitialize)pictureBox2).EndInit();
			bunifuGradientPanel1.ResumeLayout(false);
			bunifuGradientPanel1.PerformLayout();
			((ISupportInitialize)pictureBox1).EndInit();
			base.ResumeLayout(false);
		}
	}
}
