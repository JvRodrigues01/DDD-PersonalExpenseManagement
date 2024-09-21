using PEM.Domain.Entities.Base;
using PEM.Domain.Enums;

namespace PEM.Domain.Entities
{
    public class Budget : EntityBase
    {
        public Budget() 
        {
        
        }

        public Guid Id { get; private set; }
        public decimal Amount { get; private set; } 
        public BudgetPeriodEnum Period { get; private set; }
        public Guid UserId { get; private set; }
        public User User { get; private set; }
    }
}
