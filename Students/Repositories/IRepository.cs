using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Students.Repositories
{
    public interface IRepository<T>
    {

        List<T> GetAll();

        T Update(T value);

        T Get(long id);

        void Create(T value);

        void Delete(T value);

    }
}
