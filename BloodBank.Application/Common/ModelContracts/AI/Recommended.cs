using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BloodBank.Application.Common.ModelContracts.AI
{
    public class Recommended
    {
        public string Message { get; set; } = string.Empty;
        public List<RecommendedResponse> Response { get; set; } = [];
        public string Governorate { get; set; } = string.Empty;
        public string BloodType { get; set; } = string.Empty;
    }
}
