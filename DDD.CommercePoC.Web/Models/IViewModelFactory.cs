using DDD.CommercePoC.SharedKernel.Model;
using DDD.CommercePoC.SharedKernel.Model.Interfaces;
using JetBrains.Annotations;

namespace DDD.CommercePoC.Web.Models
{
    public interface IViewModelFactory<in TEntity, out TViewModel> where TEntity : IEntity
    {
        [NotNull]
        TViewModel Create([NotNull] TEntity entity);
    }
}