using System.Windows.Input;
using Bewerbro.Commands;

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

        public ApplicationsViewModel Applications { get; set; }

        public CompaniesViewModel Companies { get; set; }

        public ICommand ShowDashboardCommand { get; set; }

        public ICommand ShowApplicationsCommand { get; set; }

        public ICommand ShowCompaniesCommand { get; set; }

        public MainViewModel()
        {
            ApplicationTitle = "Bewerbro - Dein smarter Bewerbungsassistent";

            Dashboard = new DashboardViewModel();

            Applications = new ApplicationsViewModel();

            Companies = new CompaniesViewModel();

            ShowCompaniesCommand = new RelayCommand(ShowCompanies);

            CurrentViewModel = Dashboard;

            ShowDashboardCommand =
                new RelayCommand(ShowDashboard);

            ShowApplicationsCommand =
                new RelayCommand(ShowApplications);
        }

        private void ShowDashboard()
        {
            CurrentViewModel = Dashboard;
        }

        private void ShowApplications()
        {
            CurrentViewModel = Applications;
        }

        private void ShowCompanies()
        {
            CurrentViewModel = Companies;
        }
    }
}