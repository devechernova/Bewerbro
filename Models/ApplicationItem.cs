using Bewerbro.ViewModels;

namespace Bewerbro.Models
{
    public class ApplicationItem : BaseViewModel
    {
        private string _jobTitle;
        private string _company;
        private string _status;
        private string _applicationDate;

        public string JobTitle
        {
            get => _jobTitle;
            set
            {
                _jobTitle = value;
                OnPropertyChanged();
            }
        }

        public string Company
        {
            get => _company;
            set
            {
                _company = value;
                OnPropertyChanged();
            }
        }

        public string Status
        {
            get => _status;
            set
            {
                _status = value;
                OnPropertyChanged();
            }
        }

        public string ApplicationDate
        {
            get => _applicationDate;
            set
            {
                _applicationDate = value;
                OnPropertyChanged();
            }
        }
    }
}