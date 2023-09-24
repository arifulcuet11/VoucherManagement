using Microsoft.AspNetCore.Mvc;
using System.Net;
using VoucherManagement.Command.Interfaces;
using VoucherManagement.Entities;
using VoucherManagement.Entities.Models;
using VoucherManagement.Queries.Interfaces;

namespace VoucherManagement.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class VouchersController : ControllerBase
    {
        private readonly ICreateVoucher _createVoucher;
        private readonly IListVouchers _listVouchers;
        private readonly IValidateVoucher _validateVoucher;

        public VouchersController(
            ICreateVoucher createVoucher,
            IListVouchers listVouchers,
            IValidateVoucher validateVoucher)
        {

            _createVoucher = createVoucher;
            _listVouchers = listVouchers;
            _validateVoucher = validateVoucher;
        }

        [HttpPost]
        public async Task<IActionResult> CreateVoucher([FromBody] Voucher voucher)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var result = await _createVoucher.AddAsync(voucher);

                    return Ok(result);
                }

                return BadRequest(ModelState);
            }
            catch (Exception ex)
            {
                int code = (int)HttpStatusCode.InternalServerError;

                if (ex.Data.Contains("StatusCode") && Enum.TryParse(ex.Data["StatusCode"].ToString(), out HttpStatusCode httpStatusCode))
                {
                    code = (int)httpStatusCode;
                };

                return StatusCode(code, new ErrorResponse
                {
                    Status = code,
                    Title = "Error creating voucher.",
                    Error = new Error
                    {
                        Message = ex.Message,
                        Details = ex.StackTrace
                    }
                });
            }

        }

        [HttpGet("codes")]
        public async Task<IActionResult> ListVoucher()
        {
            try
            {
                var result = await _listVouchers.ListAsync();
                return Ok(result);
            }
            catch (Exception)
            {
                /*
                 * execption handle
                 */
                 throw;
            }

        }

        [HttpPost("validate/{code}")]
        public async Task<IActionResult> ValidateVoucher(string code)
        {
            try
            {
                if (string.IsNullOrEmpty(code))
                    return BadRequest("Voucher code is required.");

                var result = await _validateVoucher.ValidateAsync(code);

                return Ok(result);
            }
            catch (Exception ex)
            {
                int statusCode = (int)HttpStatusCode.InternalServerError;

                if (ex.Data.Contains("StatusCode") && Enum.TryParse(ex.Data["StatusCode"].ToString(), out HttpStatusCode httpStatusCode))
                {
                    statusCode = (int)httpStatusCode;
                };

                return StatusCode(statusCode, new ErrorResponse
                {
                    Status = statusCode,
                    Title = "Error validating voucher.",
                    Error = new Error
                    {
                        Message = ex.Message,
                        Details = ex.StackTrace
                    }
                });
            }

        }

    }
}