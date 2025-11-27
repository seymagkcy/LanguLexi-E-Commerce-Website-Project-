using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LanguLexi.Core.Entities;

namespace LanguLexi.Service.Abstract
{
    public interface IRelatedItemService
    {
        List<Course> GetRelatedCourses(Course course);

    }
}
