using System.IO;
using System.Text;
using System;

namespace Lab1_4
{
    public static class Compressor
    {
        public static void Compress(string sourceFile, string destFile)
        {
            using (FileStream inputFileStream = File.OpenRead(sourceFile), outputFileStream = File.OpenWrite(destFile))
            {
                using (StreamReader streamReader = new StreamReader(inputFileStream, Encoding.GetEncoding(866)))
                {
                    using (BinaryWriter binaryWriter = new BinaryWriter(outputFileStream, Encoding.GetEncoding(866)))
                    {
                        //TODO Compressor
                        //Class
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
                                    {
                                        binaryWriter.Write(counter);
                                        binaryWriter.Write(prevCharacter.Value);
                                        counter = 0;
                                    }
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


        public static void UnCompress(string sourceFile, string destFile)
        {
            //Уменьшить количество уровней вложенности
            //Избавиться от encoding
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
                                //Пакет данных
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
    }
}
