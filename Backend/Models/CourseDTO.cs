namespace Backend.Models
{
    public class CourseDTO
    {
        public string Title { get; set; }
        public int PracticalTime { get; set; }
        public int TheoryTime { get; set; }
        public string Description { get; set; }
        public bool CanSubscribe { get; set; } = true;
        public int Id { get; set; }
    }
}