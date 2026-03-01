
using System.Collections;
using System.Reflection.Emit;
using System.Timers;

namespace FriendsPoint
{
    public partial class Main       // Пишу именно partial class, чтобы соединить все файлы начинающиеся на Main в один класс
    {
        float rot = 0;
        float basScale = 1f;
        float round = 0;
        float angle = 0;
        Vector2 cntrPos = new Vector2(0, 0);
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
            rot += 0.01f;
            //basScale += 0.01f;
            angle += MathF.PI / 180;
            round = Math.Abs(MathF.Sin(angle)) * 100;
            DrawEngine.DrawRoundRect(SpriteBatch, new Vector2(500, 500), new Vector2(150, 150), 50, 0, basScale, 1f, Color.Blue, BasicStrokeStyleIn, BasicLineStyleSolid);
            DrawUI(SpriteBatch); // Отрисовка интерфейса
            base.Draw(gameTime);
            SpriteBatch.End();
        }
    }
}