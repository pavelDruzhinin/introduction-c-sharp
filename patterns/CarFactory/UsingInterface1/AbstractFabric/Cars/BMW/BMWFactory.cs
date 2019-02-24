using UsingInterface1.AbstractFabric.Cars.Abstract;

namespace UsingInterface1.AbstractFabric.Cars.BMW
{
    class BMWFactory : CarFactory
    {
        public override AbstractCar CreateCar()
        {
            return new BMWCar();
        }
        public override AbstractEngine CreateEngine()
        {
            return new BMWEngine();
        }
    }
}
