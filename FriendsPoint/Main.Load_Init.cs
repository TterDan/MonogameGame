
namespace FriendsPoint
{
    public partial class Main           // Пишу именно partial class, чтобы соединить все файлы начинающиеся на Main в один класс
    {
        // Инициализация
        protected override void Initialize()
        {
            font = Content.Load<SpriteFont>("DebugFont");                           // Назначаю шрифт для текста
            multiplyEffect = Content.Load<Effect>("MultiplyTextures");


            windowSize = new Vector2(GraphicsDevice.Viewport.Width, GraphicsDevice.Viewport.Height);                    // Получаю размеры окна
            ScreenCenter = new Vector2(windowSize.X / 2, windowSize.Y / 2);
            Console.Init(windowSize);

            CircleTexture = DrawEngine.CreateCircleTexture(300, GraphicsDevice);
            HalfCircleTexture = DrawEngine.CreateHalfCircleTexture(300, GraphicsDevice);
            QuarterCircleTexture = DrawEngine.CreateQuarterCircleTexture(300, GraphicsDevice);


            DrawEngine.Init(font, GraphicsDevice, QuarterCircleTexture);


            SpriteBatch = new SpriteBatch(GraphicsDevice);

            CircleHBoxObj.CircleTexture = CircleTexture;

            // Инициализирую спрайтбатч
            Texture2D fistTexture = Content.Load<Texture2D>("weapons/fist");
            Cursor = Content.Load<Texture2D>("interface/cursor");
            fist = new Weapon(GraphicsDevice, fistTexture, "Fist", "Melee", Vector2.Zero, 40, 70, new List<float> { 15, 0, 1, 3, 0, 300, 20, 0, 0, 0}, new Vector2(56, 45), 0, 0, 0, Vector2.Zero);

            map = new Map(new Vector2(0, 0), 400, 400);                                                                 // Инициализирую карту
            OtherGameObjects.Add(map);

            player = new Player(GraphicsDevice, Vector2.Zero, 70, 120, 4f, new Vector2(windowSize.X / 2 , windowSize.Y / 2), fist, font);     // Инициализирую игрока
            Players.Add(player);
            player.spriteBatch = SpriteBatch;
            player.Fist = fist;

            droppedWeapons = new List<(Weapon, Vector2)>();

            rnd = new System.Random();
            weaponsArray = JsonNode.Parse(File.ReadAllText("../../../WeaponData.json")).AsArray();
            for(int i = 0; i < 20; i++)
            {
                int rndWeapon = rnd.Next(1, weaponsArray.Count);
                string pathToImg = weaponsArray[rndWeapon]["Path"].ToString();
                Texture2D weaponTexture = Content.Load<Texture2D>($"weapons/{pathToImg}");
                Weapon wpn = new Weapon(GraphicsDevice, weaponTexture, weaponsArray[rndWeapon]["Name"].ToString(), weaponsArray[rndWeapon]["Type"].ToString(), new Vector2(rnd.Next(-500, 500), rnd.Next(-500, 500)), 60, 105, new List<float> { 40, 15, 1, 3, 4000, 130, 20, 0, 15, 45 }, new Vector2(((float)weaponsArray[rndWeapon]["OffsetX"]), ((float)weaponsArray[rndWeapon]["OffsetY"])), ((float)weaponsArray[rndWeapon]["RecoilStrength"]), ((float)weaponsArray[rndWeapon]["RecoilStrengthForCamera"]), ((float)weaponsArray[rndWeapon]["PatternIndex"]), new Vector2(((float)weaponsArray[rndWeapon]["TrunkOffsetX"]), ((float)weaponsArray[rndWeapon]["TrunkOffsetY"])));
                Weapons.Add(wpn);
            }
            base.Initialize();
        }
        // Код загрузки моделей и контента
        protected override void LoadContent()
        {
            player.Texture = Content.Load<Texture2D>("players/albert");          // Назначаю текстуру игрока
            map.Texture = Content.Load<Texture2D>("floor");                         // Назначаю текстуру карты
        }

    }
}