using GraphicsEnviromentComp2.CustomException;
using GraphicsEnvironmentComp2.Commands;
using GraphicsEnvironmentComp2.GraphicContext;
using GraphicsEnvironmentComp2.Parser;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GraphicsEnvironmentComp2
{
    public partial class Form1 : Form
    {
        private VariableContext variableContext = new VariableContext();

        public Form1()
        {
            InitializeComponent();
            Application.ThreadException += new ThreadExceptionEventHandler(GlobalExceptionHandler);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void GlobalExceptionHandler(object sender, ThreadExceptionEventArgs e)
        {
            if (e.Exception is CustomArgumentException customEx)
            {
                // Message put in a MessageBox
                MessageBox.Show(customEx.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                // Handle other types of exceptions
                MessageBox.Show(e.Exception.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Runbutton_Click(object sender, EventArgs e)
        {
            try
            {
                var input = Singleline.Text;
                var multiLineContent = MultiLine.Text;

                var parser = new CommandParser(variableContext);
                var command = parser.ParseCommand(input, multiLineContent);
                var graphics = GraphicPanel.CreateGraphics();

                command.Execute(graphics);
            }
            catch (CustomArgumentException)
            {
                // Rethrow the exception so its handled by the global exception handler
                throw;
            }
        }

        private void MultiLineRunBtn_Click(object sender, EventArgs e)
        {
            try
            {
                string multiLineTextContent = MultiLine.Text;
                Graphics graphics = GraphicPanel.CreateGraphics();
                CommandParser parser = new CommandParser(variableContext);

                string[] lines = multiLineTextContent.Split(new string[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries);

                foreach (string line in lines)
                {
                    try
                    {
                        ICommandInterface command = parser.ParseCommand(line, multiLineTextContent);
                        command.Execute(graphics);
                    }
                    catch (CustomArgumentException ex)
                    {
                        // error message in a MessageBox
                        MessageBox.Show(ex.UserFriendlyMessage, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            catch (Exception ex)
            {
                // Handle unexpected exceptions
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }





        private void MultiLine_TextChanged(object sender, EventArgs e)
        {

        }

        private void SyntaxButton_Click(object sender, EventArgs e)
        {

        }

        private void GraphicPanel_Paint(object sender, PaintEventArgs e)
        {

        }
        private void Singleline_TextChanged(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void SyntaxReportBox(object sender, PaintEventArgs e)
        {

        }

        private void BothRun_Click(object sender, EventArgs e)
        {

        }

        private void MultiLineBoth_TextChanged(object sender, EventArgs e)
        {

        }
    }
}