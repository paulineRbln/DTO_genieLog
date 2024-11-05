namespace ApiUniversity.Models;

public class Instructor{
    public int Id {get;set;}
    public string LastName {get;set;}
    public string FirstName {get;set;}
    public DateTime? HireDate {get;set;}
    
    public List<Department> AdministeredDepartments {get;set;}
    public List<Course> Courses {get;set;}
}