using FluentValidation;

namespace KatlaSport.Services.OrderManagement
{
    public class UpdateOrderRequestValidator : AbstractValidator<UpdateOrderRequest>
    {
        public UpdateOrderRequestValidator()
        {
            RuleFor(o => o.CustomerId).GreaterThan(0);
            RuleFor(o => o.TransportId).GreaterThan(0);
            RuleFor(o => o.OrderProducts).NotNull();
        }
    }
}