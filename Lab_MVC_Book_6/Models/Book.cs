namespace Lab_MVC_Book_6.Models
{
    public class Book
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string Author { get; set; } = null!;
        public string Genre { get; set; } = null!;
        public string Publishing { get; set; } = null!;
        public int YearOfPublishing { get; set; }
        public string FilePath { get; set; } = null!;
    }
}
