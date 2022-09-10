using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Castle.DynamicProxy;
using Castle.DynamicProxy.Generators.Emitters.CodeBuilders;
using Core.CrossCuttingConcerns.Validations;
using Core.Utilities.Interceptors;
using FluentValidation;

namespace Core.Aspects.Autofac.Validation
{
    public class ValidationAspect : MethodInterception //ascept
    {
        private Type _validatorType;

        public ValidationAspect(Type validatorType)
        {
            //defensive coding : savunma odaklı kodlama 
            if (!typeof(IValidator).IsAssignableFrom(validatorType))

            {
                throw new System.Exception("Bu sınıf bir doğrulama sınıfı değil");
            }
            _validatorType = validatorType;
        }

        protected override void OnBefore(IInvocation invocation)
        {
            var validator = (IValidator)Activator.CreateInstance(_validatorType);
            var entityType = _validatorType.BaseType.GetGenericArguments()[0];
            var entities = invocation.Arguments.Where(t => t.GetType() == entityType);
            foreach (var entity in entities)
            {
                ValidationTool.Validate(validator,entity);
            }
        }
    }
}
