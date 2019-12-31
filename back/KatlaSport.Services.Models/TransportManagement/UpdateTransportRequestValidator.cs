using FluentValidation;

namespace KatlaSport.Services.TransportManagement
{
    public class UpdateTransportRequestValidator : AbstractValidator<UpdateTransportRequest>
    {
        public UpdateTransportRequestValidator()
        {
            RuleFor(i => i.Name).Length(3, 30);
            RuleFor(i => i.ModeId).NotNull();
        }
    }
}
