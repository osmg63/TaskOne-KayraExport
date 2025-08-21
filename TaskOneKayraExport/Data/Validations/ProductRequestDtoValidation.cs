using FluentValidation;
using TaskOneKayraExport.Dto;

namespace TaskOneKayraExport.Data.Validations
{
    public class ProductRequestDtoValidator:AbstractValidator<ProductRequestDto> 
    {
        public ProductRequestDtoValidator()
        {
            RuleFor(x=>x.Name)
                .NotEmpty().WithMessage("Name is required")
                .MaximumLength(50).WithMessage("UserName cannot exceed 50 characters.");


            RuleFor(x => x.Description)
                .NotEmpty().WithMessage("Description is required");

            RuleFor(x => x.Stock)
                .NotEmpty().WithMessage("Stock is required")
                .InclusiveBetween(0, 1000).WithMessage("Stock must be between 1 and 1000");

        }


    }
}
