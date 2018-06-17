using System.Collections.Generic;

namespace GPA_App.Models
{
    public class Student
    {
        public string Name { get; set; }

        public string MatricNo { get; set; }

        public List<Course> Results { get; set; } = new List<Course>();
    }
}
