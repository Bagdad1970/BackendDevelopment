using FluentValidation;
using Models.Dto.V1.Requests;

namespace WebApplication1.Validators;

public class V1QueryOrdersRequestValidator : AbstractValidator<V1QueryOrdersRequest>
{
    public V1QueryOrdersRequestValidator()
    {
        RuleFor(x => x.Ids)
            .NotEmpty().WithMessage("Ids cannot be empty if provided")
            .When(x => x.Ids != null);

        RuleForEach(x => x.Ids)
            .GreaterThan(0).WithMessage("Each Id must be greater than 0")
            .When(x => x.Ids != null);

        RuleFor(x => x.Page)
            .GreaterThanOrEqualTo(0).WithMessage("Page must be greater than or equal to 0")
            .When(x => x.Page != null);

        RuleFor(x => x.PageSize)
            .GreaterThan(0).WithMessage("PageSize must be greater than 0")
            .When(x => x.PageSize != null);

        RuleFor(x => x)
            .Must(x => x.Ids?.Length > 0 || x.CustomerIds?.Length > 0)
            .WithMessage("IDs or Customer IDs must be provided");
    }
}