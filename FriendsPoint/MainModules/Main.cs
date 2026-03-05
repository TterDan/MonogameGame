
using FriendsPoint.GameObjects.Player;

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
        private Random rnd;
        private static Texture2D Cursor;

        private List<GameObject> Players;
        private List<GameObject> Weapons;
        private List<GameObject> Enemies;
        private List<GameObject> OtherGameObjects;
        public Main()
        {
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

        public int GetTimerIndex(string key) {
            return TimerEngine.GetTimerIndex(key);
        }
        public float GetTimer(int index) {
            return TimerEngine.GetTimer(index);
        }
        public void AddTimer(float _Value, float _End, float _Step, string _Key, string _StepType) {
            TimerEngine.AddTimer(_Value, _End, _Step, _Key, _StepType);
        }
    }
}
