using BloodBank.Application.Common.ModelContracts.BloodBag;
using BloodBank.Application.Services.Common;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;

namespace BloodBank.Application.Services.Blood
{
    public class BloodSevrice : InventoryService<BloodBag, BloodBagResponse>, IBloodSevrice
    {
        public BloodSevrice(IUnitOfWork unitOfWork)
            : base(unitOfWork, unitOfWork.BloodBags)
        {
        }

        protected override Func<IQueryable<BloodBag>, IIncludableQueryable<BloodBag, object>> IncludeDetails =>
            query => query.Include(item => item.BloodType)
                .Include(item => item.Donor)
                .Include(item => item.BloodBank);
    }
}
