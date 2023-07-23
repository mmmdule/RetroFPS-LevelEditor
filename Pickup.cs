using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Text.Json;
using System.Text.Json.Serialization;

namespace LevelEditor {
    internal class Pickup : MapGameObject {
        private int value;
        //health, revolverAmmo, shotgunAmmo

        public Pickup(string type, int x, int y) : base(x, y) {
            this.Type = type; //"SmallMedkit", "Bullets", "ShotgunAmmo"
        }

        public Pickup(int value, string type, int x, int y) : base(x, y) {
            this.Value = value;
            this.Type = type;
        }

        public int Value { get => value; set => this.value = value; }
    }
}
