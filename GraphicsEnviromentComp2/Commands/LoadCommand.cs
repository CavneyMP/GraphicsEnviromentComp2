using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphicsEnviromentComp2.Commands
{
    /// <summary>
    /// Loads the content from a specified file.
    /// </summary>
    public class LoadCommand : ICommandInterface
    {
        private readonly string _filePath;

        /// <summary>
        /// Initializes an instance of the LoadCommand class.
        /// </summary>
        /// <param name="filePath">The path to load.</param>
        public LoadCommand(string filePath)
        {
            _filePath = filePath;
        }

        /// <summary>
        /// Executes the command to load content from the file.
        /// </summary>
        /// <param name="graphics">Graphics context not used.</param>
        public void Execute(Graphics graphics)
        {
            // Check the file exists
            if (!File.Exists(_filePath))
            {
                throw new FileNotFoundException("The specified file was not found.", _filePath);
            }

            // Read the file using IO
            string fileContent = File.ReadAllText(_filePath);
        }
    }
}
