namespace ApiUniversity.Models;

public class InstructorDTO{
    public int Id {get;set;}
    public string LastName {get;set;}
    public string FirstName {get;set;}
    public DateTime? HireDate {get;set;}

    public InstructorDTO() {}

    public InstructorDTO(Instructor instructor)
    {
        Id = instructor.Id;
        LastName = instructor.LastName;
        FirstName = instructor.FirstName;
        HireDate = instructor.HireDate;
    }
}