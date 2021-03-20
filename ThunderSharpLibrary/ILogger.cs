using System;
using System.Collections.Generic;
using System.Text;

namespace ThunderSharpLibrary
{
    public interface ILogger
    {
        public void WriteLog(string message = "");
    }
}
