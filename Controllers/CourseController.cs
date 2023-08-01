using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StudentRegistration.Data;
using StudentRegistration.Models;

namespace StudentRegistration.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class CourseController : ControllerBase
    {
        private readonly StudentProfileDbContext dbContext;

        public CourseController(StudentProfileDbContext _dbContext)=> dbContext = _dbContext;

        [HttpGet]
        public async Task<IEnumerable<Course>> GetCourses()
        {
            return await dbContext.Courses.ToListAsync();
        }

        [HttpGet("{id}")]
        [ProducesResponseType(typeof(Course), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetById(int id)
        {
            var course = dbContext.Courses.FindAsync(id);
            return course == null ? NotFound() : Ok(course);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public async Task<IActionResult> Create(Course course)
        {
            await dbContext.Courses.AddAsync(course);
            await dbContext.SaveChangesAsync();
            return CreatedAtAction(nameof(GetById), new { id = course.Id }, course);
        }

        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Update(int id, Course course)
        {
            if(id != course.Id) return BadRequest(nameof(course));
            dbContext.Entry(course).State = EntityState.Modified;
            await dbContext.SaveChangesAsync();
            return NoContent();
        }

        [HttpDelete ("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Delete(int id)
        {
            var courseToDelete = await dbContext.Courses.FindAsync(id);
            if (courseToDelete == null) return NotFound();
            
            dbContext.Courses.Remove(courseToDelete);
            await dbContext.SaveChangesAsync();
            return NoContent();
        }
        
    }
}
