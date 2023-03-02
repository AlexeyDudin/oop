using System;
using System.IO;
using System.Text;

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
            using (FileStream inputFileStream = File.OpenRead(sourceFile), outputFileStream = File.OpenWrite(destFile))
            {
                using (StreamReader streamReader = new StreamReader(inputFileStream, Encoding.GetEncoding(866)))
                {
                    using (BinaryWriter binaryWriter = new BinaryWriter(outputFileStream, Encoding.GetEncoding(866)))
                    {

                        byte counter = 0;
                        char? prevCharacter = null;
                        char? readChar = null;

                        while (streamReader.Peek() >= 0)
                        {
                            string readString = streamReader.ReadToEnd();
                            foreach (char currCharacter in readString)
                            {
                                readChar = currCharacter;
                                if (currCharacter == prevCharacter)
                                {
                                    if (Byte.MaxValue - counter < 1)
                                        throw new IndexOutOfRangeException($"Произошло переполнение! Количество повторных байт {currCharacter} превышает значение 255");

                                    counter++;
                                }
                                else if (prevCharacter != null)
                                {
                                    binaryWriter.Write(counter);
                                    binaryWriter.Write(prevCharacter.Value);
                                    prevCharacter = currCharacter;
                                    counter = 1;
                                }
                                else
                                {
                                    prevCharacter = currCharacter;
                                    counter = 1;
                                }
                            }
                        }

                        //Записываем последний считаный байт
                        if (readChar != null)
                        {
                            binaryWriter.Write(counter);
                            binaryWriter.Write(readChar.Value);
                        }
                    }
                }
            }
        }

        private static void UnCompress(string sourceFile, string destFile)
        {
            using (FileStream inputFileStream = File.OpenRead(sourceFile), outputFileStream = File.OpenWrite(destFile))
            {
                using (BinaryReader binaryReader = new BinaryReader(inputFileStream, Encoding.GetEncoding(866)))
                {
                    using (StreamWriter streamWriter = new StreamWriter(outputFileStream, Encoding.GetEncoding(866)))
                    {
                        bool isEndOfFile = false;

                        while (!isEndOfFile)
                        {
                            if (binaryReader.PeekChar() == -1)
                                isEndOfFile = true;
                            else
                            {
                                byte counter = binaryReader.ReadByte();
                                if (binaryReader.PeekChar() == -1)
                                    throw new EndOfStreamException($"Непредвиденный конец файла {sourceFile}");
                                char character = binaryReader.ReadChar();
                                for (byte i = 0; i < counter; i++)
                                {
                                    streamWriter.Write(character);
                                }
                            }
                        }
                    }
                }
            }
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
