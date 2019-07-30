using Students.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Students.Repositories
{
    public class StudentRepository : IRepository<Student> {

        private readonly IStudentContext _context;
        
        public StudentRepository(IStudentContext context)
        {
            _context = context;
        }

        public List<Student> GetAll()
        {
            return _context.Student.ToList();
        }

        public Student Get(long id)
        {
            return _context.Student.FirstOrDefault(c => c.Id == id);
        }

        public Student Update(Student value)
        {
            _context.Student.Update(value);

            return null;
        }

        public void Create(Student value)
        {
            _context.Student.Add(value);
        }

        public void Delete(Student value)
        {
            _context.Student.Remove(value);
        }
    }
}
