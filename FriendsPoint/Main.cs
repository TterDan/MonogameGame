using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;
using System.Threading;

namespace FriendsPoint
{
    public partial class Main : Game
    {
        // Начальные переменные
        private GraphicsDeviceManager _graphics;
        private SpriteBatch render;         // Спрайтбатч
        private Texture2D blackTxtr;        // Черная текстурка для отрисовки разного
        private Texture2D redTxtr;          // Красная текстурка для отрисовки врагов
        private Player player;              // Экземпляр игрока
        private Map map;                    // Экземпляр карты
        private Vector2 windowSize;         // Размеры окна
        private List<GameObject> objects;   // Множество всех объектов на карте
        private Texture2D debugPixel;       // Текстура для отладки
        private SpriteFont font;            // Экземпляр интерфейса
        public Main()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }
    }
}
