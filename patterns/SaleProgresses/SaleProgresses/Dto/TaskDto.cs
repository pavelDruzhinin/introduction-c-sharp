using System;
using SaleProgresses.Domain;

namespace SaleProgresses.Dto
{
    public class TaskDto
    {
        public TaskType Type { get; set; }
        public DateTime StartLine { get; set; }
        public int SaleId { get; set; }
    }
}