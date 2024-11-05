using ApiUniversity.Data;
using ApiUniversity.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ApiUniversity.Controllers;

[ApiController]
[Route("api/enrollment")]
public class EnrollmentController : ControllerBase
{
    private readonly DBContext _context;

    public EnrollmentController(DBContext context)
    {
        _context = context;
    }

    [HttpGet("{id}")]
        public ActionResult<DetailedEnrollmentDTO> GetEnrollment(int id)
        {
            var enrollment = _context.Enrollments
                .Include(e => e.Student)  // Charger l'étudiant
                .Include(e => e.Course)   // Charger le cours
                .FirstOrDefault(e => e.Id == id);

            if (enrollment == null)
            {
                return NotFound();
            }
            
            return new DetailedEnrollmentDTO(enrollment);
        }
    
    [HttpPost]
    public ActionResult<DetailedEnrollmentDTO> CreateEnrollment(EnrollmentDTO enrollmentDTO)
    {
        // Validation de l'existence de l'étudiant et du cours
        var student = _context.Students.FirstOrDefault(s => s.ID == enrollmentDTO.StudentId);
        var course = _context.Courses.FirstOrDefault(c => c.Id == enrollmentDTO.CourseId);

        if (student == null || course == null)
        {
            return BadRequest("Etudiant ou cours non trouvés");
        }

        // Création de l'objet Enrollment
        var enrollment = new Enrollment
        {
            StudentId = enrollmentDTO.StudentId,
            CourseId = enrollmentDTO.CourseId,
            Grade = enrollmentDTO.Grade
        };

        // Ajouter l'inscription à la base de données
        _context.Enrollments.Add(enrollment);
        _context.SaveChanges();

        // Retourner l'objet créé sous forme de DetailedEnrollmentDTO
        var detailedEnrollmentDTO = new DetailedEnrollmentDTO(enrollment);
        return CreatedAtAction(nameof(GetEnrollment), new { id = enrollment.Id }, detailedEnrollmentDTO);
    }
}