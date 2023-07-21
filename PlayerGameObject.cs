using LevelEditor.Properties;
using System.Drawing;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace LevelEditor {
    internal class PlayerGameObject {
        private int health;

        private bool hasRevolver;
        private int revolverAmmo;
        
        private bool hasShotgun;
        private int shotgunAmmo;

        private int x;
        private int y;

        [JsonIgnore]
        private readonly Image image = Resources.player;
        //A readonly field can't be assigned after the constructor exits

        public PlayerGameObject(int health, bool hasRevolver, int revolverAmmo, bool hasShotgun, int shotgunAmmo, int x, int y) {
            this.health = health;
            this.hasRevolver = hasRevolver;
            this.revolverAmmo = revolverAmmo;
            this.hasShotgun = hasShotgun;
            this.shotgunAmmo = shotgunAmmo;
            this.x = x;
            this.y = y;
        }

        public PlayerGameObject(int x, int y) {             
            this.health = 100;
            this.hasRevolver = true;
            this.revolverAmmo = 75;
            this.hasShotgun = true;
            this.shotgunAmmo = 50;
            this.x = x;
            this.y = y;
        }

        public int Health { get => health; set => health = value; }
        public bool HasRevolver { get => hasRevolver; set => hasRevolver = value; }
        public int RevolverAmmo { get => revolverAmmo; set => revolverAmmo = value; }
        public bool HasShotgun { get => hasShotgun; set => hasShotgun = value; }
        public int ShotgunAmmo { get => shotgunAmmo; set => shotgunAmmo = value; }
        public int X { get => x; set => x = value; }
        public int Y { get => y; set => y = value; }

        [JsonIgnore]
        public Image Image => image;

        public override string ToString() {
            return "PlayerGameObject{" + "health=" + health + ", hasRevolver=" + hasRevolver + ", revolverAmmo=" + revolverAmmo + ", hasShotgun=" + hasShotgun + ", shotgunAmmo=" + shotgunAmmo + ", x=" + x + ", y=" + y + '}';
        }
    }
}
