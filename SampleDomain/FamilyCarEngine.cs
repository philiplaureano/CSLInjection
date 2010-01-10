using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SampleDomain
{
    public class FamilyCarEngine : Engine
    {
        public override void Start()
        {
            Console.WriteLine("Starting Family Car Engine");
        }

        public override void Stop()
        {
            Console.WriteLine("Stopping Family Car Engine");
        }
    }
}
