using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LinFu.AOP.Interfaces;
using Microsoft.Practices.ServiceLocation;
using SampleDomain;

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

            // HACK: We need to manually map the FamilyCarEngine back to 
            // an Engine type since there's currently no way to automatically
            // figure out the correct service that should be 
            // instantiated from the container
            var serviceType = targetType;

            if (serviceType == typeof(FamilyCarEngine))
                serviceType = typeof(Engine);

            var result = _locator.GetInstance(serviceType);

            return result;
        }
    }
}
