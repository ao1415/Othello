using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Othello
{
	public partial class ReplayForm : Form
	{

		private class Data
		{
			public char turn = Config.Draw;
			public Point pos = new Point(-1, -1);
			public char[,] table = new char[Config.Size, Config.Size];
			public string blackTimer = "TimeOver";
			public int blackCount = 0;
			public string whiteTimer = "TimeOver";
			public int whiteCount = 0;

		}

		List<Data> replayDatas = new List<Data>();
		private string name01;
		private string name02;
		int gameTurn = 0;

		private Image image;
		private Font font;
		public ReplayForm(string filename)
		{
			InitializeComponent();

			Text = Path.GetFileName(filename);

			MakeReplayData(filename);

			image = new Bitmap(pictureBox1.Size.Width, pictureBox1.Size.Height);
			font = new Font("メイリオ", 16);
			Draw();
			pictureBox1.Image = image;
		}

		private void MakeReplayData(string filename)
		{
			string[] replayFileLines = File.ReadAllLines(filename);

			name01 = replayFileLines[0];
			name02 = replayFileLines[1];
			string LifeTime = replayFileLines[2];

			GameEngine gameEngine = new GameEngine();

			int turn = 3;
			char result = Config.Draw;
			while (true)
			{
				var nextPlayer = gameEngine.NextColor;
				var nextTable = gameEngine.NextTable;

				if (nextPlayer == Config.Draw)
				{
					result = gameEngine.Winner;
					break;
				}

				var coms = replayFileLines[turn].Split(' ');
				turn++;

				string command = coms[0] + " " + coms[1];

				Data data = new Data();

				data.turn = nextPlayer;
				data.table = (char[,])gameEngine.NextTableChar.Clone();

				int blackCount = 0;
				int whiteCount = 0;
				for (int y = 0; y < Config.Size; y++)
				{
					for (int x = 0; x < Config.Size; x++)
					{
						if (data.table[y, x] == Config.Black) blackCount++;
						else if (data.table[y, x] == Config.White) whiteCount++;
					}
				}

				data.pos.X = int.Parse(coms[0]);
				data.pos.Y = int.Parse(coms[1]);
				data.blackCount = blackCount;
				data.whiteCount = whiteCount;

				int time = int.Parse(coms[2]);
				if (nextPlayer == Config.Black)
				{
					data.blackTimer = coms[2];

					if (replayDatas.Count == 0) data.whiteTimer = LifeTime;
					else data.whiteTimer = replayDatas.Last().whiteTimer;

					if (time < 0)
					{
						result = Config.White;
						break;
					}
				}
				else if (nextPlayer == Config.White)
				{
					data.whiteTimer = coms[2];
					data.blackTimer = replayDatas.Last().blackTimer;

					if (time < 0)
					{
						result = Config.Black;
						break;
					}
				}

				replayDatas.Add(data);
				
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

			Data endData = new Data();
			endData.table = gameEngine.NextTableChar;

			int endBlackCount = 0;
			int endWhiteCount = 0;
			for (int y = 0; y < Config.Size; y++)
			{
				for (int x = 0; x < Config.Size; x++)
				{
					if (endData.table[y, x] == Config.Black) endBlackCount++;
					else if (endData.table[y, x] == Config.White) endWhiteCount++;
				}
			}

			endData.blackCount = endBlackCount;
			endData.whiteCount = endWhiteCount;

			endData.blackTimer = replayDatas.Last().blackTimer;
			endData.whiteTimer = replayDatas.Last().whiteTimer;

			replayDatas.Add(endData);

		}

		private void Draw()
		{

			int CellSize = 48;
			int CursorSize = 12;
			int TableWidth = CellSize * Config.Size + 1;

			using (Graphics g = Graphics.FromImage(image))
			{
				g.FillRectangle(Brushes.LightGreen, new Rectangle(0, 0, CellSize * Config.Size + 1, CellSize * Config.Size + 1));
				g.DrawRectangle(Pens.Black, new Rectangle(0, 0, CellSize * Config.Size + 1, CellSize * Config.Size + 1));


				if (gameTurn - 1 >= 0)
				{
					int px = replayDatas[gameTurn - 1].pos.X * CellSize;
					int py = replayDatas[gameTurn - 1].pos.Y * CellSize;
					g.FillPolygon(Brushes.Red, new Point[] { new Point(px, py), new Point(px + CursorSize, py), new Point(px, py + CursorSize) });
					g.FillPolygon(Brushes.Red, new Point[] { new Point(px + CellSize, py), new Point(px + CellSize - CursorSize, py), new Point(px + CellSize, py + CursorSize) });
					g.FillPolygon(Brushes.Red, new Point[] { new Point(px, py + CellSize), new Point(px + CursorSize, py + CellSize), new Point(px, py + CellSize - CursorSize) });
					g.FillPolygon(Brushes.Red, new Point[] { new Point(px + CellSize, py + CellSize), new Point(px + CellSize - CursorSize, py + CellSize), new Point(px + CellSize, py + CellSize - CursorSize) });
				}

				for (int y = 0; y < Config.Size; y++)
				{
					for (int x = 0; x < Config.Size; x++)
					{
						int px = x * CellSize;
						int py = y * CellSize;

						g.DrawLine(Pens.Black, px, py, px + CellSize, py);
						g.DrawLine(Pens.Black, px, py, px, py + CellSize);

						if (replayDatas[gameTurn].table[y, x] == Config.Black)
						{
							g.FillPie(Brushes.Black, new Rectangle(px + 2, py + 2, CellSize - 4, CellSize - 4), 0, 360);
						}
						else if (replayDatas[gameTurn].table[y, x] == Config.White)
						{
							g.FillPie(Brushes.White, new Rectangle(px + 2, py + 2, CellSize - 4, CellSize - 4), 0, 360);
						}

					}
				}

				var colorArea = new Rectangle(TableWidth, 0, pictureBox1.Width - TableWidth - 1, 48);
				g.FillRectangle(Brushes.White, colorArea);
				g.DrawRectangle(Pens.Black, colorArea);

				string nextColorStr = "次の色：";

				if (replayDatas[gameTurn].turn == Config.Black) nextColorStr += "黒";
				else if (replayDatas[gameTurn].turn == Config.White) nextColorStr += "白";

				g.DrawString(nextColorStr, font, Brushes.Black, colorArea.Location.X + 8, colorArea.Location.Y + 10);

				string blackCountStr = "石数：" + replayDatas[gameTurn].blackCount.ToString();
				string blackTimerStr = "時間：" + replayDatas[gameTurn].blackTimer;

				string whiteCountStr = "石数：" + replayDatas[gameTurn].whiteCount.ToString();
				string whiteTimerStr = "時間：" + replayDatas[gameTurn].whiteTimer;

				var blackArea = new Rectangle(TableWidth, pictureBox1.Height - 96 * 2 - 2, pictureBox1.Width - TableWidth - 1, 96);
				g.FillRectangle(Brushes.White, blackArea);
				g.DrawRectangle(Pens.Black, blackArea);

				g.DrawString(name01, font, Brushes.Black, blackArea.Location.X + 8, blackArea.Location.Y + 6);
				g.DrawString(blackCountStr, font, Brushes.Black, blackArea.Location.X + 8, blackArea.Location.Y + 30);
				g.DrawString(blackTimerStr, font, Brushes.Black, blackArea.Location.X + 8, blackArea.Location.Y + 54);

				var whiteArea = new Rectangle(TableWidth, pictureBox1.Height - 96 * 1 - 2, pictureBox1.Width - TableWidth - 1, 97);
				g.FillRectangle(Brushes.White, whiteArea);
				g.DrawRectangle(Pens.Black, whiteArea);

				g.DrawString(name02, font, Brushes.Black, whiteArea.Location.X + 8, whiteArea.Location.Y + 6);
				g.DrawString(whiteCountStr, font, Brushes.Black, whiteArea.Location.X + 8, whiteArea.Location.Y + 28);
				g.DrawString(whiteTimerStr, font, Brushes.Black, whiteArea.Location.X + 8, whiteArea.Location.Y + 50);

			}

			pictureBox1.Refresh();

		}

		private void buttonFirst_Click(object sender, EventArgs e)
		{
			gameTurn = 0;
			Draw();
		}

		private void buttonBack_Click(object sender, EventArgs e)
		{
			gameTurn = Math.Max(0, gameTurn - 1);
			Draw();
		}

		private void buttonSop_Click(object sender, EventArgs e)
		{

		}

		private void buttonNext_Click(object sender, EventArgs e)
		{
			gameTurn = Math.Min(replayDatas.Count - 1, gameTurn + 1);
			Draw();
		}

		private void buttonLast_Click(object sender, EventArgs e)
		{
			gameTurn = replayDatas.Count - 1;
			Draw();
		}

		private void ReplayForm_Load(object sender, EventArgs e)
		{
			comboBoxSpeed.SelectedIndex = Properties.Settings.Default.Speed;
		}

		private void ReplayForm_FormClosing(object sender, FormClosingEventArgs e)
		{
			Properties.Settings.Default.Speed = comboBoxSpeed.SelectedIndex;

			Properties.Settings.Default.Save();
		}
	}
}
