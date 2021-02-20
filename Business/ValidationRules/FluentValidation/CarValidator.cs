using Entities.Conctrete;
using FluentValidation;

namespace Business.ValidationRules.FluentValidation
{
    public class CarValidator : AbstractValidator<Car>
    {
        public CarValidator()
        {
            RuleFor(x => x.CarName).MinimumLength(5).WithMessage("Araç adı en az 5 karakterden oluşmalıdır.");
            RuleFor(x => x.BrandId).NotEmpty().WithMessage("Aracın bir markaya sahip olması gerekir.");
            RuleFor(x => x.ColorId).NotEmpty().WithMessage("Aracın bir renke sahip olması gerekir.");
            RuleFor(x => x.DailyPrice).GreaterThan(0).WithMessage("Aracın günlük ücreti sıfırdan büyük olmalıdır.");
            RuleFor(x => x.ModelYear).GreaterThan(0).WithMessage("Aracın model yılı sıfırdan büyük olmalıdır.");
        }
    }
}