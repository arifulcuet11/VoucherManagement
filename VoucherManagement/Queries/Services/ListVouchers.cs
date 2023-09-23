using VoucherManagement.Queries.Interfaces;

namespace VoucherManagement.Queries.Services
{
    public class ListVouchers : IListVouchers
    {
        public ListVouchers() { }
        public async Task<List<string>> ListAsync()
        {
           /*
             * DO-TO: Implement this method
            */

            var result = new List<string>();
            result.Add("Voucher 1");
            result.Add("Voucher 2");
            result.Add("Voucher 3");

            return result;
        }
    }
}
