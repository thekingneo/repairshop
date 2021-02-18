using FluentValidation;
using RepairShop.Shared.DTOs;

namespace RepairShop.Server.Validators
{
    public class AddCustomerValidator : AbstractValidator<AddCustomerDto>
    {
        public AddCustomerValidator()
        {
            RuleFor(x => x.Name).NotEmpty();
            RuleFor(x => x.Failure).NotEmpty();
            RuleFor(x => x.Returned).NotNull();
            RuleFor(x => x.DateIn).NotEmpty();
            RuleFor(x => x.PhoneNumber).NotEmpty();
            RuleFor(x => x.TvBrand).NotEmpty();
            RuleFor(x => x.TvInch).NotEmpty();
        }
    }
}