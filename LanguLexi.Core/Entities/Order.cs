using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LanguLexi.Core.Entities
{
    public class Order : IEntityLanguLexi
    {
        public int Id { get; set; }

        [Display(Name = "Sipariş Numarası"), StringLength(50)]
        public string OrderNumber { get; set; }

        [Display(Name = "Sipariş Toplam Tutarı")]
        public decimal TotalPrice { get; set; }

        [Display(Name = "Sipariş Tarihi")]
        public DateTime OrderDate { get; set; }

        [Display(Name = "Sipariş Durumu")]
        public OrderStateEnum OrderState { get; set; }

        [Display(Name = "Kullanıcı"), StringLength(50)]
        public string FullNameOfUser { get; set; }    

        [Display(Name = "Kullanıcı No")]
        public int AppUserId { get; set; }  

        [Display(Name = "Kullanıcı")]
        public AppUser? AppUser { get; set; }  

        public List<OrderItem>? OrderItems { get; set; }  


    }

    public enum OrderStateEnum
    {
        [Display(Name = "Onay Bekliyor")]
        PendingApproval,
        [Display(Name = "Onaylandı")]
        Approved,
        [Display(Name = "Tamamlandı")]
        Completed
    }
}
