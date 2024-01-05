using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PhaseFmApi.Models.Entities;
using PhaseFmApi.Models.ViewModel.ProductManagementViewModels;
using PhaseFmApi.Repository;

namespace PhaseFmApi.Controllers.AdminPortalControllers.Ecommerce.ProductManagementApiController
{
  [Route("api/productsize")]
  [ApiController]
  public class ProductSizeApiController : ControllerBase
  {
	private readonly IRepository<ProductSize> _productSizeRepository;
	private readonly PhaseFmContext _context;


	public ProductSizeApiController(IRepository<ProductSize> productSizeRepository, PhaseFmContext context)
	{
	  _productSizeRepository = productSizeRepository;

	  _context = context;
	}
	// CRUD Endpoints for product
	[HttpGet]
	public async Task<ActionResult> GetAllProductSize()
	{
	  var rows = await _productSizeRepository.GetAll();

	  return Ok(rows.Where(e => !e.IsDeleted));
	}

	[HttpPost]
	public async Task<ActionResult> AddProductSize(ProductSizeViewModel productSizeViewModel)
	{
	  var productSize = new ProductSize
	  {
		ProductId = productSizeViewModel.ProductId,

		SizeId = productSizeViewModel.SizeId
	  };

	  var row = await _context.ProductSize.Where(x => (x.ProductId == productSizeViewModel.ProductId || x.SizeId == productSizeViewModel.SizeId) && !x.IsDeleted)
					  .FirstOrDefaultAsync();

	  try
	  {
		if (row != null)
		{
		  return Conflict("You cannot add the same size to this product. Choose a different size for this product");

		}
		else
		{
		  await _productSizeRepository.Create(productSize);

		  return Ok(new
		  {
			message = "A new product size has been successfully added"
		  });
		}

	  }
	  catch (Exception)
	  {

		return BadRequest("Invalid Request");
	  }

	}
	[HttpPut]
	[Route("{productSizeId}")]
	public async Task<ActionResult> UpdateProductSize(ProductSizeViewModel productSizeViewModel, int productSizeId)
	{
	  try
	  {
		var ExistingProductSize = await _productSizeRepository.GetById(productSizeId);
		if (ExistingProductSize == null) return NotFound($"The product size does not exist");


		var row = await _context.ProductSize.Where(x => (x.ProductId == productSizeViewModel.ProductId || x.SizeId == productSizeViewModel.SizeId)
					&& productSizeViewModel.ProductId != ExistingProductSize.ProductId && productSizeViewModel.SizeId != ExistingProductSize.SizeId && !x.IsDeleted)
					.FirstOrDefaultAsync();

		if (row != null)
		{
		  return Conflict("You cannot update the size of the product to one that is already associated with this product.");
		}
		else
		{

		  ExistingProductSize.ProductId = productSizeViewModel.ProductId;

		  ExistingProductSize.SizeId = productSizeViewModel.SizeId;

		  await _productSizeRepository.Update(ExistingProductSize);

		  return Ok(new
		  {
			message = "This product size has been successfully updated"
		  });
		}


	  }
	  catch (Exception)
	  {

		return StatusCode(500, "Internal Server Error. Please contact support.");
	  }

	}
	[HttpGet]
	[Route("{productSizeId}")]
	public async Task<IActionResult> GetProductSizeByID(int productSizeId)
	{
	  try
	  {
		var cat = await _productSizeRepository.GetById(productSizeId);
		if (cat == null)
		{
		  return StatusCode(404, "Cannot Find Specified Product Size");
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
	[Route("{productSizeId}")]
	public async Task<ActionResult> DeleteProductSize(int productSizeId)
	{
	  try
	  {
		var ExistingProductSize = await _productSizeRepository.GetById(productSizeId);
		if (ExistingProductSize == null) return NotFound($"The product size does not exist");

		var row = await _context.ProductSize.Where(x => x.SizeId == productSizeId).FirstOrDefaultAsync();

		await _productSizeRepository.DeleteById(productSizeId);

		return Ok(ExistingProductSize);


	  }
	  catch (Exception)
	  {

		return StatusCode(500, "Internal Server Error. Please contact support.");
	  }

	}
  }
}
