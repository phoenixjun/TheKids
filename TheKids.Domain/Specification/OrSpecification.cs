using System;
using TheKids.Domain.Interfaces;

namespace TheKids.Domain.Specification
{
    internal class OrSpecification<TEntity> : ISpecification<TEntity>
    {
        readonly ISpecification<TEntity> _spec1;
        readonly ISpecification<TEntity> _spec2;

        protected ISpecification<TEntity> Spec1
        {
            get
            {
                return _spec1;
            }
        }
        protected ISpecification<TEntity> Spec2
        {
            get
            {
                return _spec2;
            }
        }
        internal OrSpecification(ISpecification<TEntity> spec1, ISpecification<TEntity> spec2)
        {
            if (spec1 == null)
                throw new ArgumentNullException("spec1");

            if (spec2 == null)
                throw new ArgumentNullException("spec2");

            _spec1 = spec1;
            _spec2 = spec2;
        }
        public bool IsSatisfiedBy(TEntity candidate)
        {
            return Spec1.IsSatisfiedBy(candidate) || Spec2.IsSatisfiedBy(candidate);
        }
    }
}