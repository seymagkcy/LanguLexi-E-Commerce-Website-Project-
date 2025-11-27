using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LanguLexi.Core.Entities;
using LanguLexi.Service.Abstract;

namespace LanguLexi.Service.Concrete
{
    public class CartService : ICartService
    {
        public List<CartItem> CartItems = new();

        public void AddCourse(Course course, int quantity)
        {
            var kurs = CartItems.FirstOrDefault(c => c.Course.Id == course.Id);

            if (kurs == null)
            {
                CartItems.Add(new CartItem
                {
                    Course = course, 
                    Quantity = quantity
                });
            }
            else if ((kurs != null) && (kurs.Quantity == 1))
            {      
            }
        }

        public void RemoveCourse(Course course)
        {
            CartItems.RemoveAll(c => c.Course.Id == course.Id);
        }

        public decimal TotalPrice()
        {
            return CartItems.Sum(c => c.Course.Price * c.Quantity);
        }

        public void ClearAllItems()
        {
            CartItems.Clear();
        }
    }
}
