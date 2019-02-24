using UsingInterface1.AbstractFabric.Cars.Abstract;

namespace UsingInterface1.AbstractFabric.Cars.Audi
{
    class AudiFactory:CarFactory
    {
        public override AbstractCar CreateCar()
        {
            return new AudiCar();
        }
        public override AbstractEngine CreateEngine()
        {
            return new AudiEngine();
        }
    }
}
