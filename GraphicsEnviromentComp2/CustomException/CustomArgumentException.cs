using System;

namespace GraphicsEnviromentComp2.CustomException
{
    
    ///<summary>
    /// A custom exception class derived from ArgumentException. It is used to handle exceptions 
    /// specific to the application, providing a message that is suitable for end users.
    /// </summary>
    /// 
    public class CustomArgumentException : ArgumentException
    {
        public string UserFriendlyMessage { get; private set; }

        public CustomArgumentException(string systemMessage, string userFriendlyMessage)
            : base(systemMessage)
        {
            UserFriendlyMessage = userFriendlyMessage;
        }
    }
}
