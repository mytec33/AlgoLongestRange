using System;
using System.Collections.Generic;

namespace AlgoLongestRange
{
    class Program
    {
		static void Main(string[] args)
		{
			int[] test1 = { 1, 11, 3, 0, 15, 5, 2, 4, 10, 7, 12, 6 };
			int[] result = LargestRange(test1);

			Console.WriteLine($"Range: {result[0]}, {result[1]}");
		}

		public static int[] LargestRange(int[] array)
		{
			HashSet<int> numbers = new HashSet<int>();
			int lowRange;
			int highRange;
			int[] range = new int[2];

			if (array.Length == 1)
				return new int[] { array[0], array[0] };

			// Store the numbers we have in our array to compare
			// against our left right expansion tests
			foreach (int num in array)
			{
				numbers.Add(num);
			}

			foreach (int num in array)
			{
				lowRange = num;
				while (numbers.Contains(lowRange))
				{
					lowRange--;
				}
				lowRange++;

				highRange = num;
				while (numbers.Contains(highRange))
				{
					highRange++;
				}
				highRange--;

				if (((highRange - lowRange) + 1) > ((range[1] - range[0]) + 1))
				{
					range[0] = lowRange;
					range[1] = highRange;
				}
			}

			return new int[] { range[0], range[1] };
		}
	}
}
