
namespace FriendsPoint.GameObjects {
    public class Weapon : CircleHBoxObj {                                                          // Класс оружия, наследует класс GameObject
        public string Name;
        public string Type;
        // Настройки оружия
        public float Damage;
        public float HitDamage;
        public float UserFireKnockback;
        public float CameraFireShake;
        public float ReloadTime;
        public float FireRate;
        public float Spread;
        public float SpreadMultiplier;
        public float CartrigesInMagazine;
        public float TotalCartriges;
        public Vector2 HandleOffset;
        public float MoveSpeedMultiplier;
        public float RecoilStrength;
        public float RecoilStrengthForCamera;
        public float PatternIndex;
        public Vector2 TrunkOffset;

        private Vector2 HitForce = Vector2.Zero;
        public float FlyVelocity = 0f;
        public float FlyDeceleraion = 50f;
        public float HitForceVelocity = 170f;
        private float AdditionForceDeceleraion = 1f;

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
            ReloadTime = gunSets[4];
            FireRate = gunSets[5];
            Spread = gunSets[6];
            SpreadMultiplier = gunSets[7];
            CartrigesInMagazine = gunSets[8];
            TotalCartriges = gunSets[9];
            HandleOffset = Offset;
            TextureScale = Scale * 0.45f;
            RecoilStrength = recoilStrength;
            RecoilStrengthForCamera = recoilStrengthForCamera;
            PatternIndex = patIndex;
            TrunkOffset = trunkOffset;
        }
        public void AddForce(Vector2 forceVector) {
            HitForce += forceVector * HitForceVelocity;
        }
        public void Move(float deltaTime) {
            Position += HitForce * deltaTime;
            HitForce = Vector2.Lerp(HitForce, Vector2.Zero, AdditionForceDeceleraion * deltaTime);
        }
        public override void Draw(SpriteBatch render) {
            DrawEngine.Circle(render, CircleTexture, ScreenPosition, Radius, Color.Black * 0.85f, 0.1f, 0f, 1f / (300 / Radius));
            DrawEngine.Texture(render, Texture, ScreenPosition, 0.11f, Rotation);
            DrawEngine.RectFigure(render, ScreenPosition, new Rectangle(0, 0, 20, 20), new Vector2(0, 0), Color.Yellow, 0.12f);
        }
    }
}
