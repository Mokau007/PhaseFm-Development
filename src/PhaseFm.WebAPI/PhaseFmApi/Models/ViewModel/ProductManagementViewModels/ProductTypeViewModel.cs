namespace PhaseFmApi.Models.ViewModel.ProductManagementViewModels
{
  public class ProductTypeViewModel
  {
	public int Id { get; set; }

	public string Name { get; set; } = null!;

	public string Description { get; set; } = null!;

	public int ProductCategoryId { get; set; }

	public string? CategoryName { get; set; }
  }
}
