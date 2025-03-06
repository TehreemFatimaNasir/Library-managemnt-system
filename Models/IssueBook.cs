namespace librarymanagement.Models
{
    public class IssueBook
    {
        public int Id { get; set; }
        public int studentid { get; set; }
        public string studentname { get; set; }
        public string bookname { get; set; }
        public string authorname { get; set; }
        public DateTime issuedate { get; set; }
        public DateTime duedate { get; set; }
    }
}
