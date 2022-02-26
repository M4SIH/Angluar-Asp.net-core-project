using Backend.Database.Common;

namespace Backend
{
    public class Course : DBAutoId
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public int PracticalTime { get; set; }
        public int TheoryTime { get; set; }
    }
}