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
			int[] zonesLimits = new int[] { 0, 0, 0, 3, 3, 3, 6, 6, 6 };

			for (int i = zonesLimits[x]; i < zonesLimits[x] + 3; i++)
			{
				for (int j = zonesLimits[y]; j < zonesLimits[y] + 3; j++)
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
