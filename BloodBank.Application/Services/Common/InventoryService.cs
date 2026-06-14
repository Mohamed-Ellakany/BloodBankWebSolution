using BloodBank.Application.Common.Interfaces.Repositories;
using BloodBank.Domain.Common;
using Microsoft.EntityFrameworkCore.Query;

namespace BloodBank.Application.Services.Common
{
    public abstract class InventoryService<TEntity, TResponse>
        where TEntity : class, IBloodInventoryItem
    {
        private readonly IBaseRepository<TEntity> _repository;
        private readonly IUnitOfWork _unitOfWork;

        protected InventoryService(IUnitOfWork unitOfWork, IBaseRepository<TEntity> repository)
        {
            _unitOfWork = unitOfWork;
            _repository = repository;
        }

        protected abstract Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>> IncludeDetails { get; }

        public IEnumerable<TEntity> GetAll()
        {
            return _repository.FindAll(
                item => !item.IsDeleted && item.ExpirationDate > DateTime.Now,
                include: IncludeDetails);
        }

        public IEnumerable<TEntity> GetAllDeleted()
        {
            return _repository.FindAll(
                item => item.IsDeleted || item.ExpirationDate <= DateTime.Now,
                include: IncludeDetails);
        }

        public IEnumerable<TResponse>? GetAllInType(int bloodTypeId)
        {
            return GetAvailableResponses(item => item.BloodTypeId == bloodTypeId);
        }

        public IEnumerable<TResponse>? GetAllInTypeInBank(int bloodTypeId, int bankId)
        {
            return GetAvailableResponses(item => item.BloodTypeId == bloodTypeId && item.BloodBankId == bankId);
        }

        public TEntity? FindById(int id)
        {
            return _repository.Find(item => item.Id == id);
        }

        public int Add(TEntity item)
        {
            _repository.Add(item);
            return _unitOfWork.Complete();
        }

        public int? Buy(int id)
        {
            var item = FindById(id);

            if (item is null || item.IsDeleted)
                return null;

            item.IsDeleted = true;

            return _unitOfWork.Complete();
        }

        private IEnumerable<TResponse>? GetAvailableResponses(Func<TEntity, bool> predicate)
        {
            var response = GetAll()
                .Where(predicate)
                .Adapt<IEnumerable<TResponse>>();

            return response.Any() ? response : null;
        }
    }
}
