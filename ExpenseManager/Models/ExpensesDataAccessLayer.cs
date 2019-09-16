
//using Microsoft.EntityFrameworkCore;
//using System;
//using System.Collections.Generic;
//using System.Linq;

//namespace ExpenseManager.Models
//{
//    public class ExpensesDataAccessLayer
//    {
//        ExpenseDBContext db = new ExpenseDBContext();
//        public IEnumerable<ExpenseReport> GetAllExpenses()
//        {
//            try
//            {
//                return db.ExpenseReport.ToList();
//            }

//            catch 
//            {
//                throw;
//            }
//        }

//        public IEnumerable<ExpenseReport> GetSearchResult(string searchString)
//        {
//            List<ExpenseReport> expenseReports = new List<ExpenseReport>();
//            try
//            {
//                expenseReports = GetAllExpenses().ToList();
//                return expenseReports.Where(x => x.ItemName.IndexOf(searchString, StringComparison.OrdinalIgnoreCase) >= 0);
//            }
//            catch
//            {
//                throw;
//            }
//        }

//        public void AddExpense(ExpenseReport expense)
//        {
//            try
//            {
//                db.ExpenseReport.Add(expense);
//                db.SaveChanges();

//            }
//            catch
//            {
//                throw;
//            }
//        }
//        public int UpdateExpense(ExpenseReport expense)
//        {
//            try
//            {
//                db.Entry(expense).State = EntityState.Modified;
//                db.SaveChanges();
//                return 1;
//            }
//            catch
//            {
//                throw;
//            }
//        }
//        public ExpenseReport GetExpenseData(int id)
//        {
//            try
//            {
//                ExpenseReport expense = db.ExpenseReport.Find(id);
//                return expense;
//            }
//            catch
//            {
//                throw;
//            }
//        }

//        public void DeleteExpense(int id)
//        {
//            try
//            {
//                ExpenseReport entry = db.ExpenseReport.Find(id);
//                db.ExpenseReport.Remove(entry);
//                db.SaveChanges();
//            }
//            catch
//            {
//                throw;
//            }
//        }
        
//        public  Dictionary<string,decimal> CalculateMonthlyExpense()
//        {
//            //ExpensesDataAccessLayer expenses = new ExpensesDataAccessLayer();
//            //List<ExpenseReport> reports = new List<ExpenseReport>();
//            Dictionary<string, decimal> dictMonthlySum = new Dictionary<string, decimal>();

//            decimal foodSum = db.ExpenseReport.Where
//                (c => c.Category == "Food" && (c.ExpenseDate > DateTime.Now.AddMonths(-7)))
//                .Select(c => c.Amount)
//                .Sum();

//            decimal shoppingSum = db.ExpenseReport.Where
//                (c => c.Category == "Shopping" && (c.ExpenseDate > DateTime.Now.AddMonths(-7)))
//                .Select(c => c.Amount)
//                .Sum();

//            decimal travelSum=db.ExpenseReport.Where
//                  (c => c.Category == "Travel" && (c.ExpenseDate > DateTime.Now.AddMonths(-7)))
//                  .Select(c => c.Amount)
//                  .Sum();

//            decimal healthSum = db.ExpenseReport.Where
//                 (c => c.Category == "Health" && (c.ExpenseDate > DateTime.Now.AddMonths(-7)))
//                 .Select(c => c.Amount)
//                 .Sum();

//            dictMonthlySum.Add("Food", foodSum);
//            dictMonthlySum.Add("Shopping", shoppingSum);
//            dictMonthlySum.Add("Travel", travelSum);
//            dictMonthlySum.Add("Health", healthSum);
//            return dictMonthlySum;
//        }

//        public Dictionary<string,decimal> CalculateWeeklyExpense()
//        {
//            Dictionary<string, decimal> dictWeeklySum = new Dictionary<string, decimal>();
//            decimal foodSum=db.ExpenseReport.Where
//             (c => c.Category == "Food" && (c.ExpenseDate > DateTime.Now.AddDays(-28)))
//                .Select(cat => cat.Amount)
//                .Sum();

//            decimal shoppingSum = db.ExpenseReport.Where
//               (c => c.Category == "Shopping" && (c.ExpenseDate > DateTime.Now.AddDays(-28)))
//               .Select(c => c.Amount)
//               .Sum();

//            decimal travelSum = db.ExpenseReport.Where
//               (c => c.Category == "Travel" && (c.ExpenseDate > DateTime.Now.AddDays(-28)))
//               .Select(c => c.Amount)
//               .Sum();

//            decimal healthSum = db.ExpenseReport.Where
//               (c => c.Category == "Health" && (c.ExpenseDate > DateTime.Now.AddDays(-28)))
//               .Select(c => c.Amount)
//               .Sum();

//            dictWeeklySum.Add("Food", foodSum);
//            dictWeeklySum.Add("Shopping", shoppingSum);
//            dictWeeklySum.Add("Travel", travelSum);
//            dictWeeklySum.Add("Health", healthSum);

//            return dictWeeklySum;
//        }


//    }
//}
