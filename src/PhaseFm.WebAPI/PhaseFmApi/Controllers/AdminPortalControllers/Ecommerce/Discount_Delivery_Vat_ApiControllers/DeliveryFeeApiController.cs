using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PhaseFmApi.Models.Entities;
using PhaseFmApi.Models.ViewModel.Discount_Delivery_Vat_VM;
using PhaseFmApi.Models.ViewModel.ProductManagementViewModels;
using PhaseFmApi.Repository;

namespace PhaseFmApi.Controllers.AdminPortalControllers.Discount_Delivery_Vat_ApiControllers
{
  [Route("api/delivery-fee")]
  [ApiController]
  public class DeliveryFeeApiController : ControllerBase
  {
		private readonly IRepository<Delivery> _deliveryFeeRepository;
		private readonly PhaseFmContext _context;


		public DeliveryFeeApiController(IRepository<Delivery> deliveryFeeRepository, PhaseFmContext context)
		{
			_deliveryFeeRepository = deliveryFeeRepository;
			_context = context;
		}

		// CRUD Endpoints for delivery
		[HttpGet]
		public async Task<ActionResult> GetAllDelivery()
		{
			var rows = await _deliveryFeeRepository.GetAll();

			return Ok(rows.Where(e => !e.IsDeleted));
		}

		[HttpPost]
		public async Task<ActionResult> AddDelivery(DeliveryViewModel deliveryViewModel)
		{
			var delivery = new Delivery
			{
				Price	=  deliveryViewModel.Price,
				IsActive = false,
			};

			//This query checks if they is an existing delivery entity equal to the request body.
			//It will return null if they is no duplicate entry
			var row = await _context.Deliveries.Where(x => x.Price == deliveryViewModel.Price && !x.IsDeleted)
							.FirstOrDefaultAsync();

			try
			{
				//Referential integrity to ensure that no duplicate entries can be added to the entity
				if (row != null)
				{
					return Conflict("You cannot add a delivery fee that already exists");

				}
				else
				{
					await _deliveryFeeRepository.Create(delivery);

					return Ok(new
					{
						message = "A new delivery fee has been successfully added"
					});
				}

			}
			catch (Exception)
			{

				return BadRequest("Invalid Request");
			}

		}
		[HttpPut]
		[Route("{deliveryId}")]
		public async Task<ActionResult> UpdateDelivery(DeliveryViewModel deliveryViewModel, int deliveryId)
		{
			try
			{
				var ExistingDelivery = await _deliveryFeeRepository.GetById(deliveryId);

				if (ExistingDelivery == null) return NotFound($"The delivery fee does not exist");

				//This query checks if they is an existing delivery entity equal to the request body.
				//It will return null if they is no duplicate entry
				var row = await _context.Deliveries.Where(x => x.Price == deliveryViewModel.Price
							&& (deliveryViewModel.Price != ExistingDelivery.Price) && !x.IsDeleted)
							.FirstOrDefaultAsync();

				//Referential integrity to ensure that entity is not updated with existing entry.
				if (row != null)
				{
					return Conflict("You cannot update a delivery fee with an existing delivery.");
				}
				else
				{
					ExistingDelivery.Price = deliveryViewModel.Price;

					await _deliveryFeeRepository.Update(ExistingDelivery);

					return Ok(new
					{
						message = "This delivery fee has been successfully updated"
					});
				}


			}
			catch (Exception)
			{

				return StatusCode(500, "Internal Server Error. Please contact support.");
			}

		}
		[HttpGet]
		[Route("{deliveryId}")]
		public async Task<IActionResult> GetDeliveryByID(int deliveryId)
		{
			try
			{
				var existingDelivery = await _deliveryFeeRepository.GetById(deliveryId);
				if (existingDelivery == null)
				{
					return StatusCode(404, "Cannot Find Specified delivery fee");
				}
				else
				{
					return Ok(existingDelivery);
				}

			}
			catch (Exception)
			{
				return StatusCode(500, "Internal Server Error. Please contact support.");
			}
		}

		[HttpDelete]
		[Route("{deliveryId}")]
		public async Task<ActionResult> DeleteDelivery(int deliveryId)
		{
			try
			{
				var ExistingDelivery = await _deliveryFeeRepository.GetById(deliveryId);
				if (ExistingDelivery == null) return NotFound($"The delivery fee does not exist");

				await _deliveryFeeRepository.DeleteById(deliveryId);

				return Ok(ExistingDelivery);

			}
			catch (Exception)
			{

				return StatusCode(500, "Internal Server Error. Please contact support.");
			}

		}

		[HttpPut]
		[Route("activate-delivery/{deliveryId}")]
		public async Task<ActionResult> ActivateDelivery(int deliveryId)
		{
			try
			{
				var SelectedDeliveryFee = await _deliveryFeeRepository.GetById(deliveryId);

				if (SelectedDeliveryFee == null)
				{
					return NotFound("The delivery fee does not exist");
				}

				if (SelectedDeliveryFee.IsActive == true)
				{

					SelectedDeliveryFee.IsActive = false;

					await _deliveryFeeRepository.Update(SelectedDeliveryFee);
				}
				else
				{

					//Checks if they delivery fee that is already
					var ActiveDeliveryFee = _context.Deliveries.Where(x => x.IsActive == true).FirstOrDefault();

					//If null it means that they is no active delivery and it sets the selected delivery to true.
					//This ensures that only one delivery fee can be active at a given time
					if (ActiveDeliveryFee == null)
					{
						SelectedDeliveryFee.IsActive = true;

						await _deliveryFeeRepository.Update(SelectedDeliveryFee);
					}
					else
					{
						ActiveDeliveryFee.IsActive = false;

						await _deliveryFeeRepository.Update(ActiveDeliveryFee);

						SelectedDeliveryFee.IsActive = true;

						await _deliveryFeeRepository.Update(SelectedDeliveryFee);

					}
				}
				return Ok(SelectedDeliveryFee);
			}
			catch (Exception)
			{
				return StatusCode(500, "Internal Server Error. Please contact support.");
			}
		}

	}
}
