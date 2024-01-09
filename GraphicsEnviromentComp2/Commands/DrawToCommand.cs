using GraphicsEnvironmentComp2.Commands;
using GraphicsEnvironmentComp2.GraphicContext;
using System.Drawing;
using System;

public class DrawToCommand : ICommandInterface
{
    private readonly string _xParameter;
    private readonly string _yParameter;
    private readonly GraphicsContext _GraphicContext;
    private readonly VariableContext _VariableContext;

    public DrawToCommand(string xParameter, string yParameter, GraphicsContext GraphicContext, VariableContext VariableContext)
    {
        _xParameter = xParameter;
        _yParameter = yParameter;
        _GraphicContext = GraphicContext;
        _VariableContext = VariableContext;
    }

    public void Execute(Graphics graphics)
    {
        int x = TryToParseParameter(_xParameter, _VariableContext);
        int y = TryToParseParameter(_yParameter, _VariableContext);

        Point newPosition = new Point(x, y);

        graphics.DrawLine(_GraphicContext.CurrentPen, _GraphicContext.CurrentPosition, newPosition);
        _GraphicContext.UpdatePosition(newPosition);
    }

    private int TryToParseParameter(string parameter, VariableContext varContext)
    {
        if (int.TryParse(parameter, out int value))
        {
            return value;
        }
        else
        {
            return varContext.GetVariable(parameter);
        }
    }
}
