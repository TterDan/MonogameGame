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

        public int AdditionRadius;
        public Texture2D AdditionalHitboxTexture;

        public Weapon(GraphicsDevice GraphicsDevice, Texture2D texture, string name, string type, Vector2 position, int radius, int additionRadius, List<float> gunSets) {
            Name = name;
            Type = type;
            Texture = texture;
            Position = position;
            Layer = 1.0f;
            Radius = radius;
            AdditionRadius = additionRadius;
            AdditionalHitboxTexture = CreateCircleTexture(GraphicsDevice, AdditionRadius, Color.Black);
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

            TextureScale = Scale * 0.35f;
        }
        public void move() {
            currentSpeed = Vector2.Lerp(currentSpeed, Vector2.Zero, 0.2f);
            Position -= currentSpeed;
            ScreenPosition -= currentSpeed;
        }

        public override void OtherDraw(SpriteBatch render) {                // Переопределяю функцию OtherDraw() из GameObject, чтобы отрисовать что-то еще помимо базовой отрисовки
            render.Draw(
                AdditionalHitboxTexture,              //Текстура
                ScreenPosition,         // Положение 
                new Rectangle(0, 0, AdditionRadius * 2, AdditionRadius * 2),    // Область текстуры для отрисовки
                Color.Black * 0.2f,       // Цвет
                Rotation,           // Вращение
                new Vector2(AdditionRadius, AdditionRadius), // Центр объекта, вокруг которого происходит вращение и тд
                Scale,              // Масштабирование
                SpriteEffects.None, // Отражение по горизонтали и вертикали
                Layer               // Слой
            );
        }
        }
    }
