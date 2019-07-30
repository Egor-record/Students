using Microsoft.EntityFrameworkCore;
using Students.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Students.Persistence
{
    public class StudentContext : DbContext, IStudentContext
    {

        public DbSet<Student> Student { get; set; }


        public StudentContext(DbContextOptions<StudentContext> options)
            : base(options)
        {

        }


    }
}


public interface IStudentContext
{

    DbSet<Student> Student { get; set; }


    int SaveChanges();

}