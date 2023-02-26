using Microsoft.VisualStudio.TestTools.UnitTesting;
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

        private static float[][] ReadMatrixFromFile(string fileName)
        {
            //В английском языке нет слова readed. read!! а не readed
            string[] readStringsFromFile = File.ReadAllLines(fileName);
            Assert.AreEqual(3, readStringsFromFile.Length);
            //if (readStringsFromFile.Length != 3)
            //    throw new ArgumentException("Размер матрицы в файле не соответствует размеру 3x3");
            float[][] result = new float[readStringsFromFile.Length][];
            for (int i = 0; i < readStringsFromFile.Length; i++)
            {
                result[i] = new float[readStringsFromFile.Length];
            }

            //line counter; element counter -> row column
            int counterLines = 0;
            int counterElements = 0;
            foreach (string line in readStringsFromFile)
            {
                //проверка на много символов
                string[] elementsInString = line.Split(' ');
                Assert.AreEqual(3, elementsInString.Length);
                //if (elementsInString.Length != 3)
                //    throw new ArgumentException($"Размер матрицы в файле не соответствует размеру 3x3. Ошибка в строке {counterLines}");
                foreach (string elementString in elementsInString)
                {
                    //result[counterLines][counterElements] = Int32.Parse(elementString);
                    bool canConvert = float.TryParse(elementString, out result[counterLines][counterElements]);
                    Assert.IsTrue(canConvert);
                    counterElements++;
                }
                counterElements = 0;
                counterLines++;
            }

            return result;
        }

        //Правильное наименование функции - Transpose
        //readedMatrix имеет другой контекст. Переименовать -> matrix
        private static float[][] GetTransposedMatrix(float[][] inputMatrix)
        {
            float[][] result = new float[inputMatrix.Length][];
            for (int i = 0; i < inputMatrix.Length; i++)
            {
                result[i] = new float[inputMatrix.Length];
            }

            for (int i = 0; i < inputMatrix.Length; i++)
            {
                for (int j = 0; j < inputMatrix[i].Length; j++)
                {
                    result[i][j] = inputMatrix[j][i];
                }
            }
            return result;
        }
        
        //120 символов MAX - Done
        private static float GetMatrixDeterminant(float[][] readedMatrix)
        {
            float result = readedMatrix[0][0] * readedMatrix[1][1] * readedMatrix[2][2] +
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
        private static float[][] GetMatrixCofactor(float[][] inputMatrix)
        {
            float[][] resultMatrixCofactor = new float[inputMatrix.Length][];
            Assert.AreEqual(inputMatrix.Length, 3);
            for (int i = 0; i < inputMatrix.Length; i++)
            {
                resultMatrixCofactor[i] = new float[inputMatrix.Length];
            }
            resultMatrixCofactor[0][0] = inputMatrix[1][1] * inputMatrix[2][2] - inputMatrix[2][1] * inputMatrix[1][2];
            resultMatrixCofactor[0][1] = -(inputMatrix[1][0] * inputMatrix[2][2] - inputMatrix[2][0] * inputMatrix[1][2]);
            resultMatrixCofactor[0][2] = inputMatrix[1][0] * inputMatrix[2][1] - inputMatrix[2][0] * inputMatrix[1][1];
            resultMatrixCofactor[1][0] = -(inputMatrix[0][1] * inputMatrix[2][2] - inputMatrix[2][1] * inputMatrix[0][2]);
            resultMatrixCofactor[1][1] = inputMatrix[0][0] * inputMatrix[2][2] - inputMatrix[2][0] * inputMatrix[0][2];
            resultMatrixCofactor[1][2] = -(inputMatrix[0][0] * inputMatrix[2][1] - inputMatrix[2][0] * inputMatrix[0][1]);
            resultMatrixCofactor[2][0] = inputMatrix[0][1] * inputMatrix[1][2] - inputMatrix[1][1] * inputMatrix[0][2];
            resultMatrixCofactor[2][1] = -(inputMatrix[0][0] * inputMatrix[1][2] - inputMatrix[1][0] * inputMatrix[0][2]);
            resultMatrixCofactor[2][2] = inputMatrix[0][0] * inputMatrix[1][1] - inputMatrix[1][0] * inputMatrix[0][1];

            return resultMatrixCofactor;
        }

        //Переименовать в PrintMatrix
        private static void PrintMatrix(float[][] inputMatrix)
        {
            for (int i = 0; i < inputMatrix.Length; i++)
            {
                for (int j = 0; j < inputMatrix[i].Length; j++)
                {
                    Console.Write(inputMatrix[i][j].ToString("0.000") + "\t");
                }
                Console.WriteLine();
            }
        }

        //Переименовать функцию и параметры arguments by scalar
        //Переименовал функцию и параметры - Done
        private static float[][] MatrixMultiplication(float[][] inputMatrix, float multiplierFactor)
        {
            float[][] result = new float[inputMatrix.Length][];
            for (int i = 0; i < inputMatrix.Length; i++)
            {
                result[i] = new float[inputMatrix.Length];
            }

            for (int i = 0; i < inputMatrix.Length; i++)
            {
                for (int j = 0; j < inputMatrix.Length; j++)
                {
                    result[i][j] = inputMatrix[i][j] * multiplierFactor;
                }
            }

            return result;
        }

        public static float[][] GetInverseMatrix(float[][] inputMatrix)
        {
            float matrixDeterminant = GetMatrixDeterminant(inputMatrix); //Выдает ArgumentException при детерминанте = 0;
            float[][] transporedMatrix = GetTransposedMatrix(inputMatrix);
            float[][] cofactorMatrix = GetMatrixCofactor(transporedMatrix);

            float coefficient = (1 / matrixDeterminant);

            float[][] result = MatrixMultiplication(cofactorMatrix, coefficient);
            return result;
        }

        public static int Main(string[] args)
        {
            ResultEnums resultCheckParam = CheckParams(args);
            if (resultCheckParam != ResultEnums.Ok)
                return (int)resultCheckParam;

            try
            {
                //вывести в функцию - Done
                //заменить int на float double - Done
                float[][] readedMatrix = ReadMatrixFromFile(args[0]);
                float[][] inverseMatrix = GetInverseMatrix(readedMatrix);

                PrintMatrix(inverseMatrix);
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
