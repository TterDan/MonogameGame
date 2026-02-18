
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
        public float DropSpeed = 20f;
        public float RecoilStrength;
        public float RecoilStrengthForCamera;
        public float PatternIndex;
        public Vector2 TrunkOffset;
        public Vector2 currentSpeed;

        public Weapon(GraphicsDevice GraphicsDevice, Texture2D texture, string name, string type, Vector2 position, int radius, int additionRadius, List<float> gunSets, Vector2 Offset, float recoilStrength, float recoilStrengthForCamera, float patIndex, Vector2 trunkOffset) {
            Name = name;
            Type = type;
            Texture = texture;
            Position = position;
            Layer = 1.0f;
            Radius = radius;
            AdditionRadius = additionRadius;
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
            RecoilStrength = recoilStrength;
            RecoilStrengthForCamera = recoilStrengthForCamera;
            PatternIndex = patIndex;
            TrunkOffset = trunkOffset;
        }
        public void move() {
            currentSpeed = Vector2.Lerp(currentSpeed, Vector2.Zero, 0.15f);
            Position -= currentSpeed;
            ScreenPosition -= currentSpeed;
        }
        public override void Draw(SpriteBatch render) {
            DrawEngine.Circle(render, CircleTexture, ScreenPosition, Radius, Color.Black * 0.85f, 0.1f, 0f, 1f / (300 / Radius));
            DrawEngine.Texture(render, Texture, ScreenPosition, 0.11f, Rotation);
            DrawEngine.RectFigure(render, ScreenPosition, new Rectangle(0, 0, 20, 20), new Vector2(0, 0), Color.Yellow, 0.12f);
        }
    }
}
