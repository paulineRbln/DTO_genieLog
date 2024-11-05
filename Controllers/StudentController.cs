using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ApiUniversity.Models;

namespace ApiUniversity.Controllers;

[ApiController]
[Route("api/student")]
public class StudentController : ControllerBase
{
    private readonly DBContext _context;

    public StudentController(DBContext context)
    {
        _context = context;
    }

    // GET: api/student
    [HttpGet]
    /*[SwaggerOperation(
    Summary = "Obtenir la liste des étudiants",
    Description = "Renvoie la liste complète des étudiants")]
    [SwaggerResponse(StatusCodes.Status200OK, "Liste des étudiants récupérée avec succès", typeof(IEnumerable<Todo>))]
    [SwaggerResponse(StatusCodes.Status404NotFound, "Aucun étudiant trouvé")]*/
    public async Task<ActionResult<IEnumerable<StudentDTO>>> GetStud()
    {
        // Récupérer tous les todos
        var students = _context.Students.Select(x => new StudentDTO(x));
        return await students.ToListAsync();
    }

    // GET: api/student/2
    [HttpGet("{id}")]
    public async Task<ActionResult<StudentDTO>> GetStudent(int id)
    {
        var student = await _context.Students.SingleOrDefaultAsync(t => t.ID == id);

        if (student == null)
            return NotFound();

        return new StudentDTO(student);
    }


    // POST: api/student
    [HttpPost]
    public async Task<ActionResult<StudentDTO>> PostStudent(Student student)
    {
        _context.Students.Add(student);
        await _context.SaveChangesAsync();

        return CreatedAtAction(nameof(GetStudent), new { id = student.ID }, student);
    }

    // PUT: api/todo/2
    [HttpPut("{id}")]
    public async Task<IActionResult> PutStudent(int id, StudentDTO student)
    {
        if (id != student.ID)
            return BadRequest();

        _context.Entry(student).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!_context.Students.Any(m => m.ID == id))
                return NotFound();
            else
                throw;
        }

        return NoContent();
    }

    // DELETE: api/todo/2
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteStudent(int id)
    {
        var student = await _context.Students.FindAsync(id);

        if (student == null)
            return NotFound();

        _context.Students.Remove(student);
        await _context.SaveChangesAsync();

        return NoContent();
    }


}