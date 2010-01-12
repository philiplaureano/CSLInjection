using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LinFu.AOP.Interfaces;
using SampleDomain;
using StructureMap;
using StructureMap.Configuration.DSL;
using StructureMap.ServiceLocatorAdapter;
using Microsoft.Practices.ServiceLocation;

namespace ConsoleClient
{
    class Program
    {
        static void Main(string[] args)
        {
            // Use the car without any service injection
            var car = new FamilyCar();
            car.Move();
            car.Stop();

            var host = car as IActivatorHost;
            if (host == null)
                return;
            
            
            var registry = new Registry();
            registry.ForRequestedType<Engine>().
                TheDefaultIsConcreteType<RaceCarEngine>();

            var container = new Container(registry);
            var locator = new StructureMapServiceLocator(container);
            var activator = new ContainerTypeActivator(locator);

            TypeActivatorRegistry.SetActivator(activator);

            host.Activator = activator;

            car.Move();
            car.Stop();

            return;
        }
    }
}
