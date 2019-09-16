using ExpenseManager.Persistence.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExpenseManager.Persistence.Repositories
{
    public  abstract class BaseRepository
    {
        protected readonly ExpenseDBContext _context;
        public BaseRepository(ExpenseDBContext context)
        {
            _context = context;
        }
    }
}
