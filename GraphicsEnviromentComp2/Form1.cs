using GraphicsEnviromentComp2.CustomException;
using GraphicsEnvironmentComp2.Commands;
using GraphicsEnvironmentComp2.GraphicContext;
using GraphicsEnvironmentComp2.Parser;
using System;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;

namespace GraphicsEnvironmentComp2
{

    /// <summary>
    /// This is the main form for the graphics environment
    /// </summary>
    public partial class Form1 : Form
    {
        private VariableContext variableContext = new VariableContext();


        /// <summary>
        /// This initialises a new instance of the Form1 class
        /// </summary>
        public Form1()
        {
            InitializeComponent();
            Application.ThreadException += new ThreadExceptionEventHandler(GlobalExceptionHandler);
        }
        /// <summary>
        /// This is the global exception handler, to report the user back errors gracefully in a message box
        /// </summary>
        /// <param name="sender">The sender of the exception</param>
        /// <param name="e">Thread exception event arguments</param>

        private void GlobalExceptionHandler(object sender, ThreadExceptionEventArgs e)
        {
            if (e.Exception is CustomArgumentException customEx)
            {
                MessageBox.Show(customEx.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                MessageBox.Show(e.Exception.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// event handler for "run" button click.
        /// </summary>
        /// <param name="sender">The sender of the event</param>
        /// <param name="e">The event arguments</param>

        private void Runbutton_Click(object sender, EventArgs e)
        {
            try
            {
                var input = Singleline.Text;
                var multiLineContent = MultiLine.Text;

                var parser = new CommandParser(variableContext);
                var command = parser.ParseCommand(input, multiLineContent);
                var graphics = GraphicPanel.CreateGraphics();
                var safeGraphics = new SafeGraphics(graphics);

                command.Execute(safeGraphics);

                graphics.Dispose(); 
            }
            catch (CustomArgumentException)
            {
                throw;
            }
        }

        /// <summary>
        /// Event handler for mutli run button click.
        /// </summary>
        /// <param name="sender">The sender of the event</param>
        /// <param name="e">The event arguments</param>
        private void MultiLineRunBtn_Click(object sender, EventArgs e)
        {
            try
            {
                string multiLineTextContent = MultiLine.Text;
                var graphics = GraphicPanel.CreateGraphics();
                var safeGraphics = new SafeGraphics(graphics);
                CommandParser parser = new CommandParser(variableContext);

                string[] lines = multiLineTextContent.Split(new string[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries);

                foreach (string line in lines)
                {
                    try
                    {
                        ICommandInterface command = parser.ParseCommand(line, multiLineTextContent);
                        command.Execute(safeGraphics); 
                    }
                    catch (CustomArgumentException ex)
                    {
                        MessageBox.Show(ex.UserFriendlyMessage, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }

                graphics.Dispose();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        /// <summary>
        /// Event handler for both run
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BothRun_Click(object sender, EventArgs e)
        {
            string commandsProgram1 = MultiLine.Text;
            string commandsProgram2 = MultiLineBoth.Text; 

            Thread program1Thread = new Thread(() => ExecuteCommands(commandsProgram1));
            program1Thread.Start();

            Thread program2Thread = new Thread(() => ExecuteCommands(commandsProgram2));
            program2Thread.Start();
        }
        /// <summary>
        /// Executes a set of commands in a seperatate thread
        /// </summary>
        /// <param name="commands">The commands to execute</param>
        private void ExecuteCommands(string commands)
        {
            var graphics = GraphicPanel.CreateGraphics();
            var safeGraphics = new SafeGraphics(graphics);
            var parser = new CommandParser(variableContext);

            string[] lines = commands.Split(new string[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries);
            foreach (string line in lines)
            {
                ICommandInterface command = parser.ParseCommand(line, "");
                command.Execute(safeGraphics);
                Thread.Sleep(500);
            }

            graphics.Dispose();
        }

        private void MultiLine_TextChanged(object sender, EventArgs e)
        {
            // Empty event
        }

        private void GraphicPanel_Paint(object sender, PaintEventArgs e)
        {
            // Empty event
        }

        private void Singleline_TextChanged(object sender, EventArgs e)
        {
            // Empty event
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // Empty event 
        }

        private void MultiLineBoth_TextChanged(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// Safe Graphics Class to make system thread safe
        /// </summary>
        public class SafeGraphics
        {
            private readonly Graphics _graphics;
            private static readonly object _lockObj = new object();
            /// <summary>
            /// Initilises a new instance of safe graphics class
            /// </summary>
            /// <param name="graphics">The graphics object to work with</param>
            public SafeGraphics(Graphics graphics)
            {
                _graphics = graphics;
            }

            /// <summary>
            /// Executes a graphics operation within a locked context
            /// </summary>
            /// <param name="drawAction"></param>
            public void Execute(Action<Graphics> drawAction)
            {
                lock (_lockObj)
                {
                    drawAction(_graphics);
                }
            }
        }
    }
}
