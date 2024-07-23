using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheTurtleChallenge
{
    /// <summary>
    /// Represents a logger of an message
    /// </summary>
    public class ConsoleLogger: ILogger
    {
        /// <summary>
        /// Logs a message to the console.
        /// </summary>
        /// <param name="message"> message to be showed</param>
        public void Log(string message)
        {
            Console.WriteLine(message);
        }
    }
}
