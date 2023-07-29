using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Windows.Forms;

namespace LevelEditor {
    internal class RecentProjectsManager {
        List<Project> recentProjects;

        public RecentProjectsManager() {
            ReadRecentProjectsFromFile();
            SortRecentProjects();
        }

        private void ReadRecentProjectsFromFile() {
            if (!Directory.Exists("./data"))
                Directory.CreateDirectory("./data");

            if (!File.Exists("./data/recentProjects.json")) {
                File.Create("./data/recentProjects.json");
            }

            string json = File.ReadAllText("./data/recentProjects.json");
            try {
                RecentProjects = JsonSerializer.Deserialize<List<Project>>(json);
            }
            catch (JsonException) {
                RecentProjects = new List<Project>();
                //MessageBox.Show("JSON Exception!");
            }
        }

        public void WriteRecentProjectsToFile() {
            string json = JsonSerializer.Serialize(RecentProjects);
            File.WriteAllText("./data/recentProjects.json", json);
        }

        private void SortRecentProjects() {
            RecentProjects.Sort((x, y) => y.LastOpened.CompareTo(x.LastOpened));
        }

        public void AddProject(Project project) {
            ReadRecentProjectsFromFile();
            RecentProjects.Add(project);
            SortRecentProjects();
            WriteRecentProjectsToFile();
        }

        public List<Project> RecentProjects { get => recentProjects; set => recentProjects = value; }
    }
}
