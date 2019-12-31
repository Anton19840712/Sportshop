using FluentValidation;

namespace KatlaSport.Services.TransportManagement
{
    public class UpdateInformationRequestValidator : AbstractValidator<UpdateInformationRequest>
    {
        public UpdateInformationRequestValidator()
        {
            RuleFor(i => i.TransportId).GreaterThan(1);
            RuleFor(i => i.Name).NotNull().Must(i => i.Contains(".doc") || i.Contains(".docx") || i.Contains(".xls") || i.Contains(".xlsx"));
        }
    }
}
