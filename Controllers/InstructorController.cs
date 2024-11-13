using ApiUniversity.Data;
using ApiUniversity.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ApiUniversity.Controllers;

[ApiController]
[Route("api/instructor")]
public class InstructorController : ControllerBase
{
    private readonly DBContext _context;

    public InstructorController(DBContext context)
    {
        _context = context;
    }

    // GET: api/instructor/5
    [HttpGet("{id}")]
    public async Task<ActionResult<DetailedInstructorDTO>> GetInstructor(int id)
    {
        // Attendre la tâche pour obtenir l'instructeur
        var instructor = await _context.Instructors
            .Include(i => i.AdministeredDepartments)  // Charger les départements administrés
            .Include(i => i.Courses)                 // Charger les cours
            .FirstOrDefaultAsync(e => e.Id == id);   // Recherche de l'instructeur

        if (instructor == null)
        {
            return NotFound();  // Retourner une réponse "Not Found" si l'instructeur n'est pas trouvé
        }
        
        // Retourner un DTO détaillé une fois l'instructeur trouvé
        return new DetailedInstructorDTO(instructor);
    }
    
    // POST: api/course
    [HttpPost]
    public async Task<ActionResult<InstructorDTO>> PostInstructor(InstructorDTO instructorDTO)
    {
        Instructor instructor = new Instructor(instructorDTO);

        _context.Instructors.Add(instructor);
        await _context.SaveChangesAsync();

        return CreatedAtAction(nameof(GetInstructor), new { id = instructor.Id }, new InstructorDTO(instructor));
    }

    // POST: api/instructor/{InstructorId}/course
    [HttpPost("{instructorId}/course")]
    public async Task<ActionResult> AssignCoursesToInstructor(int instructorId)
    {
        // Récupérer l'instructeur par son ID
        var instructor = await _context.Instructors
            .Include(i => i.Courses)  // Inclure les cours déjà assignés
            .FirstOrDefaultAsync(i => i.Id == instructorId);

        if (instructor == null)
        {
            return NotFound($"Instructor with ID {instructorId} not found.");
        }

        var courseIds = instructor.Courses.Select(c => c.Id).ToList();

        TaughtCourseDTO liste = new TaughtCourseDTO();
        liste.CourseIds = courseIds;


        // Sauvegarder les modifications dans la base de données
        await _context.SaveChangesAsync();

        // Retourner une réponse indiquant que l'opération a été réussie
        return Ok(liste); // 204 No Content pour indiquer que l'opération a réussi
    }


}