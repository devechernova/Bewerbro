using System.Collections.ObjectModel;
using System.IO;
using System.Text.Json;
using Bewerbro.Models;

namespace Bewerbro.Services
{
    public static class CompanyDataService
    {
        private const string FilePath = "companies.json";

        public static void SaveCompanies(ObservableCollection<CompanyItem> companies)
        {
            string json = JsonSerializer.Serialize(
                companies,
                new JsonSerializerOptions
                {
                    WriteIndented = true
                });

            File.WriteAllText(FilePath, json);
        }

        public static ObservableCollection<CompanyItem> LoadCompanies()
        {
            if (!File.Exists(FilePath))
            {
                return new ObservableCollection<CompanyItem>();
            }

            string json = File.ReadAllText(FilePath);

            return JsonSerializer.Deserialize<ObservableCollection<CompanyItem>>(json)
                   ?? new ObservableCollection<CompanyItem>();
        }
    }
}