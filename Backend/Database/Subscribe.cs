using System;
using Backend.Database.Common;

namespace Backend.Database
{
    public class Subscribe : DBAutoId
    {
        public User User { get; set; }
        public Course Course { get; set; }
        public DateTime SubscribeTime { get; set; }
        public bool IsActive { get; set; }
    }
}