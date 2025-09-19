using System.ComponentModel.DataAnnotations;

namespace StudentRecord.Models
{
    public class Student
    {
        [Required]
        public string RollNumber { get; set; }

        public string Name { get; set; }

        public int Marks { get; set; }
    }
}