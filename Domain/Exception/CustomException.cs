namespace Domain.Exception
{
    /// <summary>
    /// Specific Exceptions Class
    /// </summary>
    public class CustomException : System.Exception
    {
        /// <summary>
        /// Initializes a new instance
        /// </summary>
        public CustomException()
            : base()
        {
        }

        /// <summary>
        /// Initializes a new instance with a specified error message.
        /// </summary>
        /// <param name="message">Message Error</param>
        public CustomException(string message)
            : base(message)
        {
        }

        /// <summary>
        /// Initializes a new instance with a specified error message and a reference 
        /// to the inner exception that is the cause of this exception.
        /// </summary>
        /// <param name="message">Message Error</param>
        public CustomException(string message, System.Exception innerException)
            : base(message, innerException)
        {
        }
    }
}
