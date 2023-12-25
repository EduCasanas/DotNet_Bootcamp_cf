namespace LibraryApp.entities
{
    public class Book
    {
        public int Id { get; set; }
        public required string Title { get; set; }
        public required string Autor { get; set; }
        public required string Category { get; set; }
        public bool IsAvailable { get; set; }
    }
}
