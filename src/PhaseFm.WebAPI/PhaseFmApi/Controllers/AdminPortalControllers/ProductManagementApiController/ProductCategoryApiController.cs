using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PhaseFmApi.Models.Entities;
using PhaseFmApi.Models.ViewModel;
using PhaseFmApi.Repository;

namespace PhaseFmApi.Controllers.AdminPortalControllers.ProductManagementApiController
{
	[Route("api/productcategory")]
	[ApiController]
	public class ProductCategoryApiController : ControllerBase
	{
		private readonly IRepository<ProductCategory> _productCategoryRepository;
		private readonly PhaseFmContext _context;


		public ProductCategoryApiController(IRepository<ProductCategory> productCategoryRepository, PhaseFmContext context)
		{
			_productCategoryRepository = productCategoryRepository;
			_context = context;
		}
		// CRUD
		[HttpGet]
		public async Task<ActionResult> GetAllProductCategory()
		{
			var cat = await _productCategoryRepository.GetAll();

			return Ok(cat.Where(e => !e.IsDeleted));
		}
		[HttpPost]
		public async Task<ActionResult> AddProductCategory(ProductCategoryViewModel productCategoryViewModel)
		{
			var productCategory = new ProductCategory
			{
				Name = productCategoryViewModel.Name,
				Description = productCategoryViewModel.Description
			};

			var row = await _context.Productcategories.Where(x => (x.Name == productCategoryViewModel.Name || x.Description == productCategoryViewModel.Description) && !x.IsDeleted)
							.FirstOrDefaultAsync();

			try
			{
				if (row != null)
				{
					return Conflict("You cannot add a product category with a product category name or description that already exists.");

				}
				else
				{
					await _productCategoryRepository.Create(productCategory);

					return Ok(new
					{
						message="A new product category has been successfully added"
					});
				}

			}
			catch (Exception)
			{

				return BadRequest("Invalid Request");
			}

		}
		[HttpPut]
		[Route("{productCategoryId}")]
		public async Task<ActionResult> UpdateProductCategory(ProductCategoryViewModel productCategoryViewModel, int productCategoryId)
		{
			try
			{
				var ExistingProductCategory = await _productCategoryRepository.GetById(productCategoryId);
				if (ExistingProductCategory == null) return NotFound($"The product category does not exist");

				var row = await _context.Productcategories.Where(x => (x.Name == productCategoryViewModel.Name || x.Description == productCategoryViewModel.Description)
							&& (productCategoryViewModel.Name != ExistingProductCategory.Name && productCategoryViewModel.Description != ExistingProductCategory.Description) && !x.IsDeleted)
							.FirstOrDefaultAsync();

				if (row != null)
				{
					return Conflict("You cannot update a product category with a product category name or description that already exists in other entries outside of this context.");
				}
				else
				{
					ExistingProductCategory.Name = productCategoryViewModel.Name;

					ExistingProductCategory.Description = productCategoryViewModel.Description;

					await _productCategoryRepository.Update(ExistingProductCategory);

					return Ok(new
					{
						message = "This new product category has been successfully updated"
					});
				}


			}
			catch (Exception)
			{

				return StatusCode(500, "Internal Server Error. Please contact support.");
			}

		}
		[HttpGet]
		[Route("{productCategoryId}")]
		public async Task<IActionResult> GetProductCategoryByID(int productCategoryId)
		{
			try
			{
				var cat = await _productCategoryRepository.GetById(productCategoryId);
				if (cat == null)
				{
					return StatusCode(404, "Cannot Find Specified product category");
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
		[Route("{productCategoryId}")]
		public async Task<ActionResult> DeleteProductCategory(int productCategoryId)
		{
			try
			{
				var ExistingProductCategory = await _productCategoryRepository.GetById(productCategoryId);
				if (ExistingProductCategory == null) return NotFound($"The product category does not exist");

				var row = await _context.Products.Where(x => x.ProductCategoryId == productCategoryId).FirstOrDefaultAsync();

				if (row != null)
				{
					return Conflict("You cannot delete a product category that is associated to an existing product. Delete all products associated to this product category");
				}
				else
				{
					await _productCategoryRepository.DeleteById(productCategoryId);

					return Ok(ExistingProductCategory);
				}

			}
			catch (Exception)
			{

				return StatusCode(500, "Internal Server Error. Please contact support.");
			}

		}
	}
}
