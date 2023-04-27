namespace Lab4_1
{
    public class StreamHandler
    {
        private List<object> Objects { get; set; } = new List<object>();
        private TextWriter output;
        private TextReader input;

        public StreamHandler(TextReader tr, TextWriter tw) 
        {
            input = tr;
            output = tw;
        }
    }
}
