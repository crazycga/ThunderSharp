using System;

namespace ThunderSharpLibrary
{
    /// <summary>
    /// The intention here is to allow for a variety of logging methods, so you're not tied to the Console.Writeline output; requires only a "WriteLog (string message)" function
    /// </summary>
    public class Logger_class : ILogger
    {
        private string _filename = string.Empty;

        public void WriteLog(string message = "")
        {
            if (message.Equals(string.Empty))
            {
                Console.WriteLine();
                return;
            }

            Console.WriteLine(DateTime.Now.ToString() + ": " + message);
        }
    }
}
