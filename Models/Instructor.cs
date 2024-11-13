namespace ApiUniversity.Models;

public class Instructor{
    public int Id {get;set;}
    public string LastName {get;set;}
    public string FirstName {get;set;}
    public DateTime? HireDate {get;set;}
    
    public List<Department> AdministeredDepartments {get;set;}
    public List<Course> Courses {get;set;}

    public Instructor(){}

    public Instructor(InstructorDTO instructorDTO)
    {
        Id = instructorDTO.Id;
        LastName = instructorDTO.LastName;
        FirstName = instructorDTO.FirstName;
        HireDate = instructorDTO.HireDate;
    }

    public Instructor(DetailedInstructorDTO instructorDTO)
    {
        Id = instructorDTO.Id;
        LastName = instructorDTO.LastName;
        FirstName = instructorDTO.FirstName;
        HireDate = instructorDTO.HireDate;

        AdministeredDepartments= instructorDTO.AdministeredDepartments;
        Courses = instructorDTO.Courses?.Select(course => new Course(course)).ToList() ?? new List<Course>();  
    }
}
