using PEM.Domain.Entities.Base;
using PEM.Domain.Enums;

namespace PEM.Domain.Entities
{
    public class Expense : EntityBase
    {
        public Expense() 
        {
            
        }

        public Guid Id { get; private set; }
        public string Description { get; private set; }
        public decimal Amount { get; private set; }
        public bool IsMonthly { get; private set; }
        public ExpenseCategory Category { get; private set; }
        public bool IsPaid { get; private set; }
        public DateTime? PaymentDate { get; private set; }
        public int? InstallmentCount { get; private set; }
        public int? CurrentInstallment { get; private set; }
        public DateTime EndDate { get; private set; }
        public Guid PaymentMethodId { get; private set; }
        public PaymentMethod PaymentMethod { get; private set; }
        public Guid UserId { get; private set; }
        public User User { get; private set; }
    }
}
