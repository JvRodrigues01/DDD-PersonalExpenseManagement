using PEM.Domain.Entities.Base;

namespace PEM.Domain.Entities
{
    public class PaymentMethod : EntityBase
    {
        public PaymentMethod()
        {
            
        }

        public Guid Id { get; private set; }
        public string Description { get; private set; }
    }
}
