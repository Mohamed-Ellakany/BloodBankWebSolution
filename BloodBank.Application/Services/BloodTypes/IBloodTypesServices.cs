using BloodBank.Application.Common.ModelContracts.Types;
using BloodBank.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BloodBank.Application.Services.BloodTypes
{
    public interface IBloodTypesServices
    {

        IEnumerable<BloodTypesResponse> GetAll();

        IEnumerable<BloodType> GetAllOrdered();

        BloodTypesResponse? GetById(int id);

    }
}
