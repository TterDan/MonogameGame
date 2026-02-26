
using System.Collections;
using System.Reflection.Emit;
using System.Timers;

namespace FriendsPoint
{
    public partial class Main       // Пишу именно partial class, чтобы соединить все файлы начинающиеся на Main в один класс
    {
        float rot = 0;
        float basScale = 1f;
        protected override void Draw(GameTime gameTime) {

            GraphicsDevice.Clear(Color.White);
            SpriteBatch.Begin(
                SpriteSortMode.FrontToBack
            );
            for (int i = 0; i < Players.Count; i++) {
                Players[i].Draw(SpriteBatch);
            }
            for (int i = 0; i < Weapons.Count; i++) {
                Weapons[i].Draw(SpriteBatch);
            }
            for (int i = 0; i < Enemies.Count; i++) {
                Enemies[i].Draw(SpriteBatch);
            }
            for (int i = 0; i < OtherGameObjects.Count; i++) {
                OtherGameObjects[i].Draw(SpriteBatch);
            }
            if (Console.IsConsoleOpen == true) {
                Console.DrawConsole(SpriteBatch);
            }
            //rot += 0.02f;
            //basScale += 0.01f;
            DrawEngine.DrawRect(SpriteBatch, new Vector2(100, 500), new Vector2(300, 150), rot, basScale, 1f, BasicFillStyle, BasicStrokeStyleIn, BasicLineStyleSolid);
            DrawUI(SpriteBatch); // Отрисовка интерфейса
            base.Draw(gameTime);
            SpriteBatch.End();
        }
    }
}