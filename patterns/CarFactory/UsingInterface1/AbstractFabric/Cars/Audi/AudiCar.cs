using System;
using UsingInterface1.AbstractFabric.Cars.Abstract;

namespace UsingInterface1.AbstractFabric.Cars.Audi
{
    class AudiCar : AbstractCar
    {
        public override void MaxSpeed(AbstractEngine engine)
        {
            Console.WriteLine("Максимальная скорость автомобиля " + engine.max_speed);
        }
    }
}
