using ExpenseManager.Models;
using ExpenseManager.Persistence.Contexts;
using ExpenseManager.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExpenseManager.Persistence.Repositories
{
    public class ExpenseRepository : BaseRepository, IExpenseRepository
    {
        public ExpenseRepository(ExpenseDBContext context) : base(context)
        { }

        public  async Task AddExpense(ExpenseReport expense)
        {
            try
            {
                await _context.ExpenseReport.AddAsync(expense);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                //Todo Logging.
            }
        }

        public Dictionary<string, decimal> CalculateMonthlyExpense()
        {
            decimal foodSum = _context.ExpenseReport.Where
                (c => c.Category == "Food" && (c.ExpenseDate > DateTime.Now.AddMonths(-7)))
                .Select(c => c.Amount)
                .Sum();

            decimal shoppingSum = _context.ExpenseReport.Where
                (c => c.Category == "Shopping" && (c.ExpenseDate > DateTime.Now.AddMonths(-7)))
                .Select(c => c.Amount)
                .Sum();

            decimal travelSum = _context.ExpenseReport.Where
                  (c => c.Category == "Travel" && (c.ExpenseDate > DateTime.Now.AddMonths(-7)))
                  .Select(c => c.Amount)
                  .Sum();

            decimal healthSum = _context.ExpenseReport.Where
                 (c => c.Category == "Health" && (c.ExpenseDate > DateTime.Now.AddMonths(-7)))
                 .Select(c => c.Amount)
                 .Sum();
            var dictMonthlySum = new Dictionary<string, decimal>
            {
                { "Food", foodSum },
                { "Shopping", shoppingSum },
                { "Travel", travelSum },
                { "Health", healthSum }
            };
    
            return dictMonthlySum;
        }

        public  Dictionary<string, decimal> CalculateWeeklyExpense()
        {
        
            decimal foodSum = _context.ExpenseReport.Where
             (c => c.Category == "Food" && (c.ExpenseDate > DateTime.Now.AddDays(-28)))
                .Select(cat => cat.Amount)
                .Sum();

            decimal shoppingSum = _context.ExpenseReport.Where
               (c => c.Category == "Shopping" && (c.ExpenseDate > DateTime.Now.AddDays(-28)))
               .Select(c => c.Amount)
               .Sum();

            decimal travelSum = _context.ExpenseReport.Where
               (c => c.Category == "Travel" && (c.ExpenseDate > DateTime.Now.AddDays(-28)))
               .Select(c => c.Amount)
               .Sum();

            decimal healthSum = _context.ExpenseReport.Where
               (c => c.Category == "Health" && (c.ExpenseDate > DateTime.Now.AddDays(-28)))
               .Select(c => c.Amount)
               .Sum();

            var dictWeeklySum = new Dictionary<string, decimal>
            {
                { "Food", foodSum },
                { "Shopping", shoppingSum },
                { "Travel", travelSum },
                { "Health", healthSum }
            };
            return dictWeeklySum;
        }

        public async Task DeleteExpense(int expenseId)
        {
            try
            {
                ExpenseReport entry = await _context.ExpenseReport.FindAsync(expenseId);
                _context.ExpenseReport.Remove(entry);
               await _context.SaveChangesAsync();
            }
            catch(Exception ex)
            {
                //Logging.
            }
        }

        public  Task<IEnumerable<ExpenseReport>> GetAllExpenses()
        {
            var expenses= Task.Run(()=> _context.ExpenseReport.AsEnumerable());
            expenses.Wait();
            return expenses;
        }

        public async Task<ExpenseReport> GetExpenseData(int expenseId)
        {
            try
            {
                ExpenseReport expense = await _context.ExpenseReport.FindAsync(expenseId);
                return expense;
            }
            catch(Exception ex)
            {
                return new ExpenseReport();
                //Logging
            }
        }

        public  async Task<IEnumerable<ExpenseReport>> GetSearchResult(string searchString)
        {
            
            try
            {
                var expenseReports = await GetAllExpenses();
                return expenseReports.Where(x => x.ItemName.IndexOf(searchString, StringComparison.OrdinalIgnoreCase) >= 0);
            }
            catch(Exception ex)
            {
                return new List<ExpenseReport>
                {
                    new ExpenseReport()
                };
               //Logging.
            }
        }

        public async Task<int> UpdateExpense(ExpenseReport expense)
        {
            try
            {
                 _context.Entry(expense).State = EntityState.Modified;
                await _context.SaveChangesAsync();
                return 1;
            }
            catch (Exception ex)
            {
                //Todo Logging.
                return 0;
            }
        }
    }
}
