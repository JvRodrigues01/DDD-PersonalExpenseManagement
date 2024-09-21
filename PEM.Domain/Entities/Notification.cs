using PEM.Domain.Entities.Base;

namespace PEM.Domain.Entities
{
    public class Notification : EntityBase
    {
        public Notification()
        {
                
        }

        public Guid Id { get; private set; }
        public string Message { get; private set; }
        public DateTime NotificationDate { get; private set; }
        public Guid UserId { get; private set; }
        public User User { get; private set; }
    }
}
