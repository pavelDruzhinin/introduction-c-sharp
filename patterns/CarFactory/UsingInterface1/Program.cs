using System;
using UsingInterface1.AbstractFabric.Cars.Abstract;
using UsingInterface1.AbstractFabric.Cars.Audi;
using UsingInterface1.AbstractFabric.Cars.BMW;
using UsingInterface1.AbstractFabric.Clients;

namespace UsingInterface1
{
    class Program
    {
        static void Main(string[] args)
        {
            // Абстрактная фабрика № 1 
            CarFactory bmw_car = new BMWFactory();
            var c1 = new Client(bmw_car);
            c1.Run();

            // Абстрактная фабрика № 2      
            CarFactory audi_factory = new AudiFactory();
            var c2 = new Client(audi_factory);
            c2.Run();
            Console.Read();
        }
    }
}
