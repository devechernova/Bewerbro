using System.Collections.ObjectModel;

namespace Bewerbro.ViewModels
{
    public class ApplicationsViewModel : BaseViewModel
    {
        public ObservableCollection<ApplicationItem> Applications { get; set; }

        public ApplicationsViewModel()
        {
            Applications = new ObservableCollection<ApplicationItem>()
            {
                new ApplicationItem
                {
                    Company = "NEXUS AG",
                    Position = "Praktikum Softwareentwicklung",
                    Status = "InReview"
                },

                new ApplicationItem
                {
                    Company = "Vector Informatik",
                    Position = "Werkstudent C#",
                    Status = "Sent"
                },

                new ApplicationItem
                {
                    Company = "dmTECH",
                    Position = "Junior Developer",
                    Status = "Interview"
                }
            };
        }
    }

    public class ApplicationItem
    {
        public string Company { get; set; }

        public string Position { get; set; }

        public string Status { get; set; }
    }
}