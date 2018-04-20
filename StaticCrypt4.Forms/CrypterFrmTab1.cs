using Bunifu.Framework.UI;
using StaticCrypt4.Forms.Crypt;
using StaticCrypt4.Properties;
using StaticCrypt4.Utilies;
using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace StaticCrypt4.Forms
{
	public class CrypterFrmTab1 : Form
	{
		public IContainer components;

		public BunifuTextbox bunifuTextbox1;

		public BunifuFlatButton bunifuFlatButton1;

		public BunifuCustomLabel bunifuCustomLabel1;

		public BunifuCustomLabel bunifuCustomLabel2;

		public BunifuCustomLabel bunifuCustomLabel3;

		public BunifuCustomLabel bunifuCustomLabel4;

		public BunifuFlatButton bunifuFlatButton2;

		public BunifuTextbox bunifuTextbox2;

		public BunifuCustomLabel bunifuCustomLabel5;

		public BunifuCustomLabel bunifuCustomLabel6;

		public BunifuCustomLabel bunifuCustomLabel7;

		public BunifuCustomLabel bunifuCustomLabel8;

		public PictureBox pictureBox1;

		public BunifuCustomLabel bunifuCustomLabel9;

		public CrypterFrmTab1()
		{
			InitializeComponent();
		}

		private void CrypterFrmTab1_Load(object sender, EventArgs e)
		{
			Helpers.TabNumber = 1;
			bunifuTextbox1.BackgroundImage = null;
			bunifuTextbox2.BackgroundImage = null;
		}

		private void bunifuFlatButton2_Click(object sender, EventArgs e)
		{
			using (OpenFileDialog openFileDialog = new OpenFileDialog())
			{
				openFileDialog.Filter = "Icon File | *.ico";
				if (openFileDialog.ShowDialog() == DialogResult.OK)
				{
					bunifuTextbox2.text = openFileDialog.FileName;
					pictureBox1.Image = Bitmap.FromHicon(new Icon(openFileDialog.FileName, new Size(40, 40)).Handle);
					bunifuCustomLabel7.Text = FileUtils.FileLenght(openFileDialog.FileName).ToString() + " KB";
				}
			}
		}

		private void bunifuImageButton2_Click(object sender, EventArgs e)
		{
		}

		private void bunifuFlatButton1_Click(object sender, EventArgs e)
		{
			using (OpenFileDialog openFileDialog = new OpenFileDialog())
			{
				openFileDialog.Filter = "PE File | *.exe";
				if (openFileDialog.ShowDialog() == DialogResult.OK)
				{
					bunifuTextbox1.text = openFileDialog.FileName;
					bunifuCustomLabel2.Text = RuntimeLanguage.Get(openFileDialog.FileName);
					bunifuCustomLabel3.Text = FileUtils.FileLenght(openFileDialog.FileName).ToString() + " KB";
					if (bunifuCustomLabel2.Text == ".NET 2")
					{
						Call.inj.chromeRadioButton11.Checked = true;
						Call.inj.chromeRadioButton4.Checked = true;
						StaticCrypt4.Utilies.Crypt.InjectPath = "\"1\"";
					}
					else if (bunifuCustomLabel2.Text == ".NET 4")
					{
						Call.inj.chromeRadioButton12.Checked = true;
						Call.inj.chromeRadioButton4.Checked = true;
						StaticCrypt4.Utilies.Crypt.InjectPath = "\"2\"";
					}
					else
					{
						Call.inj.chromeRadioButton13.Checked = true;
						Call.inj.chromeRadioButton6.Checked = true;
						StaticCrypt4.Utilies.Crypt.InjectPath = "\"7\"";
					}
				}
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

		public void InitializeComponent()
		{
			ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof(CrypterFrmTab1));
			bunifuCustomLabel1 = new BunifuCustomLabel();
			bunifuCustomLabel2 = new BunifuCustomLabel();
			bunifuCustomLabel3 = new BunifuCustomLabel();
			bunifuCustomLabel4 = new BunifuCustomLabel();
			bunifuCustomLabel5 = new BunifuCustomLabel();
			bunifuCustomLabel6 = new BunifuCustomLabel();
			bunifuCustomLabel7 = new BunifuCustomLabel();
			bunifuCustomLabel8 = new BunifuCustomLabel();
			bunifuCustomLabel9 = new BunifuCustomLabel();
			pictureBox1 = new PictureBox();
			bunifuFlatButton2 = new BunifuFlatButton();
			bunifuTextbox2 = new BunifuTextbox();
			bunifuFlatButton1 = new BunifuFlatButton();
			bunifuTextbox1 = new BunifuTextbox();
			((ISupportInitialize)pictureBox1).BeginInit();
			base.SuspendLayout();
			bunifuCustomLabel1.AutoSize = true;
			bunifuCustomLabel1.Font = new Font("Microsoft Sans Serif", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 0);
			bunifuCustomLabel1.Location = new Point(41, 101);
			bunifuCustomLabel1.Name = "bunifuCustomLabel1";
			bunifuCustomLabel1.Size = new Size(123, 16);
			bunifuCustomLabel1.TabIndex = 15;
			bunifuCustomLabel1.Text = "Runtime File Type :";
			bunifuCustomLabel2.AutoSize = true;
			bunifuCustomLabel2.Font = new Font("Microsoft Sans Serif", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 0);
			bunifuCustomLabel2.Location = new Point(170, 101);
			bunifuCustomLabel2.Name = "bunifuCustomLabel2";
			bunifuCustomLabel2.Size = new Size(31, 16);
			bunifuCustomLabel2.TabIndex = 16;
			bunifuCustomLabel2.Text = "N/A";
			bunifuCustomLabel3.AutoSize = true;
			bunifuCustomLabel3.Font = new Font("Microsoft Sans Serif", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 0);
			bunifuCustomLabel3.Location = new Point(112, 132);
			bunifuCustomLabel3.Name = "bunifuCustomLabel3";
			bunifuCustomLabel3.Size = new Size(31, 16);
			bunifuCustomLabel3.TabIndex = 18;
			bunifuCustomLabel3.Text = "N/A";
			bunifuCustomLabel4.AutoSize = true;
			bunifuCustomLabel4.Font = new Font("Microsoft Sans Serif", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 0);
			bunifuCustomLabel4.Location = new Point(41, 132);
			bunifuCustomLabel4.Name = "bunifuCustomLabel4";
			bunifuCustomLabel4.Size = new Size(65, 16);
			bunifuCustomLabel4.TabIndex = 17;
			bunifuCustomLabel4.Text = "File Size :";
			bunifuCustomLabel5.AutoSize = true;
			bunifuCustomLabel5.Font = new Font("Microsoft Sans Serif", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 0);
			bunifuCustomLabel5.Location = new Point(27, 20);
			bunifuCustomLabel5.Name = "bunifuCustomLabel5";
			bunifuCustomLabel5.Size = new Size(108, 16);
			bunifuCustomLabel5.TabIndex = 21;
			bunifuCustomLabel5.Text = "Select Your File :";
			bunifuCustomLabel6.AutoSize = true;
			bunifuCustomLabel6.Font = new Font("Microsoft Sans Serif", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 0);
			bunifuCustomLabel6.Location = new Point(30, 173);
			bunifuCustomLabel6.Name = "bunifuCustomLabel6";
			bunifuCustomLabel6.Size = new Size(111, 16);
			bunifuCustomLabel6.TabIndex = 22;
			bunifuCustomLabel6.Text = "Select Your Icon :";
			bunifuCustomLabel7.AutoSize = true;
			bunifuCustomLabel7.Font = new Font("Microsoft Sans Serif", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 0);
			bunifuCustomLabel7.Location = new Point(125, 271);
			bunifuCustomLabel7.Name = "bunifuCustomLabel7";
			bunifuCustomLabel7.Size = new Size(31, 16);
			bunifuCustomLabel7.TabIndex = 24;
			bunifuCustomLabel7.Text = "N/A";
			bunifuCustomLabel8.AutoSize = true;
			bunifuCustomLabel8.Font = new Font("Microsoft Sans Serif", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 0);
			bunifuCustomLabel8.Location = new Point(54, 271);
			bunifuCustomLabel8.Name = "bunifuCustomLabel8";
			bunifuCustomLabel8.Size = new Size(68, 16);
			bunifuCustomLabel8.TabIndex = 23;
			bunifuCustomLabel8.Text = "Icon Size :";
			bunifuCustomLabel9.AutoSize = true;
			bunifuCustomLabel9.Font = new Font("Microsoft Sans Serif", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 0);
			bunifuCustomLabel9.Location = new Point(54, 326);
			bunifuCustomLabel9.Name = "bunifuCustomLabel9";
			bunifuCustomLabel9.Size = new Size(62, 16);
			bunifuCustomLabel9.TabIndex = 29;
			bunifuCustomLabel9.Text = "Preview :";
			pictureBox1.BorderStyle = BorderStyle.FixedSingle;
			pictureBox1.Location = new Point(123, 309);
			pictureBox1.Name = "pictureBox1";
			pictureBox1.Size = new Size(50, 50);
			pictureBox1.TabIndex = 28;
			pictureBox1.TabStop = false;
			bunifuFlatButton2.Activecolor = Color.FromArgb(23, 27, 35);
			bunifuFlatButton2.BackColor = Color.FromArgb(23, 27, 35);
			bunifuFlatButton2.BackgroundImageLayout = ImageLayout.Stretch;
			bunifuFlatButton2.BorderRadius = 0;
			bunifuFlatButton2.ButtonText = "...";
			bunifuFlatButton2.Cursor = Cursors.Hand;
			bunifuFlatButton2.Iconcolor = Color.Transparent;
//			bunifuFlatButton2.Iconimage = Resources._null;
			bunifuFlatButton2.Iconimage_right = null;
			bunifuFlatButton2.Iconimage_right_Selected = null;
			bunifuFlatButton2.Iconimage_Selected = null;
			bunifuFlatButton2.IconZoom = 90.0;
			bunifuFlatButton2.IsTab = false;
			bunifuFlatButton2.Location = new Point(591, 205);
			bunifuFlatButton2.Name = "bunifuFlatButton2";
			bunifuFlatButton2.Normalcolor = Color.FromArgb(23, 27, 35);
			bunifuFlatButton2.OnHovercolor = Color.FromArgb(23, 27, 35);
			bunifuFlatButton2.OnHoverTextColor = Color.White;
			bunifuFlatButton2.selected = false;
			bunifuFlatButton2.Size = new Size(87, 29);
			bunifuFlatButton2.TabIndex = 20;
			bunifuFlatButton2.Textcolor = Color.White;
			bunifuFlatButton2.TextFont = new Font("Microsoft Sans Serif", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 0);
			bunifuFlatButton2.Click += bunifuFlatButton2_Click;
			bunifuTextbox2.AllowDrop = true;
			bunifuTextbox2.BackColor = Color.White;
//			bunifuTextbox2.BackgroundImage = (Image)componentResourceManager.GetObject("bunifuTextbox2.BackgroundImage");
			bunifuTextbox2.BackgroundImageLayout = ImageLayout.Stretch;
			bunifuTextbox2.BorderStyle = BorderStyle.FixedSingle;
			bunifuTextbox2.ForeColor = Color.Black;
//			bunifuTextbox2.Icon = (Image)componentResourceManager.GetObject("bunifuTextbox2.Icon");
			bunifuTextbox2.Location = new Point(33, 205);
			bunifuTextbox2.Name = "bunifuTextbox2";
			bunifuTextbox2.Size = new Size(523, 29);
			bunifuTextbox2.TabIndex = 19;
			bunifuTextbox2.text = "";
			bunifuFlatButton1.Activecolor = Color.FromArgb(23, 27, 35);
			bunifuFlatButton1.BackColor = Color.FromArgb(23, 27, 35);
			bunifuFlatButton1.BackgroundImageLayout = ImageLayout.Stretch;
			bunifuFlatButton1.BorderRadius = 0;
			bunifuFlatButton1.ButtonText = "...";
			bunifuFlatButton1.Cursor = Cursors.Hand;
			bunifuFlatButton1.Iconcolor = Color.Transparent;
//			bunifuFlatButton1.Iconimage = Resources._null;
			bunifuFlatButton1.Iconimage_right = null;
			bunifuFlatButton1.Iconimage_right_Selected = null;
			bunifuFlatButton1.Iconimage_Selected = null;
			bunifuFlatButton1.IconZoom = 90.0;
			bunifuFlatButton1.IsTab = false;
			bunifuFlatButton1.Location = new Point(588, 54);
			bunifuFlatButton1.Name = "bunifuFlatButton1";
			bunifuFlatButton1.Normalcolor = Color.FromArgb(23, 27, 35);
			bunifuFlatButton1.OnHovercolor = Color.FromArgb(23, 27, 35);
			bunifuFlatButton1.OnHoverTextColor = Color.White;
			bunifuFlatButton1.selected = false;
			bunifuFlatButton1.Size = new Size(87, 29);
			bunifuFlatButton1.TabIndex = 14;
			bunifuFlatButton1.Textcolor = Color.White;
			bunifuFlatButton1.TextFont = new Font("Microsoft Sans Serif", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 0);
			bunifuFlatButton1.Click += bunifuFlatButton1_Click;
			bunifuTextbox1.AllowDrop = true;
			bunifuTextbox1.BackColor = Color.White;
//			bunifuTextbox1.BackgroundImage = (Image)componentResourceManager.GetObject("bunifuTextbox1.BackgroundImage");
			bunifuTextbox1.BackgroundImageLayout = ImageLayout.Stretch;
			bunifuTextbox1.BorderStyle = BorderStyle.FixedSingle;
			bunifuTextbox1.ForeColor = Color.Black;
//			bunifuTextbox1.Icon = (Image)componentResourceManager.GetObject("bunifuTextbox1.Icon");
			bunifuTextbox1.Location = new Point(30, 54);
			bunifuTextbox1.Name = "bunifuTextbox1";
			bunifuTextbox1.Size = new Size(523, 29);
			bunifuTextbox1.TabIndex = 13;
			bunifuTextbox1.text = "";
			base.AutoScaleDimensions = new SizeF(6f, 13f);
			base.AutoScaleMode = AutoScaleMode.Font;
			AutoScroll = true;
			BackColor = Color.White;
			base.ClientSize = new Size(710, 370);
			base.Controls.Add(bunifuCustomLabel9);
			base.Controls.Add(pictureBox1);
			base.Controls.Add(bunifuCustomLabel7);
			base.Controls.Add(bunifuCustomLabel8);
			base.Controls.Add(bunifuCustomLabel6);
			base.Controls.Add(bunifuCustomLabel5);
			base.Controls.Add(bunifuFlatButton2);
			base.Controls.Add(bunifuTextbox2);
			base.Controls.Add(bunifuCustomLabel3);
			base.Controls.Add(bunifuCustomLabel4);
			base.Controls.Add(bunifuCustomLabel2);
			base.Controls.Add(bunifuCustomLabel1);
			base.Controls.Add(bunifuFlatButton1);
			base.Controls.Add(bunifuTextbox1);
			base.FormBorderStyle = FormBorderStyle.None;
			base.Name = "CrypterFrmTab1";
			Text = "CrypterFrmTab1";
			base.Load += CrypterFrmTab1_Load;
			((ISupportInitialize)pictureBox1).EndInit();
			base.ResumeLayout(false);
			base.PerformLayout();
		}
	}
}
