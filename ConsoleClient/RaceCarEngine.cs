using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SampleDomain;

namespace ConsoleClient
{
    public class RaceCarEngine : Engine
    {
        public override void Start()
        {
            Console.WriteLine("RaceCar Engine Started");
        }

        public override void Stop()
        {
            Console.WriteLine("RaceCar Engine Stopped");
        }
    }
}
