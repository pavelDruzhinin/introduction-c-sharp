using SaleProgresses.Dto;

namespace SaleProgresses.Factories
{
    public interface ITaskFactory
    {
        Task Create(TaskDto dto);
    }

    class TaskFactory : ITaskFactory
    {
        public Task Create(TaskDto dto)
        {
            throw new System.NotImplementedException();
        }
    }
}