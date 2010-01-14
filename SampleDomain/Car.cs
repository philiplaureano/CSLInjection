using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SampleDomain
{
    public abstract class Car
    {
        private Engine _engine;

        public virtual void Move()
        {
            CreateEngineIfNecessary();

            _engine.Start();
            Console.WriteLine("The car is now moving.");
        }

        public virtual void Stop()
        {
            CreateEngineIfNecessary();
            _engine.Stop();
            Console.WriteLine("The car has now stopped.");
        }

        private void CreateEngineIfNecessary()
        {
            _engine = new FamilyCarEngine();
        }
    }
}
