﻿using Castle.DynamicProxy;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Tesodev.Core.Constants;
using Tesodev.Core.CrossCuttingConcerns;
using Tesodev.Core.Utilities.Interceptors;

namespace Tesodev.Core.Aspects.Autofac.Validation
{
    public class ValidationAspect : MethodInterception //Aspect
    {
        private Type _validatorType;
        public ValidationAspect(Type validatorType)
        {
            //defensive coding
            if (!typeof(IValidator).IsAssignableFrom(validatorType))
            {
                throw new Exception(Messages.ThisIsNotAnExamClass);
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
                ValidationTool.Validate(validator, entity);
            }
        }


    }
}
