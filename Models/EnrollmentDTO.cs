namespace ApiUniversity.Models
{
    public class EnrollmentDTO
    {
        public int StudentId { get; set; }
        public int CourseId { get; set; }
        public Grade? Grade { get; set; }

        // Constructeur sans paramètres
        public EnrollmentDTO() { }
    }
}