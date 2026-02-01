namespace BookStoreApp.API.Models
{
    public class VertualizeResponse<T>
    {
        public List<T> Items { get; set; }
        public int TotalSize { get; set; }
    }
}
