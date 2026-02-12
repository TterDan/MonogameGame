
using Microsoft.Xna.Framework.Graphics;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace FriendsPoint
{
    public partial class Main       // Пишу именно partial class, чтобы соединить все файлы начинающиеся на Main в один класс
    {
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
            DrawUI(render); // Отрисовка интерфейса
            base.Draw(gameTime);
            render.End();
        }
    }
}