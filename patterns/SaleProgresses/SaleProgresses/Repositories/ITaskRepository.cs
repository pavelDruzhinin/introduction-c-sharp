using SaleProgresses.Factories;

namespace SaleProgresses.Repositories
{
    public interface ITaskRepository
    {
        bool CompleteTask(int taskId); // or taskId
        bool UpdateLastInvoiceBySaleId(int saleId, string number);
        bool CompleteLastInvoiceBySaleId(int saleId);
        bool Add(Task task, int saleId);
    }

    class TaskRepository : ITaskRepository
    {
        public bool CompleteTask(int taskId)
        {
            throw new System.NotImplementedException();
        }

        public bool UpdateLastInvoiceBySaleId(int saleId, string number)
        {
            throw new System.NotImplementedException();
        }

        public bool CompleteLastInvoiceBySaleId(int saleId)
        {
            throw new System.NotImplementedException();
        }

        public bool Add(Task task, int saleId)
        {
            throw new System.NotImplementedException();
        }
    }
}