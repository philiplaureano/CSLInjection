using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LinFu.AOP.Interfaces;
using Microsoft.Practices.ServiceLocation;

namespace ConsoleClient
{
    public class ContainerTypeActivator : ITypeActivator
    {
        private IServiceLocator _locator;
        public ContainerTypeActivator(IServiceLocator locator)
        {
            _locator = locator;
        }

        public bool CanActivate(ITypeActivationContext context)
        {
            return CreateInstance(context) != null;
        }

        public object CreateInstance(ITypeActivationContext context)
        {
            var targetType = context.TargetType;
            var result = _locator.GetInstance(targetType);

            return result;
        }
    }
}
