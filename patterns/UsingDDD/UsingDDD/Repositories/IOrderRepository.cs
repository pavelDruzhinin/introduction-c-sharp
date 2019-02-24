using System.Collections.Generic;
using UsingDDD.Domain;

namespace UsingDDD.Repositories
{
    public interface IOrderRepository
    {
        Order GetOrder(int orderNumber);
        void AddOrder(Order order);
        void SetFieldWhenReconstitutingFromPersistence(object instance, string field, object newValue);
        IEnumerable<Order> GetOrders(Customer customer);
    }
}