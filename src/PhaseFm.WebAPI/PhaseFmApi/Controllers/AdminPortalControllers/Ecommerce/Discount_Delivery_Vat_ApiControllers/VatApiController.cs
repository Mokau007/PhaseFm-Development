using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PhaseFmApi.Models.Entities;
using PhaseFmApi.Models.ViewModel.Discount_Delivery_Vat_VM;
using PhaseFmApi.Repository;

namespace PhaseFmApi.Controllers.AdminPortalControllers.Ecommerce.Discount_Vat_Vat_ApiControllers
{
  [Route("api/vat")]
  [ApiController]
  public class VatApiController : ControllerBase
  {
		private readonly IRepository<Vat> _vatRepository;
		private readonly PhaseFmContext _context;


		public VatApiController(IRepository<Vat> vatRepository, PhaseFmContext context)
		{
			_vatRepository = vatRepository;
			_context = context;
		}

		// CRUD Endpoints for vat
		[HttpGet]
		public async Task<ActionResult> GetAllVat()
		{
			var rows = await _vatRepository.GetAll();

			return Ok(rows.Where(e => !e.IsDeleted));
		}

		[HttpPost]
		public async Task<ActionResult> AddVat(VatViewModel vatViewModel)
		{
			var vat = new Vat
			{
				Percentage = vatViewModel.Percentage,
				IsActive = false,
			};

			//This query checks if they is an existing vat entity equal to the request body.
			//It will return null if they is no duplicate entry
			var row = await _context.Vats.Where(x => x.Percentage == vatViewModel.Percentage && !x.IsDeleted)
							.FirstOrDefaultAsync();

			try
			{
				//Referential integrity to ensure that no duplicate entries can be added to the entity
				if (row != null)
				{
					return Conflict("You cannot add a vat percentage that already exists");

				}
				else
				{
					await _vatRepository.Create(vat);

					return Ok(new
					{
						message = "A new vat percentage has been successfully added"
					});
				}

			}
			catch (Exception)
			{

				return BadRequest("Invalid Request");
			}

		}

		[HttpPut]
		[Route("{vatId}")]
		public async Task<ActionResult> UpdateVat(VatViewModel vatViewModel, int vatId)
		{
			try
			{
				var ExistingVat = await _vatRepository.GetById(vatId);

				if (ExistingVat == null) return NotFound($"The vat percentage does not exist");

				//This query checks if they is an existing vat entity equal to the request body.
				//It will return null if they is no duplicate entry
				var row = await _context.Vats.Where(x => x.Percentage == vatViewModel.Percentage
							&& (vatViewModel.Percentage != ExistingVat.Percentage) && !x.IsDeleted)
							.FirstOrDefaultAsync();

				//Referential integrity to ensure that entity is not updated with existing entry.
				if (row != null)
				{
					return Conflict("You cannot update a vat percentage with an existing vat.");
				}
				else
				{
					ExistingVat.Percentage = vatViewModel.Percentage;

					await _vatRepository.Update(ExistingVat);

					return Ok(new
					{
						message = "This vat percentage has been successfully updated"
					});
				}


			}
			catch (Exception)
			{

				return StatusCode(500, "Internal Server Error. Please contact support.");
			}

		}

		[HttpGet]
		[Route("{vatId}")]
		public async Task<IActionResult> GetVatByID(int vatId)
		{
			try
			{
				var existingVat = await _vatRepository.GetById(vatId);
				if (existingVat == null)
				{
					return StatusCode(404, "Cannot Find Specified vat percentage");
				}
				else
				{
					return Ok(existingVat);
				}

			}
			catch (Exception)
			{
				return StatusCode(500, "Internal Server Error. Please contact support.");
			}
		}

		[HttpDelete]
		[Route("{vatId}")]
		public async Task<ActionResult> DeleteVat(int vatId)
		{
			try
			{
				var ExistingVat = await _vatRepository.GetById(vatId);
				if (ExistingVat == null) return NotFound($"The vat percentage does not exist");

				await _vatRepository.DeleteById(vatId);

				return Ok(ExistingVat);

			}
			catch (Exception)
			{

				return StatusCode(500, "Internal Server Error. Please contact support.");
			}

		}

		[HttpPut]
		[Route("activate-vat/{vatId}")]
		public async Task<ActionResult> ActivateVat(int vatId)
		{
			try
			{
				var SelectedVat = await _vatRepository.GetById(vatId);

				if (SelectedVat == null)
				{
					return NotFound("The vat percentage does not exist");
				}

				if (SelectedVat.IsActive == true)
				{

					SelectedVat.IsActive = false;

					await _vatRepository.Update(SelectedVat);
				}
				else
				{

					//Checks if they vat percentage that is already
					var ActiveVat = _context.Vats.Where(x => x.IsActive == true).FirstOrDefault();

					//If null it means that they is no active vat and it sets the selected vat to true.
					//This ensures that only one vat percentage can be active at a given time
					if (ActiveVat == null)
					{
						SelectedVat.IsActive = true;

						await _vatRepository.Update(SelectedVat);
					}
					else
					{
						ActiveVat.IsActive = false;

						await _vatRepository.Update(ActiveVat);

						SelectedVat.IsActive = true;

						await _vatRepository.Update(SelectedVat);

					}
				}
				return Ok(SelectedVat);
			}
			catch (Exception)
			{
				return StatusCode(500, "Internal Server Error. Please contact support.");
			}
		}
	}
}
