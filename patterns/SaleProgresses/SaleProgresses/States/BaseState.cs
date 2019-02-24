using SaleProgresses.Domain;

namespace SaleProgresses.States
{
    public abstract class BaseState
    {
        public abstract void Handle(SaleProgress progress);
    }
}