using PEM.Domain.Entities.Base;

namespace PEM.Domain.Entities
{
    public class User : EntityBase
    {
        public User(string firstName, string lastName, string email, string password) 
        {
            FirstName = firstName;
            LastName = lastName;
            Email = email;
            Password = password;

            SetNewEntity();
        }

        public Guid Id { get; private set; }
        public string FirstName { get; private set; }
        public string LastName { get; private set; }
        public string Email { get; private set; }
        public string Password { get; private set; }

        public IList<Expense> Expenses { get; private set; }
        public IList<Notification> Notifications { get; private set; }
        public IList<RecurringExpense> RecurringExpenses { get; private set; }
        public IList<Budget> Budgets { get; private set; }

        public void UpdatePasswordHash(string newPasswordHash)
        {
            Password = newPasswordHash;
        }
    }
}
