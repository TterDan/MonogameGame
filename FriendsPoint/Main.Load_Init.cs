using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Threading;

namespace FriendsPoint
{
    public partial class Main
    {
        // Инициализация
        protected override void Initialize()
        {
            windowSize = new Vector2(GraphicsDevice.Viewport.Width, GraphicsDevice.Viewport.Height);
            player = new Player(Vector2.Zero, 150, 150, 5, new Vector2(windowSize.X / 2, windowSize.Y / 2)); // Стартовая позиция игрока
            map = new Map(new Vector2(0, 0), 1000, 1000); // Стартовая позиция игрока
            obj = new SomeObject();
            render = new SpriteBatch(GraphicsDevice);
            blackTxtr = new Texture2D(GraphicsDevice, 1, 1);

            objects = new List<GameObject>(); // инициализирую список всех элементов
            base.Initialize();
        }

        // Код загрузки моделей и контента
        protected override void LoadContent()
        {
            blackTxtr.SetData(new[] { Color.Black });
            player.BlackTexture = blackTxtr;
            map.BlackTexture = blackTxtr;
            obj.BlackTexture = blackTxtr;
            player.Texture = Content.Load<Texture2D>("players/soldierRF"); // Назначаем текстуру игроку
            //map.Texture = Content.Load<Texture2D>("players/floor"); // Назначаем текстуру карте
        }
    }
}