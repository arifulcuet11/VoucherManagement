using Microsoft.EntityFrameworkCore;
using VoucherManagement.DatabaseContext;
using VoucherManagement.Queries.Interfaces;

namespace VoucherManagement.Queries.Services
{
    public class ListVouchers : IListVouchers
    {
        private readonly VoucherContext _voucherContext;
        public ListVouchers(VoucherContext voucherContext)
        {
            _voucherContext = voucherContext;
        }

        public async Task<List<string>> ListAsync()
        {
            var codes = new List<string>();

            /*
             * TO-D0: Implement this method
             * All logic here
             */

            var vouchers = await _voucherContext.Vouchers.ToListAsync();

            if (vouchers != null && vouchers.Count > 0)
            {
                codes = vouchers.Select(x => x.Code).ToList();
            }

            return codes;
        }
    }
}
