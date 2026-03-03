
using System.Collections;
using System.Reflection.Emit;
using System.Timers;
using static System.Formats.Asn1.AsnWriter;

namespace FriendsPoint
{
    public partial class Main       // Пишу именно partial class, чтобы соединить все файлы начинающиеся на Main в один класс
    {
        protected override void Draw(GameTime gameTime) {

            GraphicsDevice.Clear(Color.LightBlue);
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

            DrawUI(SpriteBatch); // Отрисовка интерфейса
            SpriteBatch.End();
            base.Draw(gameTime);
        }
    }
}