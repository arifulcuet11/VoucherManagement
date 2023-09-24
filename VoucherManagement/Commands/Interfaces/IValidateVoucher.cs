using VoucherManagement.Entities.Models;

namespace VoucherManagement.Command.Interfaces
{
    public interface IValidateVoucher
    {
        Task<ValidateVoucherResponse> ValidateAsync(string code);
    }
}
