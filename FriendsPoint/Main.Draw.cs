using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Threading;

namespace FriendsPoint
{
    public partial class Main
    {
        // Отрисовка кадра, в целом лучше делать весь кадр конкретно здесь, а не в других частях проекта
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.White);
            _spriteBatch.Begin();
            player.Draw(_spriteBatch);
            map.Draw(_spriteBatch);
            _spriteBatch.End();
            base.Draw(gameTime);
        }
    }
}