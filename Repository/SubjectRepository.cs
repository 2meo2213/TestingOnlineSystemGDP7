using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using System.Text;
using System.Threading.Tasks;
using Model;
using DataAccessLayer;
using Model.ViewModel;

namespace Repository
{
    public class SubjectRepository : Interfaces.ISubject<Subject>, IDisposable
    {

        private DBEntityContext context;
        public SubjectRepository(DBEntityContext context)
        {
            this.context = context;
        }

        public int Delete(int id)
        {
            var item = context.Subjects.Where(s => s.SubjectID == id).SingleOrDefault();
            try
            {
                if (item.Status == 0)
                {
                    context.Subjects.Remove(item);
                    return context.SaveChanges();
                }
            }
            catch
            {
                return 0;
            }

            return 0;
        }


        private bool disposed = false;
        public void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    context.Dispose();
                }
            }
            this.disposed = true;
        }
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        public IEnumerable<Subject> GetAll()
        {
            
               

            return context.Subjects.ToList();
            
        }

        public Subject GetById(int id)
        {
            return context.Subjects.SingleOrDefault();
        }

        public int Insert(Subject t)
        {
            context.Subjects.Add(t);
            return context.SaveChanges();
        }

        public IEnumerable<Subject> Search(string searchString)
        {
            return context.Subjects.Where(s => s.SubjectName.Contains(searchString));
        }

        public int Update(Subject t)
        {
            context.Entry(t).State = EntityState.Modified;
            return context.SaveChanges();
        }

        
    }
}
