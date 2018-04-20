using MajyxScannerLib;
using StaticCrypt4.Forms;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;

namespace StaticCrypt4.Utilies
{
	public static class Scan
	{
		public static string ScanResult = string.Empty;

		public static string RateResult = string.Empty;

		public static string[,] ResultScan = new string[2, 35];

		public static string errordata = string.Empty;

		public static bool IsFinish = false;

		public static string ScanURL = string.Empty;

		private static MajyxScan ms = new MajyxScan("6", "f73398929c9881afec1df41dfba5ac5970bf90ee");

		public static void Run(string path)
		{
			try
			{
				IsFinish = false;
				FrmClass.scfrm.listView1.Invoke((MethodInvoker)delegate
				{
					FrmClass.scfrm.listView1.Items.Clear();
				});
				Start(path);
				IsFinish = true;
			}
			catch (Exception ex)
			{
				MessageBox.Show("The scan Was Failed." + Environment.NewLine + "Reason : " + ex.ToString(), "Scan Error", MessageBoxButtons.OK, MessageBoxIcon.Hand);
			}
		}

		private static void Start(string path)
		{
			object obj = ms.SendRequest("submit/1", true, path);
			if (obj.ToString().Contains("success"))
			{
				obj = obj.ToString().Replace("{\"status\":\"success\",\"id\":\"", "").Replace("\"}", "");
				string text = ms.SendRequest("status/" + obj, false, "").ToString();
				int num = 0;
				while (true)
				{
					if (text.Contains("Clean"))
					{
						break;
					}
					if (text.Contains("Infected"))
					{
						break;
					}
					if (text.Contains("Failed"))
					{
						break;
					}
					Thread.Sleep(1000);
					num++;
					if (num == 600)
					{
						break;
					}
					text = ms.SendRequest("status/" + obj, false, "").ToString();
				}
				string text2 = ms.SendRequest("status/" + obj, false, "").ToString();
				if (MajyxScan.IsValid(text2))
				{
					while (true)
					{
						if (MajyxScan.Deserialize<MajyxRate>(text2).avcount == "35")
						{
							break;
						}
						Thread.Sleep(1000);
						text2 = ms.SendRequest("rate/" + obj, false, "").ToString();
					}
					string text3 = ms.SendRequest("details/" + obj, false, "").ToString();
					if (MajyxScan.IsValid(text3))
					{
						for (int i = 0; i < MajyxScan.Deserialize<List<MajyxDetails>>(text3).Count; i++)
						{
							MajyxDetails majyxDetails = MajyxScan.Deserialize<List<MajyxDetails>>(text3)[i];
							AddToLstV(majyxDetails.antivirus, majyxDetails.detection, i);
						}
						RateResult = MajyxScan.Deserialize<MajyxRate>(text2).detection + "/" + MajyxScan.Deserialize<MajyxRate>(text2).avcount;
					}
				}
			}
			ScanURL = "https://scan.majyx.net/scans/result/" + obj;
			FrmClass.scfrm.bunifuFlatButton3.Invoke((MethodInvoker)delegate
			{
				FrmClass.scfrm.bunifuFlatButton3.Enabled = true;
			});
			FrmClass.scfrm.bunifuFlatButton3.Invoke((MethodInvoker)delegate
			{
				FrmClass.scfrm.bunifuFlatButton3.Cursor = Cursors.Hand;
			});
			FrmClass.scfrm.bunifuFlatButton3.Invoke((MethodInvoker)delegate
			{
				FrmClass.scfrm.bunifuFlatButton2.Enabled = true;
			});
			FrmClass.scfrm.bunifuFlatButton3.Invoke((MethodInvoker)delegate
			{
				FrmClass.scfrm.bunifuFlatButton2.Cursor = Cursors.Hand;
			});
		}

		private static void AddToLstV(string av, string detect, int num)
		{
			ListViewItem lvi = new ListViewItem(av);
			lvi.SubItems.Add(detect);
			FrmClass.scfrm.listView1.Invoke((MethodInvoker)delegate
			{
				FrmClass.scfrm.listView1.Items.Add(lvi);
			});
			SetColor(num, detect);
		}

		private static void SetColor(int num, string result)
		{
			FrmClass.scfrm.listView1.Invoke((MethodInvoker)delegate
			{
				FrmClass.scfrm.listView1.Items[num].UseItemStyleForSubItems = false;
			});
			if (result == "File is clean")
			{
				FrmClass.scfrm.listView1.Invoke((MethodInvoker)delegate
				{
					FrmClass.scfrm.listView1.Items[num].ForeColor = Color.ForestGreen;
				});
				FrmClass.scfrm.listView1.Invoke((MethodInvoker)delegate
				{
					FrmClass.scfrm.listView1.Items[num].SubItems[1].ForeColor = Color.ForestGreen;
				});
			}
			else
			{
				FrmClass.scfrm.listView1.Invoke((MethodInvoker)delegate
				{
					FrmClass.scfrm.listView1.Items[num].ForeColor = Color.Red;
				});
				FrmClass.scfrm.listView1.Invoke((MethodInvoker)delegate
				{
					FrmClass.scfrm.listView1.Items[num].SubItems[1].ForeColor = Color.Red;
				});
			}
		}
	}
}
