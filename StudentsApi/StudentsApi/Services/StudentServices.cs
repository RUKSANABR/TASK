using StudentsApi.Models;
using System.Xml.Linq;

namespace StudentAPI.Services
{
    public class StudentService
    {
        private static List<Student> students = new();
        private static int nextId = 1;

        public List<Student> GetAll() => students;

        public Student? GetById(int id) =>
            students.FirstOrDefault(s => s.Id == id);

        public Student Add(Student student)
        {
            student.Id = nextId++;
            students.Add(student);
            return student;
        }

        public bool Update(int id, Student updatedStudent)
        {
            var existing = GetById(id);
            if (existing == null) return false;

            existing.FullName = updatedStudent.FullName;
            existing.Course = updatedStudent.Course;
            existing.Age = updatedStudent.Age;
            return true;
        }

        public bool Delete(int id)
        {
            var student = GetById(id);
            if (student == null) return false;
            students.Remove(student);
            return true;
        }
    }
}