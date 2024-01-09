using GraphicsEnvironmentComp2.Commands;
using GraphicsEnvironmentComp2.GraphicContext;
using System.Drawing;

public class IncrementCommand : ICommandInterface
{
    private string _variableName;
    private int _incrementValue;
    private VariableContext _variableContext;

    public IncrementCommand(string variableName, int incrementValue, VariableContext variableContext)
    {
        _variableName = variableName;
        _incrementValue = incrementValue;
        _variableContext = variableContext;
    }

    public void Execute(Graphics graphics)
    {
        // Retrieve the current value of the variable, increment it, and update it back
        int currentValue = _variableContext.GetVariable(_variableName);
        _variableContext.SetVariable(_variableName, currentValue + _incrementValue);
    }
}
