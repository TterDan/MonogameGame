using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;

namespace FriendsPoint.GameObjects {
    public class Weapon : CircleHBoxObj {                                                          // Класс оружия, наследует класс GameObject
        public string Name;
        public string Type;
        public Rectangle Rect;

        // Настройки оружия
        public float Damage;
        public float HitDamage;
        public float UserFireKnockback;
        public float CameraFireShake;
        public float reloadTime;
        public float fireRate;
        public float spread;
        public float spreadMultiplier;
        public float cartrigesInMagazine;
        public float totalCartriges;

        public float moveSpeedMultiplier;


        public Vector2 currentSpeed;

        public Weapon(GraphicsDevice GraphicsDevice, string name, string type, Vector2 position, int radius, List<float> gunSets) {
            Name = name;
            Type = type;
            Position = position;
            Layer = 1.0f;
            Radius = radius;
            HitboxTexture = CreateCircleTexture(GraphicsDevice, Radius, Color.Black);
            DrawRect = new Rectangle(0, 0, Radius * 2, Radius * 2);
            Damage = gunSets[0];
            HitDamage = gunSets[1];
            UserFireKnockback = gunSets[2];
            CameraFireShake = gunSets[3];
            reloadTime = gunSets[4];
            fireRate = gunSets[5];
            spread = gunSets[6];
            spreadMultiplier = gunSets[7];
            cartrigesInMagazine = gunSets[8];
            totalCartriges = gunSets[9];
        }
        public void move() {
            currentSpeed = Vector2.Lerp(currentSpeed, Vector2.Zero, 0.2f);
            Position -= currentSpeed;
            ScreenPosition -= currentSpeed;
        }
    }
}
