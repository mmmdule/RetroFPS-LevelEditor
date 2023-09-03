using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Windows.Forms;

namespace LevelEditor {
    public partial class Project {
        //maps will be stored in "./maps/<MapName>.json" inside the project directory
        //that way we don't store the maps in the project file
        private List<String> mapNameList; 

        private string name;
        private string gameTitle;
        private string gameSubtitle;
        [JsonIgnore]
        private string path; //used for recent projects, not stored in project file
        private string author;

        private DateTime dateCreated;
        private DateTime lastOpened;

        public Project() {
            mapNameList = new List<string>();
            name = "";
            gameTitle = "";
            gameSubtitle = "";
            path = "";
            author = "";
            dateCreated = DateTime.Now;
            lastOpened = DateTime.Now;
        }

        public Project(string name, string gameTitle, string gameSubtitle, string path, string author) {
            mapNameList = new List<string>();
            this.name = name;
            this.gameTitle = gameTitle;
            this.gameSubtitle = gameSubtitle;
            this.path = path;
            this.author = author;
            dateCreated = DateTime.Now;
            lastOpened = DateTime.Now;
        }

        public void CreateProjectDirectory(string path, string name) {
            if(!Directory.Exists($"{path}\\{name}"))
                Directory.CreateDirectory($"{path}\\{name}");
            Directory.CreateDirectory($"{path}\\{name}\\maps");
        }

        public void SaveToJsonFile(string path, string name) {
            string jsonString = JsonSerializer.Serialize<Project>(this, JsonOptions.MyDefaultOptions);
            File.WriteAllText($"{path}\\{name}\\{name}.lep", jsonString);
            //lep == Level Editor Project
        }

        public Map ReadMap(int index) {
            string tmpPath = $"{path}\\{name}\\maps\\{mapNameList[index]}.lem";
            try {
                //all classes used in map need empty constructor for deserialization
                Map map = JsonSerializer.Deserialize<Map>(File.ReadAllText($"{tmpPath}")/*, JsonOptions.MyDefaultOptions*/);

                //map adjustments
                map.JsonAdjust();

                //Map map = dto.convertToMap();
                return map;
            }
            catch {
                return null;
            }
        }

        public List<string> MapNameList { get => mapNameList; set => mapNameList = value; }
        public string Name { get => name; set => name = value; }
        public string GameTitle { get => gameTitle; set => gameTitle = value; }
        public string GameSubtitle { get => gameSubtitle; set => gameSubtitle = value; }
        
        public string Path { get => path; set => path = value; } //used for recent projects, not important for project file
        public string Author { get => author; set => author = value; }
        public DateTime DateCreated { get => dateCreated; set => dateCreated = value; }
        public DateTime LastOpened { get => lastOpened; set => lastOpened = value; }
    }
}
