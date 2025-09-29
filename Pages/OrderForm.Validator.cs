using FluentValidation;
namespace FluentBuilderDemo_BlazorServer.Pages;
public sealed class OrderVmValidator : AbstractValidator<OrderVm>
{
    public OrderVmValidator()
    {
        RuleFor(x => x.CustomerId).NotEmpty().WithMessage("Customer Id is required.");
        //RuleFor(x => x.DeliveryDate).Must(d => d is null || 
        //d.Value >= DateOnly.FromDateTime(DateTime.Today)).WithMessage("Delivery date cannot be in the past.");
        RuleFor(x => x.Lines).Must(lines => lines is not null && lines.Count > 0).WithMessage("Add at least one line.");
        RuleForEach(x => x.Lines).ChildRules(lines =>{
            lines.RuleFor(l => l.Sku).NotEmpty().WithMessage("SKU is required.");
            lines.RuleFor(l => l.Quantity).GreaterThan(0).WithMessage("Quantity must be positive.");
            lines.RuleFor(l => l.Amount).GreaterThanOrEqualTo(0).WithMessage("Price cannot be negative.");
            lines.RuleFor(l => l.Currency).NotEmpty().WithMessage("Currency is required.");
        });
    }
}
