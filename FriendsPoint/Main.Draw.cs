
using System.Collections;
using System.Reflection.Emit;
using System.Timers;

namespace FriendsPoint
{
    public partial class Main       // Пишу именно partial class, чтобы соединить все файлы начинающиеся на Main в один класс
    {
        int someTimer = 0;
        protected override void Draw(GameTime gameTime) {

            GraphicsDevice.Clear(Color.White);
            render.Begin(
                SpriteSortMode.FrontToBack
            );

            for (int i = 0; i < Players.Count; i++) {
                Players[i].Draw(render);
            }
            for (int i = 0; i < Weapons.Count; i++) {
                Weapons[i].Draw(render);
            }
            for (int i = 0; i < Enemies.Count; i++) {
                Enemies[i].Draw(render);
            }
            for (int i = 0; i < OtherGameObjects.Count; i++) {
                OtherGameObjects[i].Draw(render);
            }
            if (Console.IsConsoleOpen == true) {
                Console.DrawConsole(render);
            }
            DrawEngine.DrawRect(render, new Vector2(100, 500), new Vector2(150, 150), BasicFillStyle, BasicStrokeStyleIn, BasicLineStyleSolid, 1f);
            DrawEngine.DrawRect(render, new Vector2(300, 500), new Vector2(150, 150), BasicFillStyle, BasicStrokeStyleOn, BasicLineStyleSolid, 1f);
            DrawEngine.DrawRect(render, new Vector2(500, 500), new Vector2(150, 150), BasicFillStyle, BasicStrokeStyleOut, BasicLineStyleSolid, 1f);

            DrawEngine.DrawRect(render, new Vector2(100, 700), new Vector2(150, 150), BasicFillStyle, BasicStrokeStyleOn, BasicLineStyleDouble, 1f);
            DrawEngine.DrawRect(render, new Vector2(300, 700), new Vector2(150, 150), BasicFillStyle, BasicStrokeStyleOn, BasicLineStyleDotted, 1f);
            DrawEngine.DrawRect(render, new Vector2(500, 700), new Vector2(150, 150), BasicFillStyle, BasicStrokeStyleOn, BasicLineStyleDashed, 1f);

            DrawEngine.DrawRect(render, new Vector2(700, 700), new Vector2(150, 150), BasicFillStyle, BasicStrokeStyleOn, BasicLineStyleWavy, 1f);
            DrawUI(render); // Отрисовка интерфейса
            base.Draw(gameTime);
            render.End();
        }
    }
}