namespace BookStoreApp.API.Models.Book
{
    public class BookReadOnlyDto : BaseDto
    {
        public string Title { get; set; }
        public string Image { get; set; }
        public decimal Price { get; set; }
        public int Authorid { get; set; }
        public string AuthorName { get; set; }
    }
}
