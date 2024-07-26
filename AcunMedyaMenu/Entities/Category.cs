using System;
namespace AcunMedyaMenu.Entities
{
	public class Category
	{
		public int CategoryId { get; set; }
		public string  CategoryName { get; set; }
		public string Icon { get; set; }
		public string  Description { get; set; }

        public virtual ICollection<Product> Products { get; set; }

    }
}

