using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PhaseFmApi.Models.Entities;
using PhaseFmApi.Models.ViewModel.ProductManagementViewModels;
using PhaseFmApi.Repository;

namespace PhaseFmApi.Controllers.AdminPortalControllers.Ecommerce.ProductManagementApiController
{
  [Route("api/producttype")]
  [ApiController]
  public class ProductTypeApiController : ControllerBase
  {
	private readonly IRepository<ProductType> _productTypeRepository;
	private readonly PhaseFmContext _context;


	public ProductTypeApiController(IRepository<ProductType> productTypeRepository, PhaseFmContext context)
	{
	  _productTypeRepository = productTypeRepository;
	  _context = context;
	}
	// CRUD Endpoints for product
	[HttpGet]
	public async Task<ActionResult> GetAllProductType()
	{

	  var rows = await _context.Producttypes.Where(x => !x.IsDeleted).Select(c => new ProductTypeViewModel
	  {
		Id = c.Id,
		Name = c.Name,
		Description = c.Description,
		CategoryName = c.ProductCategory.Name,
	  }).ToListAsync();

	  return Ok(rows);
	}
	[HttpPost]
	public async Task<ActionResult> AddProductType(ProductTypeViewModel productTypeViewModel)
	{
	  var productType = new ProductType
	  {
		Name = productTypeViewModel.Name,
		Description = productTypeViewModel.Description,
		ProductCategoryId = productTypeViewModel.ProductCategoryId
	  };

	  var row = await _context.Productcategories.Where(x => (x.Name == productTypeViewModel.Name || x.Description == productTypeViewModel.Description) && !x.IsDeleted)
					  .FirstOrDefaultAsync();

	  try
	  {
		if (row != null)
		{
		  return Conflict("You cannot add a product type with a product type name or description that already exists.");

		}
		else
		{
		  await _productTypeRepository.Create(productType);

		  return Ok(new
		  {
			message = "A new product type has been successfully added"
		  });
		}

	  }
	  catch (Exception)
	  {

		return BadRequest("Invalid Request");
	  }

	}
	[HttpPut]
	[Route("{productTypeId}")]
	public async Task<ActionResult> UpdateProductType(ProductTypeViewModel productTypeViewModel, int productTypeId)
	{
	  try
	  {
		var ExistingProductType = await _productTypeRepository.GetById(productTypeId);
		if (ExistingProductType == null) return NotFound($"The product category does not exist");

		var row = await _context.Productcategories.Where(x => (x.Name == productTypeViewModel.Name || x.Description == productTypeViewModel.Description)
					&& (productTypeViewModel.Name != ExistingProductType.Name || productTypeViewModel.Description != ExistingProductType.Description) && !x.IsDeleted)
					.FirstOrDefaultAsync();

		if (row != null)
		{
		  return Conflict("You cannot update a product category with a product type name or description that already exists in other entries outside of this context.");
		}
		else
		{
		  ExistingProductType.Name = productTypeViewModel.Name;

		  ExistingProductType.Description = productTypeViewModel.Description;

		  ExistingProductType.ProductCategoryId = productTypeViewModel.ProductCategoryId;

		  await _productTypeRepository.Update(ExistingProductType);

		  return Ok(new
		  {
			message = "This product type has been successfully updated"
		  });
		}


	  }
	  catch (Exception)
	  {

		return StatusCode(500, "Internal Server Error. Please contact support.");
	  }

	}
	[HttpGet]
	[Route("{productTypeId}")]
	public async Task<IActionResult> GetProductTypeByID(int productTypeId)
	{
	  try
	  {
		var cat = await _productTypeRepository.GetById(productTypeId);
		if (cat == null)
		{
		  return StatusCode(404, "Cannot Find Specified product type");
		}
		else
		{
		  return Ok(cat);
		}

	  }
	  catch (Exception)
	  {
		return StatusCode(500, "Internal Server Error. Please contact support.");
	  }
	}
	[HttpDelete]
	[Route("{productTypeId}")]
	public async Task<ActionResult> DeleteProductType(int productTypeId)
	{
	  try
	  {
		var ExistingProductType = await _productTypeRepository.GetById(productTypeId);
		if (ExistingProductType == null) return NotFound($"The product type does not exist");

		var row = await _context.Products.Where(x => x.ProductTypeId == productTypeId).FirstOrDefaultAsync();

		if (row != null)
		{
		  return Conflict("You cannot delete a product type that is associated to an existing product or product category. Delete all products associated to this product type");
		}
		else
		{
		  await _productTypeRepository.DeleteById(productTypeId);

		  return Ok(ExistingProductType);
		}

	  }
	  catch (Exception)
	  {

		return StatusCode(500, "Internal Server Error. Please contact support.");
	  }

	}
  }
}

