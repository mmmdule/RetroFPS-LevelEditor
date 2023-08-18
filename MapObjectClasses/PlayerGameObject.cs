using LevelEditor.Properties;
using System.Drawing;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace LevelEditor
{
    public partial class PlayerGameObject : MapObject
    {
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

        public PlayerGameObject(int health, bool hasRevolver, int revolverAmmo, bool hasShotgun, int shotgunAmmo, int x, int y) : base(x, y)
        {
            type = "player";
            image = Resources.player;

            this.health = health;
            this.hasRevolver = hasRevolver;
            this.revolverAmmo = revolverAmmo;
            this.hasShotgun = hasShotgun;
            this.shotgunAmmo = shotgunAmmo;
        }

        public PlayerGameObject(int x, int y) : base(x, y)
        {
            type = "player";
            image = Resources.player;

            health = 100;
            hasRevolver = true;
            revolverAmmo = 75;
            hasShotgun = true;
            shotgunAmmo = 50;
        }

        //for deserialization purposes
        public PlayerGameObject() {
        }

        public int Health { get => health; set => health = value; }
        public bool HasRevolver { get => hasRevolver; set => hasRevolver = value; }
        public int RevolverAmmo { get => revolverAmmo; set => revolverAmmo = value; }
        public bool HasShotgun { get => hasShotgun; set => hasShotgun = value; }
        public int ShotgunAmmo { get => shotgunAmmo; set => shotgunAmmo = value; }

        public override string ToString()
        {
            return "PlayerGameObject{" + "health=" + health + ", hasRevolver=" + hasRevolver + ", revolverAmmo=" + revolverAmmo + ", hasShotgun=" + hasShotgun + ", shotgunAmmo=" + shotgunAmmo + ", x=" + X + ", y=" + Y + '}';
        }
    }
}
