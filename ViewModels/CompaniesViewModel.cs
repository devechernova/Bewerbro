using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;

namespace Bewerbro.ViewModels
{
    public class CompaniesViewModel : BaseViewModel
    {
        public ObservableCollection<CompanyItem> Companies { get; set; }

        public CompaniesViewModel()
        {
            Companies = new ObservableCollection<CompanyItem>()
            {
                new CompanyItem
                {
                    Name = "NEXUS AG",
                    City = "Karlsruhe"
                },

                new CompanyItem
                {
                    Name = "Vector Informatik",
                    City = "Stuttgart"
                },

                new CompanyItem
                {
                    Name = "dmTECH",
                    City = "Karlsruhe"
                },

                new CompanyItem
                {
                    Name = "msg systems",
                    City = "Karlsruhe"
                }
            };
        }
    }

    public class CompanyItem
    {
        public string Name { get; set; }

        public string City { get; set; }
    }
}