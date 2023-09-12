using System.Runtime.Serialization;

namespace NightClubManager.Business.Exceptions
{
    [Serializable]
    internal class RoleRequirementNotFoundException : Exception
    {
        private int id;

        public RoleRequirementNotFoundException()
        {
        }

        public RoleRequirementNotFoundException(int id)
        {
            this.id = id;
        }

        public RoleRequirementNotFoundException(string? message) : base(message)
        {
        }

        public RoleRequirementNotFoundException(string? message, Exception? innerException) : base(message, innerException)
        {
        }

        protected RoleRequirementNotFoundException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}