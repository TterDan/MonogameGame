using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Threading;

namespace FriendsPoint
{
    public partial class Main : Game
    {
        // Начальные переменные
        private GraphicsDeviceManager _graphics;
        private SpriteBatch render;
        private Texture2D blackTxtr;
        private Player player;
        private Map map;
        private Vector2 windowSize;
        private SomeObject obj;
        private List<GameObject> objects; // Список всех элементов на карте, в данный момент я его не использую, это для будущего, когда элементов станет очень много, чтобы быстро по ним всем проходиться, когда нужно
        // Хз какой то код системный
        public Main()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }
    }
}
