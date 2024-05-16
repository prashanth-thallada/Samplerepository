using System.ComponentModel.DataAnnotations;

namespace SampleAPI.Entities
{
	public class Order
	{
		public string Name { get; set; }
		public string Description { get; set; }

		[Key]
		public string UID { get; set; }
		public bool Invoiced { get; set; }
		public bool Deleted { get; set; }
		public long EntryDate { get; set; }
	}
}
