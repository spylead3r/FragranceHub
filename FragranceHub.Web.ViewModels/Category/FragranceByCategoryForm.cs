﻿namespace FragranceHub.Web.ViewModels.Category
{
    public class FragranceByCategoryForm
    {
        public string Id { get; set; } = null!;

        public string Name { get; set; } = null!;

        public string ImageUrl { get; set; } = null!;

        public string Category { get; set; } = null!;

        public decimal Price { get; set; }
    }
}
