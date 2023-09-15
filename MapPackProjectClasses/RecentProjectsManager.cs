using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Windows.Forms;

namespace LevelEditor {
    internal class RecentProjectsManager {
        static List<Project> recentProjects;

        [JsonIgnore]
        string path = Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData) + "/Level Editor";

        public RecentProjectsManager() {
            ReadRecentProjectsFromFile();
            SortRecentProjects();
        }

        private void ReadRecentProjectsFromFile() {
            if (!Directory.Exists(path))
                Directory.CreateDirectory(path);

            if (!File.Exists(path + "/recentProjects.json")) {
                File.Create(path + "/recentProjects.json");
            }

            string json = File.ReadAllText(path + "/recentProjects.json");
            try {
                RecentProjects = JsonSerializer.Deserialize<List<Project>>(json);
            }
            catch (JsonException) {
                RecentProjects = new List<Project>();
                //MessageBox.Show("JSON Exception!");
            }
        }

        public void WriteRecentProjectsToFile() {
            string json = JsonSerializer.Serialize(RecentProjects, JsonOptions.MyDefaultOptions);
            File.WriteAllText(path + "/recentProjects.json", json);
        }

        private void SortRecentProjects() {
            RecentProjects.Sort((x, y) => x.LastOpened.CompareTo(y.LastOpened));
        }

        public void AddProject(Project project) {
            ReadRecentProjectsFromFile();
            RecentProjects.Add(project);
            SortRecentProjects();
            WriteRecentProjectsToFile();
        }

        public void UpdateRecentProjects(Project project) {
            bool found = recentProjects.Exists(x => x.Name == project.Name && x.Path == project.Path);

            if (!found) {
                AddProject(project);
                return;
            }

            recentProjects.Find(x => x.Name == project.Name && x.Path == project.Path).LastOpened = DateTime.Now;
            WriteRecentProjectsToFile();
        }

        public void ClearRecentProjects() {
            recentProjects.Clear();
            WriteRecentProjectsToFile();
        }

        public List<Project> RecentProjects { get => recentProjects; set => recentProjects = value; }
    }
}
