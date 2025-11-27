using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LanguLexi.Core.Entities.JoinEntities
{
    public class TeacherCourse 
    {
        [Display(Name = "Öğretmen No")]
        public int TeacherId { get; set; }

        [Display(Name = "Öğretmen" )]
        public Teacher Teacher { get; set; }

        [Display(Name = "Kurs No")]
        public int CourseId { get; set; }

        [Display(Name = "Kurs")]
        public Course Course { get; set; }

        // Payload(lar)
        public int DisplaySequence { get; set; }  
    }
}
