using System;
using System.IO;

/*
 * По массиву A целых чисел со значениями из диапазона (1; 10000] создать массив целых чисел B,
 * в котором на каждой позиции стоит ближайшая степень двойки меньшая значения из массива A у той же позиции.
 * Например, A = {30, 100, 300} B = {16, 64, 256}.
 * Если хотя бы один из элементов массива А находится вне заданного диапазона - выводить Incorrect Input
 * в консоль. Гарантируется, что на вход подается N целых чисел.
 *
 * Пример входных данных:
 * 3 10 20
 *
 * Пример выходных данных:
 * 2 8 16
 */

namespace Task02
{
    class Program
    {
        private const string inputPath = "input.txt";
        private const string outputPath = "output.txt";
        
        static int[] ReadFile(string path)
        {
            string text = File.ReadAllText(path);
            string[] array = text.Split();
            int[] result = new int[array.Length];

            for (int elem = 0; elem < array.Length; ++elem)
                int.TryParse(array[elem], out result[elem]);

            return result;
        }
        
        static bool CheckArray(int[] array)
        {
            for (int elem = 0; elem < array.Length; ++elem)
                if (array[elem] <= 1 || array[elem] > 10000)
                    return false;

            return true;
        }
        
        static int[] ConvertArray(int[] array)
        {
            int[] result = new int[array.Length];
            for (int elem = 0; elem < array.Length; ++elem)
            {
                for (int num = array[elem] - 1; num > 0; --num)
                { if (Pow2(num)) { result[elem] = num; break; } }
            }

            return result;
        }

        static bool Pow2(int num)
        {
            for (int count = 0; Math.Pow(2, count) <= num; ++count)
                if (Math.Pow(2, count) == num) return true;

            return false;
        }

        static void WriteFile(string path, int[] array)
        {
            string text = null;
            for (int elem = 0; elem < array.Length; ++elem)
                text += array[elem] + " ";
            File.WriteAllText(path, text);
        }

        static void Main(string[] args)
        {
            FillFile();
            
            int[] A;
            int[] B;
            
            try
            {
                A = ReadFile(inputPath);

                if (!CheckArray(A))
                {
                    Console.WriteLine("Incorrect Input");
                    Environment.Exit(0);
                }

                B = ConvertArray(A);

                WriteFile(outputPath, B);
            }
            catch (Exception ex) { Console.WriteLine(ex.Message); }

            ConsoleOutput();
        }
        
        #region Testing methods for Github Classroom, do not touch!

        static void FillFile()
        {
            try
            {
                File.WriteAllText(inputPath, Console.ReadLine());
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        static void ConsoleOutput()
        {
            try
            {
                Console.WriteLine(File.ReadAllText(outputPath));
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        #endregion
    }
}
