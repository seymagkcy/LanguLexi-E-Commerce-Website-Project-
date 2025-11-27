using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LanguLexi.Core.Entities
{
    public class CartItem : IEntityLanguLexi
    {
        public int Id { get; set; }

        [Display(Name = "Kurs No")]
        public int CourseId { get; set; }    


        [Display(Name = "Kurs")]
        public Course Course { get; set; }   

        [Display(Name= "Miktar")]
        public int Quantity { get; set; }

    }
}
