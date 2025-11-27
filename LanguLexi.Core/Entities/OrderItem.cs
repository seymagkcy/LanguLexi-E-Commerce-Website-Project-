using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace LanguLexi.Core.Entities
{
    public class OrderItem :IEntityLanguLexi
    {
        public int Id { get; set; }

        [Display(Name = "Miktar")]
        public int Quantity { get; set; }

        [Display(Name = "Birim Fiyat")]
        public decimal UnitPrice { get; set; }

        [Display(Name = "Sipariş Numarası")]
        public int OrderId { get; set; }  

        [Display(Name = "Sipariş")]
        public Order? Order { get; set; }  

        [Display(Name = "Kurs No")]
        public int CourseId { get; set; }  

        [Display(Name = "Kurs")]
        public Course? Course { get; set; }  


    }
}
