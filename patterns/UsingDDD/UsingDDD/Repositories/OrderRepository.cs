using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using UsingDDD.Domain;

namespace UsingDDD.Repositories
{
    public class OrderRepository : IOrderRepository
    {
        private readonly IList<Order> _orders;

        public OrderRepository()
        {
            _orders = new List<Order>();
        }

        public Order GetOrder(int orderNumber)
        {
            return _orders.FirstOrDefault(x => x.OrderNumber == orderNumber);
        }

        public void AddOrder(Order order)
        {
            _orders.Add(order);
        }

        public void SetFieldWhenReconstitutingFromPersistence(object instance, string field, object newValue)
        {
            var t = instance.GetType();
            var f = t.GetField(field,
                BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);

            if (f != null)
                f.SetValue(instance, newValue);
        }

        public IEnumerable<Order> GetOrders(Customer customer)
        {
            return _orders.Where(x => x.Customer.Equals(customer));
        }
    }
}