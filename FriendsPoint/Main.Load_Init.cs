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
            blackTxtr = new Texture2D(GraphicsDevice, 1, 1);                                                            // Инициализирую черную текстуру
            redTxtr = new Texture2D(GraphicsDevice, 1, 1);                                                              // Инициализирую красную текстуру
            redTxtr.SetData(new[] { Color.Red });
            player = new Player(Vector2.Zero, 60, 60, 5, new Vector2(windowSize.X / 2 , windowSize.Y / 2), "hand");     // Инициализирую игрока
            map = new Map(new Vector2(0, 0), 400, 400);                                                                 // Инициализирую карту
            objects = new List<GameObject>();                                                                           // Инициализирую список всех элементов
            debugPixel = new Texture2D(GraphicsDevice, 1, 1);
            debugPixel.SetData(new[] { Color.Red });                                                                    
            objects.Add(map);
            objects.Add(player);

            for (int i = 0; i < 5; i++) {                                                                                // Добавляю несколько врагов на карту для теста
                Enemy enemy = new Enemy(
                    redTxtr,
                    new Vector2(200 + i * 100, 200),
                    50,
                    50,
                    3.0f
                );
                objects.Add(enemy);
            }

            base.Initialize();
        }

        // Код загрузки моделей и контента
        protected override void LoadContent()
        {
            blackTxtr.SetData(new[] { Color.Black });                               // Делаю черную текстуру реально черной
            Player.BlackTexture = blackTxtr;                                        // Назначаю черную текстуру для класса игрока
            player.Texture = Content.Load<Texture2D>("players/soldierRF");          // Назначаю текстуру игрока
            map.Texture = Content.Load<Texture2D>("floor");                         // Назначаю текстуру карты
            font = Content.Load<SpriteFont>("DebugFont");                           // Назначаю шрифт для текста
        }
    }
}