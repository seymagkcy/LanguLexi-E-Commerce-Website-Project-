using LanguLexi.Core.Entities;

namespace LanguLexi.WebUI.Models
{
    public class CourseDetailsViewModel
    {
        public Course? Course { get; set; }

        public List<Course>? RelatedCourses { get; set; }
    }
}
