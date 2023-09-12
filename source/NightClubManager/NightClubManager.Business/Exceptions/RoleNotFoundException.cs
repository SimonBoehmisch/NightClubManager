using System.Runtime.Serialization;

namespace NightClubManager.Business.Exceptions
{
    [Serializable]
    internal class RoleNotFoundException : Exception
    {
        private int id;

        public RoleNotFoundException()
        {
        }

        public RoleNotFoundException(int id)
        {
            this.id = id;
        }

        public RoleNotFoundException(string? message) : base(message)
        {
        }

        public RoleNotFoundException(string? message, Exception? innerException) : base(message, innerException)
        {
        }

        protected RoleNotFoundException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}