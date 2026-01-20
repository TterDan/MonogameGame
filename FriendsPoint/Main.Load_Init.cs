using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;
using System.Threading;

namespace FriendsPoint
{
    public partial class Main           // Пишу именно partial class, чтобы соединить все файлы начинающиеся на Main в один класс
    {
        // Инициализация
        protected override void Initialize()
        {
            windowSize = new Vector2(GraphicsDevice.Viewport.Width, GraphicsDevice.Viewport.Height);                    // Получаю размеры окна
            render = new SpriteBatch(GraphicsDevice);                                                                   // Инициализирую спрайтбатч

            hand = new Weapon(GraphicsDevice, "hand", Vector2.Zero, 10);

            player = new Player(GraphicsDevice, Vector2.Zero, 35, 5, new Vector2(windowSize.X / 2 , windowSize.Y / 2), hand);     // Инициализирую игрока

            System.Diagnostics.Debug.WriteLine(windowSize);
            map = new Map(new Vector2(0, 0), 400, 400);                                                                 // Инициализирую карту
            objects = new List<GameObject>();                                                                           // Инициализирую список всех элементов
            debugPixel = new Texture2D(GraphicsDevice, 1, 1);
            debugPixel.SetData(new[] { Color.Red });                                                                    
            objects.Add(map);
            objects.Add(player);
            graphics.ApplyChanges();
            for (int i = 0; i < 2; i++) {                                                                                // Добавляю несколько врагов на карту для теста
                Enemy enemy = new Enemy(
                    GraphicsDevice,
                    new Vector2(200 + i * 100, 200),
                    30,
                    3.0f
                );
                objects.Add(enemy);
            }

            base.Initialize();
        }

        // Код загрузки моделей и контента
        protected override void LoadContent()
        {
            player.Texture = Content.Load<Texture2D>("players/soldierRF");          // Назначаю текстуру игрока
            map.Texture = Content.Load<Texture2D>("floor");                         // Назначаю текстуру карты
            font = Content.Load<SpriteFont>("DebugFont");                           // Назначаю шрифт для текста
            Weapon testwpn = new Weapon(GraphicsDevice, "glock", new Vector2(100, 100), 20);
            Weapon testwpn2 = new Weapon(GraphicsDevice, "glock", new Vector2(100, 200), 20);
            objects.Add(testwpn);
            objects.Add(testwpn2);
        }
    }
}