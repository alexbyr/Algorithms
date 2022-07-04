using System;
using System.Collections;

namespace Algorytms
{
    public static class ArraysAndStrings
    {

        /// <summary>
        /// Rotate array on 90 degree
        /// </summary>
        /// <param name="image"></param>
        /// <returns></returns>
        public static void task_1_7(int[,] image)
        {
			int n = image.GetLength(0);
			for (int i = 0; i < n / 2; i++)///
			{
				int last = n - i - 1;
				for(int j = i; j < last; j++)
                {
					int top = image[i,j];

					//first elemnt change to bottom left
					image[i, j] = image[last - (j - i), i];

					//bottom left
					image[last - (j - i), i] = image[last,last - (j - i)];

					//botom right
					image[last, last - (j - i)] = image[j,last];

					//top right
					image[j,last] = top;
                }

				Console.WriteLine("\n");
			}
        }

        public static void Task_1_7_PrintArray(int[,] array)
        {
			for(int i=0;i<array.GetLength(0);i++)
            {
				for (int j = 0; j < array.GetLength(1); j++)
					Console.Write(array[i, j].ToString() + "\t");
				Console.WriteLine("\n");
            }
        }

		/// <summary>
		/// находится ли строка на растоянии 1ой модификации или нуля от заданной
		//	вставка удаление замена
		/// </summary>
		/// <param name="str1"></param>
		/// <param name="str2"></param>
		/// <returns></returns>
		public static bool Task_1_5(string str1, string str2)
		{
			if (Math.Abs(str1.Length - str2.Length) > 1)
				return false;
			else if ((str1.Length - str2.Length) == 1)
				//check if deleting 1 symbol equlise two string
				return Task_1_5_EquilIfDelete(str1, str2);
			else if ((str2.Length - str1.Length) == 1)
				return Task_1_5_EquilIfDelete(str2, str1);
			else //check if modifying helo the situation
			{
				bool isNotEqualOnce = false;
				for (int i = 0; i < str1.Length; i++)
				{
					if (str1[i] != str2[i])
					{
						if (isNotEqualOnce)
							return false;
						isNotEqualOnce = true;
					}
				}

				return true;
			}
		}

		static bool Task_1_5_EquilIfDelete(string str1, string str2)
		{
			for (int i = 0; i < str1.Length; i++)
			{
				if (str1.Remove(i, 1) == str2)
					return true;
			}
			return false;
		}

		public static string Task_1_3(string inputString)
		{
			return inputString.Replace(" ", "%20");
		}


		public static bool Task_1_2(string str1, string str2)
		{
			int[] charCounter = new int[128];

			foreach (char ch in str1)
				charCounter[(int)ch]++;

			foreach (char ch in str2)
			{
				charCounter[(int)ch]--;
				if (charCounter[(int)ch] < 0)
					return false;
			}

			return true;
		}


		/// <summary>
		/// Алгоритм определяющий все ли символы в строке втсречаються один раз
		/// </summary>
		/// <param name="inputString"></param>
		/// <returns></returns>
		public static bool Task_1_1_1(string inputString)
		{
			ArrayList strController = new ArrayList();

			foreach (char ch in inputString)
			{
				Console.WriteLine(((int)ch).ToString());
				if (strController.Contains(ch)) return false;
				else strController.Add(ch);
			}

			return true;
		}

		/// <summary>
		/// Задание такое же как и в 1 1 1 только не использовать дополнительные структуры.
		///	ограничение - используютьь только символы a-z
		/// </summary>
		/// <param name="inputString"></param>
		/// <returns></returns>
		public static bool Task_1_1_2(string inputString)
		{
			int flagsKeeper = 0;
			foreach (char ch in inputString)
			{
				int checkVal = 1 << ((int)ch) - ((int)'a');

				//check if it presents
				if ((flagsKeeper & checkVal) != 0)
					return false;
				flagsKeeper |= checkVal;
			}
			return true;
		}
	}
}

