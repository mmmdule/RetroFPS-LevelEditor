using LevelEditor.Properties;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text.Json.Serialization;
using System.Windows.Forms;

namespace LevelEditor
{

    [JsonDerivedType(typeof(Pickup))]
    [JsonDerivedType(typeof(MapNpcObject))]
    internal class MapObject
    {
        protected int x;                  //X coordinate (column in table)
        protected int y;                  //Y coordinate (row in table)
        protected string type;    //most important, determines prefab to be spawned
        protected Image image;

        [JsonIgnore]
        protected static Dictionary<Image, string> imageDict = new Dictionary<Image, string>
        {
            { Resources.ArchwaySingle, "ArchwaySingle" },
            { Resources.ArchwaySingle, "ArchwaySmall" },
            { Resources.ArmorBlink, "ArmorBlink" },
            { Resources.Bullets , "Bullets" },
            { Resources.Cobweb_Wall , "Cobweb_Wall" },
            { Resources.Imp , "Imp" },
            { Resources.DoorGate , "DoorGate" },
            { Resources.EnergyBall , "EnergyBall" },
            { Resources.ExitDoor , "ExitDoor" },
            { Resources.Key , "Key" },
            { Resources.ShotgunAmmo , "ShotgunAmmo" },
            { Resources.SmallMedkit , "SmallMedkit" },
            { Resources.Stone, "Stone" },
            { Resources.Torch , "Torch" },
            { Resources.Tri_horn , "Tri_horn" },
            { Resources.wallBrick , "wallBrick" },
            { Resources.wallStone , "wallStone" },
            { Resources.wallMoss , "wallMoss" },
            { Resources.tileWall, "tileWall" }
        };

        public MapObject(int x, int y)
        {
            X = x;
            Y = y;
            image = Resources.wallBrick;
        }

        public MapObject(int x, int y, string type)
        {
            X = x;
            Y = y;
            Type = type;
            SetImageFromType(type);
        }

        public MapObject(int x, int y, Image image)
        {
            X = x;
            Y = y;
            Image = image;
        }

        public int X { get => x; set => x = value; }
        public int Y { get => y; set => y = value; }
        public string Type { get => type; set => type = value; }
        [JsonIgnore]
        public Image Image { get => image; set => image = value; }

        public virtual void SetTypeFromImage(Image image)
        {
            //See which of the images from Resources the param "image" matches
            //And set the Type property of this object based on it

            //tag-ovi slika postavljeni su u Resources.Designer.cs
            Type = image.Tag.ToString();
        }


        public virtual void SetImageFromType(string type)
        {
            //See which of the images from Resources the param "image" matches
            //And set the Type property of this object based on it


            Image = imageDict.FirstOrDefault(x => x.Value == type).Key;

            Type = type;
        }
    }
}
