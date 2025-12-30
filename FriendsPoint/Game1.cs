using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Threading;

namespace FriendsPoint
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;
        private Texture2D pixel;
        private Player player;
        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            // TODO: Add your initialization logic here

            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);
            player = new Player(new Vector2(100, 100));

            // создаем текстуру 1x1 для прямоугольника
            pixel = new Texture2D(GraphicsDevice, 1, 1);
            pixel.SetData(new[] { Color.White });
            player.Texture = pixel; // назначаем текстуру игроку
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            // TODO: Add your update logic here

            base.Update(gameTime);
        }
        private int timer = 0;
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.White);
            timer++;
            _spriteBatch.Begin();

            // рисуем игрока
            player.Draw(_spriteBatch);

            _spriteBatch.End();
            base.Draw(gameTime);
        }
    }
}
