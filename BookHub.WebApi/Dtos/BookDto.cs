using BookHub.WebApi.Entities.Enums;

namespace BookHub.WebApi.Dtos
{
    public class BookDto
    {
        public string Title { get; set; }

        public string Author { get; set; }

        public string ISBN { get; set; }
        public int PublishedYear { get; set; }

        public Genre? Genre { get; set; }

        public decimal Price { get; set; }
    }
}
