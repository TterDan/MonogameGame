
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
            BasicStyle Rect1 = new BasicStyle(new Vector2(150, 150), new Vector2(100, 100), new Vector2(0, 0), 0f);
            someTimer++;
            if (someTimer > 150 && someTimer < 300) {

                DrawEngine.DrawRect(render, new Vector2(10, 10), Rect1, BasicFillStyle, BasicStrokeStyle);
            } else if (someTimer <= 150) {

                DrawEngine.DrawRect(render, new Vector2(10, 10), Rect1, BasicFillStyle);
            } else {
                someTimer = 0;
            }
            Console.Log(someTimer, "repeat", "Gay");
            DrawUI(render); // Отрисовка интерфейса
            base.Draw(gameTime);
            render.End();
        }
    }
}