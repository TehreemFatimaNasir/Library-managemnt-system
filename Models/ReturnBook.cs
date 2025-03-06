namespace librarymanagement.Models
{
    public class ReturnBook
    {
        public int Id { get; set; }
        public int studentid { get; set; }
        public string bookname { get; set; }
        public string authorname { get; set; }
        public DateTime returndate { get; set; }  
        public decimal fineamount { get; set; }
    }
}
