using ExpenseManager.Models;
using ExpenseManager.Services;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ExpenseManager.Controllers
{
    public class ExpenseController : Controller
    {
        private readonly IExpenseService _expenseService;

        public ExpenseController(IExpenseService expenseService)
        {
            _expenseService = expenseService;
        }
        // GET: /<controller>/
        public async Task<IActionResult> Index(string searchString)
        {
            var expenseData = await _expenseService.GetAllExpenses();
            if (!string.IsNullOrEmpty(searchString))
            {
                expenseData = await _expenseService.GetSearchResult(searchString);
            }
            return View(expenseData);
        }
        public async Task<IActionResult> AddEditExpenses(int itemId)
        {
            ExpenseReport model = new ExpenseReport();
            if (itemId > 0)
            {
                model = await _expenseService.GetExpenseData(itemId);
            }
            return PartialView("_expenseForm", model);
        }

        [HttpPost]
        public async Task<IActionResult> Create(ExpenseReport newExpense)
        {
            if (ModelState.IsValid)
            {
                if (newExpense.ItemId > 0)
                {
                    await _expenseService.UpdateExpense(newExpense);
                }
                else
                {
                    await _expenseService.AddExpense(newExpense);
                }
            }
            return RedirectToAction("Index");
        }

      [HttpPost]
        public async Task<IActionResult> Delete(int itemId)
        {
            await _expenseService.DeleteExpense(itemId);
            return RedirectToAction("Index");
        }

        public IActionResult ExpenseSummary()
        {
            return PartialView("_expenseReport");
        }

        public JsonResult GetWeeklyExpense()
        {
            var weeklyExpense = _expenseService.CalculateWeeklyExpense();
            return new JsonResult(weeklyExpense);
        }
        public JsonResult GetMonthlyExpense()
        {
            var monthlyExpense = _expenseService.CalculateMonthlyExpense();
            return new JsonResult(monthlyExpense);
        }
    }
}
