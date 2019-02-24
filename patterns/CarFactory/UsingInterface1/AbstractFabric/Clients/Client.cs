using UsingInterface1.AbstractFabric.Cars.Abstract;

namespace UsingInterface1.AbstractFabric.Clients
{
    class Client
    {
        private readonly AbstractCar abstractCar;
        private readonly AbstractEngine abstractEngine;
        public Client(CarFactory car_factory)
        {
            abstractCar = car_factory.CreateCar();
            abstractEngine = car_factory.CreateEngine();
        }

        public void Run()
        {
            abstractCar.MaxSpeed(abstractEngine);
        } 
    }
}
