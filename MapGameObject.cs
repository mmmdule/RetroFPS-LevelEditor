using LevelEditor.Properties;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace LevelEditor {
    //TODO: finish the setDefaultPropsForType() method

    internal class MapGameObject //: PictureBox
    {
        private string type; //most important, determines prefab to be spawned
        private int health;
        private int projectileDamage;
        private float firingRate; //pause between shots
        private float patrolRange;
        private float attackRange;
        private float chaseRange;
        private bool canMove;
        private int x; //X coordinate (column in table)
        private int y; //Y coordinate (row in table)
        private Image image;

        private Point location;

        [JsonIgnore]
        public static Dictionary<Image, string> imageDict = new Dictionary<Image, string>
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

        public static void WriteCurrentListToJson(string path, string filename, List<MapGameObject> list) {
            path = Path.Combine(path, filename);
            if (!File.Exists(path))
                File.Create(path).Close();
            Console.Write(JsonSerializer.Serialize(list)); 
            var options1 = new JsonSerializerOptions {
                Encoder = System.Text.Encodings.Web.JavaScriptEncoder.UnsafeRelaxedJsonEscaping,
                WriteIndented = true
            };
            using (StreamWriter outputFile = new StreamWriter(path)) {
                
                outputFile.Write(JsonSerializer.Serialize(list, options1));
            }
        }

        public MapGameObject()
        {
            type = "";
            health = 0;
            //projectileDamage = 0;
            firingRate = 0;
            patrolRange = 0;
            attackRange = 0;
            chaseRange = 0;
            canMove = true;
            x = 0;
            y = 0;
            location = new Point(x, y);
            image = Resources.wallBrick;
            
        }

        public MapGameObject(int x, int y)
        {
            type = "";
            health = 0;
            //projectileDamage = 0;
            firingRate = 0;
            patrolRange = 0;
            attackRange = 0;
            chaseRange = 0;
            canMove = true;
            this.x = x;
            this.y = y;
            location = new Point(x, y);
            image = Resources.wallBrick;
        }

        public string Type { get => type; set => type = value; }
        public int Health { get => health; set => health = value; }
        public int ProjectileDamage { get => projectileDamage; set => projectileDamage = value; }
        public float FiringRate { get => firingRate; set => firingRate = value; }
        public float PatrolRange { get => patrolRange; set => patrolRange = value; }
        public float AttackRange { get => attackRange; set => attackRange = value; }
        public float ChaseRange { get => chaseRange; set => chaseRange = value; }
        public bool CanMove { get => canMove; set => canMove = value; }
        public int X { get => x; set => x = value; }
        public int Y { get => y; set => y = value; }
        [JsonIgnore]
        public Image Image { get => image; set => image = value; }

        [JsonIgnore]
        public Point Location { get {
                                        if (x != location.X || x != location.Y) {
                                            location.X = x;
                                            location.Y = y;
                                            return location;
                                        }   
                                        else
                                            return location;
                                      }
                                set => location = value; }

        public void SetTypeFromImage(Image image)
        {
            //See which of the images from Resources the param "image" matches
            //And set the Type property of this object based on it

            //tag-ovi slika postavljeni su u Resources.Designer.cs
            this.Type = image.Tag.ToString();
            this.image = image;

            setDefaultPropsForType(Type);
        }

        public void SetImageFromType(string type)
        {
            //See which of the images from Resources the param "image" matches
            //And set the Type property of this object based on it


            this.Image = imageDict.FirstOrDefault(x => x.Value == type).Key;

            this.Type = type;
            this.setDefaultPropsForType(type);
        }

        public void setDefaultPropsForType(string type) {
            //based on the type, set default values for health, firing rate, canMove etc.
            switch (type) {
                case "ArchwaySingle":
                case "ArchwaySmall":
                case "ArmorBlink":
                case "Cobweb_Wall":
                case "DoorGate":
                case "ExitDoor":
                case "Key":
                case "Stone":
                case "Torch":
                    this.canMove = false;
                    break;
                case "Bullets":
                    this.health = 15;
                    break;
                case "ShotgunAmmo":
                    this.health = 7;
                    break;
                case "SmallMedkit":
                    this.health = 10;
                    break;
                case "wallBrick":
                case "wallStone":
                case "wallMoss":
                case "tileWall":
                    this.canMove = false;
                    this.projectileDamage = 0;
                    this.firingRate = 0;
                    this.patrolRange = 0;
                    this.attackRange = 0;
                    this.chaseRange = 0;
                    break;
                case "Imp":
                    this.canMove = true;
                    this.health = 50;
                    this.firingRate = 2.25f; //pause between attacks
                    this.patrolRange = 10;
                    this.attackRange = 18;
                    this.chaseRange = 18;
                    this.attackRange = 13.5f;
                    this.projectileDamage = 16; //damage of fireball prefab
                    break;
                case "EnergyBall":
                    this.canMove = false;
                    //maybe make damage dynamic
                    break;
                case "Tri_horn":
                    this.canMove = true;
                    this.health = 100;
                    this.firingRate = 1.87f; //pause between attacks
                    this.patrolRange = 15;
                    this.attackRange = 20;
                    this.chaseRange = 25;
                    this.attackRange = 13.5f;
                    this.projectileDamage = 3 * 12; //damage of 3 EnergyBall prefabs
                    break;
                default:
                    break;
            }
        }
    }
}
