using System;
using System.IO;

/*
 * По массиву A целых чисел со значениями из диапазона [-10;10] создать массив булевских значений L.
 * Количество элементов в массивах совпадает.
 * На местах неотрицательных элементов в массиве A
 * в массиве L стоят значения true, на месте отрицательных – false.
 * Если хотя бы один из элементов массива А находится вне заданного диапазона - выводить Incorrect Input
 * в консоль. Гарантируется, что на вход подается N целых чисел.
 *
 * Пример входных данных:
 * 0 -1
 *
 * Пример выходных данных:
 * true false
 */

namespace _01_07_Files
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
                if (array[elem] < -10 || array[elem] > 10)
                    return false;

            return true;
        }
        
        static bool[] IntToBoolArray(int[] array)
        {
            bool[] result = new bool[array.Length];
            for (int elem = 0; elem < array.Length; ++elem)
            {
                if (array[elem] >= 0)
                    result[elem] = true;
                else result[elem] = false;
            }

            return result;
        }
        
        static void WriteFile(string path, bool[] array)
        {
            string text = null;
            for (int elem = 0; elem < array.Length; ++elem)
            {
                if (array[elem]) text += "true ";
                else text += "false ";
            }
            File.WriteAllText(path, text);
        }

        static void Main(string[] args)
        {
            FillFile();
            
            int[] A;
            bool[] L;
            
            try
            {
                A = ReadFile(inputPath);
                
                if (!CheckArray(A))
                {
                    Console.WriteLine("Incorrect Input");
                    Environment.Exit(0);
                }
                
                L = IntToBoolArray(A);
                WriteFile(outputPath, L);
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
