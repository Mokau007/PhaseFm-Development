﻿namespace PhaseFmApi.Models.ViewModel.Discount_Delivery_Vat_VM
{
  public class VatViewModel
  {
		public int Id { get; set; }

		public decimal Percentage { get; set; }

		public bool IsActive { get; set; } = false;
	}
}
