using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BloodBank.Application.Common.ModelContracts.AI
{
        public class DiseaseRequest
        {
            public List<PredictDto> Diseases { get; set; } = [];
        }
    
}
