using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LanguLexi.Core.Entities;

namespace LanguLexi.Service.Abstract
{
    public interface ICartService
    {
         void AddCourse(Course course, int quantity);
   
         void RemoveCourse(Course course);

         decimal TotalPrice();

         void ClearAllItems();

    }
}
