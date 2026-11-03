using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bewerbro.ViewModels
{
    public class DashboardViewModel : BaseViewModel
    {
        public int ApplicationCount { get; set; }

        public int InterviewCount { get; set; }

        public int OfferCount { get; set; }

        public int RejectionCount { get; set; }

        public DashboardViewModel()
        {
            ApplicationCount = 12;
            InterviewCount = 3;
            OfferCount = 1;
            RejectionCount = 5;
        }
    }
}
