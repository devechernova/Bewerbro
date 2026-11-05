using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bewerbro.Services;

namespace Bewerbro.ViewModels
{
    public class DashboardViewModel : BaseViewModel
    {
        private int _applicationCount;

        public int ApplicationCount
        {
            get => _applicationCount;
            set
            {
                _applicationCount = value;
                OnPropertyChanged();
            }
        }

        public int InterviewCount { get; set; }

        public int OfferCount { get; set; }

        public int RejectionCount { get; set; }

        public void RefreshApplicationCount()
        {
            ApplicationCount = ApplicationDataService.LoadApplications().Count;
        }

        public DashboardViewModel()
        {
            RefreshApplicationCount();

            InterviewCount = 3;
            OfferCount = 1;
            RejectionCount = 5;
        }
    }
}
