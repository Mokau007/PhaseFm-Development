using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PhaseFmApi.Models.Entities;
using PhaseFmApi.Models.ViewModel.ProductManagementViewModels;
using PhaseFmApi.Repository;

namespace PhaseFmApi.Controllers.AdminPortalControllers.ProductManagementApiController
{
  [Route("api/color")]
  [ApiController]
  public class ColorsApiController : ControllerBase
  {

		private readonly IRepository<Color> _productColorRepository;
		private readonly PhaseFmContext _context;


		public ColorsApiController(IRepository<Color> productColorRepository, PhaseFmContext context)
		{
			_productColorRepository = productColorRepository;
			_context = context;
		}

		// CRUD Endpoints for product color
		[HttpGet]
		public async Task<ActionResult> GetAllColor()
		{
			var cat = await _productColorRepository.GetAll();

			return Ok(cat.Where(e => !e.IsDeleted));
		}
		[HttpPost]
		public async Task<ActionResult> AddColor(ColorViewModel productColorViewModel)
		{
			var color = new Color
			{
				Name = productColorViewModel.Name,
				ColorCode = productColorViewModel.ColorCode,
			};

			var row = await _context.Colors.Where(x => (x.Name == productColorViewModel.Name ) && !x.IsDeleted)
							.FirstOrDefaultAsync();

			try
			{
				if (row != null)
				{
					return Conflict("You cannot add a product color that already exists");

				}
				else
				{
					await _productColorRepository.Create(color);

					return Ok(new
					{
						message = "A new color has been successfully added"
					});
				}

			}
			catch (Exception)
			{

				return BadRequest("Invalid Request");
			}

		}
		[HttpPut]
		[Route("{colorId}")]
		public async Task<ActionResult> UpdateColor(ColorViewModel productColorViewModel, int colorId)
		{
			try
			{
				var ExistingColor = await _productColorRepository.GetById(colorId);
				if (ExistingColor == null) return NotFound($"The product color does not exist");

				var row = await _context.Colors.Where(x => (x.Name == productColorViewModel.Name )
							&& (productColorViewModel.Name != ExistingColor.Name ) && !x.IsDeleted)
							.FirstOrDefaultAsync();

				if (row != null)
				{
					return Conflict("You cannot update a product color with a color that already exists in other entries outside of this context.");
				}
				else
				{
					ExistingColor.Name = productColorViewModel.Name;

					ExistingColor.ColorCode = productColorViewModel.ColorCode;

					await _productColorRepository.Update(ExistingColor);

					return Ok(new
					{
						message = "This color has been successfully updated"
					});
				}


			}
			catch (Exception)
			{

				return StatusCode(500, "Internal Server Error. Please contact support.");
			}

		}
		[HttpGet]
		[Route("{colorId}")]
		public async Task<IActionResult> GetColorByID(int colorId)
		{
			try
			{
				var existingColor = await _productColorRepository.GetById(colorId);
				if (existingColor == null)
				{
					return StatusCode(404, "Cannot Find Specified product color");
				}
				else
				{
					return Ok(existingColor);
				}

			}
			catch (Exception)
			{
				return StatusCode(500, "Internal Server Error. Please contact support.");
			}
		}
		[HttpDelete]
		[Route("{colorId}")]
		public async Task<ActionResult> DeleteColor(int colorId)
		{
			try
			{
				var ExistingColor = await _productColorRepository.GetById(colorId);
				if (ExistingColor == null) return NotFound($"The product color does not exist");

				var row = await _context.Products.Where(x => x.Id == colorId).FirstOrDefaultAsync();

				if (row != null)
				{
					return Conflict("You cannot delete a product color that is associated to an existing product. Delete all color occurences associated to the product");
				}
				else
				{
					await _productColorRepository.DeleteById(colorId);

					return Ok(ExistingColor);
				}

			}
			catch (Exception)
			{

				return StatusCode(500, "Internal Server Error. Please contact support.");
			}

		}
	}

}

