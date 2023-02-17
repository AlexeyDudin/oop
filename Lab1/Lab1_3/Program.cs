using System;
using System.IO;

namespace Lab1_3
{
    public class Program
    {
        private static void PrintHelp()
        {
            Console.WriteLine("Lab1_3.exe <matrixFileName>");
        }

        private static ResultEnums CheckParams(string[] args)
        {
            if (args.Length != 1)
            {
                Console.WriteLine("Ошибка параметров командной строки");
                PrintHelp();
                return ResultEnums.ArgumentException;
            }

            if (!File.Exists(args[0]))
            {
                Console.WriteLine($"Ошибка параметров командной строки. Файл {args[0]} не найден");
                return ResultEnums.ArgumentException | ResultEnums.FileNotFound;
            }

            return ResultEnums.Ok;
        }

        private static int[][] ReadMatrixFromFile(string fileName)
        {
            //В английском языке нет слова readed. read!! а не readed
            string[] readedStringsFromFile = File.ReadAllLines(fileName);
            if (readedStringsFromFile.Length != 3)
                throw new ArgumentException("Размер матрицы в файле не соответствует размеру 3x3");
            int[][] result = new int[readedStringsFromFile.Length][];
            for (int i = 0; i < readedStringsFromFile.Length; i++)
            {
                result[i] = new int[readedStringsFromFile.Length];
            }

            //line counter; element counter -> row column
            int counterLines = 0;
            int counterElements = 0;
            foreach (string line in readedStringsFromFile)
            {
                //проверка на много символов
                string[] elementsInString = line.Split(' ');
                if (elementsInString.Length != 3)
                    throw new ArgumentException($"Размер матрицы в файле не соответствует размеру 3x3. Ошибка в строке {counterLines}");
                foreach (string elementString in elementsInString)
                {
                    result[counterLines][counterElements] = Int32.Parse(elementString);
                    counterElements++;
                }
                counterElements = 0;
                counterLines++;
            }

            return result;
        }

        //Правильное наименование функции - Transpose
        //readedMatrix имеет другой контекст. Переименовать -> matrix
        private static int[][] TransporateMatrix(int[][] readedMatrix)
        {
            int[][] result = new int[readedMatrix.Length][];
            for (int i = 0; i < readedMatrix.Length; i++)
            {
                result[i] = new int[readedMatrix.Length];
            }

            for (int i = 0; i < readedMatrix.Length; i++)
            {
                for (int j = 0; j < readedMatrix[i].Length; j++)
                {
                    result[i][j] = readedMatrix[j][i];
                }
            }
            return result;
        }
        
        //120 символов MAX - Done
        private static int GetMatrixDeterminant(int[][] readedMatrix)
        {
            int result = readedMatrix[0][0] * readedMatrix[1][1] * readedMatrix[2][2] +
                         readedMatrix[1][0] * readedMatrix[2][1] * readedMatrix[0][2] + 
                         readedMatrix[0][1] * readedMatrix[1][2] * readedMatrix[2][0] -
                         readedMatrix[2][0] * readedMatrix[1][1] * readedMatrix[0][2] -
                         readedMatrix[0][0] * readedMatrix[2][1] * readedMatrix[1][2] - 
                         readedMatrix[1][0] * readedMatrix[0][1] * readedMatrix[2][2];
            if (result == 0)
                throw new ArgumentException("Для текущей матрицы не существует определителя!");
            return result;
        }

        //transposed 
        //GetCofactorMatrix
        //Параметр функции здесь имеет другой контекст. Переименовать
        private static int[][] GetMatrixCofactor(int[][] transporedMatrix)
        {
            int[][] result = new int[transporedMatrix.Length][];
            for (int i = 0; i < transporedMatrix.Length; i++)
            {
                result[i] = new int[transporedMatrix.Length];
            }
            result[0][0] = transporedMatrix[1][1] * transporedMatrix[2][2] - transporedMatrix[2][1] * transporedMatrix[1][2];
            result[0][1] = -(transporedMatrix[1][0] * transporedMatrix[2][2] - transporedMatrix[2][0] * transporedMatrix[1][2]);
            result[0][2] = transporedMatrix[1][0] * transporedMatrix[2][1] - transporedMatrix[2][0] * transporedMatrix[1][1];
            result[1][0] = -(transporedMatrix[0][1] * transporedMatrix[2][2] - transporedMatrix[2][1] * transporedMatrix[0][2]);
            result[1][1] = transporedMatrix[0][0] * transporedMatrix[2][2] - transporedMatrix[2][0] * transporedMatrix[0][2];
            result[1][2] = -(transporedMatrix[0][0] * transporedMatrix[2][1] - transporedMatrix[2][0] * transporedMatrix[0][1]);
            result[2][0] = transporedMatrix[0][1] * transporedMatrix[1][2] - transporedMatrix[1][1] * transporedMatrix[0][2];
            result[2][1] = -(transporedMatrix[0][0] * transporedMatrix[1][2] - transporedMatrix[1][0] * transporedMatrix[0][2]);
            result[2][2] = transporedMatrix[0][0] * transporedMatrix[1][1] - transporedMatrix[1][0] * transporedMatrix[0][1];

            return result;
        }

        //Переименовать в PrintMatrix
        private static void PrintResult(float[][] result)
        {
            for (int i = 0; i < result.Length; i++)
            {
                for (int j = 0; j < result[i].Length; j++)
                {
                    Console.Write(result[i][j].ToString("0.000") + "\t");
                }
                Console.WriteLine();
            }
        }

        //Переименовать функцию и параметры arguments by scalar
        private static float[][] MultiplyMatrix(int[][] determinantMatrix, float matrixDeterminant)
        {
            float[][] result = new float[determinantMatrix.Length][];
            for (int i = 0; i < determinantMatrix.Length; i++)
            {
                result[i] = new float[determinantMatrix.Length];
            }

            for (int i = 0; i < determinantMatrix.Length; i++)
            {
                for (int j = 0; j < determinantMatrix.Length; j++)
                {
                    result[i][j] = determinantMatrix[i][j] * matrixDeterminant;
                }
            }

            return result;
        }

        public static int Main(string[] args)
        {
            ResultEnums resultCheckParam = CheckParams(args);
            if (resultCheckParam != ResultEnums.Ok)
                return (int)resultCheckParam;

            try
            {
                //вывести в функцию
                //заменить int на float double
                int[][] readedMatrix = ReadMatrixFromFile(args[0]);
                int matrixDeterminant = GetMatrixDeterminant(readedMatrix); //Выдает ArgumentException при детерминанте = 0;
                int[][] transporedMatrix = TransporateMatrix(readedMatrix);
                int[][] cofactorMatrix = GetMatrixCofactor(transporedMatrix);

                float coefficient = (1 / matrixDeterminant);

                float[][] result = MultiplyMatrix(cofactorMatrix, coefficient);

                PrintResult(result);
            }
            catch (ArgumentException e)
            {
                Console.WriteLine(e.Message);
                return (int)ResultEnums.ArgumentException;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return (int)ResultEnums.FileWorkException;
            }
            
            return (int)ResultEnums.Ok;
        }

    }
}
