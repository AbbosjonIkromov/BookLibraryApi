﻿using BookHub.WebApi.Entities.Enums;
using Microsoft.EntityFrameworkCore;

namespace BookHub.WebApi.Dtos
{
    public class CreateBookDto
    {
        public string Title { get; set; }

        public string Author { get; set; }

        public string ISBN { get; set; }
        public int PublishedYear { get; set; }

        public Genre? Genre { get; set; }

        public decimal Price { get; set; }
    }
}
