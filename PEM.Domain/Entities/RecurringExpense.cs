using PEM.Domain.Entities.Base;
using PEM.Domain.Enums;

namespace PEM.Domain.Entities
{
    public class RecurringExpense : EntityBase
    {
        public RecurringExpense()
        {
            
        }

        public Guid Id { get; private set; }
        public string Description { get; private set; }
        public decimal Amount { get; private set; }
        public ExpenseFrequencyEnum Frequency { get; private set; }
        public DateTime StartDate { get; private set; }
        public DateTime? EndDate { get; private set; }
        public Guid UserId { get; private set; }
        public User User { get; private set; }
    }
}
