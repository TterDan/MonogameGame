namespace FriendsPoint.GameObjects.Player {
    public partial class Player : CircleHBoxObj {          // Класс игрока, наследует класс GameObject

        public Weapon Fist;
        public float MoveSpeed;
        Vector2 CurrentSpeed = Vector2.Zero;
        public Vector2 ScreenCenter;
        public Weapon currentWeapon;            // Текущее оружие игрока
        public Vector2 mouseDirection;
        public Vector2 mousePosition;
        public Random rnd;
        public float Health = 100f;

        public SpriteBatch spriteBatch;
        public bool isShooting;
        public Vector2 currentOffset;
        public Vector2 recoilOffset;
        public int shotcount;
        public double currentFireTime = 200;
        public double ShotDrawTimer = 0;
        public double currentShotDrawTime = 50;
        public Vector2 bulletLine;
        public Weapon viewWeapon;
        public SpriteFont font;
        public Vector2 mouseDirectionForCamera;
        public List<Vector2> bullets;
        public bool CanToTakeWeapon = false;
        float deltaTimeForRecoil;
        public bool isReloading = false;
        public bool isCoolDown = false;
        public float oldShotCount = 0;
        public Player(GraphicsDevice GraphicsDevice, Vector2 startPosition, int radius, int additionRadius, float moveSpeed, Vector2 playerScreenPos, Weapon weapon, SpriteFont Font) {
            Position = startPosition;
            MoveSpeed = moveSpeed;
            ScreenPosition = playerScreenPos;
            ScreenCenter = playerScreenPos;
            currentWeapon = weapon;
            Radius = radius;
            AdditionRadius = additionRadius;
            TextureScale = Scale * 0.35f;
            DrawRect = new Rectangle(0, 0, Radius * 2, Radius * 2);
            HitboxOpacity = 0.5f;
            font = Font;
            bullets = new List<Vector2>();
            rnd = new Random();
        }
        public void setConstants(float deltaTime) {
            currentShotDrawTime *= 200 * deltaTime;
            currentFireTime *= 150 * deltaTime;
        }
    }
}