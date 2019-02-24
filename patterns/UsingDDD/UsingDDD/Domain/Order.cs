using System;

namespace UsingDDD.Domain
{
    public class Order
    {
        private readonly DateTime _orderDate;
        private readonly Customer _customer;
        private readonly int _orderNumber;

        public Order(Customer customer)
        {
            _customer = customer;
            _orderDate = DateTime.Now;
        }

        public DateTime OrderDate { get { return _orderDate; } }
        public int OrderNumber { get { return _orderNumber; } }
        public Customer Customer { get { return _customer; } }
    }
}