using Bunifu.Framework.UI;
using Properties;
using StaticCrypt4.Properties;
using StaticCrypt4.Utilies;
using System;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Threading;
using System.Windows.Forms;
using WindowsFormsControlLibrary1;

namespace StaticCrypt4.Forms
{
	public class ScannerFrm : Form
	{
		private static string _pathGIF = FileUtils.StaticPath + "\\load.gif";

		private static FrameGIF _gif;

		private Thread thd;

		private Thread thd2;

		public ColumnHeader columnHeader1;

		public ColumnHeader columnHeader2;

		public BunifuTextbox bunifuTextbox2;

		public BunifuCustomLabel bunifuCustomLabel5;

		public BunifuCustomTextbox bunifuCustomTextbox1;

		public BunifuCustomLabel bunifuCustomLabel1;

		public BunifuFlatButton bunifuFlatButton1;

		public BunifuCustomLabel bunifuCustomLabel2;

		public BunifuCustomLabel bunifuCustomLabel3;

		public PictureBox pictureBox1;

		public BunifuFlatButton bunifuFlatButton2;

		public BunifuFlatButton bunifuFlatButton3;

		public ListView listView1;

		private IContainer components;

		public ScannerFrm()
		{
			InitializeComponent();
		}

		private void ScannerFrm_Load(object sender, EventArgs e)
		{
			bunifuTextbox2.BackgroundImage = null;
		}

		private void bunifuFlatButton2_Click(object sender, EventArgs e)
		{
			using (OpenFileDialog openFileDialog = new OpenFileDialog())
			{
				openFileDialog.Filter = "All Files | *.*";
				if (openFileDialog.ShowDialog() == DialogResult.OK)
				{
					bunifuTextbox2.text = openFileDialog.FileName;
				}
			}
		}

		private void bunifuFlatButton3_Click(object sender, EventArgs e)
		{
			bunifuCustomLabel3.Text = "-- / 35";
			bunifuCustomLabel3.ForeColor = Color.Black;
			try
			{
				thd.Abort();
				thd2.Abort();
			}
			catch
			{
			}
			bunifuFlatButton3.Enabled = false;
			bunifuFlatButton3.Cursor = Cursors.Default;
			bunifuFlatButton2.Enabled = false;
			bunifuFlatButton2.Cursor = Cursors.Default;
			thd = new Thread((ThreadStart)delegate
			{
				Scan.Run(bunifuTextbox2.text);
			});
			thd.IsBackground = true;
			thd.Start();
			thd2 = new Thread((ThreadStart)delegate
			{
				Wait();
			});
			thd2.IsBackground = true;
			thd2.Start();
		}

		private void bunifuFlatButton1_Click(object sender, EventArgs e)
		{
			try
			{
				Clipboard.SetText(bunifuCustomTextbox1.Text);
			}
			catch
			{
			}
		}

		private void Wait()
		{
			if (FileUtils.CheckPath())
			{
				try
				{
					File.WriteAllBytes(FileUtils.StaticPath + "\\load.gif", Resources.load);
				}
				catch
				{
				}
			}
			_gif = new FrameGIF(_pathGIF);
			_gif.ReverseAtEnd = false;
			pictureBox1.Invoke((MethodInvoker)delegate
			{
				pictureBox1.Visible = true;
			});
			pictureBox1.Invoke((MethodInvoker)delegate
			{
				pictureBox1.Image = _gif.GetNextFrame();
			});
			while (!Scan.IsFinish)
			{
				Thread.Sleep(10);
			}
			try
			{
				bunifuCustomLabel3.Invoke((MethodInvoker)delegate
				{
					bunifuCustomLabel3.Text = Scan.RateResult;
				});
				if (Scan.RateResult == "0/35")
				{
					bunifuCustomLabel3.ForeColor = Color.ForestGreen;
				}
				else
				{
					bunifuCustomLabel3.ForeColor = Color.Red;
				}
			}
			catch
			{
			}
			pictureBox1.Invoke((MethodInvoker)delegate
			{
				pictureBox1.Visible = false;
			});
			bunifuCustomTextbox1.Invoke((MethodInvoker)delegate
			{
				bunifuCustomTextbox1.Text = Scan.ScanURL;
			});
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
			ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof(ScannerFrm));
			listView1 = new ListView();
			columnHeader1 = new ColumnHeader();
			columnHeader2 = new ColumnHeader();
			bunifuCustomLabel5 = new BunifuCustomLabel();
			bunifuCustomTextbox1 = new BunifuCustomTextbox();
			bunifuCustomLabel1 = new BunifuCustomLabel();
			bunifuCustomLabel2 = new BunifuCustomLabel();
			bunifuCustomLabel3 = new BunifuCustomLabel();
			bunifuFlatButton1 = new BunifuFlatButton();
			bunifuFlatButton2 = new BunifuFlatButton();
			bunifuTextbox2 = new BunifuTextbox();
			bunifuFlatButton3 = new BunifuFlatButton();
			pictureBox1 = new PictureBox();
			((ISupportInitialize)pictureBox1).BeginInit();
			base.SuspendLayout();
			listView1.Columns.AddRange(new ColumnHeader[2]
			{
				columnHeader1,
				columnHeader2
			});
			listView1.Location = new Point(12, 12);
			listView1.Name = "listView1";
			listView1.Size = new Size(338, 402);
			listView1.TabIndex = 0;
			listView1.UseCompatibleStateImageBehavior = false;
			listView1.View = View.Details;
			columnHeader1.Text = "AntiVirus";
			columnHeader1.Width = 159;
			columnHeader2.Text = "Result";
			columnHeader2.Width = 174;
			bunifuCustomLabel5.AutoSize = true;
			bunifuCustomLabel5.Font = new Font("Microsoft Sans Serif", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 0);
			bunifuCustomLabel5.Location = new Point(393, 12);
			bunifuCustomLabel5.Name = "bunifuCustomLabel5";
			bunifuCustomLabel5.Size = new Size(158, 16);
			bunifuCustomLabel5.TabIndex = 65;
			bunifuCustomLabel5.Text = "Select The File To Scan :";
			bunifuCustomTextbox1.BorderColor = Color.SeaGreen;
			bunifuCustomTextbox1.BorderStyle = BorderStyle.FixedSingle;
			bunifuCustomTextbox1.Font = new Font("Microsoft Sans Serif", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 0);
			bunifuCustomTextbox1.Location = new Point(396, 190);
			bunifuCustomTextbox1.Multiline = true;
			bunifuCustomTextbox1.Name = "bunifuCustomTextbox1";
			bunifuCustomTextbox1.Size = new Size(285, 23);
			bunifuCustomTextbox1.TabIndex = 66;
			bunifuCustomLabel1.AutoSize = true;
			bunifuCustomLabel1.Font = new Font("Microsoft Sans Serif", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 0);
			bunifuCustomLabel1.Location = new Point(393, 151);
			bunifuCustomLabel1.Name = "bunifuCustomLabel1";
			bunifuCustomLabel1.Size = new Size(86, 16);
			bunifuCustomLabel1.TabIndex = 67;
			bunifuCustomLabel1.Text = "Scan Result :";
			bunifuCustomLabel2.AutoSize = true;
			bunifuCustomLabel2.Font = new Font("Microsoft Sans Serif", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 0);
			bunifuCustomLabel2.Location = new Point(393, 280);
			bunifuCustomLabel2.Name = "bunifuCustomLabel2";
			bunifuCustomLabel2.Size = new Size(52, 16);
			bunifuCustomLabel2.TabIndex = 69;
			bunifuCustomLabel2.Text = "Result :";
			bunifuCustomLabel3.AutoSize = true;
			bunifuCustomLabel3.Font = new Font("Microsoft Sans Serif", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 0);
			bunifuCustomLabel3.Location = new Point(451, 280);
			bunifuCustomLabel3.Name = "bunifuCustomLabel3";
			bunifuCustomLabel3.Size = new Size(40, 16);
			bunifuCustomLabel3.TabIndex = 70;
			bunifuCustomLabel3.Text = "-- / 35";
			bunifuFlatButton1.Activecolor = Color.FromArgb(23, 27, 35);
			bunifuFlatButton1.BackColor = Color.FromArgb(23, 27, 35);
			bunifuFlatButton1.BackgroundImageLayout = ImageLayout.Stretch;
			bunifuFlatButton1.BorderRadius = 0;
			bunifuFlatButton1.ButtonText = "Copy";
			bunifuFlatButton1.Cursor = Cursors.Hand;
			bunifuFlatButton1.Iconcolor = Color.Transparent;
//			bunifuFlatButton1.Iconimage = Resources._null;
			bunifuFlatButton1.Iconimage_right = null;
			bunifuFlatButton1.Iconimage_right_Selected = null;
			bunifuFlatButton1.Iconimage_Selected = null;
			bunifuFlatButton1.IconZoom = 470.0;
			bunifuFlatButton1.IsTab = false;
			bunifuFlatButton1.Location = new Point(396, 229);
			bunifuFlatButton1.Name = "bunifuFlatButton1";
			bunifuFlatButton1.Normalcolor = Color.FromArgb(23, 27, 35);
			bunifuFlatButton1.OnHovercolor = Color.FromArgb(23, 27, 35);
			bunifuFlatButton1.OnHoverTextColor = Color.White;
			bunifuFlatButton1.selected = false;
			bunifuFlatButton1.Size = new Size(285, 29);
			bunifuFlatButton1.TabIndex = 68;
			bunifuFlatButton1.Textcolor = Color.White;
			bunifuFlatButton1.TextFont = new Font("Microsoft Sans Serif", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 0);
			bunifuFlatButton1.Click += bunifuFlatButton1_Click;
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
			bunifuFlatButton2.IconZoom = 60.0;
			bunifuFlatButton2.IsTab = false;
			bunifuFlatButton2.Location = new Point(609, 50);
			bunifuFlatButton2.Name = "bunifuFlatButton2";
			bunifuFlatButton2.Normalcolor = Color.FromArgb(23, 27, 35);
			bunifuFlatButton2.OnHovercolor = Color.FromArgb(23, 27, 35);
			bunifuFlatButton2.OnHoverTextColor = Color.White;
			bunifuFlatButton2.selected = false;
			bunifuFlatButton2.Size = new Size(73, 29);
			bunifuFlatButton2.TabIndex = 64;
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
			bunifuTextbox2.Location = new Point(397, 50);
			bunifuTextbox2.Name = "bunifuTextbox2";
			bunifuTextbox2.Size = new Size(206, 29);
			bunifuTextbox2.TabIndex = 63;
			bunifuTextbox2.text = "";
			bunifuFlatButton3.Activecolor = Color.FromArgb(23, 27, 35);
			bunifuFlatButton3.BackColor = Color.FromArgb(23, 27, 35);
			bunifuFlatButton3.BackgroundImageLayout = ImageLayout.Stretch;
			bunifuFlatButton3.BorderRadius = 0;
			bunifuFlatButton3.ButtonText = "Scan";
			bunifuFlatButton3.Cursor = Cursors.Hand;
			bunifuFlatButton3.Iconcolor = Color.Transparent;
//			bunifuFlatButton3.Iconimage = Resources._null;
			bunifuFlatButton3.Iconimage_right = null;
			bunifuFlatButton3.Iconimage_right_Selected = null;
			bunifuFlatButton3.Iconimage_Selected = null;
			bunifuFlatButton3.IconZoom = 470.0;
			bunifuFlatButton3.IsTab = false;
			bunifuFlatButton3.Location = new Point(397, 97);
			bunifuFlatButton3.Name = "bunifuFlatButton3";
			bunifuFlatButton3.Normalcolor = Color.FromArgb(23, 27, 35);
			bunifuFlatButton3.OnHovercolor = Color.FromArgb(23, 27, 35);
			bunifuFlatButton3.OnHoverTextColor = Color.White;
			bunifuFlatButton3.selected = false;
			bunifuFlatButton3.Size = new Size(285, 29);
			bunifuFlatButton3.TabIndex = 71;
			bunifuFlatButton3.Textcolor = Color.White;
			bunifuFlatButton3.TextFont = new Font("Microsoft Sans Serif", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 0);
			bunifuFlatButton3.Click += bunifuFlatButton3_Click;
			pictureBox1.Location = new Point(504, 322);
			pictureBox1.Name = "pictureBox1";
			pictureBox1.Size = new Size(58, 58);
			pictureBox1.TabIndex = 72;
			pictureBox1.TabStop = false;
			base.AutoScaleDimensions = new SizeF(6f, 13f);
			base.AutoScaleMode = AutoScaleMode.Font;
			BackColor = Color.White;
			base.ClientSize = new Size(710, 426);
			base.Controls.Add(pictureBox1);
			base.Controls.Add(bunifuFlatButton3);
			base.Controls.Add(bunifuCustomLabel3);
			base.Controls.Add(bunifuCustomLabel2);
			base.Controls.Add(bunifuFlatButton1);
			base.Controls.Add(bunifuCustomLabel1);
			base.Controls.Add(bunifuCustomTextbox1);
			base.Controls.Add(bunifuCustomLabel5);
			base.Controls.Add(bunifuFlatButton2);
			base.Controls.Add(bunifuTextbox2);
			base.Controls.Add(listView1);
			base.FormBorderStyle = FormBorderStyle.None;
			base.Name = "ScannerFrm";
			Text = "ScannerFrm";
			base.Load += ScannerFrm_Load;
			((ISupportInitialize)pictureBox1).EndInit();
			base.ResumeLayout(false);
			base.PerformLayout();
		}
	}
}
