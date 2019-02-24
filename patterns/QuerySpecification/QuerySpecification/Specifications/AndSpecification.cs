using QuerySpecification.Specifications.Contracts;

namespace QuerySpecification.Specifications
{
    public class AndSpecification<T> : CompositeSpecification<T>
    {
        readonly ISpecification<T> leftSpecification;
        readonly ISpecification<T> rightSpecification;

        public AndSpecification(ISpecification<T> left, ISpecification<T> right)
        {
            this.leftSpecification = left;
            this.rightSpecification = right;
        }

        public override bool IsSatisfiedBy(T o)
        {
            return this.leftSpecification.IsSatisfiedBy(o) && this.rightSpecification.IsSatisfiedBy(o);
        }
    }
}