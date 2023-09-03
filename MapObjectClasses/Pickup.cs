using LevelEditor.Properties;
using System.Drawing;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace LevelEditor
{

    public partial class Pickup : MapObject
    {
        private int value;
        //health, revolverAmmo, shotgunAmmo
        public Pickup() : base() {
        }


        public Pickup(string type, int x, int y) : base(x, y)
        {
            Type = type; //"SmallMedkit", "Bullets", "ShotgunAmmo"
            SetDefaultValues();
        }

        public Pickup(int value, string type, int x, int y) : base(x, y)
        {
            Value = value;
            Type = type;
            SetDefaultValues();
        }

        public Pickup(string type, int x, int y, Image image) : base(x, y, image)
        {
            Value = value;
            Type = type;
            SetDefaultValues();
        }

        [JsonInclude]
        public int Value { get => value; set => this.value = value; }

        public void SetDefaultValues()
        {
            switch (Type)
            {
                case "SmallMedkit":
                    Value = 10;
                    break;
                case "Bullets":
                    Value = 15;
                    break;
                case "ShotgunAmmo":
                    Value = 7;
                    break;
                default:
                    Value = 0;
                    break;
            }
        }

        public void SetImageFromType() {
            switch (Type) {
                case "SmallMedkit":
                    Image = Resources.SmallMedkit;
                    break;
                case "Bullets":
                    Image = Resources.Bullets;
                    break;
                case "ShotgunAmmo":
                    Image = Resources.ShotgunAmmo;
                    break;
                default:
                    throw new System.Exception("Invalid pickup type while setting image");
                    break;
            }
        }
    }
}
