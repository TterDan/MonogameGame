
namespace FriendsPoint
{
    public partial class Main : Game
    {
        // Начальные переменные
        private GraphicsDeviceManager GraphicsDeviceManager;
        private SpriteBatch SpriteBatch;         // Спрайтбатч

        private Player player;              // Экземпляр игрока
        private Map map;                    // Экземпляр карты
        private Vector2 windowSize;         // Размеры окна
        private Vector2 ScreenCenter;
        private List<(Weapon, Vector2)> droppedWeapons;
        private SpriteFont font;            // Шрифт для отрисовки текста
        private Weapon fist;
        private JsonArray weaponsArray;
        private Random rnd;
        private static Texture2D Cursor;

        private List<GameObject> Players;
        private List<GameObject> Weapons;
        private List<GameObject> Enemies;
        private List<GameObject> OtherGameObjects;
        BlendState maskBlend;
        Texture2D maskTexture;
        public Main()
        {
            maskBlend = new BlendState {
                ColorSourceBlend = Blend.Zero,
                ColorDestinationBlend = Blend.SourceColor,
                AlphaSourceBlend = Blend.Zero,
                AlphaDestinationBlend = Blend.SourceAlpha
            };
            //maskTexture = CreateRoundedRectMask(width, height, radius);
            Players = new List<GameObject>();
            Weapons = new List<GameObject>();
            Enemies = new List<GameObject>();
            OtherGameObjects = new List<GameObject>();
            GraphicsDeviceManager = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = false;
            GraphicsDeviceManager.PreferredBackBufferWidth = 1920;
            GraphicsDeviceManager.PreferredBackBufferHeight = 1080;
            GraphicsDeviceManager.IsFullScreen = false;

            IsFixedTimeStep = false;
            //TargetElapsedTime = TimeSpan.FromSeconds(1.0 / 144.0);

            GraphicsDeviceManager.SynchronizeWithVerticalRetrace = false;
        }
    }
}
