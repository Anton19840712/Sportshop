using FluentValidation;

namespace KatlaSport.Services.ProductManagement
{
    /// <summary>
    /// Represents a validator for <see cref="UpdateProductRequest"/>.
    /// </summary>
    public class UpdateProductRequestValidator : AbstractValidator<UpdateProductRequest>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="UpdateProductRequestValidator"/> class.
        /// </summary>
        public UpdateProductRequestValidator()
        {
            RuleFor(r => r.Name).Length(1, 50);
            RuleFor(r => r.Code).Length(6);
            RuleFor(r => r.CategoryId).GreaterThan(0);

            // TODO STEP 2 - Add rules for "Description", "ManufacturerCode" and "Price" here.
            RuleFor(r => r.Description).Length(0, 300);
            RuleFor(r => r.ManufacturerCode).Length(4, 10);
            RuleFor(r => r.Price).GreaterThanOrEqualTo(0);
        }
    }
}
