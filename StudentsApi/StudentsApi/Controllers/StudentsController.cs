using Microsoft.AspNetCore.Mvc;
using StudentsApi.Models;
using StudentsApi.Models;
using StudentAPI.Services;
using StudentAPI.Services;
using StudentsApi.Models;

namespace StudentAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class StudentsController : ControllerBase
    {
        private readonly StudentService _service;

        public StudentsController(StudentService service)
        {
            _service = service;
        }

        // GET: api/students
        [HttpGet]
        public IActionResult GetAll()
        {
            var students = _service.GetAll();
            return Ok(students);
        }

        // GET: api/students/{id}
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var student = _service.GetById(id);
            if (student == null)
                return NotFound();
            return Ok(student);
        }

        // POST: api/students
        [HttpPost]
        public IActionResult Add(Student student)
        {
            var createdStudent = _service.Add(student);
            return CreatedAtAction(nameof(GetById), new { id = createdStudent.Id }, createdStudent);
        }

        // PUT: api/students/{id}
        [HttpPut("{id}")]
        public IActionResult Update(int id, Student student)
        {
            var updated = _service.Update(id, student);
            if (!updated)
                return NotFound();
            return NoContent(); // 204
        }

        // DELETE: api/students/{id}
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var deleted = _service.Delete(id);
            if (!deleted)
                return NotFound();
            return NoContent(); // 204
        }
    }
}