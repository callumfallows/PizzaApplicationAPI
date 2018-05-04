namespace PizzaAPI.Models.Entities
{
    public class Voucher
    {
        public string VoucherName { get; set; }
        public decimal Discount { get; set; }

        public Voucher(string voucherName)
        {
            VoucherName = voucherName;
        }
    }
}