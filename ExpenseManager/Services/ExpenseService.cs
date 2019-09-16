using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ExpenseManager.Models;
using ExpenseManager.Repositories;

namespace ExpenseManager.Services
{
    public class ExpenseService : IExpenseService
    {
        private readonly IExpenseRepository _expenseRepository;
        public ExpenseService(IExpenseRepository expenseRepository)
        {
            _expenseRepository = expenseRepository;
        }
        public async Task AddExpense(ExpenseReport expense)
        {
            await _expenseRepository.AddExpense(expense);
        }

        public  Dictionary<string, decimal> CalculateMonthlyExpense()
        {
            return  _expenseRepository.CalculateMonthlyExpense();
        }

        public Dictionary<string, decimal> CalculateWeeklyExpense()
        {
            return  _expenseRepository.CalculateWeeklyExpense();
        }

        public async Task DeleteExpense(int expenseId)
        {
            await _expenseRepository.DeleteExpense(expenseId);
        }

        public async Task<IEnumerable<ExpenseReport>> GetAllExpenses()
        {
            return await _expenseRepository.GetAllExpenses();
        }

        public async Task<ExpenseReport> GetExpenseData(int expenseId)
        {
            return await _expenseRepository.GetExpenseData(expenseId);
        }

        public async Task<IEnumerable<ExpenseReport>> GetSearchResult(string searchString)
        {
            return await _expenseRepository.GetSearchResult(searchString);
        }

        public async Task<int> UpdateExpense(ExpenseReport expense)
        {
            return await _expenseRepository.UpdateExpense(expense);
        }
    }
}
