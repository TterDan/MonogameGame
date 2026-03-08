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

        public float dropStrength = 180f;

        float[] keyframes1 =
        {
            0,      0f,
            100,      100f
        };
        float[] keyframes2 =
{
            0,      100f,
            100,      0f
        };
        public bool keah = false;
        public void firstAnim() {
            Console.Log("HAHHA");
            if (keah == false) {
                keah = true;
                anim2.Play();
                timer1.Play();
            } else {
                keah = false;
                anim1.Play();
                timer1.Play();
            }
        }
        Animation anim1;
        Animation anim2;
        Timer timer1;
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
            anim1 = new Animation(keyframes1, 2, 800, Functions.easeOutBounce);
            anim2 = new Animation(keyframes2, 2, 800, Functions.easeInOutQuint);
            timer1 = new Timer(0f, 800, 0, "Timer", firstAnim);
        }
        public void setConstants(float deltaTime) {
            currentShotDrawTime *= 200 * deltaTime;
            currentFireTime *= 150 * deltaTime;
        }
    }
}