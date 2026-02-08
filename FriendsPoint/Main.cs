
namespace FriendsPoint
{
    public partial class Main : Game
    {
        // Начальные переменные
        private GraphicsDeviceManager GraphicsDeviceManager;
        private SpriteBatch render;         // Спрайтбатч
        private Player player;              // Экземпляр игрока
        private Map map;                    // Экземпляр карты
        private Vector2 windowSize;         // Размеры окна
        private List<GameObject> objects;   // Множество всех объектов на карте
        private List<(Weapon, Vector2)> droppedWeapons;
        private SpriteFont font;            // Шрифт для отрисовки текста
        private Weapon fist;
        private JsonArray weaponsArray;
        private Random rnd;
        private Texture2D Cursor;
        public Main()
        {
            GraphicsDeviceManager = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = false;

            GraphicsDeviceManager.PreferredBackBufferWidth = 1920;
            GraphicsDeviceManager.PreferredBackBufferHeight = 1080;
            GraphicsDeviceManager.IsFullScreen = false;
        }
    }
}
