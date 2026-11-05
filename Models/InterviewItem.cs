using Bewerbro.ViewModels;

namespace Bewerbro.Models
{
    public class InterviewItem : BaseViewModel
    {
        public int Id { get; set; }

        public int ApplicationId { get; set; }

        private string _company;
        private string _position;
        private string _interviewDate;
        private string _interviewTime;
        private string _location;
        private string _contactPerson;
        private string _status;
        private string _notes;

        public string Company
        {
            get => _company;
            set
            {
                _company = value;
                OnPropertyChanged();
            }
        }

        public string Position
        {
            get => _position;
            set
            {
                _position = value;
                OnPropertyChanged();
            }
        }

        public string InterviewDate
        {
            get => _interviewDate;
            set
            {
                _interviewDate = value;
                OnPropertyChanged();
            }
        }

        public string InterviewTime
        {
            get => _interviewTime;
            set
            {
                _interviewTime = value;
                OnPropertyChanged();
            }
        }

        public string Location
        {
            get => _location;
            set
            {
                _location = value;
                OnPropertyChanged();
            }
        }

        public string ContactPerson
        {
            get => _contactPerson;
            set
            {
                _contactPerson = value;
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

        public string Notes
        {
            get => _notes;
            set
            {
                _notes = value;
                OnPropertyChanged();
            }
        }
    }
}
