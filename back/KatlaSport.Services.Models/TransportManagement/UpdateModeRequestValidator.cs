using FluentValidation;

namespace KatlaSport.Services.TransportManagement
{
    public class UpdateModeRequestValidator : AbstractValidator<UpdateModeRequest>
    {
        public UpdateModeRequestValidator()
        {
            RuleFor(i => i.Type).Length(20);
        }
    }
}
