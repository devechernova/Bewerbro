using System.Collections.ObjectModel;
using System.Windows.Input;
using Bewerbro.Commands;

namespace Bewerbro.ViewModels
{
    public class CompaniesViewModel : BaseViewModel
    {
        private string _newCompanyName;
        private string _newCompanyCity;
        private string _newCompanyWebsite;

        public ObservableCollection<CompanyItem> Companies { get; set; }

        public ICommand AddCompanyCommand { get; set; }

        public string NewCompanyName
        {
            get { return _newCompanyName; }
            set
            {
                _newCompanyName = value;
                OnPropertyChanged();
            }
        }

        public string NewCompanyCity
        {
            get { return _newCompanyCity; }
            set
            {
                _newCompanyCity = value;
                OnPropertyChanged();
            }
        }

        public string NewCompanyWebsite
        {
            get { return _newCompanyWebsite; }
            set
            {
                _newCompanyWebsite = value;
                OnPropertyChanged();
            }
        }

        public CompaniesViewModel()
        {
            AddCompanyCommand = new RelayCommand(AddCompany);

            Companies = new ObservableCollection<CompanyItem>()
            {
                new CompanyItem
                {
                    Name = "NEXUS AG",
                    City = "Karlsruhe",
                    Website = "https://www.nexus-ag.de"
                },

                new CompanyItem
                {
                    Name = "Vector Informatik",
                    City = "Stuttgart",
                    Website = "https://vector.com"
                },

                new CompanyItem
                {
                    Name = "dmTECH",
                    City = "Karlsruhe",
                    Website = "https://www.dmtech.de"
                },

                new CompanyItem
                {
                    Name = "msg systems",
                    City = "Karlsruhe",
                    Website = "https://www.msg.group"
                }
            };
        }

        private void AddCompany()
        {
            if (string.IsNullOrWhiteSpace(NewCompanyName))
                return;

            Companies.Add(new CompanyItem
            {
                Name = NewCompanyName,
                City = NewCompanyCity,
                Website = NewCompanyWebsite
            });

            NewCompanyName = "";
            NewCompanyCity = "";
            NewCompanyWebsite = "";

            OnPropertyChanged(nameof(NewCompanyName));
            OnPropertyChanged(nameof(NewCompanyCity));
            OnPropertyChanged(nameof(NewCompanyWebsite));
        }
    }

    public class CompanyItem
    {
        public string Name { get; set; }

        public string City { get; set; }

        public string Website { get; set; }
    }
}