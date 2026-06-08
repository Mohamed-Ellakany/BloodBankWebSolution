using BloodBank.Application.Common.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BloodBank.Application.Services.Home
{
    public interface IHomeService
    {
        public List<(string bloodTypeName, int count)> GetValues();

        public int GetCountOfAll();

        public int GetCountOfDonors();

        public List<ChartDto> GetSelectedValues();

    }
}
