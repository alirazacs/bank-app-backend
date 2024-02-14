namespace BankAppBackend.Exceptions
{
    public class EntityAlreadyExistException : Exception
    {
        public EntityAlreadyExistException(string exceptionMessage) : base(exceptionMessage) { }
    }

    public class EntityNotFoundException : Exception
    {
        public EntityNotFoundException(string exceptionMessage) : base(exceptionMessage) { }
    }
}
