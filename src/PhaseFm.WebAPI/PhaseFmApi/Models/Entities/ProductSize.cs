using System.ComponentModel.DataAnnotations;

namespace PhaseFmApi.Models.Entities
{
  public class ProductSize
  {
		[Key]
		public int Id { get; set; }

		public int ProductId { get; set; }

		public int SizeId { get; set; }

		public virtual Size Size { get; set; } = null!;

		public virtual Product Product { get; set; } = null!;

		public DateTime? DateUpdated { get; set; }
		public DateTime DateCreated { get; set; }
		public bool IsDeleted { get; set; } = false;
		public DateTime? DateDeleted { get; set; }

		public object GetPrimaryKey()
		{
			return Id;
		}
	}
}
