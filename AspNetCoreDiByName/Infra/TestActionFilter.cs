using System;
using System.Collections.Generic;
using AspNetCoreDiByName.Models;
using AspNetCoreDiByName.Services;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.DependencyInjection;

namespace AspNetCoreDiByName.Infra
{
    public class TestActionFilter : ActionFilterAttribute
    {
        private readonly IServiceProvider _serviceProvider;

        private readonly Dictionary<Type, Type> _typeMapping =
            new Dictionary<Type, Type>
            {
                [typeof(DtoA)] = typeof(ValidateServiceDtoA)
            };

        public TestActionFilter(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        public override void OnActionExecuting(ActionExecutingContext context)
        {
            foreach (var argument in context.ActionArguments)
            {
                var validateServiceType = _typeMapping.GetValueOrDefault(argument.Value.GetType());

                var validateService = _serviceProvider.GetService(validateServiceType) as IValidateService;

                validateService.Validate(argument.Value);
            }
        }
    }
}
