using System.Runtime.Serialization;

namespace NightClubManager.Business.Exceptions
{
    [Serializable]
    internal class EmployeeNotFoundException : Exception
    {
        private int id;

        public EmployeeNotFoundException()
        {
        }

        public EmployeeNotFoundException(int id)
        {
            this.id = id;
        }

        public EmployeeNotFoundException(string? message) : base(message)
        {
        }

        public EmployeeNotFoundException(string? message, Exception? innerException) : base(message, innerException)
        {
        }

        protected EmployeeNotFoundException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}