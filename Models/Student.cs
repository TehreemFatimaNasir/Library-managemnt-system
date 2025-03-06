using System.ComponentModel.DataAnnotations;

namespace librarymanagement.Models
{
    public class Student
    {
        [Key]
        public int Id { get; set; }
        public string name { get; set; }
        public int studentid { get; set; }
        public string semester { get; set; }
        public string department { get; set; }
        public string contactnumber { get; set; }
    }
}
