using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Threading;

namespace FriendsPoint
{
    public partial class Main
    {
        // Отрисовка всего кадра
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.White);
            render.Begin(SpriteSortMode.FrontToBack);
            for(int i = 0; i < objects.Count; i++)
            {
                objects[i].Draw(render); // Отрисовываются все обьекты в списке
            }
            render.End();
            base.Draw(gameTime);
        }
    }
}