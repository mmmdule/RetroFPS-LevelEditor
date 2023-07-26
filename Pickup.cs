using System.Drawing;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace LevelEditor {

    internal class Pickup : MapObject {
        private int value;
        //health, revolverAmmo, shotgunAmmo

        public Pickup(string type, int x, int y) : base(x, y) {
            this.Type = type; //"SmallMedkit", "Bullets", "ShotgunAmmo"
            SetDefaultValues();
        }

        public Pickup(int value, string type, int x, int y) : base(x, y) {
            this.Value = value;
            this.Type = type;
            SetDefaultValues();
        }

        public Pickup(string type, int x, int y, Image image) : base(x, y, image) {
            this.Value = value;
            this.Type = type;
            SetDefaultValues();
        }

        [JsonInclude]
        public int Value { get => value; set => this.value = value; }

        public void SetDefaultValues() {
            switch (Type) {
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
    }
}
