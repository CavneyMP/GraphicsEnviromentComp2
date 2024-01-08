using GraphicsEnvironmentComp2.GraphicContext;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphicsEnvironmentComp2.Commands
{
    /// <summary>
    /// This class allows the user to draw a square by just specifiying the command, width and height.
    /// </summary>
    public class SquareCommand : ICommandInterface
    {
        private readonly int _width;
        private readonly int _height;
        private readonly GraphicsContext _context;


        /// <summary>
        /// This method initializes a new instance of the square command class
        /// </summary>
        /// <param name="width">It needs an integer called width, which will be the width of the square</param>
        /// <param name="height">It needs an integer called height, which will be the height of the square</param>
        /// <param name="context">The graphics context is what will hold the current graphics and context</param>

        public SquareCommand(int width, int height, GraphicsContext context)
        {
            _width = width;
            _height = height;
            _context = context;
        }


        /// <summary>
        /// This is what will execute the command, carrying out the drawing event on the exisiting graphic
        /// </summary>
        /// <param name="graphics">The existing graphics to draw </param>
        public void Execute(Graphics graphics)
        {
            Point currentPosition = _context.CurrentPosition;
            graphics.DrawRectangle(new Pen(_context.CurrentColor), currentPosition.X, currentPosition.Y, _width, _height);
        }
    }


}