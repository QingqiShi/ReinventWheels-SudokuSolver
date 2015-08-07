using System;

using System.Diagnostics;

namespace SudokuSolver
{
	class Program
	{
		static void Main(string[] args)
		{
			// Initialise board
			Board b = new Board();
			b.set(new int[,] {
				{ 0,1,4, 2,0,0, 0,9,0},
				{ 0,2,0, 0,0,0, 0,0,3},
				{ 0,6,5, 0,8,0, 0,4,0},

				{ 0,0,8, 0,3,0, 0,0,0},
				{ 2,0,0, 5,0,7, 0,0,8},
				{ 0,0,0, 0,4,0, 6,0,0},

				{ 0,8,0, 0,2,0, 1,6,0},
				{ 4,0,0, 0,0,0, 0,5,0},
				{ 0,7,0, 0,0,5, 9,8,0} });
			//b.set(new int[,] {
			//    { 0,0,0, 0,0,0, 0,0,0},
			//    { 0,0,0, 0,0,0, 0,0,0},
			//    { 0,0,0, 0,0,0, 0,0,0},

			//    { 0,0,0, 0,0,0, 0,0,0},
			//    { 0,0,0, 0,0,0, 0,0,0},
			//    { 0,0,0, 0,0,0, 0,0,0},

			//    { 0,0,0, 0,0,0, 0,0,0},
			//    { 0,0,0, 0,0,0, 0,0,0},
			//    { 0,0,0, 0,0,0, 0,0,0} });
			//b.set(new int[,]
			//{
			//    { 0,6,1, 2,0,8, 3,0,9},
			//    { 0,0,0, 0,0,1, 4,0,2},
			//    { 0,0,2, 0,0,0, 6,0,0},

			//    { 6,2,0, 0,5,3, 0,0,4},
			//    { 5,0,0, 0,8,0, 0,0,6},
			//    { 1,0,0, 6,2,0, 0,7,3},

			//    { 0,0,4, 0,0,0, 7,0,0},
			//    { 8,0,6, 3,0,0, 0,0,0},
			//    { 3,0,5, 7,0,2, 9,6,0}
			//});


			// Ask user for input
			string input = "";
			int x = 0, y = 0, value = 0;
			string[] split;

			while (true)
			{
				Console.WriteLine("Enter data in the format [x y value], or enter 0 to solve: ");
				input = Console.ReadLine();

				split = input.Split(' ');
				if (split.Length == 3)
				{
					x = Int32.Parse(split[0]);
					y = Int32.Parse(split[1]);
					value = Int32.Parse(split[2]);

					b.set(x, y, value);
				} else if (input == "0")
				{
					break;
				}
			}

			// Attempt to solve sudoku
			Solver s = new Solver(b.copy());

			Stopwatch watch = new Stopwatch();

			watch.Start();
			Board result = s.solve();
			watch.Stop();

			// Check complete
			if (result == null || !result.checkComplete())
			{
				Console.WriteLine(":( Unable to solve.");
			}
			else
			{
				Console.Clear();
				b.render();
				Console.WriteLine("Solved! Time used " + watch.Elapsed.TotalMilliseconds + "ms. Here it is: ");
				result.render();
			}
		}
	}
}
