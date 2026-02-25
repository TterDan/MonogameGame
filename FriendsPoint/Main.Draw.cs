
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
            DrawEngine.DrawRect(render, new Vector2(100, 500), new Vector2(150, 150), 1f, BasicFillStyle, BasicStrokeStyleIn, BasicLineStyleSolid);
            DrawEngine.DrawRect(render, new Vector2(300, 500), new Vector2(150, 150), 1f, BasicFillStyle, BasicStrokeStyleOn, BasicLineStyleSolid);
            DrawEngine.DrawRect(render, new Vector2(500, 500), new Vector2(150, 150), 1f, BasicFillStyle, BasicStrokeStyleOut, BasicLineStyleSolid);

            DrawEngine.DrawRect(render, new Vector2(100, 700), new Vector2(150, 150), 1f, BasicFillStyle, BasicStrokeStyleOn, BasicLineStyleDouble);
            DrawEngine.DrawRect(render, new Vector2(300, 700), new Vector2(150, 150), 1f, BasicFillStyle, BasicStrokeStyleOn, BasicLineStyleDotted);
            DrawEngine.DrawRect(render, new Vector2(500, 700), new Vector2(150, 150), 1f, BasicFillStyle, BasicStrokeStyleIn, BasicLineStyleWavy);
            DrawEngine.DrawRect(render, new Vector2(100, 900), new Vector2(150, 150), 1f, BasicFillStyle, BasicStrokeStyleOn, BasicLineStyleDashed);
            DrawEngine.DrawRect(render, new Vector2(300, 900), new Vector2(150, 150), 1f, BasicFillStyle, BasicStrokeStyleOn, BasicLineStyleDashedSpacing);

            DrawUI(render); // Отрисовка интерфейса
            base.Draw(gameTime);
            render.End();
        }
    }
}