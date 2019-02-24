using SaleProgresses.Domain;
using SaleProgresses.Dto;
using SaleProgresses.Factories;

namespace SaleProgresses.States
{
    public class Initial : BaseState
    {
        public Initial()
        {
            ITaskFactory taskFactory = new TaskFactory();
            taskFactory.Create(new TaskDto
            {
                Type = TaskType.FirstContact
            });
        }

        public override void Handle(SaleProgress progress)
        {
            var progressId = progress.ParentId ?? progress.Id;

            

            throw new System.NotImplementedException();
        }
    }
}