using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;
using System.Threading;

namespace FriendsPoint
{
    public partial class Main           // Пишу именно partial class, чтобы сединить все файлы начинающиеся на Main в один класс
    {
        // Инициализация
        protected override void Initialize()
        {
            windowSize = new Vector2(GraphicsDevice.Viewport.Width, GraphicsDevice.Viewport.Height);                    // Получаю размеры окна
            render = new SpriteBatch(GraphicsDevice);                                                                   // Инициализирую спрайтбатч
            blackTxtr = new Texture2D(GraphicsDevice, 1, 1);                                                            // Инициализирую черную текстуру
            player = new Player(Vector2.Zero, 150, 150, 5, new Vector2(windowSize.X / 2 , windowSize.Y / 2), "hand");   // Инициализирую игрока
            map = new Map(new Vector2(0, 0), 400, 400);                                                                 // Инициализирую карту
            objects = new List<GameObject>();                                                                           // Инициализирую список всех элементов
            objects.Add(map);
            objects.Add(player);
            base.Initialize();
        }

        // Код загрузки моделей и контента
        protected override void LoadContent()
        {
            blackTxtr.SetData(new[] { Color.Black });                               // Делаю черную текстуру реально черной
            Player.BlackTexture = blackTxtr;                                        // Назначаю черную текстуру для класса игрока
            player.Texture = Content.Load<Texture2D>("players/soldierRF");          // Назначаю текстуру игрока
            map.Texture = Content.Load<Texture2D>("floor");                         // Назначаю текстуру карты
        }
    }
}