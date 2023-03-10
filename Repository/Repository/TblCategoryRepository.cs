using Microsoft.EntityFrameworkCore;
using Repository.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Repository
{
    public class TblCategoryRepository : RepositoryBase<TblCategory>
    {
        private readonly EventScheduleContext _context;
        private readonly DbSet<TblCategoryRepository> _dbSet;
        public TblCategoryRepository() {
            _context = new EventScheduleContext();
            _dbSet = _context.Set<TblCategoryRepository>();
        }
    }
}
