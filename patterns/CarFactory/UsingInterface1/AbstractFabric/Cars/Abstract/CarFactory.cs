namespace UsingInterface1.AbstractFabric.Cars.Abstract
{
    abstract class CarFactory
    {
        public abstract AbstractCar CreateCar();
        public abstract AbstractEngine CreateEngine();
    }
}
