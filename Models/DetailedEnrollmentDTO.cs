namespace ApiUniversity.Models
{
    public class DetailedEnrollmentDTO
    {
        public int Id { get; set; }
        public Grade? Grade { get; set; }
        public StudentDTO Student { get; set; }
        public CourseDTO Course { get; set; }

        
        public DetailedEnrollmentDTO(Enrollment enrollment)
        {
            Id = enrollment.Id;
            Grade = enrollment.Grade;
            Student = new StudentDTO(enrollment.Student);  
            Course = new CourseDTO(enrollment.Course);    
        }

        
        public DetailedEnrollmentDTO() { }
    }
}