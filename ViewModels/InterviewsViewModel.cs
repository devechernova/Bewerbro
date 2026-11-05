using Bewerbro.Commands;
using Bewerbro.Models;
using Bewerbro.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Bewerbro.ViewModels
{
    public class InterviewsViewModel : BaseViewModel
    {
        public ObservableCollection<InterviewItem> Interviews { get; set; }

        private string _newCompany;
        private string _newPosition;
        private string _newInterviewDate;
        private string _newInterviewTime;
        private string _newLocation;
        private string _newContactPerson;
        private string _newStatus;
        private string _newNotes;

        private InterviewItem _selectedInterview;

        public ICommand AddInterviewCommand { get; set; }

        public ICommand UpdateInterviewCommand { get; set; }

        public ICommand DeleteInterviewCommand { get; set; }

        public string NewCompany
        {
            get => _newCompany;
            set
            {
                _newCompany = value;
                OnPropertyChanged();
            }
        }

        public string NewPosition
        {
            get => _newPosition;
            set
            {
                _newPosition = value;
                OnPropertyChanged();
            }
        }

        public string NewInterviewDate
        {
            get => _newInterviewDate;
            set
            {
                _newInterviewDate = value;
                OnPropertyChanged();
            }
        }

        public string NewInterviewTime
        {
            get => _newInterviewTime;
            set
            {
                _newInterviewTime = value;
                OnPropertyChanged();
            }
        }

        public string NewLocation
        {
            get => _newLocation;
            set
            {
                _newLocation = value;
                OnPropertyChanged();
            }
        }

        public string NewContactPerson
        {
            get => _newContactPerson;
            set
            {
                _newContactPerson = value;
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

        public string NewNotes
        {
            get => _newNotes;
            set
            {
                _newNotes = value;
                OnPropertyChanged();
            }
        }

        public InterviewItem SelectedInterview
        {
            get => _selectedInterview;
            set
            {
                _selectedInterview = value;

                if (_selectedInterview != null)
                {
                    NewCompany = _selectedInterview.Company;
                    NewPosition = _selectedInterview.Position;
                    NewInterviewDate = _selectedInterview.InterviewDate;
                    NewInterviewTime = _selectedInterview.InterviewTime;
                    NewLocation = _selectedInterview.Location;
                    NewContactPerson = _selectedInterview.ContactPerson;
                    NewStatus = _selectedInterview.Status;
                    NewNotes = _selectedInterview.Notes;
                }

                OnPropertyChanged();
            }
        }

        public InterviewsViewModel()
        {
            AddInterviewCommand =
                new RelayCommand(AddInterview);

            UpdateInterviewCommand =
                new RelayCommand(UpdateInterview);

            DeleteInterviewCommand =
                new RelayCommand(DeleteInterview);

            Interviews = InterviewDataService.LoadInterviews();

            if (Interviews.Count == 0)
            {
                Interviews = CreateDefaultInterviews();

                InterviewDataService.SaveInterviews(Interviews);
            }
        }
        private ObservableCollection<InterviewItem> CreateDefaultInterviews()
        {
            return new ObservableCollection<InterviewItem>()
    {
        new InterviewItem
        {
            Id = 1,
            Company = "NEXUS / IPS GmbH",
            Position = "C# Softwareentwicklung",
            InterviewDate = "15.11.2026",
            InterviewTime = "10:00",
            Location = "Microsoft Teams",
            ContactPerson = "Jessica Maddée",
            Status = "Planned",
            Notes = "Vorstellungsgespräch"
        },

        new InterviewItem
        {
            Id = 2,
            Company = "Kinemic GmbH",
            Position = "Pflichtpraktikum Softwareentwicklung",
            InterviewDate = "18.11.2026",
            InterviewTime = "14:00",
            Location = "Vor Ort",
            ContactPerson = "Tom Lenz",
            Status = "Planned",
            Notes = "Technisches Gespräch"
        }
    };
        }

        private void AddInterview()
        {
            Interviews.Add(new InterviewItem
            {
                Id = Interviews.Count == 0 ? 1 : Interviews.Max(i => i.Id) + 1,
                Company = NewCompany,
                Position = NewPosition,
                InterviewDate = NewInterviewDate,
                InterviewTime = NewInterviewTime,
                Location = NewLocation,
                ContactPerson = NewContactPerson,
                Status = NewStatus,
                Notes = NewNotes
            });

            InterviewDataService.SaveInterviews(Interviews);

            NewCompany = "";
            NewPosition = "";
            NewInterviewDate = "";
            NewInterviewTime = "";
            NewLocation = "";
            NewContactPerson = "";
            NewStatus = "";
            NewNotes = "";

            OnPropertyChanged(nameof(NewCompany));
            OnPropertyChanged(nameof(NewPosition));
            OnPropertyChanged(nameof(NewInterviewDate));
            OnPropertyChanged(nameof(NewInterviewTime));
            OnPropertyChanged(nameof(NewLocation));
            OnPropertyChanged(nameof(NewContactPerson));
            OnPropertyChanged(nameof(NewStatus));
            OnPropertyChanged(nameof(NewNotes));
        }

        private void UpdateInterview()
        {
            if (SelectedInterview == null)
                return;

            SelectedInterview.Company = NewCompany;
            SelectedInterview.Position = NewPosition;
            SelectedInterview.InterviewDate = NewInterviewDate;
            SelectedInterview.InterviewTime = NewInterviewTime;
            SelectedInterview.Location = NewLocation;
            SelectedInterview.ContactPerson = NewContactPerson;
            SelectedInterview.Status = NewStatus;
            SelectedInterview.Notes = NewNotes;

            InterviewDataService.SaveInterviews(Interviews);
        }

        private void DeleteInterview()
        {
            if (SelectedInterview == null)
                return;

            Interviews.Remove(SelectedInterview);

            InterviewDataService.SaveInterviews(Interviews);
        }
    }
}
