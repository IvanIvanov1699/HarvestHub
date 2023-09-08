using System;
using System.ComponentModel.DataAnnotations;

namespace HarvestHub.Entities
{
    public class Item
    {
        [Key]
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Category { get; set; }
        public string Region { get; set; }
        public string ImgSrc { get; set; }
        public decimal Price { get; set; }
        public DateTime Created { get; set; } = DateTime.Now;
    }
}
