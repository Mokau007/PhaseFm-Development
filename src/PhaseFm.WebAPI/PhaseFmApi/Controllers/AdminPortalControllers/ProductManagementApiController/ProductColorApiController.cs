using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PhaseFmApi.Models.Entities;
using PhaseFmApi.Models.ViewModel;
using PhaseFmApi.Repository;

namespace PhaseFmApi.Controllers.AdminPortalControllers.ProductManagementApiController
{
  [Route("api/productcolor")]
  [ApiController]
  public class ProductColorApiController : ControllerBase
  {
		private readonly IRepository<ProductColor> _productColorRepository;
		private readonly PhaseFmContext _context;


		public ProductColorApiController(IRepository<ProductColor> productColorRepository, PhaseFmContext context)
		{
			_productColorRepository = productColorRepository;

			_context = context;
		}
		// CRUD Endpoints for product
		[HttpGet]
		public async Task<ActionResult> GetAllProductColor()
		{
			var rows = await _productColorRepository.GetAll();

			return Ok(rows.Where(e => !e.IsDeleted));
		}

		[HttpPost]
		public async Task<ActionResult> AddProductColor(ProductColorViewModel productColorViewModel)
		{
			var productColor = new ProductColor
			{
				ProductId = productColorViewModel.ProductId,

				ColorId = productColorViewModel.ColorId
			};

			var row = await _context.Productcolors.Where(x => (x.ProductId == productColorViewModel.ProductId || x.ColorId == productColorViewModel.ColorId) && !x.IsDeleted)
							.FirstOrDefaultAsync();

			try
			{
				if (row != null)
				{
					return Conflict("You cannot add the same product color that is already to this product. Choose a different product color");

				}
				else
				{
					await _productColorRepository.Create(productColor);

					return Ok(new
					{
						message = "A new product color has been successfully added"
					});
				}

			}
			catch (Exception)
			{

				return BadRequest("Invalid Request");
			}

		}
		[HttpPut]
		[Route("{productColorId}")]
		public async Task<ActionResult> UpdateProductColor(ProductColorViewModel productColorViewModel, int productColorId)
		{
			try
			{
				var ExistingProductColor = await _productColorRepository.GetById(productColorId);
				if (ExistingProductColor == null) return NotFound($"The product category does not exist");


				var row = await _context.Productcolors.Where(x => (x.ProductId == productColorViewModel.ProductId || x.ColorId == productColorViewModel.ColorId)
							&& (productColorViewModel.ProductId != ExistingProductColor.ProductId && productColorViewModel.ColorId != ExistingProductColor.ColorId) && !x.IsDeleted)
							.FirstOrDefaultAsync();

				if (row != null)
				{
					return Conflict("You cannot update a product color to one that is already associated with this product.");
				}
				else
				{

					ExistingProductColor.ProductId = productColorViewModel.ProductId;

					ExistingProductColor.ColorId = productColorViewModel.ColorId;

					await _productColorRepository.Update(ExistingProductColor);

					return Ok(new
					{
						message = "This product color has been successfully updated."
					});
				}


			}
			catch (Exception)
			{

				return StatusCode(500, "Internal Server Error. Please contact support.");
			}

		}
		[HttpGet]
		[Route("{productColorId}")]
		public async Task<IActionResult> GetProductColorByID(int productColorId)
		{
			try
			{
				var cat = await _productColorRepository.GetById(productColorId);
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
		[Route("{productColorId}")]
		public async Task<ActionResult> DeleteProductColor(int productColorId)
		{
			try
			{
				var ExistingProductColor = await _productColorRepository.GetById(productColorId);
				if (ExistingProductColor == null) return NotFound($"The product color does not exist");

					await _productColorRepository.DeleteById(productColorId);

					return Ok(ExistingProductColor);
				

			}
			catch (Exception)
			{

				return StatusCode(500, "Internal Server Error. Please contact support.");
			}

		}
	}
}
