using GraphicsEnviromentComp2.GraphicContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphicsEnviromentComp2.Helpers
{
    public static class CommandHelpers
    {
        public static int ParseParameter(string parameter, VariableContext variableContext)
        {
            // Attempt to parse the parameter as an integer, if fail then retrieve from variable context
            if (int.TryParse(parameter, out int result))
            {
                return result;
            }
            else
            {
                return variableContext.GetVariable(parameter);
            }
        }
    }
}
