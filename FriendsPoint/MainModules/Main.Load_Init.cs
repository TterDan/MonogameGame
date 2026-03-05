
namespace FriendsPoint
{
    public partial class Main           // Пишу именно partial class, чтобы соединить все файлы начинающиеся на Main в один класс
    {
        // Инициализация
        protected override void Initialize()
        {
            rnd = new System.Random();
            SpriteBatch = new SpriteBatch(GraphicsDevice);

            font = Content.Load<SpriteFont>("DebugFont");                           // Назначаю шрифт для текста
            Cursor = Content.Load<Texture2D>("interface/cursor");
            Texture2D fistTexture = Content.Load<Texture2D>("weapons/fist");

            windowSize = new Vector2(GraphicsDevice.Viewport.Width, GraphicsDevice.Viewport.Height);                    // Получаю размеры окна
            ScreenCenter = new Vector2(windowSize.X / 2, windowSize.Y / 2);

            CircleTexture = DrawEngine.CreateCircleTexture(300, GraphicsDevice);
            HalfCircleTexture = DrawEngine.CreateHalfCircleTexture(300, GraphicsDevice);
            QuarterCircleTexture = DrawEngine.CreateQuarterCircleTexture(300, GraphicsDevice);
            CircleHBoxObj.CircleTexture = CircleTexture;

            Console.Init(windowSize);
            DrawEngine.Init(font, GraphicsDevice, QuarterCircleTexture);
            TimerEngine.Init();


            Weapon fist = new Weapon(GraphicsDevice, fistTexture, "Fist", "Melee", Vector2.Zero, 40, 70, new Vector2(56, 45), Vector2.Zero, 15, 0, 1, 3, 0, 300, 20, 0, 0, 0, 1f, 0);
            map = new Map(new Vector2(0, 0), 400, 400);                                                                 // Инициализирую карту
            player = new Player(GraphicsDevice, Vector2.Zero, 70, 120, 50f, new Vector2(windowSize.X / 2 , windowSize.Y / 2), fist, font);     // Инициализирую игрока
            OtherGameObjects.Add(map);
            Players.Add(player);
            droppedWeapons = new List<(Weapon, Vector2)>();

            SpawnWeapons(20);
            AnimInit();
            base.Initialize();
        }
        // Код загрузки моделей и контента
        protected override void LoadContent()
        {
            player.Texture = Content.Load<Texture2D>("players/albert");
            map.Texture = Content.Load<Texture2D>("floor");
        }
        private void SpawnWeapons(int numOfWeapons) {
            for (int i = 0; i < numOfWeapons; i++) {
                JsonArray weaponsArray = JsonNode.Parse(File.ReadAllText("../../../WeaponData.json")).AsArray();
                int rndWeapon = rnd.Next(1, weaponsArray.Count);
                string pathToImg = weaponsArray[rndWeapon]["Path"].ToString();
                Texture2D weaponTexture = Content.Load<Texture2D>($"weapons/{pathToImg}");
                Weapon wpn = new Weapon(GraphicsDevice,
                    weaponTexture,
                    weaponsArray[rndWeapon]["Name"].ToString(),
                    weaponsArray[rndWeapon]["Type"].ToString(),
                    new Vector2(rnd.Next(-500, 500), rnd.Next(-500, 500)),
                    60,
                    105,
                    new Vector2((float)weaponsArray[rndWeapon]["OffsetX"], (float)weaponsArray[rndWeapon]["OffsetY"]),
                    new Vector2((float)weaponsArray[rndWeapon]["TrunkOffsetX"], (float)weaponsArray[rndWeapon]["TrunkOffsetY"]),
                    40,
                    15,
                    1,
                    (float)weaponsArray[rndWeapon]["RecoilStrengthForCamera"],
                    (float)weaponsArray[rndWeapon]["ReloadTime"],
                    (float)weaponsArray[rndWeapon]["CoolDownTime"],
                    (float)weaponsArray[rndWeapon]["PatternIndex"],
                    (float)weaponsArray[rndWeapon]["RecoilStrength"],
                    (float)weaponsArray[rndWeapon]["CartrigesInMagazine"],
                    (float)weaponsArray[rndWeapon]["TotalCartriges"],
                    (float)weaponsArray[rndWeapon]["TextureScale"],
                    (float)weaponsArray[rndWeapon]["TextureRotationInPlayerHandDegrees"]
                    );
                wpn.Rotation = rnd.Next(-314 / 20, 314 / 20) * 0.01f;
                Weapons.Add(wpn);
            }
        }
    }
}