namespace GPAWeb.BLL.Utilities.CustomExceptions
{
    internal class AlreadyExistsException : Exception
    {
        public AlreadyExistsException() { }

        public AlreadyExistsException(string message) : base(message) { }

        public AlreadyExistsException(string message, Exception inner) : base(message, inner) { }
    }
}
