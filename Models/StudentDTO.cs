namespace ApiUniversity.Models;


public class StudentDTO {
    public int ID {get; set;}
    public string LastName {get; set;}
    public string FirstName {get; set;}
    public DateTime? EnrollmentDate {get;set;}

    public List<Enrollment> Enrollements {get;set;}

    public StudentDTO() { }

    public StudentDTO(Student student)
    {
        ID = student.ID;
        LastName = student.LastName;
        FirstName = student.FirstName;
        EnrollmentDate = student.EnrollmentDate;
        Enrollements = student.Enrollements;
    }
}