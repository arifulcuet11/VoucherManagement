using System.ComponentModel.DataAnnotations;

namespace VoucherManagement.CustomValidators
{
    [AttributeUsage(AttributeTargets.Property | AttributeTargets.Field, AllowMultiple = false)]
    public sealed class FutureDateAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (value is DateTime expirationDate && expirationDate <= DateTime.Now)
            {
                return new ValidationResult("The expiration date must be greater than the current time.");
            }

            return ValidationResult.Success;
        }
    }

}
