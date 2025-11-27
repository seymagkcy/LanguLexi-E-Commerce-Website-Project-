using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LanguLexi.Core.Entities
{
    public class Teacher : IEntityLanguLexi
    {
        public int Id { get; set; }

        [Display(Name = "Adı")]
        public string FirstName { get; set; }

        [Display(Name = "Soyadı")]
        public string LastName { get; set; }

        [Display(Name = "Unvan")]
        public string? Title { get; set; }     
                                               
        [Display(Name= "Hakkında")]
        public string? Bio {  get; set; }      

        [Display(Name = "Profil Resmi")]
        public string? ProfileImage { get; set; }

        [Display(Name = "Aktif Mi?")]
        public bool IsActive { get; set; }

        [Display(Name= "Puan")]
        [Range(0d,5d)]
        public double? Rating { get; set; }  
                                         
        [Display(Name = "Oluşturulduğu Tarih"), ScaffoldColumn(false)]
        public DateTime DateCreated { get; set; } = DateTime.Now;

        public Guid? TeacherGuid { get; set; } = Guid.NewGuid();   

        public List<Course>? Courses { get; set; }       

    }
}
