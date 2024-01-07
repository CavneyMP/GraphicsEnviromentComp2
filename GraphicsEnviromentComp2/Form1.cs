using GraphicsEnviromentComp2.Commands;
using GraphicsEnviromentComp2.GraphicContext;
using GraphicsEnviromentComp2.Parser;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GraphicsEnviromentComp2
{
    public partial class Form1 : Form
    {
        private VariableContext variableContext = new VariableContext();

        public Form1()
        {
            InitializeComponent();
        }

        private void Runbutton_Click(object sender, EventArgs e)
        {
            var input = Singleline.Text;
            var multiLineContent = MultiLine.Text;

            var parser = new CommandParser(variableContext);
            var command = parser.ParseCommand(input, multiLineContent);
            var graphics = GraphicPanel.CreateGraphics();

            command.Execute(graphics);
        }

        private void MultiLineRunBtn_Click(object sender, EventArgs e)
        {
            string multiLineTextContent = MultiLine.Text;

            Graphics graphics = GraphicPanel.CreateGraphics();

            CommandParser parser = new CommandParser(variableContext);


            string[] lines = multiLineTextContent.Split(new string[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries);

            foreach (string line in lines)
            {
                ICommandInterface command = parser.ParseCommand(line, multiLineTextContent);

                command.Execute(graphics);
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
    }
}

