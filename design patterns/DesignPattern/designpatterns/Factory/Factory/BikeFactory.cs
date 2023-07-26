using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Factory
{
    public class BikeFactory : VehicleFactory
    {
        public override Vehicle CreateVehicle()
        {
            return new Bike();
        }
    }
}
