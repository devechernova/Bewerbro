using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bewerbro.ViewModels
{
    public class MainViewModel : BaseViewModel
    {
        private string _applicationTitle;
        private BaseViewModel _currentViewModel;

        public string ApplicationTitle
        {
            get { return _applicationTitle; }
            set
            {
                _applicationTitle = value;
                OnPropertyChanged();
            }
        }

        public BaseViewModel CurrentViewModel
        {
            get { return _currentViewModel; }
            set
            {
                _currentViewModel = value;
                OnPropertyChanged();
            }
        }
        public DashboardViewModel Dashboard { get; set; }
        public MainViewModel()
        {
            ApplicationTitle = "Bewerbro - Dein smarter Bewerbungsassistent";

            Dashboard = new DashboardViewModel();

            CurrentViewModel = Dashboard;

        }
    }
}
