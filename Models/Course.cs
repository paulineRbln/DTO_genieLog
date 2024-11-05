namespace ApiUniversity.Models;

public class Course{

    public int Id {get;set;}
    public string Title {get;set;}
    public int Credits {get;set;}
    public List<Enrollment> Enrollments {get;set;}
    public int DepartmentId {get;set;}
    public Department Department {get;set;}
    public List<Instructor> Instructors {get;set;}

    public Course() { }

    public Course(CourseDTO courseDTO)
    {
        Id = courseDTO.Id;
        Title = courseDTO.Title;
        Credits = courseDTO.Credits;
    }
}