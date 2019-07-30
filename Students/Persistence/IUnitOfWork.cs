using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Students.Persistence
{
    public class UnitOfWork : IUnitOfWork
    {

        readonly IStudentContext _context;

        public UnitOfWork(IStudentContext context)
        {
            this._context = context;
        }

        public void SaveChanges()
        {
            this._context.SaveChanges();
        }
    }

    public interface IUnitOfWork
    {
        void SaveChanges();
    }
}
