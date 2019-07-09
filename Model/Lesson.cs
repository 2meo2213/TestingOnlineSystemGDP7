using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
  public  class Lesson
    {
        [Key]
        public int LessonID { get; set; }
        public string LessonName { get; set; }

        public virtual ICollection<Question> Questions { get; set; }

    }
}
