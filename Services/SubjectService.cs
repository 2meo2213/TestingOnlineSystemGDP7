using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;
using Repository;
using Repository.Interfaces;
using DataAccessLayer;
namespace Services
{
    public class SubjectService : Interfaces.ISubjectService<Subject>
    {

        private ISubject<Subject> subject;
        public SubjectService()
        {
            subject = new SubjectRepository(new DBEntityContext());
        }
        public int Delete(int id)
        {
            try
            {
                return subject.Delete(id);
            }
            catch
            {
                return 0;
            }
        }

        public IEnumerable<Subject> GetAll()
        {
            return subject.GetAll();
        }

        public Subject GetById(int id)
        {
            return subject.GetById(id);
        }

        public int Insert(Subject t)
        {
            return subject.Insert(t);
        }

        public IEnumerable<Subject> Search(string searchString)
        {
            return subject.Search(searchString);
        }

        public int Update(Subject t)
        {
            return subject.Update(t);
        }
    }
}
