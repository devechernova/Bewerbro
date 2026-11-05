using System.Collections.ObjectModel;
using Bewerbro.Models;
using Bewerbro.Services;
using System.Windows.Input;
using Bewerbro.Commands;

namespace Bewerbro.ViewModels
{
    public class ApplicationsViewModel : BaseViewModel
    {
        public ObservableCollection<ApplicationItem> Applications { get; set; }

        public ApplicationsViewModel()
        {
            Applications = CreateDefaultApplications();
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
    }
}