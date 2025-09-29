using ContosoUniversity.Models;
using Microsoft.EntityFrameworkCore;
using System.Xml.Linq;


namespace ContosoUniversity.Data
{
    public class ListData
    {
        public static async Task Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new SchoolContext(
                serviceProvider.GetRequiredService<
                    DbContextOptions<SchoolContext>>()))
            {
               
                var xmlFilePath = Path.Combine(Directory.GetCurrentDirectory(), "Data", "SeedData.xml");

                var doc = XDocument.Load(xmlFilePath);

                var students = doc.Root.Elements("Student")
                    .Select(p => new Student
                    {
                        LastName = p.Element("LastName")?.Value,
                        FirstMidName = p.Element("FirstMidName")?.Value,
                        EnrollmentDate = DateTime.Parse(p.Element("EnrollmentDate")?.Value)
                    })
                    .ToList();
                foreach (var s in students)
                {
                    if (!context.Student.Any(e => e.LastName == s.LastName && e.FirstMidName == s.FirstMidName && e.EnrollmentDate == s.EnrollmentDate))
                    {
                        context.Student.Add(s);
                    }


                    
                }
                await context.SaveChangesAsync();
            }
        }
        public void ExportToXml(IServiceProvider serviceProvider)
        {
            using (var context = new SchoolContext(
                serviceProvider.GetRequiredService<
                    DbContextOptions<SchoolContext>>()))
            {
                XDocument xmlDocument = new XDocument(new XDeclaration("1.0", "utf-8", "yes"),
                new XElement("Students",
                    from student in context.Student
                    select new XElement("Student", new XAttribute("Id", student.ID),
                        new XElement("LastName", student.LastName),
                        new XElement("FirstMidName", student.FirstMidName),
                        new XElement("EnrollmentDate", student.EnrollmentDate.ToString("yyyy-MM-dd"))
                    )
                )
            );







                    var xmlFilePath = Path.Combine(Directory.GetCurrentDirectory(), "Data", "SeedData.xml");

               

                xmlDocument.Save(xmlFilePath);
            }



        }
    }
}
        
    
               