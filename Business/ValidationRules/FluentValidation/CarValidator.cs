using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities.Concrete;
using FluentValidation;

namespace Business.ValidationRules.FluentValidation
{
    public class CarValidator : AbstractValidator<Car>
    {
        CarValidator()
        {
            RuleFor(c=>c.DailyPrice).NotEmpty();
            RuleFor(c => c.Description).MinimumLength(2).WithMessage("Açıklama en az 2 karakter olmalı");
            RuleFor(p => p.Description).Must(StartWithA).WithMessage("Ürünler A harfi ile başlamalı");


            // RuleFor(c => c.ModelYear).GreaterThan()
        }

        private bool StartWithA(string arg)
        {
            return arg.StartsWith("A");
        }
    }
}
