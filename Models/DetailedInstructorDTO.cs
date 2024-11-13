namespace ApiUniversity.Models
{
    public class DetailedInstructorDTO
    {
        public int Id {get;set;}
        public string LastName {get;set;}
        public string FirstName {get;set;}
        public DateTime? HireDate {get;set;}

        public List<Department> AdministeredDepartments {get;set;}
        public List<CourseDTO> Courses {get;set;}

        public DetailedInstructorDTO() { }

        public DetailedInstructorDTO(Instructor instructor)
        {
            Id = instructor.Id;
            LastName = instructor.LastName;
            FirstName = instructor.FirstName;
            HireDate = instructor.HireDate;

            AdministeredDepartments = instructor.AdministeredDepartments;  
            Courses = instructor.Courses?.Select(course => new CourseDTO(course)).ToList() ?? new List<CourseDTO>();   
        }


    }
}