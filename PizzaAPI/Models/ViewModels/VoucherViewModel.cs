using PizzaAPI.Models.Entities;

namespace PizzaAPI.Models.ViewModels
{
    public class VoucherViewModel
    {
        public decimal Discount { get; set; }
        public string Name { get; set; }

        public VoucherViewModel(Voucher voucher)
        {
            Name = voucher.VoucherName;
            Discount = voucher.Discount;
        }

    }
}