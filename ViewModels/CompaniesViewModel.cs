using System.Collections.ObjectModel;
using System.Windows.Input;
using Bewerbro.Commands;
using Bewerbro.Models;
using Bewerbro.Services;

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

            Companies = CompanyDataService.LoadCompanies();

            if (Companies.Count == 0)
            {
                Companies = CreateDefaultCompanies();
                CompanyDataService.SaveCompanies(Companies);
            }

        }

        private ObservableCollection<CompanyItem> CreateDefaultCompanies()
        {
            return new ObservableCollection<CompanyItem>
    {
        new CompanyItem
        {
            Name = "CGM",
            City = "Koblenz",
            Website = "https://www.cgm.com"
        },

        new CompanyItem
        {
            Name = "medicalvalues",
            City = "Karlsruhe",
            Website = "https://www.medicalvalues.de"
        },

        new CompanyItem
        {
            Name = "generic.de software technologies AG",
            City = "Karlsruhe",
            Website = "https://www.generic.de"
        },

        new CompanyItem
        {
            Name = "TelemaxX",
            City = "Karlsruhe",
            Website = "https://www.telemaxx.de"
        },

        new CompanyItem
        {
            Name = "CAS Software AG",
            City = "Karlsruhe",
            Website = "https://www.cas.de"
        },

        new CompanyItem
        {
            Name = "Bosch",
            City = "Karlsruhe",
            Website = "https://www.bosch.de"
        },

        new CompanyItem
        {
            Name = "Fraunhofer IOSB",
            City = "Karlsruhe",
            Website = "https://www.iosb.fraunhofer.de"
        },

        new CompanyItem
        {
            Name = "Kinemic",
            City = "Karlsruhe",
            Website = "https://www.kinemic.com"
        },

        new CompanyItem
        {
            Name = "CodeWerk",
            City = "Karlsruhe",
            Website = "https://www.codewerk.de"
        },

        new CompanyItem
        {
            Name = "Evacorn",
            City = "Karlsruhe",
            Website = "https://www.evacorn.com"
        },

        new CompanyItem
        {
            Name = "Aicorn",
            City = "Karlsruhe",
            Website = "https://www.aicorn.de"
        },

        new CompanyItem
        {
            Name = "NEXUS AG",
            City = "Donaueschingen",
            Website = "https://www.nexus-ag.de"
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

            CompanyDataService.SaveCompanies(Companies);

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

            CompanyDataService.SaveCompanies(Companies);
        }

        private void DeleteCompany()
        {
            if (SelectedCompany == null)
                return;

            Companies.Remove(SelectedCompany);

            CompanyDataService.SaveCompanies(Companies);
        }
    }

}