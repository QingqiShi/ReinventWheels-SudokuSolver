using System;

namespace SudokuSolver
{
	class Board
	{
		int[,] board = new int[9, 9];

		public Board copy()
		{
			Board bd = new Board();
			bd.board = (int[,]) this.board.Clone();
			return bd;
		}

		public int get(int x, int y)
		{
			return board[x, y];
		}

		public int[,] getArray()
		{
			return board;
		}

		public void set(int x, int y, int val)
		{
			board[x, y] = val;
		}

		public void set(int[, ] arr)
		{
			board = (int[,]) arr.Clone();
		}

		public void render()
		{
			string temp = "";

			Console.WriteLine("    0 1 2   3 4 5   6 7 8");
			Console.WriteLine("   +------+-------+-------+");

			for (int i = 0; i < 9; i++)
			{
				Console.Write(" " + i + " |");
				for (int j = 0; j < 9; j++)
				{
					if (board[j, i] != 0)
					{
						temp = temp + board[j, i] + " ";
					} else
					{
						temp = temp + "  ";
					}
					if (j == 2 || j == 5)
					{
						temp += "| ";
					}
				}
				Console.WriteLine(temp + "|");
				temp = "";

				if (i == 2 || i == 5)
				{
					Console.WriteLine("   |------+-------+-------|");
				}
			}
			Console.WriteLine("   +------+-------+-------+");
		}

		public bool checkComplete()
		{
			for (int i = 0; i < 9; i++)
			{
				for (int j = 0; j < 9; j++)
				{
					if (board[i, j] == 0)
					{
						return false;
					}
				}
			}
			return true;
		}
	}
}
