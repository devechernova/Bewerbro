using System.Collections.ObjectModel;
using System.IO;
using System.Text.Json;
using Bewerbro.Models;

namespace Bewerbro.Services
{
    public static class InterviewDataService
    {
        private const string FilePath = "interviews.json";

        public static void SaveInterviews(ObservableCollection<InterviewItem> interviews)
        {
            string json = JsonSerializer.Serialize(
                interviews,
                new JsonSerializerOptions
                {
                    WriteIndented = true
                });

            File.WriteAllText(FilePath, json);
        }

        public static ObservableCollection<InterviewItem> LoadInterviews()
        {
            if (!File.Exists(FilePath))
            {
                return new ObservableCollection<InterviewItem>();
            }

            string json = File.ReadAllText(FilePath);

            return JsonSerializer.Deserialize<ObservableCollection<InterviewItem>>(json)
                   ?? new ObservableCollection<InterviewItem>();
        }
    }
}