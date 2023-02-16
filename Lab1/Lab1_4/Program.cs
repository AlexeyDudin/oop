﻿using System;
using System.IO;

namespace Lab1_4
{
    public class Program
    {
        private static void PrintHelp()
        {
            Console.WriteLine("Lab1_4.exe pack/unpack <source file> <destination file>");
        }

        private static ResultEnums CheckParams(string[] args)
        {
            if (args.Length != 3)
            {
                Console.WriteLine("Ошибка параметров командной строки");
                PrintHelp();
                return ResultEnums.ArgumentException;
            }

            if (args[0] != "pack" && args[0] != "unpack")
            {
                Console.WriteLine($"Ошибка параметров командной строки! Параметр {args[0]} не расопознан");
                return ResultEnums.ArgumentException;
            }

            if (!File.Exists(args[1]))
            {
                Console.WriteLine($"Ошибка параметров командной строки! Файл {args[1]} не найден");
                return ResultEnums.ArgumentException | ResultEnums.WorkWithFileError;
            }

            return ResultEnums.Ok;
        }

        private static void Compress(string sourceFile, string destFile)
        {
            FileStream inputFileStream = File.OpenRead(sourceFile);
            FileStream outputFileStream = File.OpenWrite(destFile);

            StreamReader streamReader = new StreamReader(inputFileStream);

            byte counter = 0;
            byte? prevByte = null;
            byte? readedByte = null;

            while (streamReader.Peek() >= 0)
            {
                readedByte = (byte)streamReader.Read();
                if (readedByte == prevByte)
                {
                    if (Byte.MaxValue - counter < 1)
                    {
                        streamReader.Close();
                        inputFileStream.Close();
                        outputFileStream.Close();
                        throw new IndexOutOfRangeException($"Произошло переполнение! Количество повторных байт {(char)readedByte} превышает значение 255");
                    }
                    counter++;
                }
                else if (prevByte != null)
                {
                    outputFileStream.WriteByte(counter);
                    outputFileStream.WriteByte(prevByte.Value);
                    prevByte = readedByte;
                    counter = 1;
                }
                else
                {
                    prevByte = readedByte;
                    counter = 1;
                }
            }

            if (readedByte != null)
            {
                outputFileStream.WriteByte(counter);
                outputFileStream.WriteByte(readedByte.Value);
            }

            streamReader.Close();
            inputFileStream.Close();
            outputFileStream.Close();
        }

        private static void UnCompress(string sourceFile, string destFile)
        {
            FileStream inputFileStream = File.OpenRead(sourceFile);
            FileStream outputFileStream = File.OpenWrite(destFile);

            StreamWriter streamWriter = new StreamWriter(outputFileStream);

            bool isEndOfFile = false;

            while (!isEndOfFile)
            {
                if (inputFileStream.Position == inputFileStream.Length)
                    isEndOfFile = true;
                else
                {
                    byte counter = (byte)inputFileStream.ReadByte();
                    if (inputFileStream.Position == inputFileStream.Length)
                        throw new EndOfStreamException($"Непредвиденный конец файла {sourceFile}");
                    byte character = (byte)inputFileStream.ReadByte();
                    for (byte i = 0; i < counter; i++)
                    {
                        streamWriter.Write((char)character);
                    }
                }
            }

            streamWriter.Close();
            inputFileStream.Close();
            outputFileStream.Close();
        }

        public static int Main(string[] args)
        {
            ResultEnums resultCheckParam = CheckParams(args);
            if (resultCheckParam != ResultEnums.Ok)
                return (int)resultCheckParam;

            try
            {
                if (File.Exists(args[2]))
                    File.Delete(args[2]);

                switch (args[0])
                {
                    case "pack":
                        Compress(args[1], args[2]);
                        break;
                    case "unpack":
                        UnCompress(args[1], args[2]);
                        break;
                }
            }
            catch (IndexOutOfRangeException e)
            {
                Console.WriteLine(e.Message);
                try
                {
                    File.Delete(args[1]);
                }
                catch
                {
                    Console.WriteLine($"Ошибка удаления файла {args[1]}");
                }
                return (int)ResultEnums.WorkWithFileError;
            }
            catch (IOException e)
            {
                Console.WriteLine($"Ошибка при работе с файлом\n{e.Message}\n{string.Join("<-", e.Data)}");
                return (int)ResultEnums.WorkWithFileError;
            }
            catch (Exception e)
            {
                Console.WriteLine($"{e.Message}\n{string.Join("<-", e.Data)}");
                return (int)ResultEnums.OtherExceptions;
            }

            return (int)ResultEnums.Ok;
        }
    }
}
