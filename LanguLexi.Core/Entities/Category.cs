using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LanguLexi.Core.Entities
{
    public class Category : IEntityLanguLexi
    {
        public int Id { get; set; }

        [Display(Name = "Adı")]
        public string Name { get; set; }

        [Display(Name = "Açıklama")]
        public string? Description { get; set; }

        [Display(Name = "Resim")]
        public string? Image {  get; set; }

        [Display(Name= "Aktif Mi?")]
        public bool IsActive { get; set; }        

        [Display(Name = "Sıra No")]
        public int SequenceNo { get; set; }

        [Display(Name = "Üst Kategori No")]
        public int ParentId { get; set; }  

        [Display(Name = "Oluşturulduğu Tarih"), ScaffoldColumn(false)]
        public DateTime DateCreated { get; set; } = DateTime.Now;

        public List<Course>? Courses { get; set; } 
    }
}
