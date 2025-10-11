using System.Xml.Serialization;

[XmlRoot("Seed")]
public class SeedDto
{
   [XmlArray("Courses"), XmlArrayItem("Course")]
   public List<CourseDto> Courses { get; set; } = new();

   [XmlArray("Enrollments"), XmlArrayItem("Enrollment")]
   public List<EnrollmentDto> Enrollments { get; set; } = new();

   [XmlArray("Instructors"), XmlArrayItem("Instructor")]
   public List<InstructorDto> Instructors { get; set; } = new();
   [XmlArray("OfficeAssignments"), XmlArrayItem("OfficeAssignment")]
   public List<OfficeAssignmentDto> OfficeAssignments { get; set; } = new();
   [XmlArray("Students"), XmlArrayItem("Student")]
   public List<StudentDto> Students { get; set; } = new();

   [XmlArray("Departments"), XmlArrayItem("Department")]
   public List<DepartmentDto> Departments { get; set; } = new();
}
public class CourseDto
{ 

			public int CourseID { get; set; }
			public string Title { get; set; } = "";
			public int Credits { get; set; }
			public string DepartmentRef { get; set; } = "";

	        [XmlArray("InstructorRefs"), XmlArrayItem("InstructorRef")]
		    public List<string> InstructorRefs { get; set; } = new();
}
public class EnrollmentDto
{ 
   public string StudentRef  { get; set; } = "";
   public int CourseRef	 { get; set; }
   public string? Grade { get; set; } = "";

}
public class InstructorDto {

	[XmlAttribute("id")]
    public string Id { get; set; } = "";
    public string FirstName { get; set; } = "";
    public string LastName { get; set; } = "";
    public DateTime HireDate { get; set; }

}
public class OfficeAssignmentDto { 
	
	public string InstructorRef { get; set; } = "";
	public string Location { get; set; } = "";

}
public class StudentDto {

	[XmlAttribute("id")]
    public string Id { get; set; } = "";
	public string FirstName { get; set; } = "";
	public string LastName { get; set; } = "";
	public DateTime EnrollmentDate { get; set; }

}

public class DepartmentDto {

	[XmlAttribute("id")]
    public string Id { get; set; } = "";
    public string Name { get; set; } = "";
	public decimal Budget { get; set; }
	public DateTime StartDate { get; set; }
	public string AdministratorRef { get; set; } = "";
}