using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PhaseFmApi.Models.Entities;
using PhaseFmApi.Models.ViewModel.Discount_Delivery_Vat_VM;
using PhaseFmApi.Repository;

namespace PhaseFmApi.Controllers.AdminPortalControllers.Discount_Delivery_Discount_ApiControllers
{
  [Route("api/discount")]
  [ApiController]
  public class DiscountApiController : ControllerBase
  {
		private readonly IRepository<Discount> _discountRepository;
		private readonly PhaseFmContext _context;


		public DiscountApiController(IRepository<Discount> discountRepository, PhaseFmContext context)
		{
			_discountRepository = discountRepository;
			_context = context;
		}

		// CRUD Endpoints for discount
		[HttpGet]
		public async Task<ActionResult> GetAllDiscount()
		{
			var rows = await _discountRepository.GetAll();

			return Ok(rows.Where(e => !e.IsDeleted));
		}

		[HttpPost]
		public async Task<ActionResult> AddDiscount(DiscountViewModel discountViewModel)
		{
			var discount = new Discount
			{
				Percentage = discountViewModel.Percentage,

			};

			//This query checks if they is an existing discount entity equal to the request body.
			//It will return null if they is no duplicate entry
			var row = await _context.Discounts.Where(x => x.Percentage == discountViewModel.Percentage && !x.IsDeleted)
							.FirstOrDefaultAsync();

			try
			{
				//Referential integrity to ensure that no duplicate entries can be added to the entity
				if (row != null)
				{
					return Conflict("You cannot add a discount percentage that already exists");

				}
				else
				{
					await _discountRepository.Create(discount);

					return Ok(new
					{
						message = "A new discount percentage has been successfully added"
					});
				}

			}
			catch (Exception)
			{

				return BadRequest("Invalid Request");
			}

		}

		[HttpPut]
		[Route("{discountId}")]
		public async Task<ActionResult> UpdateDiscount(DiscountViewModel discountViewModel, int discountId)
		{
			try
			{
				var ExistingDiscount = await _discountRepository.GetById(discountId);

				if (ExistingDiscount == null) return NotFound($"The discount percentage does not exist");

				//This query checks if they is an existing discount entity equal to the request body.
				//It will return null if they is no duplicate entry
				var row = await _context.Discounts.Where(x => x.Percentage == discountViewModel.Percentage
							&& (discountViewModel.Percentage != ExistingDiscount.Percentage) && !x.IsDeleted)
							.FirstOrDefaultAsync();

				//Referential integrity to ensure that entity is not updated with existing entry.
				if (row != null)
				{
					return Conflict("You cannot update a discount percentage with an existing discount.");
				}
				else
				{
					ExistingDiscount.Percentage = discountViewModel.Percentage;

					await _discountRepository.Update(ExistingDiscount);

					return Ok(new
					{
						message = "This discount percentage has been successfully updated"
					});
				}


			}
			catch (Exception)
			{

				return StatusCode(500, "Internal Server Error. Please contact support.");
			}

		}

		[HttpGet]
		[Route("{discountId}")]
		public async Task<IActionResult> GetDiscountByID(int discountId)
		{
			try
			{
				var existingDiscount = await _discountRepository.GetById(discountId);
				if (existingDiscount == null)
				{
					return StatusCode(404, "Cannot Find Specified discount percentage");
				}
				else
				{
					return Ok(existingDiscount);
				}

			}
			catch (Exception)
			{
				return StatusCode(500, "Internal Server Error. Please contact support.");
			}
		}

		[HttpDelete]
		[Route("{discountId}")]
		public async Task<ActionResult> DeleteDiscount(int discountId)
		{
			try
			{
				var ExistingDiscount = await _discountRepository.GetById(discountId);
				if (ExistingDiscount == null) return NotFound($"The discount percentage does not exist");

				await _discountRepository.DeleteById(discountId);

				return Ok(ExistingDiscount);

			}
			catch (Exception)
			{

				return StatusCode(500, "Internal Server Error. Please contact support.");
			}

		}
	}
}
