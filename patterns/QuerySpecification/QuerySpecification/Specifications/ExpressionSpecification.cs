using System;

namespace QuerySpecification.Specifications
{
    public class ExpressionSpecification<T> : CompositeSpecification<T>
    {
        private readonly Func<T, bool> expression;
        public ExpressionSpecification(Func<T, bool> expression)
        {
            if (expression == null)
                throw new ArgumentNullException();

            this.expression = expression;
        }

        public override bool IsSatisfiedBy(T o)
        {
            return this.expression(o);
        }
    }
}