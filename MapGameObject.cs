using LevelEditor.Properties;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LevelEditor
{
    internal class MapGameObject //: PictureBox
    {
        private string type; //most important, determines prefab to be spawned
        private int health;
        private int projectileDamage;
        private float firingRate; //pause between shots
        private float patrolRange;
        private float sightRange;
        private float chaseRange;
        private bool canMove;
        private int x; //X coordinate (column in table)
        private int y; //Y coordinate (row in table)
        private Image image;

        private Point location;

        Dictionary<Image, string> imageDict = new Dictionary<Image, string>
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
            { Resources.wallBrick , "wallBrick" }
        };

        public MapGameObject()
        {
            type = "";
            health = 0;
            projectileDamage = 0;
            firingRate = 0;
            patrolRange = 0;
            sightRange = 0;
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
            projectileDamage = 0;
            firingRate = 0;
            patrolRange = 0;
            sightRange = 0;
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
        public float SightRange { get => sightRange; set => sightRange = value; }
        public float ChaseRange { get => chaseRange; set => chaseRange = value; }
        public bool CanMove { get => canMove; set => canMove = value; }
        public int X { get => x; set => x = value; }
        public int Y { get => y; set => y = value; }
        public Image Image { get => image; set => image = value; }
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

            this.type = imageDict.FirstOrDefault(x => x.Key == image).Value;
            this.image = image;
        }

        public void SetImageFromType(string type)
        {
            //See which of the images from Resources the param "image" matches
            //And set the Type property of this object based on it

            this.Image = imageDict.FirstOrDefault(x => x.Value == type).Key;
            this.type = type;
        }
    }
}
