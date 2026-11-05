using Bewerbro.Commands;
using Bewerbro.Models;
using Bewerbro.Services;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Input;

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
            Id = 1,
            Name = "CGM",
            City = "Koblenz",
            Website = "https://www.cgm.com"
        },

        new CompanyItem
        {
            Id = 2,
            Name = "medicalvalues",
            City = "Karlsruhe",
            Website = "https://www.medicalvalues.de"
        },

        new CompanyItem
        {
            Id = 3,
            Name = "generic.de software technologies AG",
            City = "Karlsruhe",
            Website = "https://www.generic.de"
        },

        new CompanyItem
        {
            Id = 4,
            Name = "TelemaxX",
            City = "Karlsruhe",
            Website = "https://www.telemaxx.de"
        },

        new CompanyItem
        {
            Id = 5,
            Name = "CAS Software AG",
            City = "Karlsruhe",
            Website = "https://www.cas.de"
        },

        new CompanyItem
        {
            Id = 6,
            Name = "Bosch",
            City = "Karlsruhe",
            Website = "https://www.bosch.de"
        },

        new CompanyItem
        {
            Id = 7,
            Name = "Fraunhofer IOSB",
            City = "Karlsruhe",
            Website = "https://www.iosb.fraunhofer.de"
        },

        new CompanyItem
        {
            Id = 8,
            Name = "Kinemic",
            City = "Karlsruhe",
            Website = "https://www.kinemic.com"
        },

        new CompanyItem
        {
            Id = 9,
            Name = "CodeWerk",
            City = "Karlsruhe",
            Website = "https://www.codewerk.de"
        },

        new CompanyItem
        {
            Id = 10,
            Name = "Evacorn",
            City = "Karlsruhe",
            Website = "https://www.evacorn.com"
        },

        new CompanyItem
        {
            Id = 11,
            Name = "Aicorn",
            City = "Karlsruhe",
            Website = "https://www.aicorn.de"
        },

        new CompanyItem
        {
            Id = 12,
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
                Id = Companies.Count == 0 ? 1 : Companies.Max(c => c.Id) + 1,
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