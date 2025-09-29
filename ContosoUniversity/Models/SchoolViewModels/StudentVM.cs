using System.ComponentModel.DataAnnotations;

namespace ContosoUniversity.Models.SchoolViewModels
{
    public class StudentVM
    {
        public int ID { get; set; }

        [Required]
        [StringLength(50, ErrorMessage = "Name length can't be more than 50.")]
        public string LastName { get; set; }

        [Required]
        [StringLength(50, ErrorMessage = "Name length can't be more than 50.")]
        public string FirstMidName { get; set; }

        public DateTime EnrollmentDate { get; set; }
    }
}
