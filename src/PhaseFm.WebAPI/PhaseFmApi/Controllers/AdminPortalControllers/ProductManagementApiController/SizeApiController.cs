using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PhaseFmApi.Models.Entities;
using PhaseFmApi.Models.ViewModel;
using PhaseFmApi.Repository;

namespace PhaseFmApi.Controllers.AdminPortalControllers.ProductManagementApiController
{
	[Route("api/size")]
	[ApiController]
	public class SizeApiController : ControllerBase
	{
		private readonly IRepository<Size> _sizeRepository;
		private readonly PhaseFmContext _context;


		public SizeApiController(IRepository<Size> sizeRepository, PhaseFmContext context)
		{
			_sizeRepository = sizeRepository;
			_context = context;
		}
		// CRUD Endpoints for product
		[HttpGet]
		public async Task<ActionResult> GetAllSize()
		{
			var cat = await _sizeRepository.GetAll();

			return Ok(cat.Where(e => !e.IsDeleted));
		}
		[HttpPost]
		public async Task<ActionResult> AddSize(SizeViewModel sizeViewModel)
		{
			var size = new Size
			{
				Name = sizeViewModel.Name,
				Description = sizeViewModel.Description,

			
			};

			var row = await _context.Sizes.Where(x => (x.Name == sizeViewModel.Name) && !x.IsDeleted)
							.FirstOrDefaultAsync();

			try
			{
				if (row != null)
				{
					return Conflict("You cannot add a size that already exists.");

				}
				else
				{
					await _sizeRepository.Create(size);

					return Ok(new
					{
						message = "A new size has been successfully added"
					});
				}

			}
			catch (Exception)
			{

				return BadRequest("Invalid Request");
			}

		}
		[HttpPut]
		[Route("{sizeId}")]
		public async Task<ActionResult> UpdateSize(SizeViewModel sizeViewModel, int sizeId)
		{
			try
			{
				var ExistingSize = await _sizeRepository.GetById(sizeId);
				if (ExistingSize == null) return NotFound($"The size does not exist");

				var row = await _context.Sizes.Where(x => (x.Name == sizeViewModel.Name)
							&& (sizeViewModel.Name != ExistingSize.Name) && !x.IsDeleted)
							.FirstOrDefaultAsync();

				if (row != null)
				{
					return Conflict("You cannot update a size to one that already exists in other entries outside of this context.");
				}
				else
				{
					ExistingSize.Name = sizeViewModel.Name;

					ExistingSize.Description = sizeViewModel.Description;

					await _sizeRepository.Update(ExistingSize);

					return Ok(new
					{
						message = "This size has been successfully updated"
					});
				}


			}
			catch (Exception)
			{

				return StatusCode(500, "Internal Server Error. Please contact support.");
			}

		}
		[HttpGet]
		[Route("{sizeId}")]
		public async Task<IActionResult> GetSizeByID(int sizeId)
		{
			try
			{
				var existingSize = await _sizeRepository.GetById(sizeId);
				if (existingSize == null)
				{
					return StatusCode(404, "Cannot Find Specified size");
				}
				else
				{
					return Ok(existingSize);
				}

			}
			catch (Exception)
			{
				return StatusCode(500, "Internal Server Error. Please contact support.");
			}
		}
		[HttpDelete]
		[Route("{sizeId}")]
		public async Task<ActionResult> DeleteSize(int sizeId)
		{
			try
			{
				var ExistingSize = await _sizeRepository.GetById(sizeId);
				if (ExistingSize == null) return NotFound($"The size does not exist");

				var row = await _context.ProductSize.Where(x => x.Id == sizeId).FirstOrDefaultAsync();

				if (row != null)
				{
					return Conflict("You cannot delete a size that is associated to an existing product. Delete all occurances of the size associated to this product");
				}
				else
				{
					await _sizeRepository.DeleteById(sizeId);

					return Ok(ExistingSize);
				}

			}
			catch (Exception)
			{

				return StatusCode(500, "Internal Server Error. Please contact support.");
			}

		}
	}

}



