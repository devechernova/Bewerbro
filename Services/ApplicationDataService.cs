using System.Collections.ObjectModel;
using System.IO;
using System.Text.Json;
using Bewerbro.Models;

namespace Bewerbro.Services
{
    public static class ApplicationDataService
    {
        private const string FilePath = "applications.json";

        public static void SaveApplications(ObservableCollection<ApplicationItem> applications)
        {
            string json = JsonSerializer.Serialize(
                applications,
                new JsonSerializerOptions
                {
                    WriteIndented = true
                });

            File.WriteAllText(FilePath, json);
        }

        public static ObservableCollection<ApplicationItem> LoadApplications()
        {
            if (!File.Exists(FilePath))
            {
                return new ObservableCollection<ApplicationItem>();
            }

            string json = File.ReadAllText(FilePath);

            return JsonSerializer.Deserialize<ObservableCollection<ApplicationItem>>(json)
                   ?? new ObservableCollection<ApplicationItem>();
        }
    }
}