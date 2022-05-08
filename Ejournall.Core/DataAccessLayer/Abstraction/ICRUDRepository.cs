using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ejournall.DataAccessLayer.Abstraction
{
    public interface ICRUDRepository<T>
    {
        List<T> GetAll();
        bool Insert(T entity);
        bool Update(T entity);
        bool Delete(int Id);
    }
}
