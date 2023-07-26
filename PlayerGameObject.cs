using LevelEditor.Properties;
using System.Drawing;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace LevelEditor {
    internal class PlayerGameObject : MapObject{
        private int health;

        private bool hasRevolver;
        private int revolverAmmo;
        
        private bool hasShotgun;
        private int shotgunAmmo;

        //private int x;
        //private int y;

        //private const string type = "Player";

        //[JsonIgnore]
        //private readonly Image image = Resources.player;
        ////A readonly field can't be assigned after the constructor exits

        public PlayerGameObject(int health, bool hasRevolver, int revolverAmmo, bool hasShotgun, int shotgunAmmo, int x, int y) : base(x, y) {
            this.type = "player";
            this.image = Resources.player;

            this.health = health;
            this.hasRevolver = hasRevolver;
            this.revolverAmmo = revolverAmmo;
            this.hasShotgun = hasShotgun;
            this.shotgunAmmo = shotgunAmmo;
        }

        public PlayerGameObject(int x, int y) : base(x, y) {
            this.type = "player";
            this.image = Resources.player;

            this.health = 100;
            this.hasRevolver = true;
            this.revolverAmmo = 75;
            this.hasShotgun = true;
            this.shotgunAmmo = 50;
        }

        public int Health { get => health; set => health = value; }
        public bool HasRevolver { get => hasRevolver; set => hasRevolver = value; }
        public int RevolverAmmo { get => revolverAmmo; set => revolverAmmo = value; }
        public bool HasShotgun { get => hasShotgun; set => hasShotgun = value; }
        public int ShotgunAmmo { get => shotgunAmmo; set => shotgunAmmo = value; }

        public override string ToString() {
            return "PlayerGameObject{" + "health=" + health + ", hasRevolver=" + hasRevolver + ", revolverAmmo=" + revolverAmmo + ", hasShotgun=" + hasShotgun + ", shotgunAmmo=" + shotgunAmmo + ", x=" + X + ", y=" + Y + '}';
        }
    }
}
