
using System.Collections;
using System.Reflection.Emit;
using System.Timers;
using static System.Formats.Asn1.AsnWriter;

namespace FriendsPoint
{
    public partial class Main       // Пишу именно partial class, чтобы соединить все файлы начинающиеся на Main в один класс
    {
        float rot = 0;
        float basScale = 1f;
        int round = 25;
        float angle = 0;
        Vector2 cntrPos = new Vector2(0, 0);

        static public Effect multiplyEffect;
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
            //round = (int)(MathF.Sin(angle));
            //angle += MathF.PI / 180;
            //rot += MathF.PI / 180;  

            DrawEngine.DrawRoundRect(SpriteBatch, new Vector2(500, 500), new Vector2(150, 150), new Vector2(75, 75), round, rot, basScale, 1f, Color.Blue * 0.5f, BasicStrokeStyleIn, BasicLineStyleSolid);
            DrawUI(SpriteBatch); // Отрисовка интерфейса

            SpriteBatch.End();









            base.Draw(gameTime);
        }
    }
}