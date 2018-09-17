using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Othello
{
	class Engine
	{

		/// <summary>初期持ち時間</summary>
		private readonly int lifeTime;
		/// <summary>ログファイル出力フラグ</summary>
		private readonly bool log;

		private MainForm mainForm;

		/// <summary>プロセス管理</summary>
		private PlayerProcess player01 = new PlayerProcess();
		private PlayerProcess player02 = new PlayerProcess();

		/// <summary>リプレイ用のログ</summary>
		private string replayLog = string.Empty;

		public Engine(PlayerProcess player01, PlayerProcess player02, int lifeTime, bool log, MainForm mainForm)
		{
			this.player01 = player01;
			this.player02 = player02;

			this.lifeTime = lifeTime;
			this.log = log;

			this.mainForm = mainForm;

		}

		public async Task<char> GameTaskAsync(CancellationToken token)
		{
			if (token.IsCancellationRequested)
			{
				return Config.Draw;
			}

			string size = Config.Size.ToString();
			string time = lifeTime.ToString();

			bool check = true;

			check &= InitProcess();

			player01.name = await ReadlineAsync(player01);
			player02.name = await ReadlineAsync(player02);

			check &= CheckPlayerName();

			char result = Config.Draw;

			if (check)
			{
				Writeline(player01, size);
				Writeline(player01, time);
				Writeline(player01, Config.Black.ToString());

				Writeline(player02, size);
				Writeline(player02, time);
				Writeline(player02, Config.White.ToString());

				Stopwatch player01Timer = new Stopwatch();
				Stopwatch player02Timer = new Stopwatch();

				GameEngine gameEngine = new GameEngine();

				while (true)
				{
					if (token.IsCancellationRequested)
					{
						result = Config.Draw;
						break;
					}

					var nextPlayer = gameEngine.NextColor;
					var nextTable = gameEngine.NextTable;

					string command;
					if (nextPlayer == Config.Black)
					{
						player01Timer.Start();

						//入力
						Writeline(player01, player01Timer.ElapsedMilliseconds.ToString());
						foreach (var str in nextTable)
						{
							Writeline(player01, str);
						}
						Writeline(player01, Config.End);

						//出力
						command = await ReadlineAsync(player01);

						player01Timer.Stop();

						if (player01Timer.ElapsedMilliseconds > lifeTime)
						{
							result = Config.White;
							break;
						}

					}
					else if (nextPlayer == Config.White)
					{
						player02Timer.Start();

						//入力
						Writeline(player02, player02Timer.ElapsedMilliseconds.ToString());
						foreach (var str in nextTable)
						{
							Writeline(player02, str);
						}
						Writeline(player02, Config.End);

						//出力
						command = await ReadlineAsync(player02);

						player02Timer.Stop();

						if (player02Timer.ElapsedMilliseconds > lifeTime)
						{
							result = Config.Black;
							break;
						}
					}
					else
					{
						result = gameEngine.Winner;
						break;
					}

					if (gameEngine.CheckPosition(command, nextPlayer))
					{
						gameEngine.Put(command, nextPlayer);
					}
					else
					{
						if (nextPlayer == Config.Black)
						{
							result = Config.White;
							break;
						}
						else if (nextPlayer == Config.White)
						{
							result = Config.Black;
							break;
						}
					}


				}

				FileWrite();
			}

			return result;
		}

		private bool InitProcess()
		{
			player01.startInfo.UseShellExecute = false;
			player01.startInfo.CreateNoWindow = true;
			player01.startInfo.RedirectStandardInput = true;
			player01.startInfo.RedirectStandardOutput = true;
			player01.startInfo.RedirectStandardError = true;

			player02.startInfo.UseShellExecute = false;
			player02.startInfo.CreateNoWindow = true;
			player02.startInfo.RedirectStandardInput = true;
			player02.startInfo.RedirectStandardOutput = true;
			player02.startInfo.RedirectStandardError = true;

			try
			{
				player01.process = Process.Start(player01.startInfo);
			}
			catch (Exception e)
			{
				LogWriteLine(mainForm.textGameLog, "起動に失敗しました:" + e.ToString());
				return false;
			}

			try
			{
				player02.process = Process.Start(player02.startInfo);
			}
			catch (Exception e)
			{
				LogWriteLine(mainForm.textGameLog, "起動に失敗しました:" + e.ToString());
				return false;
			}

			player01.process.ErrorDataReceived += (object sender, DataReceivedEventArgs e) =>
			{
				if (!string.IsNullOrEmpty(e.Data)) LogWriteLine(player01.cerr, e.Data);
			};
			player02.process.ErrorDataReceived += (object sender, DataReceivedEventArgs e) =>
			{
				if (!string.IsNullOrEmpty(e.Data)) LogWriteLine(player02.cerr, e.Data);
			};

			player01.process.BeginErrorReadLine();
			player02.process.BeginErrorReadLine();

			return true;
		}

		public void Close()
		{
			if (player01.process != null)
			{
				if (!player01.process.HasExited)
				{
					player01.process.Kill();
					player01.process.WaitForExit(3000);
				}
				player01.process.Dispose();
			}

			if (player02.process != null)
			{
				if (!player02.process.HasExited)
				{
					player02.process.Kill();
					player02.process.WaitForExit(3000);
				}
				player02.process.Dispose();
			}
		}

		private void FileWrite()
		{
			DateTime dt = DateTime.Now;
			string fileDate = dt.ToString("yyyyMMddHHmmss");

			string directoryPath = Config.LogDirectory + "/" + fileDate;
			Directory.CreateDirectory(directoryPath);

			string replayFileName = directoryPath + "/" + "replay_" + player01.name + "_" + player02.name + Config.FileExtension;
			File.WriteAllText(replayFileName, replayLog);

			if (log)
			{
				string cinFileName = directoryPath + "/";
				File.WriteAllText(cinFileName + "1_in_" + player01.name + Config.FileExtension, GetLogText(player01.cin));
				File.WriteAllText(cinFileName + "2_in_" + player02.name + Config.FileExtension, GetLogText(player02.cin));

				string coutFileName = directoryPath + "/";
				File.WriteAllText(coutFileName + "1_out_" + player01.name + Config.FileExtension, GetLogText(player01.cout));
				File.WriteAllText(coutFileName + "2_out_" + player02.name + Config.FileExtension, GetLogText(player02.cout));

				string cerrFileName = directoryPath + "/";
				File.WriteAllText(cerrFileName + "1_err_" + player01.name + Config.FileExtension, GetLogText(player01.cerr));
				File.WriteAllText(cerrFileName + "2_err_" + player02.name + Config.FileExtension, GetLogText(player02.cerr));
			}
		}

		private bool CheckPlayerName()
		{
			char[] invalidChars = Path.GetInvalidFileNameChars();

			if (player01.name.IndexOfAny(invalidChars) >= 0)
			{
				LogWriteLine(mainForm.textGameLog, "無効なユーザ名です:" + player01.name);
				return false;
			}
			if (player02.name.IndexOfAny(invalidChars) >= 0)
			{
				LogWriteLine(mainForm.textGameLog, "無効なユーザ名です:" + player02.name);
				return false;
			}

			return true;
		}

		private void Writeline(PlayerProcess player, string str)
		{
			player.process.StandardInput.WriteLine(str);
			player.process.StandardInput.Flush();
			LogWriteLine(player.cin, str);
		}
		private async Task<string> ReadlineAsync(PlayerProcess player)
		{
			string cout = await player.process.StandardOutput.ReadLineAsync();
			LogWriteLine(player.cout, cout);

			return cout;
		}
		private async Task<string> ReadErrlineAsync(PlayerProcess player)
		{
			string cerr = await player.process.StandardError.ReadLineAsync();
			LogWriteLine(player.cerr, cerr);

			return cerr;
		}

		private void LogWriteLine(TextBox textbox, string str)
		{
			mainForm.Invoke(new Action<TextBox, string>((control, text) =>
			{
				control.AppendText(text + Environment.NewLine);
				control.Refresh();
			}), new object[] { textbox, str });
		}
		private void LogWrite(TextBox textbox, string str)
		{
			mainForm.Invoke(new Action<TextBox, string>((control, text) =>
			{
				control.AppendText(text);
				control.Refresh();
			}), new object[] { textbox, str });
		}

		private string GetLogText(TextBox textbox)
		{
			string text = (string)mainForm.Invoke(new Func<TextBox, string>((control) =>
			   {
				   return (string)control.Text.Clone();
			   }), textbox);

			return text;
		}


	}
}
