using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Text.Json.Nodes;
using System.Threading;

namespace FriendsPoint
{
    public partial class Main : Game
    {
        // Начальные переменные
        private GraphicsDeviceManager graphics;
        private SpriteBatch render;         // Спрайтбатч
        private Player player;              // Экземпляр игрока
        private Map map;                    // Экземпляр карты
        private Vector2 windowSize;         // Размеры окна
        private List<GameObject> objects;   // Множество всех объектов на карте
        private List<(Weapon, Vector2)> droppedWeapons;
        private Texture2D debugPixel;       // Текстура для отладки
        private SpriteFont font;            // Экземпляр интерфейса
        private Weapon hand;
        private JsonArray weaponsArray;
        private Random rnd;
        public Main()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;

            graphics.PreferredBackBufferWidth = 1920;
            graphics.PreferredBackBufferHeight = 1080;
            graphics.IsFullScreen = false;
        }
    }
}
