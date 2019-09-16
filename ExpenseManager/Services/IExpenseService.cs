using ExpenseManager.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExpenseManager.Services
{
    public interface IExpenseService
    {
        Task<IEnumerable<ExpenseReport>> GetAllExpenses();
        Task<IEnumerable<ExpenseReport>> GetSearchResult(string searchString);
        Task AddExpense(ExpenseReport expense);
        Task<int> UpdateExpense(ExpenseReport expense);
        Task<ExpenseReport> GetExpenseData(int expenseId);
        Task DeleteExpense(int expenseId);
        Dictionary<string, decimal> CalculateMonthlyExpense();
        Dictionary<string, decimal> CalculateWeeklyExpense();
    }
}
