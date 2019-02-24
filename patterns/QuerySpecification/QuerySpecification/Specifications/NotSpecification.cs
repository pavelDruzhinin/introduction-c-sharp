using QuerySpecification.Specifications.Contracts;

namespace QuerySpecification.Specifications
{
    public class NotSpecification<T> : CompositeSpecification<T>
    {
        private readonly ISpecification<T> _notSpecification;

        public NotSpecification(ISpecification<T> notSpecification)
        {
            _notSpecification = notSpecification;
        }

        public override bool IsSatisfiedBy(T o)
        {
            return !this._notSpecification.IsSatisfiedBy(o);
        }
    }
}