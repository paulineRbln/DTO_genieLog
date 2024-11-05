namespace ApiUniversity.Models;


public class Student {
    public int ID {get; set;}
    public string LastName {get; set;}
    public string FirstName {get; set;}
    public DateTime? EnrollmentDate {get;set;}

    public List<Enrollment> Enrollements {get;set;}
    
    public Student() { }

    public Student(StudentDTO studentDTO)
    {
        ID = studentDTO.ID;
        LastName = studentDTO.LastName;
        FirstName = studentDTO.FirstName;
        EnrollmentDate = studentDTO.EnrollmentDate;
        Enrollements = studentDTO.Enrollements;
    }
}
