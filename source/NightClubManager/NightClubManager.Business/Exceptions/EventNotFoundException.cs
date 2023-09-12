using System.Runtime.Serialization;

namespace NightClubManager.Business.Exceptions
{
    [Serializable]
    internal class EventNotFoundException : Exception
    {
        private int id;

        public EventNotFoundException()
        {
        }

        public EventNotFoundException(int id)
        {
            this.id = id;
        }

        public EventNotFoundException(string? message) : base(message)
        {
        }

        public EventNotFoundException(string? message, Exception? innerException) : base(message, innerException)
        {
        }

        protected EventNotFoundException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}