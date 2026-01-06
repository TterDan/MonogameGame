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
            render.Begin(SpriteSortMode.FrontToBack);
            player.Draw(render);
            map.Draw(render);
            obj.Draw(render); // Сюда закидывать рендеры всех обьектов
            for(int i = 0; i < renderlist.Count; i++)
            {
               renderlist[i].Draw(render);
            }
            render.End();
            base.Draw(gameTime);
        }
    }
}