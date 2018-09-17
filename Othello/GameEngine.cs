using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Othello
{
	class GameEngine
	{

		private char[,] table = new char[Config.Size, Config.Size];
		private bool[,] blackPutTable = new bool[Config.Size, Config.Size];
		private bool[,] whitePutTable = new bool[Config.Size, Config.Size];

		private char nextColor = Config.Black;
		private char winner;
		private string result;

		public GameEngine()
		{
			for (int y = 0; y < Config.Size; y++)
			{
				for (int x = 0; x < Config.Size; x++)
				{
					table[y, x] = Cell.Empty;
				}
			}

			table[Config.Size / 2 - 0, Config.Size / 2 - 0] = Cell.White;
			table[Config.Size / 2 - 1, Config.Size / 2 - 0] = Cell.Black;
			table[Config.Size / 2 - 0, Config.Size / 2 - 1] = Cell.Black;
			table[Config.Size / 2 - 1, Config.Size / 2 - 1] = Cell.White;

			CreatePutTable(blackPutTable, Config.Black);
		}

		public bool CheckPosition(string command, char color)
		{
			string[] coms = command.Split(' ');

			Point point = new Point();

			if (coms.Length == 2)
			{
				if (int.TryParse(coms[0], out int x))
				{
					if (int.TryParse(coms[1], out int y))
					{
						point.X = x;
						point.Y = y;
						return CheckPosition(point, color);
					}
				}
			}

			return false;
		}
		private bool CheckPosition(Point pos, char color)
		{
			if (color == Config.Black)
			{
				return blackPutTable[pos.Y, pos.X];
			}
			else if (color == Config.White)
			{
				return whitePutTable[pos.Y, pos.X];
			}

			return false;
		}

		public char NextColor
		{
			get { return nextColor; }
		}
		public string[] NextTable
		{
			get
			{
				string[] lines = new string[Config.Size];

				for (int y = 0; y < Config.Size; y++)
				{
					lines[y] = string.Empty;
					for (int x = 0; x < Config.Size; x++)
					{
						lines[y] += table[y, x];
					}
				}

				return lines;
			}
		}

		public string Result
		{
			get { return result; }
		}
		public char Winner
		{
			get { return winner; }
		}

		public void Put(string command, char color)
		{
			string[] coms = command.Split(' ');

			Point point = new Point();

			if (coms.Length == 2)
			{
				if (int.TryParse(coms[0], out int x))
				{
					if (int.TryParse(coms[1], out int y))
					{
						point.X = x;
						point.Y = y;
						Put(point, color);
					}
				}
			}
		}
		private void Put(Point pos, char color)
		{

			Reverse(pos, color);
			Update();

		}
		
		private void Update()
		{
			nextColor = ReverseColor(nextColor);

			bool pass = false;

			if (nextColor == Config.Black)
			{
				pass = !CreatePutTable(blackPutTable, nextColor);
			}
			else if (nextColor == Config.White)
			{
				pass = !CreatePutTable(whitePutTable, nextColor);
			}
			if (!pass) return;

			nextColor = ReverseColor(nextColor);

			pass = false;
			if (nextColor == Config.Black)
			{
				pass = !CreatePutTable(blackPutTable, nextColor);
			}
			else if (nextColor == Config.White)
			{
				pass = !CreatePutTable(whitePutTable, nextColor);
			}
			if (!pass) return;

			nextColor = Config.Draw;

			int blackCount = 0;
			int whiteCount = 0;
			for (int y = 0; y < Config.Size; y++)
			{
				for (int x = 0; x < Config.Size; x++)
				{
					if (table[y, x] == Config.Black) blackCount++;
					else if (table[y, x] == Config.White) whiteCount++;
				}
			}

			if (blackCount > whiteCount) winner = Config.Black;
			else if (blackCount < whiteCount) winner = Config.White;
			else winner = Config.Draw;

			result = blackCount.ToString() + " " + whiteCount.ToString();

		}

		private void Reverse(Point pos, char color)
		{
			int[] dx = new int[8] { -1, 0, 1, -1, 1, -1, 0, 1 };
			int[] dy = new int[8] { -1, -1, -1, 0, 0, 1, 1, 1 };

			char rColor = ReverseColor(color);

			for (int d = 0; d < 8; d++)
			{
				int x = pos.X + dx[d];
				int y = pos.Y + dy[d];

				if (Inside(x, y))
				{
					if (table[y, x] == rColor)
					{
						for (int i = 1; i < Config.Size; i++)
						{
							x += dx[d];
							y += dy[d];
							if (Inside(x, y))
							{
								if (table[y, x] == Cell.Empty) break;
								if (table[y, x] == color)
								{
									int rx = pos.X;
									int ry = pos.Y;
									for (int j = 0; j <= i; j++)
									{
										table[ry, rx] = color;
										rx += dx[d];
										ry += dy[d];
									}
									break;
								}
							}
							else
							{
								break;
							}
						}
					}
				}
			}
		}
		private bool IsReverse(Point pos, char color)
		{
			int[] dx = new int[8] { -1, 0, 1, -1, 1, -1, 0, 1 };
			int[] dy = new int[8] { -1, -1, -1, 0, 0, 1, 1, 1 };

			char rColor = ReverseColor(color);

			if (table[pos.Y, pos.X] != Cell.Empty) return false;

			for (int d = 0; d < 8; d++)
			{
				int x = pos.X + dx[d];
				int y = pos.Y + dy[d];

				if (Inside(x, y))
				{
					if (table[y, x] == rColor)
					{
						for (int i = 1; i < Config.Size; i++)
						{
							x += dx[d];
							y += dy[d];
							if (Inside(x, y))
							{
								if (table[y, x] == Cell.Empty) break;
								if (table[y, x] == color) return true;
							}
							else
							{
								break;
							}
						}
					}
				}
			}

			return false;
		}

		private bool CreatePutTable(bool[,] table, char color)
		{
			bool isPut = false;
			for (int y = 0; y < Config.Size; y++)
			{
				for (int x = 0; x < Config.Size; x++)
				{
					table[y, x] = IsReverse(new Point(x, y), color);
					isPut |= table[y, x];
				}
			}

			return isPut;
		}

		private bool Inside(int x, int y)
		{
			return (Inside(x) && Inside(y));
		}
		private bool Inside(int x)
		{
			return (0 <= x && x < Config.Size);
		}
		private char ReverseColor(char color)
		{
			if (color == Config.Black) return Config.White;
			if (color == Config.White) return Config.Black;
			return Config.Draw;
		}

		static class Cell
		{
			public static char Empty = '-';
			public static char Black = Config.Black;
			public static char White = Config.White;
		}

	}
}
