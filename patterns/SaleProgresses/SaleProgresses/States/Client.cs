using System;
using SaleProgresses.Domain;
using SaleProgresses.Dto;
using SaleProgresses.Factories;
using SaleProgresses.Repositories;

namespace SaleProgresses.States
{
    public class Client : BaseState
    {
        public Client()
        {
            #region Parameters

            ITaskFactory _taskFactory = new TaskFactory();
            ITaskRepository _taskRepository = new TaskRepository();
            const int period = 12;
            const int prevTaskId = 1;
            var dto = new TaskDto
            {
                Type = TaskType.Call,
                StartLine = DateTime.Today.AddMonths(period - 1)
            };

            #endregion

            #region Doing

            var task = _taskFactory.Create(dto);

            _taskRepository.Add(task, dto.SaleId);
            _taskRepository.CompleteTask(prevTaskId);

            //TODO:company is Client and sale is Client

            #endregion
        }

        public override void Handle(SaleProgress progress)
        {
            throw new System.NotImplementedException();
        }
    }
}