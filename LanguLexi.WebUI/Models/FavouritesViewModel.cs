using LanguLexi.Core.Entities;

namespace LanguLexi.WebUI.Models
{
    public class FavouritesViewModel
    {
        public List<Course>? FavouriteCourses { get; set; }

        public List<Course>? RelatedCoursesToFavourites { get; set; }
    }
}
