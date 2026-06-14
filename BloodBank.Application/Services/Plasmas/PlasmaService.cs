using BloodBank.Application.Common.ModelContracts.Plasma;
using BloodBank.Application.Services.Common;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;

namespace BloodBank.Application.Services.Plasmas
{
    public class PlasmaService : InventoryService<Plasma, PlasmaResponse>, IPlasmaService
    {
        public PlasmaService(IUnitOfWork unitOfWork)
            : base(unitOfWork, unitOfWork.Plasmas)
        {
        }

        protected override Func<IQueryable<Plasma>, IIncludableQueryable<Plasma, object>> IncludeDetails =>
            query => query.Include(item => item.BloodType)
                .Include(item => item.BloodBank);
    }
}
