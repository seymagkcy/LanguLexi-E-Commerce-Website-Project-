using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LanguLexi.Core.Entities
{
    public class Course : IEntityLanguLexi 
    {
        public int Id { get; set; }

        [Display(Name= "Kurs Başlığı")]
        public string Title { get; set; }

        [Display(Name = "Açıklama")]
        public string? Description { get; set; }

        [Display(Name= "Fiyat")]
        public decimal Price { get; set; }

        [Display(Name = "Kurs Kodu")]
        public string? CourseCode { get; set; }
 
        [Display(Name= "Resim")]
        public string? Image { get; set; }

        [Display(Name = "Aktif Mi?")]
        public bool IsActive { get; set; }

        [Display(Name ="Anasayfada Gösteriliyor Mu?")]
        public bool IsHome {  get; set; }

        [Display(Name = "Sıra No")]
        public int SequenceNo { get; set; }

        [Display(Name = "Puan")]
        [Range(0d,5d)]
        public double? Rating { get; set; }   
                                             
        [Display(Name = "Oluşturulduğu Tarih"), ScaffoldColumn(false)]
        public DateTime DateCreated { get; set; } = DateTime.Now;

        [Display(Name = "Kategori No")]
        public int? CategoryId { get; set; }     


        [Display(Name = "Kategori")]
        public Category? Category { get; set; }    

        public List<Level>? Levels { get; set; }   


        public List<Teacher>? Teachers { get; set; }    


    }
}
