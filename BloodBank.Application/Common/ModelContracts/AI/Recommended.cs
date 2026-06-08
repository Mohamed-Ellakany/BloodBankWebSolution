using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BloodBank.Application.Common.ModelContracts.AI
{
    public class Recommended
    {
        public string  Message { get; set; }
        public List<RecommendedResponse> Response { get; set; }
        public string Governorate { get; set; }
        public string BloodType { get; set; }
    }
}
