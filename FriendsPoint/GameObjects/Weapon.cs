
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

        public float TextureRotationInPlayerHand;

        private Vector2 HitForce = Vector2.Zero;
        public float FlyVelocity = 0f;
        public float FlyDeceleraion = 50f;
        public float HitForceVelocity = 170f;
        private float AdditionForceDeceleraion = 1f;
        public float ReloadCount;
        public float CoolDownTime;

        public Weapon(GraphicsDevice GraphicsDevice, 
            Texture2D texture, 
            string name, 
            string type, 
            Vector2 position, 
            int radius, 
            int additionRadius, 
            Vector2 Offset, 
            Vector2 trunkOffset,
            float damage,
            float hitDamage,
            float userFireKnockback,
            float recoilStrengthForCamera,
            float reloadTime,
            float coolDownTime,
            float patternIndex,
            float recoilStrength,
            float cartrigesInMagazine,
            float totalCartriges,
            float textureScale,
            float textureRotationInPlayerHand
            ) {
            Name = name;
            Type = type;
            Texture = texture;
            Position = position;
            Layer = 1.0f;
            Radius = radius;
            AdditionRadius = additionRadius;
            Damage = damage;
            HitDamage = hitDamage;
            UserFireKnockback = userFireKnockback;
            RecoilStrengthForCamera = recoilStrengthForCamera;
            ReloadTime = reloadTime;
            CoolDownTime = coolDownTime;
            PatternIndex = patternIndex;
            RecoilStrength = recoilStrength;
            CartrigesInMagazine = cartrigesInMagazine;
            TotalCartriges = totalCartriges;
            TextureScale = Scale * textureScale;
            TextureRotationInPlayerHand = textureRotationInPlayerHand;

            TrunkOffset = trunkOffset;
            ReloadCount = CartrigesInMagazine;
            HandleOffset = Offset;
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
            DrawEngine.DrawTexture(render, ScreenPosition, Texture, Rotation, 1 * TextureScale, 0.11f);
        }
    }
}
