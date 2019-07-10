using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;
using Model.ViewModel;
namespace Repository.Interfaces
{
   public interface ISubject<T>
    {
        IEnumerable<ViewSubject> GetAll();
       
        IEnumerable<T> Search(string searchString);
        int Insert(T t);
        int Update(T t);
        int Delete(int id);
        T GetById(int id);

        
    }
}
