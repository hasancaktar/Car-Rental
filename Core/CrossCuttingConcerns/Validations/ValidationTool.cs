using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;

namespace Core.CrossCuttingConcerns.Validations
{
    // static olması   bellek boyunca bir tane oluşturur ve sürekli onu kullanır
    public static class ValidationTool
    {
        //static bir sınıfta statik metod olmak zorunda
        public static void Validate(IValidator validator, object entity)
        {
            var context = new ValidationContext<object>(entity);
            var result = validator.Validate(context);
            if (!result.IsValid)
            {
                throw new ValidationException(result.Errors);
            }
        }
    }
}
