using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace LevelEditor {
    internal class Project {
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


        public List<string> MapNameList { get => mapNameList; set => mapNameList = value; }
        public string Name { get => name; set => name = value; }
        public string GameTitle { get => gameTitle; set => gameTitle = value; }
        public string GameSubtitle { get => gameSubtitle; set => gameSubtitle = value; }
        [JsonIgnore]
        public string Path { get => path; set => path = value; } //used for recent projects, not stored in project file
        public string Author { get => author; set => author = value; }
        public DateTime DateCreated { get => dateCreated; set => dateCreated = value; }
        public DateTime LastOpened { get => lastOpened; set => lastOpened = value; }
    }
}
