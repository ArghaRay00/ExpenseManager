

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

using ExpenseManager.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace ExpenseManager.Controllers
{
    public class ExpenseController : Controller
    {
        ExpensesDataAccessLayer expenseManager = new ExpensesDataAccessLayer();
        // GET: /<controller>/
        public IActionResult Index(string searchString)
        {
            List<ExpenseReport> reports = new List<ExpenseReport>();

            reports = expenseManager.GetAllExpenses().ToList();
            if (!string.IsNullOrEmpty(searchString))
            {
                reports = expenseManager.GetSearchResult(searchString).ToList();
            }
            return View(reports);
        }
        public ActionResult AddEditExpenses(int itemId)
        {
            ExpenseReport model = new ExpenseReport();
            if (itemId > 0)
            {
                model = expenseManager.GetExpenseData(itemId);
            }
            return PartialView("_expenseForm", model);
        }

        [HttpPost]
        public ActionResult Create(ExpenseReport newExpense)
        {
            if (ModelState.IsValid)
            {
                if (newExpense.ItemId > 0)
                {
                    expenseManager.UpdateExpense(newExpense);
                }
                else
                {
                    expenseManager.AddExpense(newExpense);
                }
            }
            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult Delete(int id)
        {
            expenseManager.DeleteExpense(id);
            return RedirectToAction("Index");
        }

        public ActionResult ExpenseSummary()
        {
            return PartialView("_expenseReport");
        }

        public JsonResult GetWeeklyExpense()
        {
            Dictionary<string, decimal> weeklyExpense = expenseManager.CalculateWeeklyExpense();
            return new JsonResult(weeklyExpense);
        }
        public JsonResult GetMonthlyExpense()
        {
            Dictionary<string, decimal> monthlyExpense = expenseManager.CalculateWeeklyExpense();
            return new JsonResult(monthlyExpense);
        }
    }
}
