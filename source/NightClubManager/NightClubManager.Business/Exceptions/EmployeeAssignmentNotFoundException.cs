using System.Runtime.Serialization;

namespace NightClubManager.Business.Exceptions
{
    [Serializable]
    internal class EmployeeAssignmentNotFoundException : Exception
    {
        private int id;

        public EmployeeAssignmentNotFoundException()
        {
        }

        public EmployeeAssignmentNotFoundException(int id)
        {
            this.id = id;
        }

        public EmployeeAssignmentNotFoundException(string? message) : base(message)
        {
        }

        public EmployeeAssignmentNotFoundException(string? message, Exception? innerException) : base(message, innerException)
        {
        }

        protected EmployeeAssignmentNotFoundException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}