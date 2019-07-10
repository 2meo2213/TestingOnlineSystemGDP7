using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
  public  class Subject
    {
        [Key]
        public int SubjectID { get; set; }
        public string SubjectName { get; set; }

        public int Status { get; set; }
        public DateTime? CreatedDate { get; set; }

      
        public virtual Exam Exam { get; set; }
        public virtual ICollection<Question> Questions { get; set; }
        public virtual ICollection<Lesson> Lessons { get; set; }



    }
}
