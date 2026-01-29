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
        public Vector2 handleOffset;
        public float moveSpeedMultiplier;

        public Vector2 currentSpeed;

        public int AdditionRadius;
        public Texture2D AdditionalHitboxTexture;

        public Weapon(GraphicsDevice GraphicsDevice, Texture2D texture, string name, string type, Vector2 position, int radius, int additionRadius, List<float> gunSets, Vector2 Offset) {
            Name = name;
            Type = type;
            Texture = texture;
            Position = position;
            Layer = 1.0f;
            Radius = radius;
            AdditionRadius = additionRadius;
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
            handleOffset = Offset;
            TextureScale = Scale * 0.45f;
        }
        public void move() {
            currentSpeed = Vector2.Lerp(currentSpeed, Vector2.Zero, 0.2f);
            Position -= currentSpeed;
            ScreenPosition -= currentSpeed;
        }

        public override void Draw(SpriteBatch render) {
            DrawEngine.DrawTexture(render, Texture, ScreenPosition, null, null, Rotation, 0.5f, 0.12f);
            DrawEngine.DrawCircle(render, ScreenPosition, DrawRect.Value, new Vector2(DrawRect.Value.Width / 2, DrawRect.Value.Height / 2), Radius, Color.Black, Rotation, 1, 0.11f);
            Rectangle AdditionDrawRect = new Rectangle(0, 0, AdditionRadius * 2, AdditionRadius * 2);
            DrawEngine.DrawCircle(render, ScreenPosition, AdditionDrawRect, new Vector2(AdditionDrawRect.Width / 2, AdditionDrawRect.Height / 2), AdditionRadius, Color.Black * 0.5f, Rotation, 1, 0.1f);
        }
    }
}
