namespace FriendsPoint
{
    public partial class Main           // Пишу именно partial class, чтобы соединить все файлы начинающиеся на Main в один класс
    {
        // Инициализация
        protected override void Initialize()
        {
            font = Content.Load<SpriteFont>("DebugFont");                           // Назначаю шрифт для текста
            DrawEngine.GameFont = font;
            DrawEngine.GraphicsDevice = GraphicsDevice;
            windowSize = new Vector2(GraphicsDevice.Viewport.Width, GraphicsDevice.Viewport.Height);                    // Получаю размеры окна
            Console.WindowSize = windowSize;


            render = new SpriteBatch(GraphicsDevice);      
            // Инициализирую спрайтбатч
            Texture2D fistTexture = Content.Load<Texture2D>("weapons/fist");
            Cursor = Content.Load<Texture2D>("interface/cursor");
            fist = new Weapon(GraphicsDevice, fistTexture, "Fist", "Melee", Vector2.Zero, 20, 50, new List<float> { 15, 0, 1, 3, 0, 300, 20, 0, 0, 0}, new Vector2(56, 45), 0, 0, 0, Vector2.Zero);

            player = new Player(GraphicsDevice, Vector2.Zero, 35, 60, 7, new Vector2(windowSize.X / 2 , windowSize.Y / 2), fist, font);     // Инициализирую игрока
            player.spriteBatch = render;
                        player.Fist = fist;

            map = new Map(new Vector2(0, 0), 400, 400);                                                                 // Инициализирую карту
            objects = new List<GameObject>();                                                                           // Инициализирую список всех элементов
            droppedWeapons = new List<(Weapon, Vector2)>();
            
            objects.Add(map);
            objects.Add(player);
            rnd = new System.Random();
            weaponsArray = JsonNode.Parse(File.ReadAllText("../../../WeaponData.json")).AsArray();
            for (int i = 0; i < 2; i++) {                                                                                // Добавляю несколько врагов на карту для теста
                Enemy enemy = new Enemy(
                    GraphicsDevice,
                    new Vector2(200 + i * 100, 200),
                    30,
                    3f
                );
                objects.Add(enemy);
            }
            for(int i = 0; i < 20; i++)
            {
                int rndWeapon = rnd.Next(1, weaponsArray.Count);
                string pathToImg = weaponsArray[rndWeapon]["Path"].ToString();
                Texture2D weaponTexture = Content.Load<Texture2D>($"weapons/{pathToImg}");
                Weapon wpn = new Weapon(GraphicsDevice, weaponTexture, weaponsArray[rndWeapon]["Name"].ToString(), weaponsArray[rndWeapon]["Type"].ToString(), new Vector2(rnd.Next(-500, 500), rnd.Next(-500, 500)), 30, 50, new List<float> { 40, 15, 1, 3, 4000, 130, 20, 0, 15, 45 }, new Vector2(((float)weaponsArray[rndWeapon]["OffsetX"]), ((float)weaponsArray[rndWeapon]["OffsetY"])), ((float)weaponsArray[rndWeapon]["RecoilStrength"]), ((float)weaponsArray[rndWeapon]["RecoilStrengthForCamera"]), ((float)weaponsArray[rndWeapon]["PatternIndex"]), new Vector2(((float)weaponsArray[rndWeapon]["TrunkOffsetX"]), ((float)weaponsArray[rndWeapon]["TrunkOffsetY"])));
                objects.Add(wpn);
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