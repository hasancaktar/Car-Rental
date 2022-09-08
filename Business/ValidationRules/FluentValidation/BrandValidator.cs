using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities.Concrete;
using FluentValidation;

namespace Business.ValidationRules.FluentValidation
{
    public class BrandValidator : AbstractValidator<Brand>
    {
         public  BrandValidator()
        {
            RuleFor(b=>b.BrandName).NotEmpty();
            RuleFor(b => b.BrandName).MinimumLength(2).WithMessage("Marka en az 2 karakter olmalı");
            RuleFor(p => p.BrandName).Must(StartWithA).WithMessage("Marka A harfi ile başlamalı");


           
        }

         private bool StartWithA(string arg)
         {
             return arg.StartsWith("A");
         }
    }
    }

