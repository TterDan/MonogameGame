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
            render.Begin();

            player.Draw(render);
            map.Draw(render);
            obj.Draw(render); //сюда закидывать рендеры всех обьектов

            render.End();
            base.Draw(gameTime);
        }
    }
}