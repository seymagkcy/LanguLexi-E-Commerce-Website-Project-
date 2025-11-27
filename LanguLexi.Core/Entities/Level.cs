using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LanguLexi.Core.Entities
{
    public  class Level : IEntityLanguLexi
    {
        public int Id { get; set; }

        [Display(Name = "Kur Seviyesi")]
        public string LevelCode { get; set; }  
        
        public string Description { get; set; } 


        [Display(Name = "Oluşturulduğu Tarih"), ScaffoldColumn(false)]
        public DateTime DateCreated { get; set; } = DateTime.Now;

        public List<Course>? Courses { get; set; }         

    }
}
