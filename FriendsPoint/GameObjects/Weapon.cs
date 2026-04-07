
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
        public float BoomTimer;
        public float ExplosionArea;
        public float Duration;
        public Dictionary<string, Action<List <GameObject>>> GrenadesAction;
        public float GrenadeCoolDown;
        public Random rnd;
        public bool IsActivated;
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
            float textureRotationInPlayerHand,
            float boomTimer,
            float explosionArea,
            float duration
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
            BoomTimer = boomTimer;
            TrunkOffset = trunkOffset;
            ReloadCount = CartrigesInMagazine;
            HandleOffset = Offset;
            ExplosionArea = explosionArea;
            Duration = duration;
            GrenadesAction = new Dictionary<string, Action<List<GameObject>>>() {
                {"Molotov", Molotov },
                {"Smoke", Smoke },
                {"HighExplosive", High }
            };
            GrenadeCoolDown = duration;
            rnd = new Random();
            IsActivated = false;
        }
        public void AddForce(Vector2 forceVector) {
            HitForce += forceVector * HitForceVelocity;
        }
        public void Move(float deltaTime) {
            Position += HitForce * deltaTime;
            HitForce = Vector2.Lerp(HitForce, Vector2.Zero, AdditionForceDeceleraion * deltaTime);
        }

        public void Molotov(List<GameObject> Enemies)
        {
            IsActivated = true;
            for (int j = 0; j < Enemies.Count; j++)
            {
                Enemy enemy = (Enemy)Enemies[j];
                if (enemy.Radius + ExplosionArea >= (enemy.ScreenPosition - ScreenPosition).Length())
                {
                    if (GrenadeCoolDown - Duration >= 0.8)
                    {
                        GrenadeCoolDown = Duration;
                        HitDamage += 0.02f;
                    }
                    enemy.TakeDamage(HitDamage, Enemies, j);
                }
            }
        }

        public void High(List<GameObject> Enemies) // прости господи за такой код 
        {
            IsActivated = true;
            for(int i = 0; i < 10; i++)
            {

                for(int k = 0; k < Enemies.Count; k++)
                {
                    Enemy enemyOsk = (Enemy)Enemies[k];
                    if(i <= 0 && enemyOsk.Radius + ExplosionArea >= (enemyOsk.ScreenPosition - ScreenPosition).Length())
                    {
                        enemyOsk.TakeDamage(HitDamage, Enemies, i);
                    }
                    var direction = ScreenPosition - new Vector2(rnd.Next(-2000, 2000), rnd.Next(-2000, 2000));
                    var enemyDirection = enemyOsk.ScreenPosition - ScreenPosition;
                    var scalar = enemyDirection.X * direction.X + enemyDirection.Y * direction.Y;
                    var cosAngle = scalar / (enemyDirection.Length() * direction.Length());
                    float Angle = MathF.Acos(cosAngle);
                    float LengthBetweenDirectionAndEnemy = enemyDirection.Length() * MathF.Sin(Angle);
                    if (LengthBetweenDirectionAndEnemy < enemyOsk.Radius && cosAngle > 0)
                    {
                        if (enemyOsk.TakeDamage(Damage, Enemies, k) == true)
                        {
                            k--;
                        }
                    }
                }
            }
        }

        public void Smoke(List<GameObject> Enemies)
        {
            IsActivated = true;
            for (int j = 0; j < Enemies.Count; j++)
            {
                Enemy enemy = (Enemy)Enemies[j];
                if (enemy.Radius + ExplosionArea >= (enemy.ScreenPosition - ScreenPosition).Length())
                {
                    // Сделаем анимацию смока слоем поверх игроков
                }
            }
        }


        public override void Draw(SpriteBatch render) {
            DrawEngine.Circle(render, CircleTexture, ScreenPosition, Radius, Color.Black * 0.65f, 0.1f);
            DrawEngine.DrawTexture(render, ScreenPosition, Texture, Rotation, 1 * TextureScale, 0.11f);
        }
    }
}
