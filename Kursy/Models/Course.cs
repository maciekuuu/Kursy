namespace Kursy.Models
{
    public class Course
    {
        public int Id { get; set; }
        public string Name { get; set; } = String.Empty;
        public bool Visible { get; set; } = true;
    }
}
