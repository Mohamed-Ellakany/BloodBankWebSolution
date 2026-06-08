using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BloodBank.Application.Common.ModelContracts.AI
{
    public class PredictResponse
    {
        public int TotalItems { get; set; }

        public List<ResultDto> Results { get; set; }



    }

    public class ResultDto
    {
        public string Disease { get; set; }

        public double? Prevalence { get; set; }

        public string donationStatus { get; set; }

    }

}
