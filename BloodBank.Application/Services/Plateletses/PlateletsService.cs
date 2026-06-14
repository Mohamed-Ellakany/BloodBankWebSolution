using BloodBank.Application.Common.ModelContracts.Plateletses;
using BloodBank.Application.Services.Common;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;

namespace BloodBank.Application.Services.Plateletses
{
    public class PlateletsService : InventoryService<Platelets, PlateletsesResponse>, IPlateletsService
    {
        public PlateletsService(IUnitOfWork unitOfWork)
            : base(unitOfWork, unitOfWork.Platelets)
        {
        }

        protected override Func<IQueryable<Platelets>, IIncludableQueryable<Platelets, object>> IncludeDetails =>
            query => query.Include(item => item.BloodType)
                .Include(item => item.BloodBank);
    }
}
