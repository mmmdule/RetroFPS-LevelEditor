using LevelEditor.Properties;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace LevelEditor {
    internal class Map {
        private List<MapGameObject> mapGameObjects;
        private string name;
        private bool storyTextSegment;
        private string storyText;
        private int wallTexture;
        private int startX;
        private int startY;

        public Map(List<MapGameObject> mapGameObjects, string name, bool storyTextSegment, string storyText, int wallTexture, int startX, int startY) {
            this.mapGameObjects = mapGameObjects;
            this.name = name;
            this.storyTextSegment = storyTextSegment;
            this.storyText = storyText;
            this.wallTexture = wallTexture;
            this.startX = startX;
            this.startY = startY;
        }

        public List<MapGameObject> MapGameObjects { get => mapGameObjects; set => mapGameObjects = value; }
        public string Name { get => name; set => name = value; }
        public bool StoryTextSegment { get => storyTextSegment; set => storyTextSegment = value; }
        public string StoryText { get => storyText; set => storyText = value; }
        public int WallTexture { get => wallTexture; set => wallTexture = value; }
        public int StartX { get => startX; set => startX = value; }
        public int StartY { get => startY; set => startY = value; }


        //json serialize map object
        public void WriteMapToJson(string path, string filename) { //, Map map) {
            path = Path.Combine(path, filename);
            if (!File.Exists(path))
                File.Create(path).Close();
            Console.Write(JsonSerializer.Serialize(this));
            var options1 = new JsonSerializerOptions {
                Encoder = System.Text.Encodings.Web.JavaScriptEncoder.UnsafeRelaxedJsonEscaping,
                WriteIndented = true
            };
            using (StreamWriter outputFile = new StreamWriter(path)) {
                outputFile.Write(JsonSerializer.Serialize(this, options1));
            }
        }


    }
}
