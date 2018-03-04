using System;

namespace WindowsInputRecorder.Exceptions
{
    public class LineException : Exception
    {
        private int lineIndex;
        private string line;

        public LineException(int lineIndex, string line, Exception ex)
            : base(null, ex)
        {
            this.lineIndex = lineIndex;
            this.line = line;
        }

        public int LineIndex
        {
            get { return lineIndex; }
        }

        public string Line
        {
            get { return line; }
        }
    }
}
