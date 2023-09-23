using Microsoft.EntityFrameworkCore;
using VoucherManagement.Entities;

namespace VoucherManagement.DatabaseContext
{
    public class VoucherContext : DbContext
    {
        public VoucherContext(DbContextOptions<VoucherContext> options) : base(options)
        {
        }

        public DbSet<Voucher> Vouchers { get; set; }
    }
}
