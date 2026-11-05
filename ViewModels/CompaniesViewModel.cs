using System.Collections.ObjectModel;
using System.Windows.Input;
using Bewerbro.Commands;
using Bewerbro.Models;

namespace Bewerbro.ViewModels
{
    public class CompaniesViewModel : BaseViewModel
    {
        private string _newCompanyName;
        private string _newCompanyCity;
        private string _newCompanyWebsite;

        public ObservableCollection<CompanyItem> Companies { get; set; }

        public ICommand AddCompanyCommand { get; set; }

        public ICommand DeleteCompanyCommand { get; set; }

        public ICommand UpdateCompanyCommand { get; set; }

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

        private CompanyItem _selectedCompany;

        public CompanyItem SelectedCompany
        {
            get { return _selectedCompany; }
            set
            {
                _selectedCompany = value;

                if (_selectedCompany != null)
                {
                    NewCompanyName = _selectedCompany.Name;
                    NewCompanyCity = _selectedCompany.City;
                    NewCompanyWebsite = _selectedCompany.Website;
                }

                OnPropertyChanged();
            }
        }
        public CompaniesViewModel()
        {
            AddCompanyCommand = new RelayCommand(AddCompany);
            DeleteCompanyCommand = new RelayCommand(DeleteCompany);
            UpdateCompanyCommand = new RelayCommand(UpdateCompany);

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
        private void UpdateCompany()
        {
            if (SelectedCompany == null)
                return;

            SelectedCompany.Name = NewCompanyName;
            SelectedCompany.City = NewCompanyCity;
            SelectedCompany.Website = NewCompanyWebsite;
        }

        private void DeleteCompany()
        {
            if (SelectedCompany == null)
                return;

            Companies.Remove(SelectedCompany);
        }
    }

}