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
    //TODO: finish the setDefaultPropsForType() method

    internal class MapNpcObject : MapObject
    {
        //private string type; //most important, determines prefab to be spawned
        private int health;
        private int projectileDamage;
        private float firingRate; //pause between shots
        private float patrolRange;
        private float attackRange;
        private float chaseRange;
        private bool canMove;
        //private int x; //X coordinate (column in table)
        //private int y; //Y coordinate (row in table)

        private Point location;



        public static void WriteCurrentListToJson(string path, string filename, List<MapNpcObject> list)
        {
            path = Path.Combine(path, filename);
            if (!File.Exists(path))
                File.Create(path).Close();
            Console.Write(JsonSerializer.Serialize(list));
            var options1 = new JsonSerializerOptions
            {
                Encoder = System.Text.Encodings.Web.JavaScriptEncoder.UnsafeRelaxedJsonEscaping,
                WriteIndented = true
            };
            using (StreamWriter outputFile = new StreamWriter(path))
            {

                outputFile.Write(JsonSerializer.Serialize(list, options1));
            }
        }

        public MapNpcObject() : base(0, 0)
        {
            Type = "";
            health = 0;
            //projectileDamage = 0;
            firingRate = 0;
            patrolRange = 0;
            attackRange = 0;
            chaseRange = 0;
            canMove = true;
            X = 0;
            Y = 0;
            location = new Point(X, Y);
            image = Resources.wallBrick;
        }

        public MapNpcObject(int x, int y) : base(x, y)
        {
            Type = "";
            health = 0;
            //projectileDamage = 0;
            firingRate = 0;
            patrolRange = 0;
            attackRange = 0;
            chaseRange = 0;
            canMove = true;
            X = x;
            Y = y;
            location = new Point(x, y);
            image = Resources.wallBrick;
        }

        public MapNpcObject(int x, int y, Image image) : base(x, y, image)
        {
            Type = image.Tag.ToString();
            health = 0;
            //projectileDamage = 0;
            firingRate = 0;
            patrolRange = 0;
            attackRange = 0;
            chaseRange = 0;
            canMove = true;
            X = x;
            Y = y;
            location = new Point(x, y);
            this.image = image;
            setDefaultPropsForType(image.Tag.ToString());
        }

        public int Health { get => health; set => health = value; }
        public int ProjectileDamage { get => projectileDamage; set => projectileDamage = value; }
        public float FiringRate { get => firingRate; set => firingRate = value; }
        public float PatrolRange { get => patrolRange; set => patrolRange = value; }
        public float AttackRange { get => attackRange; set => attackRange = value; }
        public float ChaseRange { get => chaseRange; set => chaseRange = value; }
        public bool CanMove { get => canMove; set => canMove = value; }

        [JsonIgnore]
        public Point Location
        {
            get
            {
                if (X != location.X || X != location.Y)
                {
                    location.X = X;
                    location.Y = Y;
                    return location;
                }
                else
                    return location;
            }
            set => location = value;
        }

        public override void SetImageFromType(string type)
        {
            //See which of the images from Resources the param "image" matches
            //And set the Type property of this object based on it

            Image = imageDict.FirstOrDefault(x => x.Value == type).Key;

            Type = type;
            setDefaultPropsForType(type);
        }

        public void setDefaultPropsForType(string type)
        {
            //based on the type, set default values for health, firing rate, canMove etc.
            switch (type)
            {
                case "Imp":
                    canMove = true;
                    health = 50;
                    firingRate = 2.25f; //pause between attacks
                    patrolRange = 10;
                    attackRange = 18;
                    chaseRange = 18;
                    attackRange = 13.5f;
                    projectileDamage = 16; //damage of fireball prefab
                    break;
                //case "EnergyBall":
                //    this.canMove = false;
                //    //maybe make damage dynamic
                //    break;
                case "Tri_horn":
                    canMove = true;
                    health = 100;
                    firingRate = 1.87f; //pause between attacks
                    patrolRange = 15;
                    attackRange = 20;
                    chaseRange = 25;
                    attackRange = 13.5f;
                    projectileDamage = 3 * 12; //damage of 3 EnergyBall prefabs
                    break;
                default:
                    break;
            }
        }
    }
}
