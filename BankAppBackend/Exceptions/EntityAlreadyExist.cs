namespace BankAppBackend.Exceptions
{
    public class EntityAlreadyExist:Exception
    {
        public EntityAlreadyExist(string exceptionMessage):base(exceptionMessage) { }
    }
}
