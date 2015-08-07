using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SudokuSolver
{
	class Solver
	{
		Board b;

		public Solver(Board board)
		{
			b = board;
		}

		public Board solve()
		{
			return s(0, b);
		}

		Board s(int num, Board b)
		{

			if (num > 81 || b.checkComplete())
			{
				return b;
			} 

			for (int i = 0; i < 9; i++)
			{
				for (int j = 0; j < 9; j++)
				{
					if (b.get(i, j) == 0)
					{
						for (int n = 1; n < 10; n++)
						{
							if (!existInRow(b, j, n) && !existInCol(b, i, n) && !existInZone(b, i, j, n))
							{
								int[,] copy = (int[,])b.getArray().Clone();
								b.set(i, j, n);
								Board tmp = s(num + 1, b);
								if (tmp != null)
								{
									return tmp;
								} else
								{
									b.set(copy);
								}
							}
						}
						return null;
					}
				}
			}
			return b;
		}

		bool existInRow(Board b, int y, int val)
		{
			for (int i = 0; i < 9; i++)
			{
				if (b.get(i, y) == val)
				{
					return true;
				}
			}
			return false;
		}

		bool existInCol(Board b, int x, int val)
		{
			for (int i = 0; i < 9; i++)
			{
				if (b.get(x, i) == val)
				{
					return true;
				}
			}
			return false;
		}

		bool existInZone(Board b, int x, int y, int val)
		{
			int x1 = 6, y1 = 6, x2 = 8, y2 = 8;

			if (x >= 0 && x <= 2)
			{
				x1 = 0;
				x2 = 2;
			} else if (x >= 3 && x <= 5)
			{
				x1 = 3;
				x2 = 5;
			}

			if (y >= 0 && y <= 2)
			{
				y1 = 0;
				y2 = 2;
			} else if (y >= 3 && y <= 5)
			{
				y1 = 3;
				y2 = 5;
			}

			for (int i = x1; i <= x2; i++)
			{
				for (int j = y1; j <= y2; j++)
				{
					if (b.get(i, j) == val)
					{
						return true;
					}
				}
			}

			return false;
		}
	}
}
