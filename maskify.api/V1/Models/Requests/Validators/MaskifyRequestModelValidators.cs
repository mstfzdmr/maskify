using FluentValidation;

namespace maskify.api.V1.Models.Requests.Validators
{
    public class MaskifyRequestModelValidators : AbstractValidator<MaskifyRequestModel>
    {
        public MaskifyRequestModelValidators()
        {
            RuleFor(o => o.Model)
                .NotNull().WithMessage("'Model' must not be null.")
                .NotEmpty().WithMessage("'Model' must not be empty.");

            RuleFor(o => o.ReplacedJsonKeyValues)
                .NotNull().WithMessage("'ReplacedJsonKeyValues' must not be null.")
                .NotEmpty().WithMessage("'ReplacedJsonKeyValues' must not be empty.");
        }
    }
}
