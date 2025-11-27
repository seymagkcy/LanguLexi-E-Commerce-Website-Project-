using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LanguLexi.Core.Entities.JoinEntities
{
    public class LevelCourse
    {
        [Display(Name = "Seviye No")]
        public int LevelId { get; set; }   


        [Display(Name = "Seviye")]
        public Level Level { get; set; }  

        [Display(Name = "Kurs No")]
        public int CourseId { get; set; }  

        [Display(Name = "Kurs")]
        public Course Course { get; set; }  

        // Payload(lar)

        [Display(Name = "Seviyenin Kurstaki Sırası")]
        public int Sequence { get; set; }   
    }
}
