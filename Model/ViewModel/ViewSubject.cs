using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.ViewModel
{
  public  class ViewSubject
    {
        public int SubjectID { get; set; }
        public string SubjectName { get; set; }

        public int Status { get; set; }
        public DateTime? CreatedDate { get; set; }

        public int ExamId { get; set; }
        public string NameExam { get; set; }

    }
}
