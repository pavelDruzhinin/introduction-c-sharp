using System;
using UsingInterface1.AbstractFabric.Cars.Abstract;

namespace UsingInterface1.AbstractFabric.Cars.BMW
{
    class BMWCar : AbstractCar
    {
        public override void MaxSpeed(AbstractEngine engine)
        {
            Console.WriteLine("Максимальная скорость " + engine.max_speed);
        }
    }
}
