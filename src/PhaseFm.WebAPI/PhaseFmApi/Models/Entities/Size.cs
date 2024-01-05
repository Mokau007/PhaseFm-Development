using System.ComponentModel.DataAnnotations;

namespace PhaseFmApi.Models.Entities
{
  public class Size
  {
		[Key]
		public int Id { get; set; }

		public string Name { get; set; } = null!;

		public string Description { get; set; } = null!;

		public virtual ICollection<ProductSize> ProductSizes { get; set; } = new List<ProductSize>();

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
