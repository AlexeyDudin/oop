using Lab4_1.Domain;

namespace Lab4_1
{
    public class StreamHandler
    {
        private List<object> objects { get; set; } = new List<object>();
        private Dictionary<string, Type> objectDictionary = new Dictionary<string, Type>();
        private TextWriter output;
        private TextReader input;

        public StreamHandler(TextReader tr, TextWriter tw) 
        {
            input = tr;
            output = tw;
            InitializeObjectDictionary();
        }

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
                        //TODO! Сделать показ на экран
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

        private void InitializeObjectDictionary()
        {
            objectDictionary.Add("point", typeof(CPoint));
            objectDictionary.Add("triangle", typeof(CTriangle));
            objectDictionary.Add("rectangle", typeof(CRectangle));
            objectDictionary.Add("circle", typeof(CCircle));
        }
    }
}
