using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Othello
{
	public partial class MainForm : Form
	{
		private CancellationTokenSource _tokenSource = null;

		public MainForm()
		{
			InitializeComponent();
		}

		private void buttonExePath01_Click(object sender, EventArgs e)
		{
			if (openFileDialog.ShowDialog() == DialogResult.OK)
			{
				textExePath01.Text = openFileDialog.FileName;
			}
		}

		private void buttonExePath02_Click(object sender, EventArgs e)
		{
			if (openFileDialog.ShowDialog() == DialogResult.OK)
			{
				textExePath02.Text = openFileDialog.FileName;
			}
		}

		private async void buttonStart_ClickAsync(object sender, EventArgs e)
		{
			buttonStart.Enabled = false;
			buttonStop.Enabled = true;

			textExePath01.Enabled = false;
			textExePath02.Enabled = false;
			buttonExePath01.Enabled = false;
			buttonExePath02.Enabled = false;

			numericBattleCount.Enabled = false;
			textLifetime.Enabled = false;
			checkLogOutput.Enabled = false;

			//非同期で起動する

			decimal battleCount = numericBattleCount.Value;

			textGameLog.Text = string.Empty;

			if (int.TryParse(textLifetime.Text, out int lifeTime))
			{
				string exePath01 = textExePath01.Text;
				string exePath02 = textExePath02.Text;

				bool log = checkLogOutput.Checked;

				textGameLog.Text += "ゲーム開始" + Environment.NewLine;

				if (_tokenSource == null) _tokenSource = new CancellationTokenSource();
				var token = _tokenSource.Token;

				for (int i = 0; i < battleCount; i++)
				{

					GameEngine engine;

					//偶奇回数目の対戦で白黒を入れ替える
					if (i % 2 == 0)
					{
						engine = new GameEngine(exePath01, exePath02, lifeTime, log);

						engine.mainForm = this;
						engine.player01Cin = textPlayer01Cin;
						engine.player01Cout = textPlayer01Cout;
						engine.player01Cerr = textPlayer01Cerr;
						engine.player02Cin = textPlayer02Cin;
						engine.player02Cout = textPlayer02Cout;
						engine.player02Cerr = textPlayer02Cerr;
					}
					else
					{
						engine = new GameEngine(exePath02, exePath01, lifeTime, log);

						engine.mainForm = this;
						engine.player02Cin = textPlayer01Cin;
						engine.player02Cout = textPlayer01Cout;
						engine.player02Cerr = textPlayer01Cerr;
						engine.player01Cin = textPlayer02Cin;
						engine.player01Cout = textPlayer02Cout;
						engine.player01Cerr = textPlayer02Cerr;
					}


					string result = await engine.GameTaskAsync(token);

					textGameLog.Text += result + Environment.NewLine;
				}
			}
			else
			{
				textGameLog.Text = "持ち時間の値が異常です";
			}

			//実行完了後
			buttonStart.Enabled = true;
			buttonStop.Enabled = false;

			textExePath01.Enabled = true;
			textExePath02.Enabled = true;
			buttonExePath01.Enabled = true;
			buttonExePath02.Enabled = true;

			numericBattleCount.Enabled = true;
			textLifetime.Enabled = true;
			checkLogOutput.Enabled = true;
		}

		private void buttonStop_Click(object sender, EventArgs e)
		{
			buttonStart.Enabled = true;
			buttonStop.Enabled = false;

			textExePath01.Enabled = true;
			textExePath02.Enabled = true;
			buttonExePath01.Enabled = true;
			buttonExePath02.Enabled = true;

			numericBattleCount.Enabled = true;
			textLifetime.Enabled = true;
			checkLogOutput.Enabled = true;


		}

		private void MainForm_Load(object sender, EventArgs e)
		{
			textExePath01.Text = Properties.Settings.Default.Player01;
			textExePath02.Text = Properties.Settings.Default.Player02;

			numericBattleCount.Value = Properties.Settings.Default.BattleCount;
			textLifetime.Text = Properties.Settings.Default.Lifetime.ToString();

			checkLogOutput.Checked = Properties.Settings.Default.Log;

		}

		private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
		{
			Properties.Settings.Default.Player01 = textExePath01.Text;
			Properties.Settings.Default.Player02 = textExePath02.Text;

			Properties.Settings.Default.BattleCount = numericBattleCount.Value;

			if (int.TryParse(textLifetime.Text, out int lifetime))
			{
				Properties.Settings.Default.Lifetime = lifetime;
			}

			Properties.Settings.Default.Log = checkLogOutput.Checked;

			Properties.Settings.Default.Save();

		}

	}
}
