using System;
namespace AcunMedyaMenu.Entities
{
	public class Order
	{
		public int OrderId { get; set; }
		public decimal TotalPrice { get; set; }
		public DateTime OrderDate { get; set; }
		public string OrderStatus { get; set; }
		public string CustomerName { get; set; }
	}
}

