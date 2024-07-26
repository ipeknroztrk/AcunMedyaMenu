using System;
namespace AcunMedyaMenu.Entities
{
	public class Product
	{
		public int ProductId { get; set; }
		public string ProductName { get; set; }
		public string Description { get; set; }
		public string ImageUrl { get; set; }
		public decimal Price { get; set; }
		public bool Status { get; set; }

        public int CategoryId { get; set; }
        public virtual Category Category { get; set; }
    }
}

