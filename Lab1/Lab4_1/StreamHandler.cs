//using Lab4_2;
using Lab4_2;
using Lab4_2.Domain;
using Lab4_2.Interfaces;
using System.IO;

namespace Lab4_1
{
    public class StreamHandler
    {
        private List<ICanvasDrawable> objects { get; set; } = new List<ICanvasDrawable>();
        private Dictionary<string, Type> objectDictionary = new Dictionary<string, Type>();
        private TextWriter output;
        private TextReader input;

        public StreamHandler(TextReader tr, TextWriter tw) 
        {
            input = tr;
            output = tw;
            InitializeObjectDictionary();
        }

        [STAThread]
        public void Start() 
        {
            string? readString;
            do
            {
                output.Write("Введите команду: ");
                readString = input.ReadLine();
                try
                {
                    if (string.IsNullOrWhiteSpace(readString))
                    {
                        output.WriteLine("Не корректная команда");
                        continue;
                    }
                    if (readString == "quit")
                        break;
                    if (readString == "show")
                    {
                        ShowWindow();
                        continue;
                    }
                    string[] splitParams = readString.Split(" ");
                    if (!objectDictionary.ContainsKey(splitParams[0]))
                    {
                        output.WriteLine($"Не известная комманда {splitParams[0]}");
                        continue;
                    }
                    dynamic newObjectInstance = Activator.CreateInstance(objectDictionary[splitParams[0]]);
                    newObjectInstance.Parse(splitParams);
                    objects.Add(newObjectInstance);
                }
                catch (Exception ex)
                {
                    output.WriteLine(ex.Message);
                }
            } while (readString != "quit");
        }

        [STAThread]
        private void ShowWindow()
        {
            var application = new MainWindow(objects);
            application.ShowDialog();
        }

        private void InitializeObjectDictionary()
        {
            objectDictionary.Add("point", typeof(CPoint));
            objectDictionary.Add("triangle", typeof(CTriangle));
            objectDictionary.Add("rectangle", typeof(CRectangle));
            objectDictionary.Add("circle", typeof(CCircle));
            objectDictionary.Add("line", typeof(CLineSegment));
        }
    }
}
