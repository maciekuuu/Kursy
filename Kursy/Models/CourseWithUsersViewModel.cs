namespace Kursy.Models
{
    public class CourseWithUsersViewModel
    {
        public Course Course { get; set; }
        public List<User>? Users { get; set; }
    }
}
