using LevelEditor.Properties;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace LevelEditor
{
    public partial class Map
    {
        [JsonIgnore]
        private List<MapObject> mapGameObjects;
        private List<MapObject> mapObjectsForJson = new List<MapObject>();
        private List<MapNpcObject> mapNpcObjects = new List<MapNpcObject>();
        private List<Pickup> pickups = new List<Pickup>();

        private string name;
        private bool storyTextSegment;
        private string storyText;
        private int wallTexture;
        private int startX;
        private int startY;
        private PlayerGameObject playerGameObject;

        //for deserialization purposes
        [JsonConstructor]
        public Map() {

        }

        public Map(List<MapObject> mapGameObjects, string name, bool storyTextSegment, string storyText, int wallTexture, int startX, int startY)
        {
            this.mapGameObjects = mapGameObjects;
            this.name = name;
            this.storyTextSegment = storyTextSegment;
            this.storyText = storyText;
            this.wallTexture = wallTexture;
            this.startX = startX;
            this.startY = startY;

            foreach (MapObject obj in mapGameObjects)
            {
                if (obj is Pickup)
                    Pickups.Add(obj as Pickup);
                else if (obj is MapNpcObject)
                    MapNpcObjects.Add(obj as MapNpcObject);
            }
        }

        public Map(List<MapObject> mapGameObjects, string name, bool storyTextSegment, string storyText, int wallTexture, PlayerGameObject playerGameObject)
        {
            this.mapGameObjects = mapGameObjects;
            this.name = name;
            this.storyTextSegment = storyTextSegment;
            this.storyText = storyText;
            this.wallTexture = wallTexture;
            this.playerGameObject = playerGameObject;
            startX = playerGameObject.X;
            startY = playerGameObject.Y;


            for (int i = 0; i < MapGameObjects.Count; i++)
            {
                if (MapGameObjects[i] is Pickup)
                    Pickups.Add(MapGameObjects[i] as Pickup);
                else if (MapGameObjects[i] is MapNpcObject)
                    MapNpcObjects.Add(MapGameObjects[i] as MapNpcObject);
                else if (!(MapGameObjects[i] is PlayerGameObject))
                    MapObjects.Add(MapGameObjects[i]);
            }

        }

        public Map(string name, bool storyTextSegment) {
            this.name = name;
            this.storyTextSegment = storyTextSegment;

            if (storyTextSegment)
                return;

            for (int i = 0; i <= 63; i += 63) //HORIZONTAL
                for (int j = 0; j < 64; j++) {
                    MapObject tmp = new MapObject(j, i);
                    tmp.SetTypeFromImage(Resources.wallBrick);
                    this.MapObjects.Add(tmp);
                }
            for (int i = 1; i <= 62; i++) //VERTICAL
                for (int j = 0; j < 64; j += 63) {
                    MapObject tmp = new MapObject(j, i);
                    tmp.SetTypeFromImage(Resources.wallBrick);
                    this.MapObjects.Add(tmp);
                }
        }

        [JsonIgnore]
        public List<MapObject> MapGameObjects { get => mapGameObjects; set => mapGameObjects = value; }
        [JsonInclude]
        public List<MapObject> MapObjects { get => mapObjectsForJson; set => mapObjectsForJson = value; }
        [JsonInclude]
        public List<MapNpcObject> MapNpcObjects { get => mapNpcObjects; set => mapNpcObjects = value; }
        [JsonInclude]
        public List<Pickup> Pickups { get => pickups; set => pickups = value; }
        public PlayerGameObject PlayerGameObject { get => playerGameObject; set => playerGameObject = value; }
        public string Name { get => name; set => name = value; }
        public bool StoryTextSegment { get => storyTextSegment; set => storyTextSegment = value; }
        public string StoryText { get => storyText; set => storyText = value; }
        public int WallTexture { get => wallTexture; set => wallTexture = value; }
        public int StartX { get => startX; set => startX = value; }
        public int StartY { get => startY; set => startY = value; }


        //json serialize map object
        public void WriteMapToJson(string path, string filename)
        { //, Map map) {
            path = Path.Combine(path, filename);
            if (!File.Exists(path))
                File.Create(path).Close();
            Console.Write(JsonSerializer.Serialize(this));
            using (StreamWriter outputFile = new StreamWriter(path))
            {
                outputFile.Write(JsonSerializer.Serialize(this, JsonOptions.MyDefaultOptions));
            }
        }

        public void JsonAdjust() {
            MapObjects.RemoveAll(x => x == null);
            MapObjects.ForEach(x => x.SetImageFromType(x.Type));
            MapGameObjects = new List<MapObject>();
            foreach (MapObject obj in MapObjects)
                MapGameObjects.Add(obj);
            foreach (MapNpcObject obj in MapNpcObjects) {
                obj.SetImageFromType();
                MapGameObjects.Add(obj);
            }
            foreach (Pickup obj in Pickups) {
                obj.SetImageFromType();
                MapGameObjects.Add(obj);
            }
            PlayerGameObject.Image = Resources.player;
        }

    }
}
