using BookHub.WebApi.Entities.Enums;

namespace BookHub.WebApi.Entities
{
    public class Book : IAuditable
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string Author { get; set; }

        public int PublishedYear { get; set; }

        public string ISBN { get; set; }

        public Genre? Genre { get; set; }

        public decimal Price { get; set; }

        public bool Active { get; set; }

        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedTime { get; set; }
    }
}
