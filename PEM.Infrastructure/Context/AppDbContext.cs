using Microsoft.EntityFrameworkCore;
using PEM.Domain.Entities;
using PEM.Infrastructure.Mappings;

namespace PEM.Infrastructure.Context
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
        public DbSet<User> Users { get; set; }
        public DbSet<Expense> Expenses { get; set; }
        public DbSet<Notification> Notifications { get; set; }
        public DbSet<RecurringExpense> RecurringExpenses { get; set; }
        public DbSet<Budget> Budgets { get; set; }
        public DbSet<PaymentMethod> PaymentMethods { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new UserMapping());
            modelBuilder.ApplyConfiguration(new ExpenseMapping());
            modelBuilder.ApplyConfiguration(new NotificationMapping());
            modelBuilder.ApplyConfiguration(new RecurringExpenseMapping());
            modelBuilder.ApplyConfiguration(new BudgetMapping());
            modelBuilder.ApplyConfiguration(new PaymentMethodMapping());
        }
    }
}
