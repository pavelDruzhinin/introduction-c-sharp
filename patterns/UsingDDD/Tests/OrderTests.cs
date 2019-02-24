using System;
using System.Linq;
using NUnit.Framework;
using UsingDDD.Domain;
using UsingDDD.Repositories;

namespace Tests
{
    [TestFixture]
    public class OrderTests
    {
        private IOrderRepository _orderRepository;

        [SetUp]
        public void Setup()
        {
            _orderRepository = new OrderRepository();
        }

        #region CanCreateOrder

        [Test, Description("Can Create Order")]
        public void CanCreateOrder()
        {
            #region Arrange

            #endregion

            #region Act

            var order = new Order(new Customer());

            #endregion

            #region Assert

            Assert.IsNotNull(order);

            #endregion

        }

        #endregion

        #region OrderDateIsCurrentAfterCreation

        [Test, Description("Insert User in DB")]
        public void OrderDateIsCurrentAfterCreation()
        {
            #region Arrange

            var theTimeBefore = DateTime.Now.AddMilliseconds(-1);

            #endregion

            #region Act

            var order = new Order(new Customer());

            #endregion

            #region Assert

            Assert.IsTrue(order.OrderDate > theTimeBefore);
            Assert.IsTrue(order.OrderDate <= DateTime.Now.AddMilliseconds(1));

            #endregion

        }

        #endregion

        #region OrderNumberIsZeroAfterCreation

        [Test, Description("Insert User in DB")]
        public void OrderNumberIsZeroAfterCreation()
        {
            #region Arrange

            #endregion

            #region Act

            var order = new Order(new Customer());

            #endregion

            #region Assert

            Assert.AreEqual(0, order.OrderNumber);

            #endregion

        }

        #endregion

        #region OrderNumberCantBeZeroAfterReconstitution

        [Test, Description("OrderNumber CantBe Zero After Reconstitution")]
        public void OrderNumberCantBeZeroAfterReconstitution()
        {
            #region Arrange

            const int orderNumber = 42;
            var customer = new Customer();
            _FakeAnOrder(orderNumber, customer, _orderRepository);

            #endregion

            #region Act

            var order = _orderRepository.GetOrder(orderNumber);

            #endregion

            #region Assert

            Assert.IsTrue(order.OrderNumber != 0);

            #endregion
        }

        private void _FakeAnOrder(int orderNumber, Customer c, IOrderRepository _repository)
        {
            var order = new Order(c);

            _repository.SetFieldWhenReconstitutingFromPersistence(order, "_orderNumber", orderNumber);

            _repository.AddOrder(order);
        }

        #endregion

        #region CanAddOrder

        [Ignore, Description("Can Add Order")]
        public void CanAddOrder()
        {
            #region Arrange

            #endregion

            #region Act

            _orderRepository.AddOrder(new Order(new Customer()));

            #endregion

            #region Assert

            #endregion

        }

        #endregion

        #region CanFindOrdersViaCustomer

        [Test, Description("CanFindOrdersViaCustomer")]
        public void CanFindOrdersViaCustomer()
        {
            #region Arrange

            var customer = new Customer();

            _FakeAnOrder(42, customer, _orderRepository);
            _FakeAnOrder(12, new Customer(), _orderRepository);
            _FakeAnOrder(3, customer, _orderRepository);
            _FakeAnOrder(21, customer, _orderRepository);
            _FakeAnOrder(1, new Customer(), _orderRepository);

            #endregion

            #region Assert

            Assert.AreEqual(3, _orderRepository.GetOrders(customer).Count());

            #endregion

        }

        #endregion

    }
}
