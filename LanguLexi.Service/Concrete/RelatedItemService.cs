using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LanguLexi.Core.Entities;
using LanguLexi.DataAccess.Abstract;
using LanguLexi.Service.Abstract;

namespace LanguLexi.Service.Concrete
{
    public class RelatedItemService : IRelatedItemService
    {
        private readonly IRepository<Course> _courseRepository;

        public RelatedItemService(IRepository<Course> courseRepository)
        {
            _courseRepository = courseRepository;
        }

        public List<Course> GetRelatedCourses(Course course)
        {
            return _courseRepository.RetrieveAll(c => (c.Category.Id == course.CategoryId));   
        }
        
    }
}
