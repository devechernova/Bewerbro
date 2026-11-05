using Bewerbro.Commands;
using Bewerbro.Models;
using Bewerbro.Services;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Input;

namespace Bewerbro.ViewModels
{
    public class ApplicationsViewModel : BaseViewModel
    {
        public ObservableCollection<ApplicationItem> Applications { get; set; }

        private string _newJobTitle;
        private string _newCompany;
        private string _newStatus;
        private string _newApplicationDate;

        private ApplicationItem _selectedApplication;

        public ICommand AddApplicationCommand { get; set; }

        public ICommand UpdateApplicationCommand { get; set; }

        public ICommand DeleteApplicationCommand { get; set; }

        public ApplicationsViewModel()
        {
            AddApplicationCommand = new RelayCommand(AddApplication);
            UpdateApplicationCommand = new RelayCommand(UpdateApplication);
            DeleteApplicationCommand = new RelayCommand(DeleteApplication);

            Applications = ApplicationDataService.LoadApplications();

            if (Applications.Count == 0)
            {
                Applications = CreateDefaultApplications();

                ApplicationDataService.SaveApplications(Applications);
            }
        }

        public string NewJobTitle
        {
            get => _newJobTitle;
            set
            {
                _newJobTitle = value;
                OnPropertyChanged();
            }
        }

        public string NewCompany
        {
            get => _newCompany;
            set
            {
                _newCompany = value;
                OnPropertyChanged();
            }
        }

        public string NewStatus
        {
            get => _newStatus;
            set
            {
                _newStatus = value;
                OnPropertyChanged();
            }
        }

        public string NewApplicationDate
        {
            get => _newApplicationDate;
            set
            {
                _newApplicationDate = value;
                OnPropertyChanged();
            }
        }

        public ApplicationItem SelectedApplication
        {
            get => _selectedApplication;
            set
            {
                _selectedApplication = value;

                if (_selectedApplication != null)
                {
                    NewJobTitle = _selectedApplication.JobTitle;
                    NewCompany = _selectedApplication.Company;
                    NewStatus = _selectedApplication.Status;
                    NewApplicationDate = _selectedApplication.ApplicationDate;
                }

                OnPropertyChanged();
            }
        }
        private ObservableCollection<ApplicationItem> CreateDefaultApplications()
        {
            return new ObservableCollection<ApplicationItem>
        {
            new ApplicationItem
            {
                JobTitle = "Pflichtpraktikum Softwareentwicklung",
                Company = "medicalvalues GmbH",
                Status = "Applied",
                ApplicationDate = "16.10.2026"
            },

            new ApplicationItem
            {
                JobTitle = "Pflichtpraktikum Softwareentwicklung",
                Company = "generic.de software technologies AG",
                Status = "Applied",
                ApplicationDate = "19.10.2026"
            },

            new ApplicationItem
            {
                JobTitle = "Praktikum Softwareentwicklung",
                Company = "CAS Software AG",
                Status = "Applied",
                ApplicationDate = "21.10.2026"
            },

            new ApplicationItem
            {
                JobTitle = "Softwareentwicklung / Digital Health Engineering",
                Company = "Fraunhofer IESE",
                Status = "Applied",
                ApplicationDate = "21.10.2026"
            },

            new ApplicationItem
            {
                JobTitle = "Pflichtpraktikum Softwareentwicklung",
                Company = "Kinemic GmbH",
                Status = "Applied",
                ApplicationDate = "22.10.2026"
            },

            new ApplicationItem
            {
                JobTitle = "Pflichtpraktikum Softwareentwicklung",
                Company = "evacon IT-Solution & Consulting",
                Status = "Applied",
                ApplicationDate = "26.10.2026"
            },

            new ApplicationItem
            {
                JobTitle = "Pflichtpraktikum Softwareentwicklung",
                Company = "aicorn GmbH",
                Status = "Applied",
                ApplicationDate = "26.10.2026"
            },

            new ApplicationItem
            {
                JobTitle = "C# Softwareentwicklung",
                Company = "NEXUS / IPS GmbH",
                Status = "Applied",
                ApplicationDate = "27.10.2026"
            }
        };
        }

        private void AddApplication()
        {
            Applications.Add(new ApplicationItem
            {
                Id = Applications.Count == 0 ? 1 : Applications.Max(a => a.Id) + 1,
                JobTitle = NewJobTitle,
                Company = NewCompany,
                Status = NewStatus,
                ApplicationDate = NewApplicationDate
            });

            ApplicationDataService.SaveApplications(Applications);

            NewJobTitle = "";
            NewCompany = "";
            NewStatus = "";
            NewApplicationDate = "";

            OnPropertyChanged(nameof(NewJobTitle));
            OnPropertyChanged(nameof(NewCompany));
            OnPropertyChanged(nameof(NewStatus));
            OnPropertyChanged(nameof(NewApplicationDate));
        }

        private void UpdateApplication()
        {
            if (SelectedApplication == null)
                return;

            SelectedApplication.JobTitle = NewJobTitle;
            SelectedApplication.Company = NewCompany;
            SelectedApplication.Status = NewStatus;
            SelectedApplication.ApplicationDate = NewApplicationDate;

            ApplicationDataService.SaveApplications(Applications);
        }
        private void DeleteApplication()
        {
            if (SelectedApplication == null)
                return;

            Applications.Remove(SelectedApplication);

            ApplicationDataService.SaveApplications(Applications);
        }
    }
}