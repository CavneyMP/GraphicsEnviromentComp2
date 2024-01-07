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
    /// Saves the current commands shown in the multi line command to a file.
    /// </summary>
    public class SaveCommand : ICommandInterface
    {
        private readonly string _filePath;
        private readonly string _contentToSave;


    /// <summary>
    /// Initializes a new instance of the save command class
    /// </summary>
    /// <param name="filePath">The filePath the user wants to save to</param>
    /// <param name="contentToSave">The text from the Multi Line text box</param>
        public SaveCommand(string filePath, string contentToSave)
        {
            _filePath = filePath;
            _contentToSave = contentToSave;
        }
        /// <summary>
        /// This executes the command, which uses the IO libary to write the data.
        /// </summary>
        /// <param name="graphics"> Graphics context is not used</param>
        public void Execute(Graphics graphics)
        {
            File.WriteAllText(_filePath, _contentToSave);
        }
    }
}
    
